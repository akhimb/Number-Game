using Godot;
using System;
using System.Collections.Generic;
public class Level_17 : Node2D
{

    private Global GLOBAL;
    private AudioStreamPlayer _Nine;
    private List<Vector2> _vectorArry;
    private int _counter = 0;
    private bool isDrawable = false;
    private CustomSignals _cs;
    private Checkpoint _checkPoint7;
    private HandDot _handDot;
    Timer _delayTimer;
    private bool timerActivated = false;
    public override void _Ready()
    {
        GLOBAL = GetNode<Global>("/root/Global");
        GLOBAL.MaxLaps = 12;
        _Nine = GetNode<AudioStreamPlayer>("Nine");
        _Nine.Play();
        _cs = GetNode<CustomSignals>("/root/CS");
        _cs.Connect("enableChalk", this, "WriteStarted");
        _cs.Connect("disableChalk", this, "WriteEnd");
        this.SetProcess(true);
        _vectorArry = new List<Vector2>();
        this._checkPoint7 = GetNode<Checkpoint>("CheckPoint7");
        this._handDot = GetNode<HandDot>("HandDot");
        this._delayTimer = GetNode<Timer>("DelayTimer");
        this._delayTimer.OneShot = true;
        this._delayTimer.WaitTime = 1f;
        this.timerActivated = false;
    }

    public override void _Draw()
    {
        if (this._vectorArry != null && this._vectorArry.Count > 0)
        {
            for (int i = 0; i < this._vectorArry.Count; i++)
            {
                DrawCircle(this._vectorArry[i], GLOBAL.DrawWidth, GLOBAL.ChalkColor);
            }
        }
    }

    public override void _Input(InputEvent inputEvent)
    {
        if (inputEvent is InputEventScreenDrag dragEvent && this.isDrawable)
        {
            this._vectorArry.Add(dragEvent.Position);
            Update();
        }
    }

    public void WriteStarted()
    {
        this.isDrawable = true;
    }

    public void WriteEnd()
    {
        this.isDrawable = false;
    }

    public override void _Process(float delta)
    {
        if (_checkPoint7._isActive)
        {
            if (!timerActivated)
            {
                this._handDot.Hide();
                this._delayTimer.Start();
                this.timerActivated = true;
            }
        }
    }

    public void _on_DelayTimer_timeout()
    {
        this._handDot.Show();
        Vector2 newPositon = new Vector2(_checkPoint7.Position.x, _checkPoint7.Position.y - 100);
        _handDot.Position = newPositon;
    }
}
