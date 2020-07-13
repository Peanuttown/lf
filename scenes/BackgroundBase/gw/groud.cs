using Godot;
using System;

public class groud : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }
    public override void _Draw(){
        //var color = new Color(154,110,90,(float)0.5);
        var color = new Color("9a6e5a");
        //var color = new Color("ff0000");
        var reslution= tzzGodot.Screen.get_resolution(this);
        var vertical_bg_height = 224;
        var area = new Rect2(new Vector2(0,vertical_bg_height),reslution.x,reslution.y-vertical_bg_height);
        this.DrawRect(area,color,true);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
