using UnityEngine;
using System.Collections;

//Adjusts depth of characters for rendering
public class Depth : MonoBehaviour {

	public float offset;
	private float Xposition;
	private float Yposition;

	void Update () {

		Xposition = transform.position.x;
		Yposition = transform.position.y;
		transform.position = new Vector3 (Xposition, Yposition, Yposition + offset);

	}
}
