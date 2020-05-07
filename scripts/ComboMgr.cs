using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics;

public abstract  class Action:Godot.GDScript{
    private float duration;
    private float elapseTimeCounter;

    private tzzGodot.Animator animator;

    public abstract void showAction(float elapseTime,tzzGodot.Animator animator);

    public void setAnimator(tzzGodot.Animator animator){
        this.animator = animator;
    }

    public Action(float duration){
        this.duration = duration;
        this.elapseTimeCounter = 0;
    }
    private void clean(){
        this.elapseTimeCounter = 0;
    }

    public bool Do(float dt,RoleBase selfRole){//return weather the action over
        if (this.elapseTimeCounter==0){
            this.showAction(this.elapseTimeCounter,selfRole.getAnimator());
            this.elapseTimeCounter +=dt;
            return false;
        }else{
            this.elapseTimeCounter +=dt;
            if (this.duration < this.elapseTimeCounter){
                this.clean();
                return true;
            }
            this.showAction(this.elapseTimeCounter,selfRole.getAnimator());
            return false;
        }
    }
}

public class ComboMgr:GDScript
{
    private RoleBase selfRole;
    [Signal]
    public delegate void SigComboOver();
    private List<Action> actions;
    private int maxPendingAction;
    private int pendingAction;
    private int comboIndex;
    public ComboMgr(List<Action> actions,int maxPendingAction,RoleBase selfRole){
        this.maxPendingAction = (maxPendingAction<=0?1:maxPendingAction);
        this.actions = actions;
        this.pendingAction = 0;
        this.selfRole = selfRole;
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
            bool actionOver =  this.actions[this.comboIndex].Do(dt,this.selfRole);
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
