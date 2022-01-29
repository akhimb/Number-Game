using Godot;
using System;
using System.Collections.Generic;

public class Level_3 : Node2D
{

    private Global GLOBAL;
    private List<Vector2> _vectorArry;
    private int _counter = 0;
    private bool isDrawable = false;
    private CustomSignals _cs;
    private AudioStreamPlayer _Two;
    public override void _Ready()
    {
        GLOBAL = GetNode<Global>("/root/Global");
        GLOBAL.MaxLaps = 13;
        this.SetProcess(true);
        _vectorArry = new List<Vector2>();
        _cs = GetNode<CustomSignals>("/root/CS");
        _cs.Connect("enableChalk", this, "WriteStarted");
        _cs.Connect("disableChalk", this, "WriteEnd");
        _Two = GetNode<AudioStreamPlayer>("Two");
        _Two.Play();
    }
    public override void _Draw()
    {
        if (this._vectorArry != null && this._vectorArry.Count > 0)
        {
            for (int i = 0; i < this._vectorArry.Count; i++)
            {
                DrawCircle(this._vectorArry[i],GLOBAL.DrawWidth,GLOBAL.ChalkColor);
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
    }

 

}
