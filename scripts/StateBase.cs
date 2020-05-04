using Godot;
using System;


abstract public class StateBase //: Node
{
    abstract public string getStateName();
    public abstract void on_enter(dynamic args);
    public abstract void on_exit(dynamic args);
    
    public StateBase(){
    }

    public abstract void handle_action(string action_name,dynamic arg);

    abstract public void handle_physics_process(float dt);
}
