using Godot;
using System;
using System.Diagnostics;

public class Battle : Node2D
{
    public BackgroundBase bg;
    public Player player;
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        init();
    }
    public void init(){
        //load player
        this.player =(Player)tzzGodot.Scene.load_scene_resource("res://scenes/Player/Player.tscn").Instance();
        this.AddChild(this.player);
        //load background
        //todo

    }
}
