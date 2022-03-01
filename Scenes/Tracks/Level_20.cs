using Godot;
using System.Collections.Generic;

public class Level_20 : Node2D
{
    private List<Vector2> _vectorArry;
    private bool isDrawable = false;
    private CustomSignals _cs;
    private Global GLOBAL;
    private Sprite _Sprite;

    private Sprite _SuperManSprite;
    private Sprite _TeddyBearSprite;
    private Sprite _BarbieSprite;
    private Sprite _SuperCarSprite;
    private Sprite _SuperWomenSprite;

    private HandDot _handDot;
    private Button _PictureButton1;
    private Button _GiftButton;
    Timer _delayTimer;
    private Particles2D _Particles;
    private bool timerActivated = false;
    public override void _Ready()
    {
        _cs = GetNode<CustomSignals>("/root/CS");
        _cs.Connect("enableChalk", this, "WriteStarted");
        _cs.Connect("disableChalk", this, "WriteEnd");
        GLOBAL = GetNode<Global>("/root/Global");
        GLOBAL.MaxLaps = 10;
        this.SetProcess(true);
        _vectorArry = new List<Vector2>();
        _Sprite = GetNode<Sprite>("Sprite");
        this._handDot = GetNode<HandDot>("HandDot");
        this._PictureButton1 = GetNode<Button>("PictureButton1");
        this._GiftButton = GetNode<Button>("GiftButton");
        _Sprite.Visible = false;
        _GiftButton.Visible = false;
        this._SuperManSprite = GetNode<Sprite>("SuperManSprite");
        this._TeddyBearSprite = GetNode<Sprite>("TeddyBearSprite");
        this._BarbieSprite = GetNode<Sprite>("BarbieSprite");
        this._SuperCarSprite = GetNode<Sprite>("SuperCarSprite");
        this._SuperWomenSprite = GetNode<Sprite>("SuperWomenSprite");
        this._SuperManSprite.Visible = false;
        this._TeddyBearSprite.Visible = false;
        this._BarbieSprite.Visible = false;
        this._SuperCarSprite.Visible = false;
        this._SuperWomenSprite.Visible = false;
        _Particles = GetNode<Particles2D>("Particles2D");
        this._delayTimer = GetNode<Timer>("DelayTimer");
        this._delayTimer.OneShot = true;
        this._delayTimer.WaitTime = 1f;
        this.timerActivated = false;

    }

    public override void _Draw()
    {
        if (this._vectorArry != null && this._vectorArry.Count > 0)
        {
            for (int i = 0; i < this._vectorArry.Count; i++)
            {
                DrawCircle(this._vectorArry[i], 20f, new Color(1, 1, 0, 0.05f));
            }
        }
    }

    public void _on_PictureButton1_pressed()
    {
        GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D").Play();
    }

    public void _on_GoNextButton_pressed()
    {
        _cs.EmitSignal("gameOver");
    }
    public void _on_DelayTimer_timeout()
    {
        this._Particles.Visible = false;
    }

    public void _on_GiftButton_pressed()
    {
        if (!timerActivated)
        {
            this._delayTimer.Start();
            this.timerActivated = true;
            this._Particles.Visible = true;
        }
        _GiftButton.Visible = false;
        _Sprite.Visible = false;
        RandomNumberGenerator rg = new RandomNumberGenerator();
        rg.Randomize();
        int number = rg.RandiRange(1, 5);
        switch (number)
        {
            case 1:
                this._SuperManSprite.Visible = true;
                break;
            case 2:
                this._TeddyBearSprite.Visible = true;
                break;
            case 3:
                this._BarbieSprite.Visible = true;
                break;
            case 4:
                this._SuperCarSprite.Visible = true;
                break;
            case 5:
                this._SuperWomenSprite.Visible = true;
                break;
            default:
                this._TeddyBearSprite.Visible = true;
                break;
        }

    }

    public override void _Input(InputEvent inputEvent)
    {
        if (inputEvent is InputEventScreenDrag dragEvent && this.isDrawable)
        {
            this._vectorArry.Add(dragEvent.Position);
            Update();
        }
    }

    public void WriteStarted()
    {
        this.isDrawable = true;
    }

    public void WriteEnd()
    {
        this.isDrawable = false;
        this._vectorArry.Clear();
        Update();
        this._handDot.Visible = false;
        _Sprite.Visible = true;
        _GiftButton.Visible = true;

        _PictureButton1.Visible = false;
        for (int i = 1; i < 10; i++)
        {
            GetNode<Checkpoint>("Checkpoint" + i.ToString()).Visible = false;
        }
        GetNode<Checkpoint>("Checkpoint").Visible = false;
    }

}