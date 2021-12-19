using Godot;
using System;

public class GameUI : Control
{
    private Label lblLapCounter;
    private Label lblWon;


    private Global _global;
    private CustomSignals _cs;
    private Car _follow;
    private AudioStreamPlayer _WonSound;
    private AudioStreamPlayer _BackgroundSound;
    private AudioStreamPlayer _CarSound;

    public override void _Ready()
    {
        _global = GetNode<Global>("/root/Global");
        _cs = GetNode<CustomSignals>("/root/CS");
        _cs.Connect("lapOver", this, "UpdateLapCounter");


        lblLapCounter = GetNode<Label>("lblLapCounter");
        _WonSound = GetNode<AudioStreamPlayer>("Won");
        _BackgroundSound = GetNode<AudioStreamPlayer>("Background");
        _CarSound = GetNode<AudioStreamPlayer>("Car");

    }



    public override void _Process(float delta)
    {
        // Vector2 followPos = new Vector2(_follow.Position.x - RectSize.x,_follow.Position.y - RectSize.y);

        // RectPosition = followPos;
    }



    //we have to make sure that the lapcounter in global is updated before this is called
    public void UpdateLapCounter()
    {
        lblLapCounter.Text = String.Format("Points : {0} / {1}", _global.LapCounter.ToString(), _global.MaxLaps);
        if (_global.LapCounter >= _global.MaxLaps)
        {
            _BackgroundSound.Stop();
            _CarSound.Stop();
            _WonSound.Play();
            
        }
    }

}
