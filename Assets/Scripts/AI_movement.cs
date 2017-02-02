using UnityEngine;
using System.Collections;

public class AI_movement : MonoBehaviour {

	private Vector3 Player;
	private Vector2 PlayerDirection;
	private float Xdif;
	private float Ydif;
	public float speed;
	public Animator anim;

	private int direction = 0;
	// 0: left
	// 1: up
	// 2: right
	// 3: down

	void Update () {
		Player = GameObject.Find ("Player").transform.position;

		Xdif = Player.x - transform.position.x;
		Ydif = Player.y - transform.position.y;

		PlayerDirection = new Vector2 (Xdif, Ydif);

		GetComponent<Rigidbody2D>().AddForce (PlayerDirection.normalized * speed);

		//change animation direction
		float angle = Vector2.Angle (PlayerDirection, Vector2.up);
		if (Xdif < 0)
		{
			angle *= -1;
		}
		angle = (angle + 180.0f) % 360.0f;

		if (angle > 45 && angle < 135) 
			anim.SetInteger("direction", 0);
		else if (angle > 135 && angle < 225) 
			anim.SetInteger("direction", 3);
		else if (angle > 225 && angle < 315) 
			anim.SetInteger("direction", 2);
		else if (angle < 45 || angle > 315) 
			anim.SetInteger("direction", 1);
	}
}
