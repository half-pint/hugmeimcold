using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {

	private float fillAmount = 90;

	private Image content;

	private float maxValue;

	public float MaxValue{
		get{
			return maxValue;
		}

		set{
			this.maxValue = value;
		}
	}


	public float Value
	{
		set{
			fillAmount = Map(value, 0, maxValue, 0, 1);
			if(content == null){
				content = GameObject.Find("Content").GetComponent<Image>();
			}
			content.fillAmount = fillAmount;
		}
	}

	// Use this for initialization
	void Awake () {
		//we cant have a second stat cause this is a stupid line of code
		
		
	}
	
	// Update is called once per frame
	void Update () {

		SyncBar();
	}

	public void SyncBar(){
		/*Debug.Log(fillAmount);*/
/*		if(content.fillAmount != fillAmount){
			content.fillAmount = fillAmount;
		}*/
	}

	private float Map(float value, float inMin, float inMax, float outMin, float outMax){
		return outMin + (value - inMin)*(outMax - outMin)/(inMax-inMin);
	}
}
