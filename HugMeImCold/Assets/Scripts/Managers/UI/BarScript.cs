using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {

	private float fillAmount = 100;

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
		}
	}

	// Use this for initialization
	void Start () {

		content = GameObject.Find("Content").GetComponent<Image>();
		
	}
	
	// Update is called once per frame
	void Update () {
		SyncBar();
	}

	public void SyncBar(){
		Debug.Log(fillAmount);
		Debug.Log(content.fillAmount);
		if(content.fillAmount != fillAmount){
			content.fillAmount = fillAmount;
		}
	}

	private float Map(float value, float inMin, float inMax, float outMin, float outMax){
		return outMin + (value - inMin)*(outMax - outMin)/(inMax-inMin);
	}
}
