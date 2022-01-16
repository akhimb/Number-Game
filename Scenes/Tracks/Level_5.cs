using Godot;
using System;

public class Level_5 : Node2D
{
           private AudioStreamPlayer _Four;
   private Global GLOBAL;
    public override void _Ready()
    {
         GLOBAL = GetNode<Global>("/root/Global");
         GLOBAL.MaxLaps = 9;
                         _Four = GetNode<AudioStreamPlayer>("Four");
        _Four.Play();
    }
}
