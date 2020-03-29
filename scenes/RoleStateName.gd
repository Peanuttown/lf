extends Label


# Declare member variables here. Examples:
# var a = 2
# var b = "text"

var states = []

# Called when the node enters the scene tree for the first time.
func _ready():
	var sm : StateMachine= $"../../StateMachine"
	var states = sm.get_all_state()
	print("here")
	for stateKey in states:
		var state : State= states[stateKey]
		assert(state)
		state.connect(sm.signal_push_state,self,"push_state")
		state.connect(sm.signal_state_over,self,"pop_state")
	self.push_state(sm.state_stack[0].state_name,null)


func pop_state(name:String,_params):
	self.states.pop_back()
	self.change_text(self.states.back())

func push_state(name:String,_params):
	self.states.push_back(name)
	self.change_text(name)

func change_text(name:String)->void:
	self.text = name

func _physics_process(delta:float):
	#self.rect_position =owner.position + self.rect_position 
	pass

# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
