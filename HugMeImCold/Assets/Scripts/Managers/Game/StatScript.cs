using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat{
	private BarScript bar;

	private float maxVal;

	private float currentVal;

	public float CurrentValue{
		get{
			return currentVal;
		}

		set{
			this.currentVal = value;
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
}
