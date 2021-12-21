using Godot;
using System;

public class Sprite : Godot.Sprite
{
    private float deltaX;
    private float deltaY;
    
    private float newDeltaX;
    private float newDeltaY;
    private Vector2 touchPosition = new Vector2();
    private bool areaEnt = false;
    public override void _Ready()
    {

    }

    public override void _Input(InputEvent inputEvent)
    {
        if (areaEnt)
        {
            if (inputEvent is InputEventScreenTouch touchEvent && inputEvent.IsPressed())
            {
                touchPosition = touchEvent.Position;
                deltaX = touchPosition.x - Position.x;
                deltaY = touchPosition.y - Position.y;
            }
            else if (inputEvent is InputEventScreenDrag tragEvent)
            {
                touchPosition = tragEvent.Position;
                newDeltaX = touchPosition.x - deltaX;
                newDeltaY = touchPosition.y - deltaY;
                Position = new Vector2(newDeltaX,newDeltaY);
            }
        }
    }

    private void _on_TouchScreenButton_pressed()
    {
        areaEnt = true;
    }

    private void _on_TouchScreenButton_released()
    {
        areaEnt = false;
    }
}
