using Godot;
using System;
using System.Collections.Generic;
using System.Diagnostics;

public abstract  class Action:Godot.GDScript{
    public string name ;
    private List<Action> subActions;
    private  int subActionIdx;
    private float duration;
    private float elapseTimeCounter;

    private tzzGodot.Animator animator;

    protected void showSubAction(float dt,float elapseTime,tzzGodot.Animator animator){
        //need sub action elasped time
        if (this.subActions[this.subActionIdx].Do(dt,animator)){
            this.subActionIdx = (this.subActionIdx + 1) % this.subActions.Count;
        }
    }

    public bool hasSubAction(){
        return (this.subActions != null) && (this.subActions.Count != 0);
    }

    public float getActionDuration(){
        if (!this.hasSubAction()){
            return this.duration;
        }
        float duration =0;
        this.subActions.ForEach(
            delegate (Action o){
                duration +=o.getActionDuration();
            }
        );
        return duration;
    }

    public abstract void showAction(float dt,float elapseTime,tzzGodot.Animator animator);

    public void setAnimator(tzzGodot.Animator animator){
        this.animator = animator;
    }
    public Action(){

    }

    public Action(float duration){
        this.duration = duration;
        this.elapseTimeCounter = 0;
    }

    public Action(List<Action> subActions){
        this.setActions(subActions);
    }

    public void setActions(List<Action> subActions){
        this.subActions =subActions;
        this.duration = this.getActionDuration();
    }

    private void clean(){
        this.elapseTimeCounter = 0;
    }

    public bool Do(float dt,tzzGodot.Animator animator){//return weather the action over
        if (this.elapseTimeCounter==0){
            this.showAction(dt,this.elapseTimeCounter,animator);
            this.elapseTimeCounter +=dt;
            //if (this.name == "debug"){
            //    Console.WriteLine("elapsed Time :"+this.elapseTimeCounter);
            //}
            return false;
        }else{
            this.elapseTimeCounter +=dt;
            //if (this.name == "debug"){
            //    Console.WriteLine("elapsed Time :"+this.elapseTimeCounter);
            //}
            if (this.duration < this.elapseTimeCounter){
                if (this.name == "debug")
                {
                    Console.WriteLine("action over");
                }
                this.clean();
                return true;
            }
            this.showAction(dt,this.elapseTimeCounter,animator);
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
        this.maxPendingAction = (maxPendingAction<=0?0:maxPendingAction);
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
            bool actionOver =  this.actions[this.comboIndex].Do(dt,this.selfRole.getAnimator());
            if (actionOver){
                this.pendingAction --;
                if (this.pendingAction==0){
                    System.Console.WriteLine("combo over");
                    this.combo_over();
                }else{
                    this.comboIndex = (this.comboIndex+1)%this.actions.Count;
                }
            }
        }
    }
}
