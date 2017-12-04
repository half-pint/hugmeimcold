using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	bool hasTarget = false;

	Transform target;

	// Use this for initialization
//	void OnEnable () {
//		
//	}
	
	// Update is called once per frame
	void Update () {
		if (hasTarget == false) {
			try{
				target = GameObject.FindObjectOfType<Player> ().transform;
				hasTarget = true;
			} catch (MissingReferenceException e) {
				return;
			}
		}
		if (target == null) {
			hasTarget = false;
		}
		if (hasTarget == true)
			this.transform.position = new Vector3(target.transform.position.x,target.transform.position.y,-10) ;

	}
}
