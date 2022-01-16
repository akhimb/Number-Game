using Godot;
using System;

public class Level_13 : Node2D
{

   private Global GLOBAL;
    private AudioStreamPlayer _Zero;
    public override void _Ready()
    {
         GLOBAL = GetNode<Global>("/root/Global");
         GLOBAL.MaxLaps = 9;
                         _Zero = GetNode<AudioStreamPlayer>("Zero");
        _Zero.Play();
    }
}
