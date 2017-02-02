using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	public float speed;

    void Start()
    {
    }

    void Update() {

        float h_move = 0;
        float v_move = 0;
        float diag_move = 1;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            v_move += 1;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            h_move -= 1;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            v_move -= 1;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            h_move += 1;
        }

        if (h_move != 0 && v_move != 0){
			diag_move = 0.7f;
		} else {
			diag_move = 1;
		}

		GetComponent<Rigidbody2D>().velocity =new Vector2(
			h_move * diag_move * speed, 
			v_move * diag_move * speed);
	}

	public void AddSpeed(int boost)
	{
		speed += boost;
	}
}
