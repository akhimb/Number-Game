using Godot;
using System;

public class Info : Node2D
{
    public override void _Ready()
    {

    }

    public void _on_GoBack_pressed()
    {
        GetTree().ChangeScene($"res://Scenes/Tracks/Level_0.tscn");
        GetTree().CurrentScene._Ready();
    }

}
