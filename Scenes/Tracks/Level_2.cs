using Godot;
using System;

public class Level_2 : Node2D
{

   private Global GLOBAL;
    public override void _Ready()
    {
         GLOBAL = GetNode<Global>("/root/Global");
         GLOBAL.MaxLaps = 14;
    }

}
