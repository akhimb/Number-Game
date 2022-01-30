using Godot;
using System.Collections.Generic;

public class Level_20 : Node2D
{
    private List<Vector2> _vectorArry;
    private bool isDrawable = false;
    private CustomSignals _cs;
    private Global GLOBAL;
    private Sprite _Sprite;
    private HandDot _handDot;
    public override void _Ready()
    {
        _cs = GetNode<CustomSignals>("/root/CS");
        _cs.Connect("enableChalk", this, "WriteStarted");
        _cs.Connect("disableChalk", this, "WriteEnd");
        GLOBAL = GetNode<Global>("/root/Global");
        GLOBAL.MaxLaps = 10;
        this.SetProcess(true);
        _vectorArry = new List<Vector2>();
        _Sprite = GetNode<Sprite>("Sprite");
        this._handDot = GetNode<HandDot>("HandDot");
    }

    public override void _Draw()
    {
        if (this._vectorArry != null && this._vectorArry.Count > 0)
        {
            for (int i = 0; i < this._vectorArry.Count; i++)
            {
                DrawCircle(this._vectorArry[i], 20f, new Color(1,1,0,0.05f));
            }
        }
    }

    public void _on_GoNextButton_pressed()
    {
        _cs.EmitSignal("gameOver");
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
        this._vectorArry.Clear();
        Update();
        this._handDot.Visible = false;
        _Sprite.Visible = true;
        for (int i = 1; i < 10; i++)
        {
            GetNode<Checkpoint>("Checkpoint"+i.ToString()).Visible = false;
        }
        GetNode<Checkpoint>("Checkpoint").Visible = false;
    }

}
