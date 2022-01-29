using Godot;
using System;

public class Level_6 : Node2D
{
    private CustomSignals _cs;
    public override void _Ready()
    {
        _cs = GetNode<CustomSignals>("/root/CS");
    }

    public void _on_GoNextButton_pressed()
    {
        _cs.EmitSignal("changeLevel");
    }

}
