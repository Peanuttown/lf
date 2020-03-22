extends "res://scripts/StateMachine.gd"


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
	self.register_state("idle",($Idle as State))
	self.register_state("move",($Move as State))
	self.register_state("jump",($Jump as State))
	#chose one state
	self.change_state("idle",null)


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
