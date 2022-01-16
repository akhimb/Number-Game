using Godot;
using System;

public class Global : Node
{
    private int _lapCounter = 0;
    public int MaxLaps { get; set; }
    private CustomSignals _cs;

    public override void _Ready()
    {
        _cs = GetNode<CustomSignals>("/root/CS");
        _cs.Connect("gameOver", this, "CallGameOver");
        _cs.Connect("changeLevel", this, "CallNextLevel");
    }

    public int LapCounter
    {
        get { return _lapCounter; }
        set
        {
            _lapCounter++;
            _cs.EmitSignal("lapOver");
            if (_lapCounter >= MaxLaps)
            {
                _cs.EmitSignal("raceOver");
                _cs.EmitSignal("disableChalk");
                _lapCounter = 0;
            }

        }
    }

    public void CallGameOver()
    {
        _lapCounter = 0;
        GetTree().ChangeScene($"res://Scenes/Tracks/Level_0.tscn");
        GetTree().CurrentScene._Ready();
    }

    public void CallNextLevel()
    {
        GetTree().ChangeScene($"res://Scenes/Tracks/Level_{Convert.ToInt32(GetTree().CurrentScene.Name.Split('_')[1]) + 1 }.tscn");
        GetTree().CurrentScene._Ready();
    }
}
