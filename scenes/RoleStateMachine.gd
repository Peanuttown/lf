#extends "res://scripts/StateMachine.gd"
extends StateMachine


# Declare member variables here. Examples:
# var a = 2
# var b = "text"

var accelerate_left=false
var accelerate_right=false
var accelerate_up=false
var accelerate_down=false


# Called when the node enters the scene tree for the first time.
func _ready():
	#register childState
	var idle = self.get_node("Idle")
	var move = self.get_node("Move")
	var jump = self.get_node("Jump")
	print(idle,move,jump)
	self.states["idle"] =idle
	self.states["move"] =move
	self.states["jump"] =jump
	var sm = (self as StateMachine)
	self.connectChildSignal(sm.signal_push_state,sm.method_push_state)
	self.connectChildSignal(sm.signal_state_over,sm.method_pop_state)
	#chose one state
	self.push_state("idle",null)


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
