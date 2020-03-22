extends Node


# Declare member variables here. Examples:
# var a = 2
# var b = "text"

var state_stack:Array=[]
var states:Dictionary ={}

func is_empty():
	return state_stack.size() ==0


func register_state(sName:String,state:State)->void:
	self.states[sName] =state

# Called when the node enters the scene tree for the first time.
func change_state(sName:String,params)->void:
	var state:State = self.states[sName];
	if !self.is_empty():
		self.state_stack.pop_back().onExit()
	state.onEnter(params);
	self.state_stack.push_back(state)

func push_state(sName:String,params:Array)->void:
	var state:State = self.states[sName]
	state.onEnter(params)
	self.state_stack.push_back(state);


func _input(event):
	var state = self.state_stack.back()
	if state:
		state.proc_input(event)


func _process(delta):
	var state = self.state_stack.back()
	if state:
		state.update(delta)

func pop_state():
	self.state_stack.pop_back().onExit()






# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
