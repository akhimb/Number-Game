using Godot;
using System;

public class Level_14 : Node2D
{
    private AudioStreamPlayer _SevenHornbillsSound;
    private AudioStreamPlayer _SevenFingersSound;
    private AudioStreamPlayer _WonMatch;
    private AudioStreamPlayer _Okay;
    private int totalMarks = 0;
    private Button goNextButton;
    private Button submitButton;
    private Boolean checkBoxSevenPressed;
    private Boolean checkBoxSeven1Pressed;
    private CheckBox checkBoxFour;
    private CheckBox checkBoxFive;
    private CheckBox checkBoxSix;
    private CheckBox checkBoxSeven;

    private CheckBox checkBoxFour1;
    private CheckBox checkBoxFive1;
    private CheckBox checkBoxSix1;
    private CheckBox checkBoxSeven1;

    private CustomSignals _cs;

    public override void _Ready()
    {
        _cs = GetNode<CustomSignals>("/root/CS");
        _SevenHornbillsSound = GetNode<AudioStreamPlayer>("SevenHornbillsSound");
        _SevenFingersSound = GetNode<AudioStreamPlayer>("SevenFingersSound");
        _WonMatch = GetNode<AudioStreamPlayer>("WonMatch");
        _Okay = GetNode<AudioStreamPlayer>("Okay");
        goNextButton = GetNode<Button>("GoNextButton");
        goNextButton.Visible = false;
        submitButton = GetNode<Button>("SubmitButton");
        checkBoxFour = GetNode<CheckBox>("CheckBoxFour");
        checkBoxFive = GetNode<CheckBox>("CheckBoxFive");
        checkBoxSix = GetNode<CheckBox>("CheckBoxSix");
        checkBoxSeven = GetNode<CheckBox>("CheckBoxSeven");

        checkBoxFour1 = GetNode<CheckBox>("CheckBoxFour1");
        checkBoxFive1 = GetNode<CheckBox>("CheckBoxFive1");
        checkBoxSix1 = GetNode<CheckBox>("CheckBoxSix1");
        checkBoxSeven1 = GetNode<CheckBox>("CheckBoxSeven1");
    }

    public void _on_GoNextButton_pressed()
    {
        _cs.EmitSignal("changeLevel");
    }

    public void _on_SevenHornbillsButton_pressed()
    {
        _SevenHornbillsSound.Play();
    }

    public void _on_SevenFingersButton_pressed()
    {
        _SevenFingersSound.Play();
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
        totalMarks += checkBoxSevenPressed == true ? 10 : 0;
        totalMarks += checkBoxSeven1Pressed == true ? 10 : 0;
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
          checkBoxSevenPressed = value;
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

    public void _on_CheckBoxFour1_toggled(bool value)
    {
        if (value == true)
        {
            checkBoxFive1.Disabled = true;
            checkBoxSix1.Disabled = true;
            checkBoxSeven1.Disabled = true;
        }
        else
        {
            checkBoxFive1.Disabled = false;
            checkBoxSix1.Disabled = false;
            checkBoxSeven1.Disabled = false;
        }

    }

    public void _on_CheckBoxFive1_toggled(bool value)
    {
        if (value == true)
        {
            checkBoxFour1.Disabled = true;
            checkBoxSix1.Disabled = true;
            checkBoxSeven1.Disabled = true;
        }
        else
        {
            checkBoxFour1.Disabled = false;
            checkBoxSix1.Disabled = false;
            checkBoxSeven1.Disabled = false;
        }
    }

    public void _on_CheckBoxSix1_toggled(bool value)
    {
        if (value == true)
        {
            checkBoxFour1.Disabled = true;
            checkBoxFive1.Disabled = true;
            checkBoxSeven1.Disabled = true;
        }
        else
        {
            checkBoxFour1.Disabled = false;
            checkBoxFive1.Disabled = false;
            checkBoxSeven1.Disabled = false;
        }
    }

    public void _on_CheckBoxSeven1_toggled(bool value)
    {
        checkBoxSeven1Pressed = value;
        if (value == true)
        {
            checkBoxFour1.Disabled = true;
            checkBoxFive1.Disabled = true;
            checkBoxSix1.Disabled = true;
        }
        else
        {
            checkBoxFour1.Disabled = false;
            checkBoxFive1.Disabled = false;
            checkBoxSix1.Disabled = false;
        }
    }

}
