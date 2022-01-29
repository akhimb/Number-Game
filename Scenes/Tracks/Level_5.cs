using Godot;
using System.Collections.Generic;
public class Level_5 : Node2D
{
    private AudioStreamPlayer _Three;
    private Global GLOBAL;
    private List<Vector2> _vectorArry;
    private int _counter = 0;
    private bool isDrawable = false;
    private CustomSignals _cs;
    public override void _Ready()
    {
        GLOBAL = GetNode<Global>("/root/Global");
        GLOBAL.MaxLaps = 14;
        _Three = GetNode<AudioStreamPlayer>("Three");
        _Three.Play();
        _cs = GetNode<CustomSignals>("/root/CS");
        _cs.Connect("enableChalk", this, "WriteStarted");
        _cs.Connect("disableChalk", this, "WriteEnd");
        this.SetProcess(true);
        _vectorArry = new List<Vector2>();
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
