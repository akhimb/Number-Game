using Godot;
using System;

public class GameUI : Control
{
    private Label lblLapCounter;
    private Global _global;
    private CustomSignals _cs;
    private AudioStreamPlayer _WonSound;
    private Particles2D _Particles;

    private Button _GoNextButton;
    Timer _delayTimer;
    private bool timerActivated = false;

    public override void _Ready()
    {
        _global = GetNode<Global>("/root/Global");
        _cs = GetNode<CustomSignals>("/root/CS");
        _cs.Connect("lapOver", this, "UpdateLapCounter");

        lblLapCounter = GetNode<Label>("lblLapCounter");
        _GoNextButton = GetNode<Button>("GoNextButton");
        _GoNextButton.Visible = false;
        _WonSound = GetNode<AudioStreamPlayer>("Won");
        _Particles = GetNode<Particles2D>("Particles2D");
        this._delayTimer = GetNode<Timer>("DelayTimer");
        this._delayTimer.OneShot = true;
        this._delayTimer.WaitTime = 1f;
        this.timerActivated = false;

    }

    public override void _Process(float delta)
    {

    }

    public void _on_DelayTimer_timeout()
    {
        this._Particles.Visible = false;
    }

    //we have to make sure that the lapcounter in global is updated before this is called
    public void UpdateLapCounter()
    {
        lblLapCounter.Text = String.Format("{0} / {1}", _global.LapCounter.ToString(), _global.MaxLaps);
        if (_global.LapCounter >= _global.MaxLaps)
        {
            _WonSound.Play();
            _GoNextButton.Visible = true;
            if (!timerActivated)
            {
                this._delayTimer.Start();
                this.timerActivated = true;
                this._Particles.Visible = true;
            }
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

    public void _on_PreviousLevelButton_pressed()
    {
        _cs.EmitSignal("callPreviousLevel");
    }

    public void _on_NextLevelButton_pressed()
    {
        _cs.EmitSignal("changeLevel");
    }



}




