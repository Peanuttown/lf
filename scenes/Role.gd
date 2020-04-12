extends Pseudo3D


# Declare member variables here. Examples:
# var a = 2
# var b = "text"


var face_direct_right =true
signal face_direct_change
var signal_face_direct_change="face_direct_change"

func handle_face_direct_change(event:InputEvent):
	var change = false
	if event.is_action_pressed("ui_right"):
		if !self.face_direct_right :
			change =true
	if event.is_action_pressed("ui_left"):
		if self.face_direct_right:
			change =true
	if change :
		self.face_direct_right = !self.face_direct_right
		self.get_node("Sprite").flip_h = !self.face_direct_right


func handle_input_common(event:InputEvent)->void:
	self.handle_face_direct_change(event)

func _unhandled_input(event):
	pass

func _ready():
	pass

func get_body_sprite()->Sprite:
	return self.get_node("Sprite") as Sprite

# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
