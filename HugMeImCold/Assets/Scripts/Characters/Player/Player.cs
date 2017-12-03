﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMotor))]
public class Player : MonoBehaviour {

	public CharacterMotor motor;

	private InputManager inputManager;
	private AudioManager audioManager;

	private DIRECTION facing;

	Vector3 velocity;
	float moveSpeed = 6;
	float accelerationTime = .1f;
	float velocityXSmoothing;
	float velocityYSmoothing;

	void Awake()
	{
		this.inputManager = Object.FindObjectOfType<InputManager>();
		this.audioManager = Object.FindObjectOfType<AudioManager>();
	}

	// Use this for initialization
	void Start () 
	{
		this.motor = GetComponent<CharacterMotor>();

		this.facing = DIRECTION.SOUTH;
	}
	
	// Update is called once per frame
	void Update () 
	{
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
	}
}