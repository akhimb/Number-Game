using Godot;
using System;

public class Dots : Area2D
{
    [Export] private bool _isActive = false;
    [Export] private bool _isFinishLine = false;
    [Export] private bool _isFirstDotPoint = false;
    [Export] private bool _isLastDotPoint = false;
    [Export] private NodePath _nextDotPoint;
    private Sprite carrot0;
    private Sprite carrot1;
    private Dots _NextDotPoint;
    private Dots _BeforeDotPoint;
    private AudioStreamPlayer _YeehaSound;

    private int _xValue = 0;
    private int _newXValue = 0;
    private Global GLOBAL;

    public override void _Ready()
    {
        GLOBAL = GetNode<Global>("/root/Global");
        _YeehaSound = GetNode<AudioStreamPlayer>("../Yeeha");
        this.SetProcess(true);
        carrot0 = GetNode<Sprite>("../Carrots0");
        carrot1 = GetNode<Sprite>("../Carrots");

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
            _NextDotPoint = GetNode<Dots>(_nextDotPoint);
            if (_NextDotPoint.Name == "Dots10")
            {
                carrot0.Visible = false;
            }
            if (_NextDotPoint.Name == "Dots")
            {
                carrot1.Visible = false;
            }
            if (!_NextDotPoint._isFirstDotPoint)
            {
                _NextDotPoint.Activate();
                if (_NextDotPoint.Name != "Dots10")
                {
                    _newXValue = 350;
                    Update();
                }

            }
        }
    }

    public void Activate()
    {
        _isActive = true;
        _YeehaSound.Stop();
    }
}
