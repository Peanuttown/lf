extends Node

class_name Action

#var action_duration=1
var action_interval=0
var action_time_acc:float=0
var frame_max_relative_index = 1

signal action_over
var sig_nm_action_over = "action_over"

func _init( action_interval:int, frame_max_relative_index:int):
	self.action_time_acc = 0
	self.action_interval = action_interval
	self.frame_max_relative_index = frame_max_relative_index

func play_frame(sprite:Sprite,frame_index_relative:int)->void:
	pass

func startAction(sprite:Sprite):
	print("start Action")
	self.play_frame(sprite,0)
	self.action_time_acc +=0.001

func first_action()->bool:
	return self.action_time_acc == 0

func clear_action():
	self.action_time_acc = 0

func action_over():
	self.clear_action()
	emit_signal("action_over")

func may_be_action_over()->void:
	if self.action_time_acc > self.action_interval * (self.frame_max_relative_index + 1):
		self.action_over()


func continueAction(sprite:Sprite,dt:float)->void:
	self.action_time_acc +=dt
	var frame_index_relative = self.action_time_acc / self.action_interval
	self.play_frame(sprite,min(frame_index_relative,self.frame_max_relative_index))
	self.may_be_action_over()

func action(sprite,dt:float):
	if first_action():
		self.startAction(sprite)
	else:
		self.continueAction(sprite,dt)


func connect_action_over(target,method)->void:
	self.connect(self.sig_nm_action_over,target,method)
