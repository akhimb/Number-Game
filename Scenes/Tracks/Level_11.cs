using Godot;
using System;

public class Level_11 : Node2D
{

   private Global GLOBAL;
    private AudioStreamPlayer _Nine;
    public override void _Ready()
    {
         GLOBAL = GetNode<Global>("/root/Global");
         GLOBAL.MaxLaps = 12;
                         _Nine = GetNode<AudioStreamPlayer>("Nine");
        _Nine.Play();
    }
}
