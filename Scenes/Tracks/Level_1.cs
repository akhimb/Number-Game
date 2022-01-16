using Godot;
using System;

public class Level_1 : Node2D
{
    private AudioStreamPlayer _One;
    private Global GLOBAL;
    public override void _Ready()
    {
        _One = GetNode<AudioStreamPlayer>("One");
        _One.Play();
        GLOBAL = GetNode<Global>("/root/Global");
        GLOBAL.MaxLaps = 4;
    }
}
