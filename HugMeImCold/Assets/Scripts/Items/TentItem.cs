using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentItem : InteractableItem {

	// Use this for initialization
	protected override void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();
	}

	public override void Interact() {
		print(this.transform.name + " INTERACTED UPON!");

		// Call function on player to set bool hasTent to true
		Player instance = this.playerInstance.GetComponent<Player>();
		instance.GetItem("tent");

		// Destroy the game object in the scene so as to simulate the item having been picked up
		Destroy(gameObject);
	}
}
