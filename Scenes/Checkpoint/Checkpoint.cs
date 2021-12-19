using Godot;
using System;

public class Checkpoint : Area2D
{
    [Export] private bool _isActive = false;
    [Export] private bool _isFinishLine = false;
    [Export] private bool _isFirstCheckPoint = false;
    [Export] private bool _isLastCheckPoint = false;
    [Export] private NodePath _nextCheckPoint;
    private Checkpoint _NextCheckPoint;
    private Checkpoint _BeforeCheckPoint;
    private AudioStreamPlayer _YeehaSound;

    private int _xValue = 0;
    private int _newXValue = 0;
    private Global GLOBAL;

    public override void _Ready()
    {
        GLOBAL = GetNode<Global>("/root/Global");
        _YeehaSound = GetNode<AudioStreamPlayer>("../Yeeha");
        this.SetProcess(true);
    }

    public override void _Draw()
    {
        DrawLine(new Vector2(_xValue, _xValue), new Vector2(_newXValue, _xValue), new Color(1, 0, 0), 25f);
    }

    public override void _Process(float delta)
    {

    }

    public void _on_Checkpoint_body_entered(Node body)
    {
        if (_isActive)
        {
            GLOBAL.LapCounter++;
            _isActive = false;
            _YeehaSound.Play();
            _NextCheckPoint = GetNode<Checkpoint>(_nextCheckPoint);
            if (!_NextCheckPoint._isFirstCheckPoint)
            {
                _NextCheckPoint.Activate();
                _newXValue = 350;
                Update();
            }
        }
    }

    public void Activate()
    {
        _isActive = true;
        _YeehaSound.Stop();
    }
}
