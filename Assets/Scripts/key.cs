using UnityEngine;
using System.Collections;

public class key : MonoBehaviour {

	public int key_n = 0;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {

			level_manager._L.AddKey(key_n);
			Destroy (this.gameObject);
		}
	}
}
