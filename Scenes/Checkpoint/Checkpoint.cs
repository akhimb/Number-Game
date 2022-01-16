using Godot;
using System;

public class Checkpoint : Area2D
{
    [Export] private bool _isActive = false;
    [Export] private bool _isFirstCheckPoint = false;
    [Export] private bool _isLastCheckPoint = false;
    [Export] private bool _isDrawEnabled = true;
    [Export] private NodePath _nextCheckPoint;
    [Export] private NodePath _currentCheckPoint;
    private Checkpoint _NextCheckPoint;
    private Global GLOBAL;
    private AudioStreamPlayer _playMileStone;
    private CollisionShape2D _collisionShape2D;

    private CustomSignals _cs;

    public override void _Ready()
    {
        GLOBAL = GetNode<Global>("/root/Global");
        _playMileStone = GetNode<AudioStreamPlayer>("PlayMileStone");
        _collisionShape2D = GetNode<CollisionShape2D>("CollisionShape2D");
        this.SetProcess(true);
        _cs = GetNode<CustomSignals>("/root/CS");
    }

    public override void _Draw()
    {

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
            if (_currentCheckPoint!=null && GetNode<Checkpoint>(_currentCheckPoint)._isFirstCheckPoint)
            {
                GD.Print("Chalk Activated");
                _cs.EmitSignal("enableChalk");
            }
            
            _NextCheckPoint = GetNode<Checkpoint>(_nextCheckPoint);
            if (!_NextCheckPoint._isFirstCheckPoint)
            {
                _NextCheckPoint.Activate();
                _playMileStone.Play();
            }

            // if (_NextCheckPoint._isDrawEnabled)
            // {
            //     GD.Print("Inside");
            // }
        }
    }

    public void Activate()
    {
        _isActive = true;
    }
}
