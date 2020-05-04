using System.Collections.Generic;
using System.Collections;
using System;

namespace StateMachine{
    public class FSM {
        private Dictionary<string,StateBase> States;
        private Stack<StateBase> state_stack;
        public FSM()
        {
            this.States = new Dictionary<string, StateBase>();
            this.state_stack = new Stack<StateBase>();
        }
        public void register_state(string name,StateBase state)
        {
            if (this.States.ContainsKey(name)){
                throw new Exception(String.Format("state repeated : [{0}]",name));
            }
            this.States.Add(name,state);
        }

        public void push_state(string name,dynamic args){
            StateBase state = this.States[name];
            if (state == null){
                throw new Exception(String.Format("state [{0}] undefined",name));
            }
            state.on_enter(args);
            this.state_stack.Push(state);
        }

        public void pop_state<T>(){
            if (this.state_stack.Count >0){
                this.state_stack.Pop();
            }
        }

        private bool stating(){
            return (this.state_stack.Count>0);
        }

        public StateBase cur_state(){
            if (this.stating()){
                return this.state_stack.Peek();
            }
            return null;
        }

        public string curStateName(){
            if (this.stating()){
                return this.state_stack.Peek().getStateName();
            }else{
                return  "";
            }
        }

        public void handle_action(string name,dynamic arg){
            StateBase curState = this.cur_state();
            if (curState!=null){
                curState.handle_action(name,arg);
            }
        }

        public void handle_physics_process(float dt){
            StateBase curState = this.cur_state();
            if (curState!=null){
                curState.handle_physics_process(dt);
            }
        }
    }
}