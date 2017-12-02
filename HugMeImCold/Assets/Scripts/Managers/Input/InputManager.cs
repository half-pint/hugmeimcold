using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

	// The control scheme dictionary
	Dictionary<string, KeyCode> controls;

	// The default axis of movement input
	public InputAxis horizontal;
	public InputAxis vertical;

	// Initialization
	void Start () 
	{
		this.initializeControls();
	}

	private void initializeControls() 
	{
		// Attempt to load from saved preferences file
		this.controls = this.loadControlLayout();

		// If we return with an empty control layout, then we add instead the default values
		if(this.controls.Count == 0) 
		{
			// TODO: Set default controls

		}

		// TODO: Initialize movement input axis
	}

	public bool GetKey(string key) 
	{
		// Check if the key exists
		if(this.controls.ContainsKey(key)) 
		{
			// Then we do have the key in the control layout
			return Input.GetKey(this.controls[key]);
		}

		// We do not have the key registered in our layout
		return false;
	}


	public bool GetKeyDown(string key) 
	{
		// Check if the key exists
		if(this.controls.ContainsKey(key)) 
		{
			// Then we do have the key in the control layout
			return Input.GetKeyDown(this.controls[key]);
		}

		// We do not have the key registered in our layout
		return false;
	}

	private Dictionary<string, KeyCode> loadControlLayout() 
	{
		// Check if player has key layout already saved
		// TODO: Load key layout from file

		// We did not return before this point, so we should just initialise an empty Dictionary as there was no previous saved layout
		return new Dictionary<string, KeyCode>();
	} 

	private void saveKeyLayout() 
	{
		// TODO: Implement
		return;
	}
	
}
