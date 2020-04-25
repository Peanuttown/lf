using Godot;
using System;


abstract public class StateBase //: Node
{
    public string stateName;

    public abstract void on_enter<T>(T args);
    public abstract void on_exit<T>(T args);
    
    public abstract void cs_physics_process(float dt);

    public StateBase(string name){
        this.stateName = name;
    }

    public abstract void handle_action(string action_name,dynamic arg);
}
