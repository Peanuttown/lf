extends Node2D


# Declare member variables here. Examples:
# var a = 2
# var b = "text"


# Called when the node enters the scene tree for the first time.
func _ready():
	var game = Game.new()
	print(game.my_name)
	print(game.test_name)

func do():
	print("parent do")



# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass