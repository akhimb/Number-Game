using Godot;
using System;

public class GameUI : Control
{
    private Label lblLapCounter;
    private Label lblInstructions;
    private Button buttonNextLevel;
    private Global _global;
    private CustomSignals _cs;
    private Car _follow;
    private AudioStreamPlayer _WonSound;


    public override void _Ready()
    {
        _global = GetNode<Global>("/root/Global");
        _cs = GetNode<CustomSignals>("/root/CS");
        _cs.Connect("lapOver", this, "UpdateLapCounter");


        lblLapCounter = GetNode<Label>("lblLapCounter");
        lblInstructions = GetNode<Label>("lblInstructions");
        buttonNextLevel = GetNode<Button>("ButtonNextLevel");

        _WonSound = GetNode<AudioStreamPlayer>("Won");
        buttonNextLevel.Visible = false;
    }



    public override void _Process(float delta)
    {
        // Vector2 followPos = new Vector2(_follow.Position.x - RectSize.x,_follow.Position.y - RectSize.y);

        // RectPosition = followPos;
    }



    //we have to make sure that the lapcounter in global is updated before this is called
    public void UpdateLapCounter()
    {
        lblLapCounter.Text = String.Format("Points : {0} / {1}", _global.LapCounter.ToString(), _global.MaxLaps);
        if (_global.LapCounter >= _global.MaxLaps)
        {
            //_BackgroundSound.Stop();
            _WonSound.Play();
            buttonNextLevel.Visible = true;
        }
    }


    public void _on_ButtonNextLevel_pressed()
    {
        
        GetTree().ChangeScene($"res://Scenes/Tracks/Level_{Convert.ToInt32(GetTree().CurrentScene.Name.Split('_')[1]) + 1 }.tscn");
        GetTree().CurrentScene._Ready();
 
        buttonNextLevel.Visible = false;
    }



    public void _on_CkBtnUseMouse_toggled(bool buttonEnabled)
    {
        if (buttonEnabled)
        {
            lblInstructions.Text = "Click left mouse button to move forward and right button to move backward.";
        }
        else
        {
            lblInstructions.Text = "Use keyboard arrow keys or use keys w - forward, s - backward, a - left, d - right .";
        }
        _cs.EmitSignal("controlChange");
    }

}
