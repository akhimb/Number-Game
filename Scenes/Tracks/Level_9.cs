using Godot;
using System;
using System.Collections.Generic;
public class Level_9 : Node2D
{

    private AudioStreamPlayer _Five;
    private List<Vector2> _vectorArry;
    private bool isDrawable = false;
    private Global GLOBAL;
    private CustomSignals _cs;
    private AnimationPlayer _animationPlayer;
    private bool _isAnimationCompleted = false;
    private Sprite _DummyHandDot;
    private HandDot _HandDot;
    public override void _Ready()
    {
        GLOBAL = GetNode<Global>("/root/Global");
        GLOBAL.MaxLaps = 11;
        _Five = GetNode<AudioStreamPlayer>("Five");
        _Five.Play();
        _cs = GetNode<CustomSignals>("/root/CS");
        _cs.Connect("enableChalk", this, "WriteStarted");
        _cs.Connect("disableChalk", this, "WriteEnd");
        this.SetProcess(true);
        _vectorArry = new List<Vector2>();
        _animationPlayer = GetNode<AnimationPlayer>("HandDotMovementAnimation");
        _animationPlayer.CurrentAnimation = "New Anim";
        _animationPlayer.Play();
        _isAnimationCompleted = false;
        _DummyHandDot = GetNode<Sprite>("DummyHandDot");
        _DummyHandDot.Visible = true;
        _HandDot = GetNode<HandDot>("HandDot");
        _HandDot.Visible = false;
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
        if (!_isAnimationCompleted)
        {
            if (_animationPlayer.IsPlaying())
            {
                this._vectorArry.Add(this._DummyHandDot.Position);
                Update();
            }
            else if (!this.isDrawable)
            {
                _isAnimationCompleted = true;
                _DummyHandDot.Visible = false;
                _HandDot.Visible = true;
                this._vectorArry.Clear();
                Update();
                _cs.EmitSignal("allowMove");
            }
        }
    }
}
