using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

	public Sprite none_left_stand;
	public Sprite none_right_stand;
	public Sprite none_up_stand;
	public Sprite none_down_stand;

	public Sprite one_left_stand;
	public Sprite one_right_stand;
	public Sprite one_up_stand;
	public Sprite one_down_stand;

	public Sprite two_left_stand;
	public Sprite two_right_stand;
	public Sprite two_up_stand;
	public Sprite two_down_stand;

	public Sprite three_left_stand;
	public Sprite three_right_stand;
	public Sprite three_up_stand;
	public Sprite three_down_stand;

	public Sprite four_left_stand;
	public Sprite four_right_stand;
	public Sprite four_up_stand;
	public Sprite four_down_stand;


	Player player;

	int direction;
	float speed;
	int sweaters;

	SpriteRenderer sr;

	Animation2DManager anim;

	string oldBool;
	string oldName;

	void Awake(){
		if (this.GetComponent<Animation2DManager> ())
			this.anim = this.GetComponent<Animation2DManager> ();
		else
			this.anim = this.gameObject.AddComponent<Animation2DManager> ();
	}
	// Use this for initialization
	void Start () {
		player = GetComponent<Player> ();
		sr = GetComponent<SpriteRenderer> ();


		ChangeSprite(FindStandingSprite ());
	}
	
	// Update is called once per frame
	void Update () {
		direction = (int)player.facing;
//		Debug.Log ("Direction is " + direction);
//		speed = player.moveSpeed;
		sweaters = player.sweaters;

		speed = Mathf.Abs(Input.GetAxis("Horizontal") + Input.GetAxis("Vertical"));

//		if (speed < 0.1) {
////			anim.Stop ();
////			anim.enabled = false;
////			anim.SetBool(oldBool,false);
			Sprite s = FindStandingSprite();
			ChangeSprite (s);
//		} 
//		else {
//			anim.enabled = true;
//			PlayAnimation (FindAnimation());
//		}
//		Debug.Log (speed);
//		Debug.Log(anim.IsPlaying("0_d_w"));
	}

	string FindAnimation() {
		string returnAnim = "0_d_w";
		if (sweaters == 0) {
			switch (direction) {
			case 0:
				returnAnim = "0_u_wa";
				break;

			case 1:
				returnAnim = "0_d_w";
				break;

			case 2:
				returnAnim = "0_r_w";
				break;

			case 3:
				returnAnim = "0_l_w";
				break;
			}

		}
		else if (sweaters == 1) {
			switch (direction) {
			case 0:
				returnAnim = "1_u_w";
				break;

			case 1:
				returnAnim = "1_d_w";
				break;

			case 2:
				returnAnim = "1_r_w";
				break;

			case 3:
				returnAnim = "1_l_w";
				break;
			}
		}
		else if (sweaters == 2) {
			switch (direction) {
			case 0:
				returnAnim = "2_u_w";
				break;

			case 1:
				returnAnim = "2_d_w";
				break;

			case 2:
				returnAnim = "2_r_w";
				break;

			case 3:
				returnAnim = "2_l_w";
				break;
			}
		}
		else if (sweaters == 3) {
			switch (direction) {
			case 0:
				returnAnim = "3_u_w";
				break;

			case 1:
				returnAnim = "3_d_w";
				break;

			case 2:
				returnAnim = "3_r_w";
				break;

			case 3:
				returnAnim = "3_l_w";
				break;
			}
		}
		else if (sweaters >= 4) {
			switch (direction) {
			case 0:
				returnAnim = "4_u_w";
				break;

			case 1:
				returnAnim = "4_d_w";
				break;

			case 2:
				returnAnim = "4_r_w";
				break;

			case 3:
				returnAnim = "4_l_w";
				break;
			}
		} 
		else returnAnim = "0_d_w";
		Debug.Log (returnAnim);
		return returnAnim;
	}

	Sprite FindStandingSprite() {

		Sprite returnSpr = none_down_stand;
		if (sweaters == 0) {
			if (direction == 0) {
//				Debug.Log ("goingupstanding");
				returnSpr = none_up_stand;
//				break;
			}
			if (direction == 1) {
				returnSpr = none_down_stand;
//				break;
			}
			if (direction == 2) {
				returnSpr = none_right_stand;
//				break;
			}
			if (direction == 3) {
				returnSpr = none_left_stand;
//				break;
			}
		} else if (sweaters == 1) {
//			Debug.Log ("onesweaterstanding");
			if (direction == 0) {
				Debug.Log ("onesweaterupstanding");
				returnSpr = one_up_stand;
//				break;
			}
			if (direction == 1) {
				returnSpr = one_down_stand;
//				break;
			}
			if (direction == 2) {
				returnSpr = one_right_stand;
//				break;
			}
			if (direction == 3) {
				returnSpr = one_left_stand;
//				break;
			}
		} else if (sweaters == 2) {
			switch (direction) {
			case 0:
				returnSpr = two_up_stand;
				break;

			case 1:
				returnSpr = two_down_stand;
				break;

			case 2:
				returnSpr = two_right_stand;
				break;

			case 3:
				returnSpr = two_left_stand;
				break;
			}
		} else if (sweaters == 3) {
			switch (direction) {
			case 0:
				returnSpr = three_up_stand;
				break;

			case 1:
				returnSpr = three_down_stand;
				break;

			case 2:
				returnSpr = three_right_stand;
				break;

			case 3:
				returnSpr = three_left_stand;
				break;
			}
		} else if (sweaters >= 4) {
			switch (direction) {
			case 0:
				returnSpr = four_up_stand;
				break;

			case 1:
				returnSpr = four_down_stand;
				break;

			case 2:
				returnSpr = four_right_stand;
				break;

			case 3:
				returnSpr = four_left_stand;
				break;
			}
			return returnSpr;
		} else {
//			Debug.Log ("I went to else");
			returnSpr = none_down_stand;
		}
		return returnSpr;
		
	}

	void ChangeSprite(Sprite s){
//		Sprite spr = (Sprite)Resources.Load ("Assets/Sprites/Player/" + ((s.name.EndsWith ("s")) ? "hugmeimcold_playersprites" : "player_base")); //s.rect;

		sr.sprite = s;
//		sr.sprite.name = s.name;
//		Debug.Log(sr.sprite.name);
//		Debug.Log (s.name);
	}

	void PlayAnimation(string name) {
		if (anim.isPlaying (name)) {
			Debug.Log ("I'm playing that already");
			return;
		}
		anim.Pause (oldName);
//		if (name.StartsWith("0")){
		anim.Play (name, true, true, true,true,0.3f);
		oldName = name;
//		}

//		if (!anim.GetCurrentAnimatorStateInfo(0).IsName(name))
//			anim.Play (name);
//		Debug.Log (anim.IsPlaying(name));
//		anim.
//		anim.clip = name;
	}

}
