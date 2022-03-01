using Godot;
using System;

public class Level_8 : Node2D
{
    private AudioStreamPlayer _FourCrocodilesSound;
    private AudioStreamPlayer _FourFIngersSound;
    private AudioStreamPlayer _WonMatch;
    private AudioStreamPlayer _Okay;
    private int totalMarks = 0;
    private Button goNextButton;
    private Button submitButton;
    private Boolean checkBoxFourPressed;
    private Boolean checkBoxFour2Pressed;
    private CheckBox checkBoxOne;
    private CheckBox checkBoxTwo;
    private CheckBox checkBoxThree;
    private CheckBox checkBoxFour;

    private CheckBox checkBoxOne2;
    private CheckBox checkBoxTwo2;
    private CheckBox checkBoxThree2;
    private CheckBox checkBoxFour2;

    private CustomSignals _cs;

    public override void _Ready()
    {
        _cs = GetNode<CustomSignals>("/root/CS");
        _FourCrocodilesSound = GetNode<AudioStreamPlayer>("FourCrocodilesSound");
        _FourFIngersSound = GetNode<AudioStreamPlayer>("FourFIngersSound");
        _WonMatch = GetNode<AudioStreamPlayer>("WonMatch");
        _Okay = GetNode<AudioStreamPlayer>("Okay");
        goNextButton = GetNode<Button>("GoNextButton");
        goNextButton.Visible = false;
        submitButton = GetNode<Button>("SubmitButton");
        checkBoxOne = GetNode<CheckBox>("CheckBoxOne");
        checkBoxTwo = GetNode<CheckBox>("CheckBoxTwo");
        checkBoxThree = GetNode<CheckBox>("CheckBoxThree");
        checkBoxFour = GetNode<CheckBox>("CheckBoxFour");

        checkBoxOne2 = GetNode<CheckBox>("CheckBoxOne2");
        checkBoxTwo2 = GetNode<CheckBox>("CheckBoxTwo2");
        checkBoxThree2 = GetNode<CheckBox>("CheckBoxThree2");
        checkBoxFour2 = GetNode<CheckBox>("CheckBoxFour2");
    }

    public void _on_GoNextButton_pressed()
    {
        _cs.EmitSignal("changeLevel");
    }

    public void _on_FourCrocodilesButton_pressed()
    {
        _FourCrocodilesSound.Play();
    }

    public void _on_FourFIngersButton_pressed()
    {
        _FourFIngersSound.Play();
    }

    public void _on_NextLevel_pressed()
    {
        _cs.EmitSignal("changeLevel");
    }
    public void _on_PictureButton1_pressed()
    {
        GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D").Play();
    }

    public void _on_PictureButton2_pressed()
    {
         GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D2").Play();
    }

    public void _on_SubmitButton_pressed()
    {
        totalMarks += checkBoxFourPressed == true ? 10 : 0;
        totalMarks += checkBoxFour2Pressed == true ? 10 : 0;
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

    public void _on_CheckBoxOne_toggled(bool value)
    {
        if (value == true)
        {
            checkBoxTwo.Disabled = true;
            checkBoxThree.Disabled = true;
            checkBoxFour.Disabled = true;
        }
        else
        {
            checkBoxTwo.Disabled = false;
            checkBoxThree.Disabled = false;
            checkBoxFour.Disabled = false;
        }

    }

    public void _on_CheckBoxTwo_toggled(bool value)
    {
        if (value == true)
        {
            checkBoxOne.Disabled = true;
            checkBoxThree.Disabled = true;
            checkBoxFour.Disabled = true;
        }
        else
        {
            checkBoxOne.Disabled = false;
            checkBoxThree.Disabled = false;
            checkBoxFour.Disabled = false;
        }
    }

    public void _on_CheckBoxThree_toggled(bool value)
    {

        if (value == true)
        {
            checkBoxOne.Disabled = true;
            checkBoxTwo.Disabled = true;
            checkBoxFour.Disabled = true;
        }
        else
        {
            checkBoxOne.Disabled = false;
            checkBoxTwo.Disabled = false;
            checkBoxFour.Disabled = false;
        }
    }

    public void _on_CheckBoxFour_toggled(bool value)
    {
        checkBoxFourPressed = value;
        if (value == true)
        {
            checkBoxOne.Disabled = true;
            checkBoxTwo.Disabled = true;
            checkBoxThree.Disabled = true;
        }
        else
        {
            checkBoxOne.Disabled = false;
            checkBoxTwo.Disabled = false;
            checkBoxThree.Disabled = false;
        }
    }

    public void _on_CheckBoxFour2_toggled(bool value)
    {
        checkBoxFour2Pressed = value;
        if (value == true)
        {
            checkBoxOne2.Disabled = true;
            checkBoxTwo2.Disabled = true;
            checkBoxThree2.Disabled = true;
        }
        else
        {
            checkBoxOne2.Disabled = false;
            checkBoxTwo2.Disabled = false;
            checkBoxThree2.Disabled = false;
        }
    }

    public void _on_CheckBoxThree2_toggled(bool value)
    {
        
        if (value == true)
        {
            checkBoxOne2.Disabled = true;
            checkBoxTwo2.Disabled = true;
            checkBoxFour2.Disabled = true;
        }
        else
        {
            checkBoxOne2.Disabled = false;
            checkBoxTwo2.Disabled = false;
            checkBoxFour2.Disabled = false;
        }
    }

    public void _on_CheckBoxTwo2_toggled(bool value)
    {
        if (value == true)
        {
            checkBoxOne2.Disabled = true;
            checkBoxThree2.Disabled = true;
            checkBoxFour2.Disabled = true;
        }
        else
        {
            checkBoxOne2.Disabled = false;
            checkBoxThree2.Disabled = false;
            checkBoxFour2.Disabled = false;
        }
    }

    public void _on_CheckBoxOne2_toggled(bool value)
    {
        if (value == true)
        {
            checkBoxTwo2.Disabled = true;
            checkBoxThree2.Disabled = true;
            checkBoxFour2.Disabled = true;
        }
        else
        {
            checkBoxTwo2.Disabled = false;
            checkBoxThree2.Disabled = false;
            checkBoxFour2.Disabled = false;
        }
    }

}
