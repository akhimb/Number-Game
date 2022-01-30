using Godot;

public class HandDot : KinematicBody2D
{
    [Export] public int speed = 700;
    private Vector2 _velocity = Vector2.Zero;
    private bool allowInput = true;
    private CustomSignals _cs;
    private Global GLOBAL;

    public override void _Ready()
    {
        _cs = GetNode<CustomSignals>("/root/CS");
        _cs.Connect("raceOver", this, "ToggleInput");
        GLOBAL = GetNode<Global>("/root/Global");
        GetNode<Sprite>("Chalk").Modulate = new Color(1,0,0,0.5f);
    }

    public void ToggleInput()
    {
        allowInput = false;
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

        if (inputEvent is InputEventScreenDrag dragEvent)
        {
            LookAt(GetGlobalMousePosition());
            _velocity = new Vector2(speed, 0).Rotated(Rotation);
            //_velocity = _velocity.Normalized() * speed;
            _velocity = MoveAndSlide(_velocity);
        }
    }

}
