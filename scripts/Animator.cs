using Godot;
using System;


namespace tzzGodot{
abstract public class Animator 
    {
        abstract public void show();
        abstract public void showWithFrameIdx(int frameIdx);
        abstract public void addToChild(Godot.Node parent);
    }
}