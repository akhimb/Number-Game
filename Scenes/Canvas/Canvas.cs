using Godot;
using System;
using System.Collections.Generic;

public class Canvas : Area2D
{
    private List<Vector2> _vectorArry;
    private int _counter = 0;
    public override void _Ready()
    {
        this.SetProcess(true);
        _vectorArry = new List<Vector2>();
    }

    public override void _Draw()
    {
        if (this._vectorArry != null && this._vectorArry.Count > 0)
        {
            foreach (var item in this._vectorArry)
            {
                DrawCircle(new Vector2(item.x, item.y), 15f, new Color(1, 1, 1));
            }
            this._counter = 0;
        }

    }

    public override void _Process(float delta)
    {
    }

    public override void _Input(InputEvent inputEvent)
    {
        if (inputEvent is InputEventScreenDrag dragEvent)
        {
            while (_counter < 5)
            {
                this._vectorArry.Add(dragEvent.Position);
                _counter++;
            }
            Update();
        }
    }

}
