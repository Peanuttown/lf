extends Node

class_name State

# Declare member variables here. Examples:
# var a = 2
# var b = "text"

signal push_state
signal state_over

var signal_push_state="push_state"
var signal_state_over = "state_over"

var state_name;


# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.

func onEnter(_params:Array)->void:
	pass

func onExit()->void:
	pass



# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
