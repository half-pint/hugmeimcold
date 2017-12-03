using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampingSpot : InteractableItem {

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
		bool hasVictoryCondition = instance.GetItemStatus();

		if(hasVictoryCondition)
		{
			// TODO: Beat the level
			// For now we just quit the game
			#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
			#else
				Application.Quit();
			#endif

			// Destroy the game object in the scene so as to simulate the item having been picked up
			Destroy(gameObject);
		}
		else
		{
			Debug.Log("Player does not have victory condition");
		}
	}
}