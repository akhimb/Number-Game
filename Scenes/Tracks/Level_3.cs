using Godot;
using System;

public class Level_3 : Node2D
{

   private Global GLOBAL;
    public override void _Ready()
    {
         GLOBAL = GetNode<Global>("/root/Global");
         GLOBAL.MaxLaps = 15;
    }

}
