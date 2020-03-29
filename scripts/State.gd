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

func state_over(params):
	self.emit_signal(signal_state_over,self.state_name,params)

func push_state(state:String,_params):
	self.emit_signal(signal_push_state,state,_params)

func get_input_direction()->Array:
	var move = false
	var direction = Vector2()
	if Input.is_action_pressed("ui_left"):
		move = true
		direction
		speed.x -= 100
	if Input.is_action_pressed("ui_right"):
		move = true
		speed.x += 100
	if Input.is_action_pressed("ui_up"):
		move = true
		speed.y -= 100
	if Input.is_action_pressed("ui_down"):
		move = true
		speed.y += 100





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
