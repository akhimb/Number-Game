using Godot;
using System;
using System.Collections.Generic;

public class Checkpoint : Area2D
{
    [Export] public bool _isActive = false;
    [Export] private bool _isFirstCheckPoint = false;
    [Export] private bool _isLastCheckPoint = false;
    [Export] private NodePath _nextCheckPoint;
    [Export] private NodePath _currentCheckPoint;
    private Checkpoint _NextCheckPoint;
    private Checkpoint _CurrentCheckPoint;
    private Global GLOBAL;
    private AudioStreamPlayer _playMileStone;
    private CustomSignals _cs;

    public override void _Ready()
    {
        GLOBAL = GetNode<Global>("/root/Global");
        _playMileStone = GetNode<AudioStreamPlayer>("PlayMileStone");
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
            if (_currentCheckPoint != null)
            {
                this._CurrentCheckPoint = GetNode<Checkpoint>(_currentCheckPoint);
                if (this._CurrentCheckPoint._isFirstCheckPoint)
                    _cs.EmitSignal("enableChalk");
                this._CurrentCheckPoint.Scale = new Vector2(.1f, .1f);
                this._CurrentCheckPoint.Modulate = new Color(102, 102, 51);
            }
            if (_nextCheckPoint != null)
            {
                this._NextCheckPoint = GetNode<Checkpoint>(_nextCheckPoint);
                if (!_NextCheckPoint._isFirstCheckPoint)
                {
                    this._NextCheckPoint.Modulate = new Color(0, 128, 0);
                    this._NextCheckPoint.Activate();
                    _playMileStone.Play();
                }
                
            }
        }
    }

    public void Activate()
    {
        _isActive = true;
    }
}
