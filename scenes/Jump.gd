extends State


# Declare member variables here. Examples:
# var a = 2
# var b = "text"
export var gravity =1600
# Called when the node enters the scene tree for the first time.
func _ready():
	self.state_name = "jump"


func onEnter(_params):
	owner.speed_vertical=600

func onExit():
	pass

func custom_process(dt:float)->void:
	pass

func custom_physics_process(dt:float)->void:

	owner.speed_vertical -= dt * gravity
	owner.update_pos(dt)
	if owner.on_ground():
		self.state_over(null)


func custom_unhandle_input(event:InputEvent):
	pass
