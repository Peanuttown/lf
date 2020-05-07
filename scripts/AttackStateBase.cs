using Godot;
using System;
using System.Diagnostics;

public class AttackStateBase : StateBase
{
    private ComboMgr comboMgr;
    public const string stateName ="atk";
    public override string getStateName(){
        return AttackStateBase.stateName;
    }
    private int actionCounter;
    public AttackStateBase(ComboMgr combos):base(){
        this.comboMgr = combos;
        this.comboMgr.connectComboOver(this,nameof(this.onComboOver));
    }
    public void onComboOver(){
        this.state_over();
    }

    // Called when the node enters the scene tree for the first time.
    private void Attack()
    {
        this.comboMgr.Combo();
    }

    private void attackCounterIncr(){
        this.actionCounter++;
    }

    public override void on_enter(dynamic args)
    {
        Console.WriteLine("attack enter");
        this.Attack();
    }

    public override void on_exit(dynamic args)
    {
        Console.WriteLine("attack exit");
    }

    public override void handle_action(string action_name, dynamic arg){
        if (action_name == this.getStateName()){
            this.Attack();
        }
    }

    public override void handle_physics_process(float dt){
        //todo
        this.comboMgr.Update(dt);
    }


//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
