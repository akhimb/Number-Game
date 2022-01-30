using Godot;
using System;

public class Level_0 : Node2D
{
    private AudioStreamPlayer _playAndroMom;
    public override void _Ready()
    {
        _playAndroMom = GetNode<AudioStreamPlayer>("PlayAndroMom");
        
        _playAndroMom.Play();
    }

    public void _on_Button_pressed()
    {

        GetTree().ChangeScene($"res://Scenes/Tracks/Level_{Convert.ToInt32(GetTree().CurrentScene.Name.Split('_')[1]) + 1 }.tscn");
        GetTree().CurrentScene._Ready();
    }

}
