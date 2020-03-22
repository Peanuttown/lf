extends Node2D


# Declare member variables here. Examples:
# var a = 2
# var b = "text"
class_name Child
signal child_signal
var method_name
var testFunc
# Called when the node enters the scene tree for the first time.
func _ready():
	pass

func do():
	print("child echo")

func emit():
	emit_signal("child_signal")

func child_method():
	print("child method call")

# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
