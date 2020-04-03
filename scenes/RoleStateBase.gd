extends State

class_name RoleStateBase
# Declare member variables here. Examples:
# var a = 2
# var b = "text"


# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.

func set_sprite_frame(frame:int):
	self.get_sprite().frame = frame

func get_sprite()->Sprite:
	return owner.get_node("Sprite") as Sprite

# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
