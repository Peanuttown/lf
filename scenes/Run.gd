extends State


# Declare member variables here. Examples:
# var a = 2
# var b = "text"

func onEnter(_params)->void:
	print("run enter")


func onExit()->void:
	print("run exit")

# Called when the node enters the scene tree for the first time.
func _ready():
	self.state_name = "run"

func custom_process(dt:float)->void:
	pass

func custom_physics_process(dt:float)->void:
	pass

func custom_unhandle_input(event:InputEvent)->void:
	if event.is_action_released("move"):
		self.state_over(null)



# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
