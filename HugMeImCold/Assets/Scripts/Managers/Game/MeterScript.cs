using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterScript : MonoBehaviour
{
    float status;
    public float decrease = 0.01f;
    public float coldness = 100f;

    public float Status { get { return status; } }

	// Use this for initialization
	void Start () {
        status = 1000f;
	}
	
	// Update is called once per frame
	void Update () {
        status -= decrease + coldness * 0.01f;
        Debug.Log(status);
	}

}
