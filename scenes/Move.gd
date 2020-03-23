extends "res://scripts/State.gd"


func onEnter(_params):
	print("move enter")
	pass

func onExit():
	print("move over")
	pass



# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.

func proc_input(event:InputEvent):

	var parent = self.get_parent()
	if event.is_action_released("ui_left"):
		parent.accelerate_left = false
	if event.is_action_released("ui_right"):
		parent.accelerate_right = false
	if event.is_action_released("ui_up"):
		parent.accelerate_up = false
	if event.is_action_released("ui_down"):
		parent.accelerate_down = false
	if Input.is_action_pressed("ui_left"):
		parent.accelerate_left = true
	if Input.is_action_pressed("ui_right"):
		parent.accelerate_right = true
	if event.is_action_pressed("ui_up"):
		parent.accelerate_up = true
	if event.is_action_pressed("ui_down"):
		parent.accelerate_down = true
# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass

func update(dt:float):
	#parent speed
	var speed = 100
	var parent = self.get_parent()
	var dir = Vector2()
	if parent.accelerate_left:
		dir.x -=1
	if parent.accelerate_right:
		dir.x +=1
	if parent.accelerate_up:
		dir.y -=1
	if parent.accelerate_down:
		dir.y +=1
	if dir.x ==0 && dir.y ==0:
		emit_signal("state_over")
	else:
		owner.position += dir *speed * dt

	
