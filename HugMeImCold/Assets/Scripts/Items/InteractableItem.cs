using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : MonoBehaviour, IInteractable {

	// instance of input manager
	protected InputManager inputManager;

	// instance of player object
	protected GameObject playerInstance;

	// Instance of text canvas
	//public GameObject canvas;

	// Range around the item in which the player can interact with the item
	protected float range = 0.7f;

	// boolean that keeps info on whether player currently is in range
	protected bool playerInRange = false;

	// Use this for initialization
	protected virtual void Start () {
		this.playerInstance = GameObject.FindGameObjectWithTag("Player");
		inputManager = Object.FindObjectOfType<InputManager>();
		//this.canvas.SetActive(false);
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		if(this.playerInstance == null) {
			this.playerInstance = GameObject.FindGameObjectWithTag("Player");
		}

		if(Vector3.Distance(this.transform.position, this.playerInstance.transform.position) < this.range) {
			// Check if player was already in range or not
			if(!playerInRange) {
				// If player wasnt, then we call the range entered function
				this.RangeEntered();
			}
		} else {
			// Check if player was already in range or not
			if(playerInRange) {
				// If the player was in range, but is now not, then we call the range exited function
				this.RangeExited();
			}
		}

		if(playerInRange) {
			if(inputManager.GetKeyDown("Interact")) {
				this.Interact();
			}
		}
	}

	// Function for what to do when object is interacted with
	public virtual void Interact() {
		print(this.transform.name + " INTERACTED UPON!");
		Destroy(gameObject);
	}

	// Function for when interactable range around object is entered
	public virtual void RangeEntered() {
		this.playerInRange = true;
		print(this.transform.name + " RANGE ENTERED!");
		//this.canvas.SetActive(true);
	}

	// Function for when interactable range around object is exited
	public virtual void RangeExited() {
		this.playerInRange = false;
		print(this.transform.name + " RANGE EXITED!");
		//this.canvas.SetActive(false);
	}
}
