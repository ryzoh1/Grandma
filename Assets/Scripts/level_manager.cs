using UnityEngine;
using System.Collections;

public class level_manager : MonoBehaviour {

	public static level_manager _L;
	private int[] keys;

	void Start () {
		if (_L != null && !_L) {
			Destroy (gameObject);
		}

		_L = this;

		DontDestroyOnLoad (gameObject);

		keys = new int[5];
	}

	void Update () {

		/*if(Input.GetKey(KeyCode.Space)) {
			int i = Application.loadedLevel;
			if (i == 2) i = -1;
			Application.LoadLevel(i + 1);
		}*/
	}

	public void AddKey(int key_n)
	{
		keys[key_n] = 1;

		if (Mathf.Min(keys) == 1) {
			Debug.Log ("got the eggs!");
			int i = Application.loadedLevel;
			if (i == 2) i = -1;
			Application.LoadLevel(i + 1);
		}
	}

}
