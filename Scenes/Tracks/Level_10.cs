using Godot;
using System;

public class Level_10 : Node2D
{

   private Global GLOBAL;
                 private AudioStreamPlayer _Eight;
    public override void _Ready()
    {
         GLOBAL = GetNode<Global>("/root/Global");
         GLOBAL.MaxLaps = 14;
                         _Eight = GetNode<AudioStreamPlayer>("Eight");
        _Eight.Play();
    }
}
