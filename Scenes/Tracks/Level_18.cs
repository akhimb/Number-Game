using Godot;
using System;

public class Level_18 : Node2D
{
    private AudioStreamPlayer _NineGeckosSound;
    private AudioStreamPlayer _NineFingersSound;
    private AudioStreamPlayer _WonMatch;
    private AudioStreamPlayer _Okay;
    private int totalMarks = 0;
    private Button goNextButton;
    private Button submitButton;
    private Boolean checkBoxNinePressed;
    private Boolean checkBoxNine2Pressed;

    private CheckBox checkBoxNine;
    private CheckBox checkBoxZero;
    private CheckBox checkBoxThree;
    private CheckBox checkBoxSeven;


    private CheckBox checkBoxSeven2;
    private CheckBox checkBoxTwo;
    private CheckBox checkBoxNine2;
    private CheckBox checkBoxOne;

    private CustomSignals _cs;

    public override void _Ready()
    {
        _cs = GetNode<CustomSignals>("/root/CS");
        _NineGeckosSound = GetNode<AudioStreamPlayer>("NineGeckosSound");
        _NineFingersSound = GetNode<AudioStreamPlayer>("NineFingersSound");
        _WonMatch = GetNode<AudioStreamPlayer>("WonMatch");
        _Okay = GetNode<AudioStreamPlayer>("Okay");
        goNextButton = GetNode<Button>("GoNextButton");
        goNextButton.Visible = false;
        submitButton = GetNode<Button>("SubmitButton");

        checkBoxNine = GetNode<CheckBox>("CheckBoxNine");
        checkBoxZero = GetNode<CheckBox>("CheckBoxZero");
        checkBoxThree = GetNode<CheckBox>("CheckBoxThree");
        checkBoxSeven = GetNode<CheckBox>("CheckBoxSeven");

        checkBoxSeven2 = GetNode<CheckBox>("CheckBoxSeven2");
        checkBoxTwo = GetNode<CheckBox>("CheckBoxTwo");
        checkBoxNine2 = GetNode<CheckBox>("CheckBoxNine2");
        checkBoxOne = GetNode<CheckBox>("CheckBoxOne");


    }

    public void _on_PictureButton1_pressed()
    {
        GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D").Play();
    }

    public void _on_PictureButton2_pressed()
    {
         GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D2").Play();
    }

    public void _on_GoNextButton_pressed()
    {
        _cs.EmitSignal("changeLevel");
    }

    public void _on_NineGeckosButton_pressed()
    {
        _NineGeckosSound.Play();
    }

    public void _on_NineFingersButton_pressed()
    {
        _NineFingersSound.Play();
    }

    public void _on_NextLevel_pressed()
    {
        _cs.EmitSignal("changeLevel");
    }

    public void _on_SubmitButton_pressed()
    {
        totalMarks += checkBoxNine2Pressed == true ? 10 : 0;
        totalMarks += checkBoxNine2Pressed == true ? 10 : 0;
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

    public void _on_CheckBoxNine_toggled(bool value)
    {
        checkBoxNinePressed = value;
        if (value == true)
        {
            checkBoxZero.Disabled = true;
            checkBoxThree.Disabled = true;
            checkBoxSeven.Disabled = true;
        }
        else
        {
            checkBoxZero.Disabled = false;
            checkBoxThree.Disabled = false;
            checkBoxSeven.Disabled = false;
        }
    }

    public void _on_CheckBoxZero_toggled(bool value)
    {
        if (value == true)
        {
            checkBoxNine.Disabled = true;
            checkBoxThree.Disabled = true;
            checkBoxSeven.Disabled = true;
        }
        else
        {
            checkBoxNine.Disabled = false;
            checkBoxThree.Disabled = false;
            checkBoxSeven.Disabled = false;
        }
    }

    public void _on_CheckBoxThree_toggled(bool value)
    {
        if (value == true)
        {
            checkBoxZero.Disabled = true;
            checkBoxNine.Disabled = true;
            checkBoxSeven.Disabled = true;
        }
        else
        {
            checkBoxZero.Disabled = false;
            checkBoxNine.Disabled = false;
            checkBoxSeven.Disabled = false;
        }
    }

    public void _on_CheckBoxSeven_toggled(bool value)
    {
        if (value == true)
        {
            checkBoxZero.Disabled = true;
            checkBoxThree.Disabled = true;
            checkBoxNine.Disabled = true;
        }
        else
        {
            checkBoxZero.Disabled = false;
            checkBoxThree.Disabled = false;
            checkBoxNine.Disabled = false;
        }
    }


    public void _on_CheckBoxSeven2_toggled(bool value)
    {
        if (value == true)
        {
            checkBoxTwo.Disabled = true;
            checkBoxNine2.Disabled = true;
            checkBoxOne.Disabled = true;
        }
        else
        {
            checkBoxTwo.Disabled = false;
            checkBoxNine2.Disabled = false;
            checkBoxOne.Disabled = false;
        }
    }

    public void _on_CheckBoxTwo_toggled(bool value)
    {
        if (value == true)
        {
            checkBoxSeven2.Disabled = true;
            checkBoxNine2.Disabled = true;
            checkBoxOne.Disabled = true;
        }
        else
        {
            checkBoxSeven2.Disabled = false;
            checkBoxNine2.Disabled = false;
            checkBoxOne.Disabled = false;
        }
    }

    public void _on_CheckBoxNine2_toggled(bool value)
    {
        checkBoxNine2Pressed = value;
        if (value == true)
        {
            checkBoxSeven2.Disabled = true;
            checkBoxTwo.Disabled = true;
            checkBoxOne.Disabled = true;
        }
        else
        {
            checkBoxSeven2.Disabled = false;
            checkBoxTwo.Disabled = false;
            checkBoxOne.Disabled = false;
        }
    }

    public void _on_CheckBoxOne_toggled(bool value)
    {
        if (value == true)
        {
            checkBoxSeven2.Disabled = true;
            checkBoxNine2.Disabled = true;
            checkBoxTwo.Disabled = true;
        }
        else
        {
            checkBoxSeven2.Disabled = false;
            checkBoxNine2.Disabled = false;
            checkBoxTwo.Disabled = false;
        }
    }

}
