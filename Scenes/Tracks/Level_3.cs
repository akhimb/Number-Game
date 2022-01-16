using Godot;
public class Level_3 : Node2D
{
           private AudioStreamPlayer _Three;
    private Global GLOBAL;
    public override void _Ready()
    {
        GLOBAL = GetNode<Global>("/root/Global");
        GLOBAL.MaxLaps = 14;
                _Three = GetNode<AudioStreamPlayer>("Three");
        _Three.Play();
    }
}
