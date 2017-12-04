using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class KeyBindDialog : MonoBehaviour {

	public GameObject keybindItemPrefab;
	public GameObject keybindList;

	private InputManager inputManager;

	string currentKeyToRebind = null;

	Dictionary<string, Text> keyToButtonText;

	// Use this for initialization
	void Start () {
		inputManager = GameObject.FindObjectOfType<InputManager>();

		string[] controlNames = inputManager.getControlKeyNames();

		keyToButtonText = new Dictionary<string, Text>();

		for(int i = 0; i < controlNames.Length; i++)
		{
			string name = controlNames[i];

			GameObject keybindItem = (GameObject)Instantiate(keybindItemPrefab);
			keybindItem.transform.SetParent(keybindList.transform);
			keybindItem.transform.localScale = Vector3.one;

			TextMeshProUGUI nameText = keybindItem.transform.Find("Title").GetComponent<TextMeshProUGUI>();
			nameText.text = name;

			Text keyNameText = keybindItem.transform.Find("Button/Text").GetComponent<Text>();
			keyNameText.text = inputManager.getKeyCodeString(name);
			
			keyToButtonText[name] = keyNameText;

			Button keybindButton = keybindItem.transform.Find("Button").GetComponent<Button>();
			keybindButton.onClick.AddListener( () => { StartRebindFor(name); });
		}
	}
	
	void StartRebindFor(string keyname)
	{
		currentKeyToRebind = keyname;
		Debug.Log("Rebinding " + keyname + " key now");
	}

	void Update()
	{
		if(currentKeyToRebind != null)
		{
			// Check to see whether it has been rebound yet
			if(Input.anyKeyDown)
			{
				KeyCode[] possibleKeys = (KeyCode[])Enum.GetValues(typeof(KeyCode));	

				foreach(KeyCode key in possibleKeys)
				{
					if(Input.GetKeyDown(key))
					{
						inputManager.setKeyCodeForKey(currentKeyToRebind, key);
						keyToButtonText[currentKeyToRebind].text = key.ToString();
						currentKeyToRebind = null;
						break;
					}
				}
			}
		}
	}
}
