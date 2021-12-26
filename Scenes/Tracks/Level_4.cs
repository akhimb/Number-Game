using Godot;
using System;

public class Level_4 : Node2D
{
    private AudioStreamPlayer _FishSound;
    private AudioStreamPlayer _FingerSound;
    private AudioStreamPlayer _WonMatch;
    private int totalMarks = 0;
    private Button restartGameButton;
    private Button submitButton;
    private Label labelResult;
    private Boolean checkBoxOnePressed;
    private CheckBox checkBoxOne;
    private CheckBox checkBoxTwo;
    private CheckBox checkBoxThree;
    public override void _Ready()
    {
        _FishSound = GetNode<AudioStreamPlayer>("One-Fish-Sound");
        _FingerSound = GetNode<AudioStreamPlayer>("One-Finger-Sound");
        _WonMatch = GetNode<AudioStreamPlayer>("WonMatch");
        restartGameButton = GetNode<Button>("RestartGame");
        restartGameButton.Visible = false;
        submitButton = GetNode<Button>("Button");
        labelResult = GetNode<Label>("LabelResult");
        checkBoxOne = GetNode<CheckBox>("CheckBoxOne");
        checkBoxTwo = GetNode<CheckBox>("CheckBoxTwo");
        checkBoxThree = GetNode<CheckBox>("CheckBoxThree");
    }

    public void _on_FishButton_pressed()
    {
        _FishSound.Play();
    }
    public void _on_RestartGame_pressed()
    {
        GetTree().ChangeScene($"res://Scenes/Tracks/Level_0.tscn");
        GetTree().CurrentScene._Ready();
    }


    public void _on_FingerButton_pressed()
    {
        _FingerSound.Play();
    }

    public void _on_Button_pressed()
    {
        TextEdit parrotCount = GetNode<TextEdit>("TxtBoxParrotCount");
        CheckBox checkBoxBirds = GetNode<CheckBox>("CheckBoxBirds");
        CheckBox checkBoxKitten = GetNode<CheckBox>("CheckBoxKitten");
        CheckBox checkBoxElephant = GetNode<CheckBox>("CheckBoxElephant");
        CheckBox checkBoxBalls = GetNode<CheckBox>("CheckBoxBalls");

        totalMarks = checkBoxOnePressed == true ? totalMarks += 10 : totalMarks -= 0;
        totalMarks = checkBoxBirds.Pressed == true ? totalMarks -= 0 : totalMarks += 10;
        totalMarks = checkBoxBalls.Pressed == true ? totalMarks -= 0 : totalMarks += 10;
        totalMarks = checkBoxElephant.Pressed == true ? totalMarks += 10 : totalMarks -= 0;
        totalMarks = checkBoxKitten.Pressed == true ? totalMarks += 10 : totalMarks -= 0;
        submitButton.Visible = false;
        restartGameButton.Visible = true;
        labelResult.Text = $"Congrats... You scored : {totalMarks} / 50";
        _WonMatch.Play();
    }


    public void _on_CheckBoxOne_toggled(bool value)
    {
        checkBoxOnePressed = value;
        if (value == true)
        {
            checkBoxTwo.Disabled = true;
            checkBoxThree.Disabled = true;
        }
        else
        {
            checkBoxTwo.Disabled = false;
            checkBoxThree.Disabled = false;
        }

    }

    public void _on_CheckBoxTwo_toggled(bool value)
    {
        if (value == true)
        {
            checkBoxOne.Disabled = true;
            checkBoxThree.Disabled = true;
        }
        else
        {
            checkBoxOne.Disabled = false;
            checkBoxThree.Disabled = false;
        }
    }

    public void _on_CheckBoxThree_toggled(bool value)
    {
        if (value == true)
        {
            checkBoxOne.Disabled = true;
            checkBoxTwo.Disabled = true;
        }
        else
        {
            checkBoxOne.Disabled = false;
            checkBoxTwo.Disabled = false;
        }
    }

}
