extends Node

class_name Combo

var actions = []

signal combo_over
var sig_nm_combo_over ="combo_over"
var sig_combo_over_switch=false

func register_actions(actions)->void:
	for action in actions:
		assert(self.has_method("handle_action_over"))
		(action as Action).connect_action_over(self,"handle_action_over")

func handle_action_over()->void:
	self.actions.pop_front()

func push_action(action:Action)->void:
	if !self.has_action():
		self.sig_combo_over_switch = false
	self.actions.push_back(action)
	(action as Action).connect_action_over(self,"handle_action_over")

func has_action()->bool:
	return self.actions.size()>0

func combo_end()->void:
	if !self.sig_combo_over_switch:
		self.sig_combo_over_switch = !self.sig_combo_over_switch
		emit_signal(sig_nm_combo_over)

func action(sprite,dt):
	if !self.has_action():
		self.combo_end()
		return
	self.actions.front().action(sprite,dt)

func connect_combo_over(target,method)->void:
	assert(target.has_method(method))
	self.connect(sig_nm_combo_over,target,method)

# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
