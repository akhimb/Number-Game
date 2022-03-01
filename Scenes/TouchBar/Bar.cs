using Godot;
using System;

public class Bar : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
        private AudioStreamPlayer2D _barSound;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
               _barSound = GetNode<AudioStreamPlayer2D>("BarSound");
    }

    public void _on_CollisionBar_body_entered(Node body)
    {
        _barSound.Play();
    }

        public void _on_CollisionBar_body_exited(Node body)
    {
        _barSound.Play();
    }

}