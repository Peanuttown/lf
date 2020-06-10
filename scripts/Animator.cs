using Godot;
using System;


namespace tzzGodot{
abstract public class Animator 
    {
        abstract public void show();
        abstract public void showWithFrameIdx(int frameIdx);
        abstract public void addToChild(Godot.Node parent);

        abstract public void SetFlipH(bool f);
        abstract public void SetFlipV(bool f);
    }

}