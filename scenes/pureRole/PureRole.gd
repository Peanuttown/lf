extends Pseudo3D


# Declare member variables here. Examples:
# var a = 2
# var b = "text"

#ref to child node stateMachine
var sm ;

# Called when the node enters the scene tree for the first time.
func _ready():
	self.sm = get_node("RoleState")

func attack():
	self.sm.cs_handle_input("attack",null)

func move():
	self.sm.cs_handle_input("move",null)

func jump():
	self.sm.cs_handle_input("jump",null)

# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
