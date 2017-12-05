using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMotor))]
public class Player : MonoBehaviour {

	public CharacterMotor motor;

	private InputManager inputManager;
	private AudioManager audioManager;

	private GameManager gameManager;

	private Stat warmth;

	public DIRECTION facing;

	public Vector3 velocity;
	float maxSpeed = 6;
	[SerializeField]
	public float moveSpeed = 6;
	float accelerationTime = .1f;
	float velocityXSmoothing;
	float velocityYSmoothing;

	bool hasTent = false;
	bool hasWood = false;

	public int sweaters = 0;


//	Animator anim;

	void Awake()
	{
		this.inputManager = Object.FindObjectOfType<InputManager>();
		this.audioManager = Object.FindObjectOfType<AudioManager>();
		this.gameManager = Object.FindObjectOfType<GameManager>();

//		this.anim = this.GetComponent<Animator> ();
	}

	// Use this for initialization
	void Start () 
	{

		
		warmth = new Stat ();

		warmth.OnValueChange += CheckIfAliveOrDead;
		//do smth
		warmth.MaxValue = 100;
		warmth.CurrentValue = 70;
		this.motor = GetComponent<CharacterMotor>();

		this.facing = DIRECTION.SOUTH;
	}
	
	void CheckIfAliveOrDead(float val){
//		Debug.Log(val);
		if(val <= 0){
			//tell game manager you are dead :( no lying
			gameManager.Lose();

		}else{
			//woop not dead yet
		}
	}

	// Update is called once per frame
	void Update () 
	{
		ReduceSpeed (sweaters);
		// Get input from input manager
		Vector2 input = new Vector2(this.inputManager.horizontal.GetInputRaw(), this.inputManager.vertical.GetInputRaw());

		// apply any input to player movement velocity with acceleration smoothing depending on whether airborne or grounded
		float targetVelocityX = input.x * this.moveSpeed;
		this.velocity.x = Mathf.SmoothDamp(this.velocity.x, targetVelocityX, ref this.velocityXSmoothing, this.accelerationTime);

		// apply gravity to player
		float targetVelocityY = input.y * moveSpeed;
		velocity.y = Mathf.SmoothDamp(this.velocity.y, targetVelocityY, ref this.velocityYSmoothing, this.accelerationTime);

		// call the move function for the character motor
		this.motor.Move(this.velocity * Time.deltaTime);

		GetDir ();
		Debug.Log (facing);
		DecreaseBodyTemperature();
//		DoAnimations ();
	}

	void DecreaseBodyTemperature(){
		warmth.decreaseStat();
	}

	public void GetItem(string item) {
		if (item == "tent")
			hasTent = true;
		else if (item == "wood")
			hasWood = true;
		else if (item == "sweater")
			sweaters++;
		else
			Debug.Log("I don't know what that item is");
	}

	public bool GetItemStatus() {
		if (hasTent && hasWood)
			return true;
		else
			return false;
	}

	void ReduceSpeed(int numOfSweaters) {
		moveSpeed = maxSpeed - numOfSweaters;
		if (moveSpeed < 0)
			moveSpeed = 0;
		else if (moveSpeed > maxSpeed)
			moveSpeed = maxSpeed;
	}
//
//	void DoAnimations() {
	//		anim.SetFloat("pSpeed",moveSpeed);
//	}

	void GetDir() {
		float xDir = Input.GetAxis("Horizontal");
		float yDir = Input.GetAxis("Vertical");

		if (xDir > 0)
			facing = DIRECTION.EAST;
		else if (xDir < 0)
			facing = DIRECTION.WEST;

		else if (yDir > 0)
			facing = DIRECTION.NORTH;
		else if (yDir < 0)
			facing = DIRECTION.SOUTH;
		else
			facing = facing;
	}


	public void IncreaseWarmth(float f) {
		this.warmth.CurrentValue += f;
	}
}
