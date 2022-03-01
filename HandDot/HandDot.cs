using Godot;

public class HandDot : KinematicBody2D
{
    [Export] public int speed = 700;
    private Vector2 _velocity = Vector2.Zero;
    private bool allowInput = true;
    private bool allowMove = false;
    private CustomSignals _cs;
    private Global GLOBAL;
    Vector2 previous_mouse_position;
    bool is_dragging = false;

    public override void _Ready()
    {
        _cs = GetNode<CustomSignals>("/root/CS");
        _cs.Connect("raceOver", this, "ToggleInput");
        _cs.Connect("allowMove", this, "ToggleMove");
        GLOBAL = GetNode<Global>("/root/Global");
        //GetNode<Sprite>("Chalk").Modulate = new Color(1,0,0,0.5f);
    }

    public void ToggleInput()
    {
        allowInput = false;
    }

    public void ToggleMove()
    {
        allowMove = true;
    }

    public void ToggleMouseControl()
    {
    }

    public override void _Process(float delta)
    {
    }

    //Remove this disable drag
    public override void _Input(InputEvent inputEvent)
    {
        if (!allowInput)
            return;

        if (!allowMove)
            return;
        // if (!is_dragging)
        //     return;

        // if (inputEvent is InputEventScreenDrag dragEvent)
        // {
        //     LookAt(GetGlobalMousePosition());
        //     _velocity = new Vector2(speed, 0).Rotated(Rotation);
        //     //_velocity = _velocity.Normalized() * speed;
        //     _velocity = MoveAndSlide(_velocity);
        // }

        if (inputEvent is InputEventMouseButton mouseClicked)
        {
            if (inputEvent.IsActionPressed("ui_touch"))
            {
                previous_mouse_position = mouseClicked.Position;
                is_dragging = true;
            }

            if (inputEvent.IsActionReleased("ui_touch"))
            {
                previous_mouse_position = new Vector2();
                is_dragging = false;
            }
        }

        if (is_dragging && inputEvent is InputEventMouseMotion dragEvent)
        {
            Position += dragEvent.Position - previous_mouse_position;
            previous_mouse_position = dragEvent.Position;
        }
    }

}
