using Godot;
using System;

public class Level_9 : Node2D
{

   private Global GLOBAL;
                 private AudioStreamPlayer _Seven;

    public override void _Ready()
    {
         GLOBAL = GetNode<Global>("/root/Global");
         GLOBAL.MaxLaps = 8;
                         _Seven = GetNode<AudioStreamPlayer>("Seven");
        _Seven.Play();
    }
}
