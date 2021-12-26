using Godot;
using System;

public class CustomSignals : Node
{
    [Signal] public delegate void lapOver();
    [Signal] public delegate void raceOver();
    [Signal] public delegate void controlChange();
    [Signal] public delegate void levelChange();

}
