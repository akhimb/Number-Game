using Godot;
using System;

public class Car : KinematicBody2D
{

    [Export] private float _steeringAngle = 15.0f;  // Amount that front wheel turns, in degrees
    [Export] private float _enginePoser = 800.0f;
    [Export] private float _maxSpeedReverse = 250.0f;
    [Export] public int speed = 400;

    private float _wheelBase = 70.0f;  // Distance from front to rear wheel

    private Vector2 _velocity = Vector2.Zero;
    private float _steerAngle;
    private Vector2 _acceleration = Vector2.Zero;
    private float _friction = -0.9f;
    private float _drag = -0.0015f;
    private float _breaking = -450.0f;

    private float _slipSpeed = 400;      // Speed where traction is reduced
    private float _tractionFast = 0.1f;  // High-speed traction
    private float _tractionSlow = 0.7f;  //Low-speed traction


    private bool allowInput = true;
    private bool allowMouseControl = true;

    private CustomSignals _cs;
    private Global GLOBAL;

    private float deltaX;
    private float deltaY;

    private float newDeltaX;
    private float newDeltaY;
    private Vector2 touchPosition = new Vector2();
    private bool areaEnt = false;

    public override void _Ready()
    {
        _cs = GetNode<CustomSignals>("/root/CS");
        _cs.Connect("raceOver", this, "ToggleInput");
        _cs.Connect("controlChange", this, "ToggleMouseControl");
        GLOBAL = GetNode<Global>("/root/Global");
    }


    public void ToggleInput()
    {
        allowInput = false;
    }

    public void ToggleMouseControl()
    {
        allowMouseControl = !allowMouseControl;
    }




    public override void _PhysicsProcess(float delta)
    {
        _acceleration = Vector2.Zero;
        if (allowMouseControl)
        {
            GetMouseInput();
            _velocity = MoveAndSlide(_velocity);
        }
        else
        {
            GetInput();
            ApplyFriction();
            CalculateSteering(delta);
            _velocity += _acceleration * delta;
            _velocity = MoveAndSlide(_velocity);
        }

    }

    // public override void _Input(InputEvent inputEvent)
    // {

    //     if (inputEvent is InputEventScreenTouch touchEvent && inputEvent.IsPressed())
    //     {
    //         LookAt(GetGlobalMousePosition());
    //         touchPosition = touchEvent.Position;
    //         deltaX = touchPosition.x - Position.x;
    //         deltaY = touchPosition.y - Position.y;
    //         _velocity = new Vector2(speed, 0).Rotated(Rotation);
    //         _velocity = _velocity.Normalized() * speed;
    //         _velocity = MoveAndSlide(_velocity);
    //     }
    //     else if (inputEvent is InputEventScreenDrag tragEvent)
    //     {
    //         touchPosition = tragEvent.Position;
    //         newDeltaX = touchPosition.x - deltaX;
    //         newDeltaY = touchPosition.y - deltaY;
    //         Position = new Vector2(newDeltaX, newDeltaY);
    //         _velocity = new Vector2(speed, 0).Rotated(Rotation);
    //         _velocity = _velocity.Normalized() * speed;
    //         _velocity = MoveAndSlide(_velocity);
    //     }

    // }


    public void GetMouseInput()
    {
        if (!allowInput)
        {
            return;
        }
        LookAt(GetGlobalMousePosition());
        _velocity = new Vector2();

        if (Input.IsActionPressed("mouse-left"))
            _velocity = new Vector2(speed, 0).Rotated(Rotation);

        if (Input.IsActionPressed("mouse-right"))
            _velocity = new Vector2(-speed, 0).Rotated(Rotation);

        _velocity = _velocity.Normalized() * speed;
    }



    private void GetInput()
    {
        if (!allowInput)
        {
            return;
        }

        float turn = Input.GetActionStrength("right") - Input.GetActionStrength("left");
        _steerAngle = turn * Mathf.Deg2Rad(_steeringAngle);

        if (Input.IsActionPressed("forward"))
        {
            _acceleration = Transform.x * _enginePoser;
        }
        if (Input.IsActionPressed("brake"))
        {
            _acceleration = Transform.x * _breaking;
        }
    }


    private void CalculateSteering(float delta)
    {
        Vector2 rearWheel = Position - Transform.x * _wheelBase / 2.0f;
        Vector2 frontWheel = Position + Transform.x * _wheelBase / 2.0f;
        rearWheel += _velocity * delta;
        frontWheel += _velocity.Rotated(_steerAngle) * delta;
        Vector2 newHeading = (frontWheel - rearWheel).Normalized();

        float traction = _tractionSlow;
        if (_velocity.Length() > _slipSpeed)
            traction = _tractionFast;


        float d = newHeading.Dot(_velocity.Normalized());
        if (d < 0)
            _velocity = -newHeading * Mathf.Min(_velocity.Length(), _maxSpeedReverse);
        else if (d > 0)
            _velocity = _velocity.LinearInterpolate(newHeading * _velocity.Length(), traction);

        Rotation = newHeading.Angle();
    }



    private void ApplyFriction()
    {
        if (_velocity.Length() < 5)
            _velocity = Vector2.Zero;

        Vector2 frictionForce = _velocity * _friction;
        Vector2 dragForce = _velocity * _velocity.Length() * _drag;

        if (_velocity.Length() < 100)
            frictionForce *= 3;

        _acceleration += dragForce + frictionForce;
    }
}
