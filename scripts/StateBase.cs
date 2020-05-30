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

    public virtual void on_resume_from_fsm_stack(){
        //empy impl
    }
    
    public StateBase(tzzGodot.Owner owner){
        this.owner = owner;
    }

    public abstract void handle_action(string action_name,object arg);

    abstract public void handle_physics_process(float dt);

    public void state_over(params object[] arg){
        Debug.WriteLine("state "+this.getStateName()+" over");
        EmitSignal(nameof(SigStateOver),arg);
    }
    public void connect_state_over(Godot.Object target,string method ){
        Debug.WriteLine("connect signal "+target);
        this.Connect(nameof(SigStateOver),target,method);
    }
}
