using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics;

public abstract  class Action:Godot.GDScript{
    private float duration;
    private float elapseTimeCounter;

    public abstract void playAnimation();

    public Action(float duration){
        this.duration = duration;
        this.elapseTimeCounter = 0;
    }
    private void clean(){
        this.elapseTimeCounter = 0;
    }

    public bool Do(float dt){//return weather the action over
        if (this.elapseTimeCounter==0){
            this.playAnimation();
            this.elapseTimeCounter +=dt;
            return false;
        }else{
            this.elapseTimeCounter +=dt;
            if (this.duration < this.elapseTimeCounter){
                this.clean();
                return true;
            }
            this.playAnimation();
            return false;
        }
    }
}

public class ComboMgr:GDScript
{
    [Signal]
    public delegate void SigComboOver();
    private List<Action> actions;
    private int maxPendingAction;
    private int pendingAction;
    private int comboIndex;
    public ComboMgr(List<Action> actions,int maxPendingAction){
        this.maxPendingAction = (maxPendingAction<=0?1:maxPendingAction);
        this.actions = actions;
        this.pendingAction = 0;
    }
    private bool comboing(){
        return this.pendingAction != 0;
    }
    public void Combo(){
        this.pendingAction = (this.pendingAction+1>this.maxPendingAction?this.pendingAction:this.pendingAction+1);
    }
    private void combo_over(){
        this.comboIndex =0;
        this.EmitSignal(nameof(SigComboOver));
    }
    public void connectComboOver(Godot.Object target,string method){
        this.Connect(
            nameof(SigComboOver),
            target,
            method
        );

    }
    public void Update(float dt){
        if (this.comboing()){
            bool actionOver =  this.actions[this.comboIndex].Do(dt);
            if (actionOver){
                Trace.WriteLine("action over");
                this.pendingAction --;
                if (this.pendingAction==0){
                    this.combo_over();
                }else{
                    this.comboIndex = (this.comboIndex+1)%this.actions.Count;
                }
            }
        }
    }
}
