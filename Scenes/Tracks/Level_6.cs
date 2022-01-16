using Godot;
using System;

public class Level_6 : Node2D
{

           private AudioStreamPlayer _Five;
   private Global GLOBAL;
    public override void _Ready()
    {
         GLOBAL = GetNode<Global>("/root/Global");
         GLOBAL.MaxLaps = 11;
                         _Five = GetNode<AudioStreamPlayer>("Five");
        _Five.Play();
    }
}
