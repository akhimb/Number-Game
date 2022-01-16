using Godot;
using System;

public class GameUI : Control
{
    private Label lblLapCounter;
    private Global _global;
    private CustomSignals _cs;
    private AudioStreamPlayer _WonSound;

    private Button _GoNextButton;


    public override void _Ready()
    {
        _global = GetNode<Global>("/root/Global");
        _cs = GetNode<CustomSignals>("/root/CS");
        _cs.Connect("lapOver", this, "UpdateLapCounter");

        lblLapCounter = GetNode<Label>("lblLapCounter");
        _GoNextButton = GetNode<Button>("GoNextButton");
        _GoNextButton.Visible = false;
        _WonSound = GetNode<AudioStreamPlayer>("Won");
    }

    public override void _Process(float delta)
    {
    }

    //we have to make sure that the lapcounter in global is updated before this is called
    public void UpdateLapCounter()
    {
        lblLapCounter.Text = String.Format("Points : {0} / {1}", _global.LapCounter.ToString(), _global.MaxLaps);
        if (_global.LapCounter >= _global.MaxLaps)
        {
            _WonSound.Play();
            _GoNextButton.Visible = true;

        }
    }

    public void _on_HomeButton_pressed()
    {
        _cs.EmitSignal("gameOver");
    }

        public void _on_GoNextButton_pressed()
    {
            _cs.EmitSignal("changeLevel");
            _GoNextButton.Visible = false;
    }

}

