using Godot;
using System;

public class Level_16 : Node2D
{
    private AudioStreamPlayer _EightOctopusSound;
    private AudioStreamPlayer _EightFingersSound;
    private AudioStreamPlayer _WonMatch;
    private AudioStreamPlayer _Okay;
    private int totalMarks = 0;
    private Button goNextButton;
    private Button submitButton;
    private Boolean checkBoxEightPressed;
    private Boolean checkBoxEight2Pressed;
    private CheckBox checkBoxSeven;
    private CheckBox checkBoxEight;
    private CheckBox checkBoxNine;
    private CheckBox checkBoxThree;

    private CheckBox checkBoxEight2;
    private CheckBox checkBoxFour;
    private CheckBox checkBoxTwo;
    private CheckBox checkBoxFive;

    private CustomSignals _cs;

    public override void _Ready()
    {
        _cs = GetNode<CustomSignals>("/root/CS");
        _EightOctopusSound = GetNode<AudioStreamPlayer>("EightOctopusSound");
        _EightFingersSound = GetNode<AudioStreamPlayer>("EightFingersSound");
        _WonMatch = GetNode<AudioStreamPlayer>("WonMatch");
        _Okay = GetNode<AudioStreamPlayer>("Okay");
        goNextButton = GetNode<Button>("GoNextButton");
        goNextButton.Visible = false;
        submitButton = GetNode<Button>("SubmitButton");

        checkBoxSeven = GetNode<CheckBox>("CheckBoxSeven");
        checkBoxEight = GetNode<CheckBox>("CheckBoxEight");
        checkBoxNine = GetNode<CheckBox>("CheckBoxNine");
        checkBoxThree = GetNode<CheckBox>("CheckBoxThree");

        checkBoxEight2 = GetNode<CheckBox>("CheckBoxEight2");
        checkBoxFour = GetNode<CheckBox>("CheckBoxFour");
        checkBoxTwo = GetNode<CheckBox>("CheckBoxTwo");
        checkBoxFive = GetNode<CheckBox>("CheckBoxFive");


    }

    public void _on_GoNextButton_pressed()
    {
        _cs.EmitSignal("changeLevel");
    }

    public void _on_EightOctopusButton_pressed()
    {
        _EightOctopusSound.Play();
    }

    public void _on_EightFingersButton_pressed()
    {
        _EightFingersSound.Play();
    }

    public void _on_PictureButton1_pressed()
    {
        GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D").Play();
    }

    public void _on_PictureButton2_pressed()
    {
         GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D2").Play();
    }

    public void _on_NextLevel_pressed()
    {
        _cs.EmitSignal("changeLevel");
    }

    public void _on_SubmitButton_pressed()
    {
        totalMarks += checkBoxEightPressed == true ? 10 : 0;
        totalMarks += checkBoxEight2Pressed == true ? 10 : 0;
        submitButton.Visible = false;
        goNextButton.Visible = true;
        if (totalMarks < 10)
        {
            _Okay.Play();
        }
        else
        {
            _WonMatch.Play();
        }
    }

    public void _on_CheckBoxSeven_toggled(bool value)
    {
        if (value == true)
        {
            checkBoxEight.Disabled = true;
            checkBoxNine.Disabled = true;
            checkBoxThree.Disabled = true;
        }
        else
        {
            checkBoxEight.Disabled = false;
            checkBoxNine.Disabled = false;
            checkBoxThree.Disabled = false;
        }

    }

    public void _on_CheckBoxEight_toggled(bool value)
    {
        checkBoxEightPressed = value;
        if (value == true)
        {
            checkBoxSeven.Disabled = true;
            checkBoxNine.Disabled = true;
            checkBoxThree.Disabled = true;
        }
        else
        {
            checkBoxSeven.Disabled = false;
            checkBoxNine.Disabled = false;
            checkBoxThree.Disabled = false;
        }
    }

    public void _on_CheckBoxNine_toggled(bool value)
    {

         if (value == true)
        {
            checkBoxEight.Disabled = true;
            checkBoxSeven.Disabled = true;
            checkBoxThree.Disabled = true;
        }
        else
        {
            checkBoxEight.Disabled = false;
            checkBoxSeven.Disabled = false;
            checkBoxThree.Disabled = false;
        }
    }

    public void _on_CheckBoxThree_toggled(bool value)
    {
        if (value == true)
        {
            checkBoxEight.Disabled = true;
            checkBoxNine.Disabled = true;
            checkBoxSeven.Disabled = true;
        }
        else
        {
            checkBoxEight.Disabled = false;
            checkBoxNine.Disabled = false;
            checkBoxSeven.Disabled = false;
        }
    }


    public void _on_CheckBoxEight2_toggled(bool value)
    {
        checkBoxEight2Pressed = value;
        if (value == true)
        {
            checkBoxFour.Disabled = true;
            checkBoxTwo.Disabled = true;
            checkBoxFive.Disabled = true;
        }
        else
        {
            checkBoxFour.Disabled = false;
            checkBoxTwo.Disabled = false;
            checkBoxFive.Disabled = false;
        }
    }

    public void _on_CheckBoxFour_toggled(bool value)
    {
          if (value == true)
        {
            checkBoxEight2.Disabled = true;
            checkBoxTwo.Disabled = true;
            checkBoxFive.Disabled = true;
        }
        else
        {
            checkBoxEight2.Disabled = false;
            checkBoxTwo.Disabled = false;
            checkBoxFive.Disabled = false;
        }
    }

    public void _on_CheckBoxTwo_toggled(bool value)
    {
         if (value == true)
        {
            checkBoxEight2.Disabled = true;
            checkBoxFour.Disabled = true;
            checkBoxFive.Disabled = true;
        }
        else
        {
            checkBoxEight2.Disabled = false;
            checkBoxFour.Disabled = false;
            checkBoxFive.Disabled = false;
        }
    }

    public void _on_CheckBoxFive_toggled(bool value)
    {
          if (value == true)
        {
            checkBoxEight2.Disabled = true;
            checkBoxTwo.Disabled = true;
            checkBoxFour.Disabled = true;
        }
        else
        {
            checkBoxEight2.Disabled = false;
            checkBoxTwo.Disabled = false;
            checkBoxFour.Disabled = false;
        }
    }

}
