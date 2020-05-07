using Godot;
using System;
using System.Diagnostics;


abstract public class StateBase :Godot.Object//: Node
{
    protected tzzGodot.Owner  owner;
    [Signal]
    public delegate void SigStateOver(params object[] args);
    abstract public string getStateName();
    public abstract void on_enter(dynamic args);
    public abstract void on_exit(dynamic args);
    
    public StateBase(tzzGodot.Owner owner){
        this.owner = owner;
    }

    public abstract void handle_action(string action_name,object arg);

    abstract public void handle_physics_process(float dt);

    public void state_over(params object[] arg){
        EmitSignal(nameof(SigStateOver),arg);
    }
    public void connect_state_over(Godot.Object target,string method ){
        this.Connect(nameof(SigStateOver),target,method);
    }
}
