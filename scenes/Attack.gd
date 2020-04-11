extends RoleStateBase


# Declare member variables here. Examples:
# var a = 2
# var b = "text"

var attack_count =0
var actioning = false
var comboCount =0
var comboDuration = 0
var comboA=0
var comboB=1
var comboFrameIndex =0

func _ready():
	self.state_name = "attack"

func onEnter(params):
	self.attack_count +=1

func onExit():
	self.attack_count =0
	print("attack exit")
	pass

func custom_physics_process(dt:float)->void:
	self.attack(dt)

func custom_process(dt:float)->void:
	pass

func custom_unhandle_input(event:InputEvent)->void:
	pass

func play_atk_animation(frame:int):
	owner.get_body_sprite().frame=frame


func combo(dt)->void:
	self.actioning = true
	if self.comboCount == self.comboA:
		self.comboDuration +=dt
		var interval = 0.5
		var intervalIndex  = int(self.comboDuration / interval)
		self.comboFrameIndex = intervalIndex % 2
		self.play_atk_animation(10+self.comboFrameIndex)


func attack(dt:float)->void:
	if self.actioning:
		self.combo(dt)
		return
	if self.attack_count >0 :
		self.combo(0)
		self.attack_count -=1
		return
	self.state_over(null)



# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
