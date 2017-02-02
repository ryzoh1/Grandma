using UnityEngine;
using System.Collections;

public class AI_tribehead : MonoBehaviour {

	public Sprite s_left;
	public Sprite s_up;
	public Sprite s_right;
	public Sprite s_down;

	private int direction;
	private float timer;

	// Use this for initialization
	void Start () {
		direction = 3;
		StartCoroutine (AnimationTimer ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator AnimationTimer(){
		while (true) {
			timer = Random.value + 0.5f;

			yield return new WaitForSeconds(timer);

			if (direction == 3) {
				this.GetComponent<SpriteRenderer> ().sprite = s_left;
				direction = 0;
			} else if (direction == 0) {
				this.GetComponent<SpriteRenderer> ().sprite = s_up;
				direction = 1;
			} else if (direction == 1) {
				this.GetComponent<SpriteRenderer> ().sprite = s_right;
				direction = 2;
			} else if (direction == 2) {
				this.GetComponent<SpriteRenderer> ().sprite = s_down;
				direction = 3;
			}
		}
	}
}
