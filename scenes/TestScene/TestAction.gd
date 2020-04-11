extends Action


# Declare member variables here. Examples:
# var a = 2
# var b = "text"

func play_frame(relative_index:int)->void:
	print("ok")

# Called when the node enters the scene tree for the first time.
func _ready():
	self.startAction()


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
