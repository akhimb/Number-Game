using Godot;
using System;

public class Level_2 : Node2D
{
    private AudioStreamPlayer _FishSound;
    private AudioStreamPlayer _FingerSound;
    private AudioStreamPlayer _WonMatch;
    private AudioStreamPlayer _Okay;
    private int totalMarks = 0;
    private Button goNextButton;
    private Button submitButton;
    private Label labelResult;
    private Boolean checkBoxOnePressed;
    private CheckBox checkBoxOne;
    private CheckBox checkBoxTwo;
    private CheckBox checkBoxThree;
    private CustomSignals _cs;
    public override void _Ready()
    {
        _FishSound = GetNode<AudioStreamPlayer>("One-Fish-Sound");
        _FingerSound = GetNode<AudioStreamPlayer>("One-Finger-Sound");
        _WonMatch = GetNode<AudioStreamPlayer>("WonMatch");
        _Okay = GetNode<AudioStreamPlayer>("Okay");
        goNextButton = GetNode<Button>("GoNextButton");
        goNextButton.Visible = false;
        submitButton = GetNode<Button>("SubmitButton");
        labelResult = GetNode<Label>("LabelResult");
        checkBoxOne = GetNode<CheckBox>("CheckBoxOne");
        checkBoxTwo = GetNode<CheckBox>("CheckBoxTwo");
        checkBoxThree = GetNode<CheckBox>("CheckBoxThree");
        _cs = GetNode<CustomSignals>("/root/CS");

    }

    public void _on_FishButton_pressed()
    {
        _FishSound.Play();
    }

    public void _on_NextLevel_pressed()
    {
        _cs.EmitSignal("changeLevel");
    }

    public void _on_FingerButton_pressed()
    {
        _FingerSound.Play();
    }

    public void _on_Button_pressed()
    {
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
        goNextButton.Visible = true;
        labelResult.Text = $"Congrats... You scored : {totalMarks} / 50";
        if (totalMarks < 31)
        {
            _Okay.Play();
        }
        else
        {
            _WonMatch.Play();
        }


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