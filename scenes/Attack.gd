extends RoleStateBase


# Declare member variables here. Examples:
# var a = 2
# var b = "text"

func _ready():
	self.state_name = "attack"

func onEnter(params):
	print("attack enter")
	self.attack()
	print("attack go on")

func onExit():
	print("attack exit")
	pass

func custom_physics_process(dt:float)->void:
	pass

func custom_process(dt:float)->void:
	pass

func custom_unhandle_input(event:InputEvent)->void:
	pass

func attack():
	yield(self.get_tree().create_timer(1.0),"timeout")
	self.state_over(null)



# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
