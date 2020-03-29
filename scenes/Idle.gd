extends State


# Declare member variables here. Examples:
# var a = 2
# var b = "text"


# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.

func onEnter(_params):
	print(owner)

func onExit():
	print("idle onExit")

func custom_process(_dt:float):
	pass

func custom_unhandle_input(event:InputEvent):
	if event.is_action_pressed("jump"):
		emit_signal("push_state","jump")
	if event.is_action_pressed("move"):
		self.emit_signal("push_state","move",null)

func custom_physics_process(_dt:float):
	pass


