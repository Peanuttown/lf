extends Node

class_name StateMachine
# Declare member variables here. Examples:
# var a = 2
# var b = "text"

var state_stack:Array=[]
var states:Dictionary ={}

var signal_push_state = "push_state"
var signal_state_over = "state_over"
var method_push_state = "push_state"
var method_change_state = "change_state"
var method_pop_state = "pop_state"

func get_current_state():
	return self.state_stack.back().state_name

func is_empty():
	return state_stack.size() ==0

func connectChildSignal(sigName:String,method)->void:
	for state in states:
		self.states[state].connect(sigName,self,method)


func get_all_state()->Dictionary:
	return self.states

# Called when the node enters the scene tree for the first time.
func change_state(sName:String,params)->void:
	var state:State = self.states[sName];
	if !self.is_empty():
		self.state_stack.pop_back().onExit()
	state.onEnter(params);
	self.state_stack.push_back(state)

func push_state(sName:String,params)->void:
	var state:State = self.states[sName]
	state.onEnter(params)
	self.state_stack.push_back(state);

func _unhandled_input(event):
	var state = self.state_stack.back()
	if state:
		state.custom_unhandle_input(event)



func _process(delta):
	var state = self.state_stack.back()
	if state:
		state.custom_process(delta)

func _physics_process(delta):
	var state = self.state_stack.back()
	if state:
		state.custom_physics_process(delta)

func pop_state(_state:String,_params):
	self.state_stack.pop_back().onExit()
	self.state_stack.back().onStateResume()






# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
