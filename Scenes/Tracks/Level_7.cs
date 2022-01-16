using Godot;
using System;

public class Level_7 : Node2D
{

   private Global GLOBAL;
              private AudioStreamPlayer _Six;
    public override void _Ready()
    {
         GLOBAL = GetNode<Global>("/root/Global");
         GLOBAL.MaxLaps = 12;
                         _Six = GetNode<AudioStreamPlayer>("Six");
        _Six.Play();
    }
}
