using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat{
	private BarScript bar = new BarScript() ;

	private float maxVal;

	private float currentVal;

	public float decrease = 0.01f;

	public delegate void ValueChangeCb(float val);

	public event ValueChangeCb OnValueChange;

	public float CurrentValue{
		get{
			return currentVal;
		}

		set{
			this.currentVal = value;
			if(OnValueChange != null){
				OnValueChange(value);
			}

			bar.Value = currentVal;

		}
	}

	public float MaxValue{
		get{
			return maxVal;
		}

		set{
			this.maxVal = value;
			bar.MaxValue = maxVal;
		}
	}

	public void decreaseStat(){
		this.CurrentValue = this.CurrentValue - decrease;
		//this.currentVal -= decrease;
		//bar.Value = currentVal;

	}
}
