using Godot;
using System;

public class Level_12 : Node2D
{
    private AudioStreamPlayer _SixBirdsSound;
    private AudioStreamPlayer _SixFingersSound;
    private AudioStreamPlayer _WonMatch;
    private AudioStreamPlayer _Okay;
    private int totalMarks = 0;
    private Button goNextButton;
    private Button submitButton;
    private Boolean checkBoxSixPressed;
    private Boolean checkBoxSix2Pressed;
    private CheckBox checkBoxFour;
    private CheckBox checkBoxFive;
    private CheckBox checkBoxSix;
    private CheckBox checkBoxSeven;

    private CheckBox checkBoxFour2;
    private CheckBox checkBoxFive2;
    private CheckBox checkBoxSix2;
    private CheckBox checkBoxSeven2;

    private CustomSignals _cs;

    public override void _Ready()
    {
        _cs = GetNode<CustomSignals>("/root/CS");
        _SixBirdsSound = GetNode<AudioStreamPlayer>("SixBirdsSound");
        _SixFingersSound = GetNode<AudioStreamPlayer>("SixFingersSound");
        _WonMatch = GetNode<AudioStreamPlayer>("WonMatch");
        _Okay = GetNode<AudioStreamPlayer>("Okay");
        goNextButton = GetNode<Button>("GoNextButton");
        goNextButton.Visible = false;
        submitButton = GetNode<Button>("SubmitButton");
        checkBoxFour = GetNode<CheckBox>("CheckBoxFour");
        checkBoxFive = GetNode<CheckBox>("CheckBoxFive");
        checkBoxSix = GetNode<CheckBox>("CheckBoxSix");
        checkBoxSeven = GetNode<CheckBox>("CheckBoxSeven");

        checkBoxFour2 = GetNode<CheckBox>("CheckBoxFour2");
        checkBoxFive2 = GetNode<CheckBox>("CheckBoxFive2");
        checkBoxSix2 = GetNode<CheckBox>("CheckBoxSix2");
        checkBoxSeven2 = GetNode<CheckBox>("CheckBoxSeven2");
    }

    public void _on_GoNextButton_pressed()
    {
        _cs.EmitSignal("changeLevel");
    }

    public void _on_SixBirdsButton_pressed()
    {
        _SixBirdsSound.Play();
    }

    public void _on_SixFingersButton_pressed()
    {
        _SixFingersSound.Play();
    }

    public void _on_NextLevel_pressed()
    {
        _cs.EmitSignal("changeLevel");
    }

    public void _on_SubmitButton_pressed()
    {
        totalMarks += checkBoxSixPressed == true ? 10 : 0;
        totalMarks += checkBoxSix2Pressed == true ? 10 : 0;
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

    public void _on_CheckBoxFour_toggled(bool value)
    {
        if (value == true)
        {
            checkBoxFive.Disabled = true;
            checkBoxSix.Disabled = true;
            checkBoxSeven.Disabled = true;
        }
        else
        {
            checkBoxFive.Disabled = false;
            checkBoxSix.Disabled = false;
            checkBoxSeven.Disabled = false;
        }

    }

    public void _on_CheckBoxFive_toggled(bool value)
    {
        if (value == true)
        {
            checkBoxFour.Disabled = true;
            checkBoxSix.Disabled = true;
            checkBoxSeven.Disabled = true;
        }
        else
        {
            checkBoxFour.Disabled = false;
            checkBoxSix.Disabled = false;
            checkBoxSeven.Disabled = false;
        }
    }

    public void _on_CheckBoxSix_toggled(bool value)
    {
        checkBoxSixPressed = value;
        if (value == true)
        {
            checkBoxFour.Disabled = true;
            checkBoxFive.Disabled = true;
            checkBoxSeven.Disabled = true;
        }
        else
        {
            checkBoxFour.Disabled = false;
            checkBoxFive.Disabled = false;
            checkBoxSeven.Disabled = false;
        }
    }

    public void _on_CheckBoxSeven_toggled(bool value)
    {
        if (value == true)
        {
            checkBoxFour.Disabled = true;
            checkBoxFive.Disabled = true;
            checkBoxSix.Disabled = true;
        }
        else
        {
            checkBoxFour.Disabled = false;
            checkBoxFive.Disabled = false;
            checkBoxSix.Disabled = false;
        }
    }

    public void _on_CheckBoxFour2_toggled(bool value)
    {
        if (value == true)
        {
            checkBoxFive2.Disabled = true;
            checkBoxSix2.Disabled = true;
            checkBoxSeven2.Disabled = true;
        }
        else
        {
            checkBoxFive2.Disabled = false;
            checkBoxSix2.Disabled = false;
            checkBoxSeven2.Disabled = false;
        }

    }

    public void _on_CheckBoxFive2_toggled(bool value)
    {
        if (value == true)
        {
            checkBoxFour2.Disabled = true;
            checkBoxSix2.Disabled = true;
            checkBoxSeven2.Disabled = true;
        }
        else
        {
            checkBoxFour2.Disabled = false;
            checkBoxSix2.Disabled = false;
            checkBoxSeven2.Disabled = false;
        }
    }

    public void _on_CheckBoxSix2_toggled(bool value)
    {
        checkBoxSix2Pressed = value;
        if (value == true)
        {
            checkBoxFour2.Disabled = true;
            checkBoxFive2.Disabled = true;
            checkBoxSeven2.Disabled = true;
        }
        else
        {
            checkBoxFour2.Disabled = false;
            checkBoxFive2.Disabled = false;
            checkBoxSeven2.Disabled = false;
        }
    }

    public void _on_CheckBoxSeven2_toggled(bool value)
    {
        if (value == true)
        {
            checkBoxFour2.Disabled = true;
            checkBoxFive2.Disabled = true;
            checkBoxSix2.Disabled = true;
        }
        else
        {
            checkBoxFour2.Disabled = false;
            checkBoxFive2.Disabled = false;
            checkBoxSix2.Disabled = false;
        }
    }

}
