using UnityEngine;
using System.Collections;

public enum SoundTrigger {None = 0, OnStart, OnContact, OnDestroy, OnDistance, OnNear};

[RequireComponent (typeof(AudioSource))]
public class SoundObject : MonoBehaviour {

	//Audio source reference
	private AudioSource source;

	//Audio variables
	public AudioClip sound;
	[Range(0f,1f)]
	public float volume = 1;

	//Sound trigger
	public SoundTrigger soundTrigger = SoundTrigger.None;

	//Trigger bools
	private bool onStart = false;
	private bool onContact = false;
	private bool onDestroy = false;
	private bool onDistance = false;
	private bool onNear = false;

	//Distance Reference (Only play when we close to distRef)
	public GameObject distanceReference; //Gameoject to look for
	public static GameObject playerRef; //Default player reference
	public float distanceTrigger; //Distance till we trigger

	void Start () {

		if (!distanceReference && soundTrigger == SoundTrigger.OnDistance) {
			
			if (!playerRef) {
				playerRef = GameObject.FindWithTag ("Player");
			}

			distanceReference = playerRef;

			if (!distanceReference) {
				Debug.Log ("No distance reference on :" + gameObject.name + " , and no player tagged in scene");
			}
		} 

		if (!sound) {

			//Destroy audio object if no audio was set
			Debug.Log ("No audio clip on :" + gameObject.name + " , audio object disabled");
			transform.GetComponent <SoundObject>().enabled = false;
		}

		//Get our audio source
		source = this.gameObject.transform.GetComponent<AudioSource>();

		//Adjust audio source
		source.maxDistance = distanceTrigger;
		source.rolloffMode = AudioRolloffMode.Linear;

		//Set trigger bools, depending on trigger type enum
		switch ((int)soundTrigger) {

			case 0:
				//None
				break;
			case 1:
				onStart = true;
				break;
			case 2:
				onContact = true;
				break;
			case 3: 
				onDestroy = true;
				break;
			case 4:
				onDistance = true;
				break;
			case 5:
				onNear = true;
				break;
		}

		if (onStart) {

			PlayAudio ();
		}
	}

	void Update () {
		
		if (onDistance || onNear) {

			float dist = Vector2.Distance (this.gameObject.transform.position, distanceReference.gameObject.transform.position);

			if (dist < distanceTrigger) {

				if (onDistance) {
					volume = (distanceTrigger / 100) * (distanceTrigger - dist);
					source.volume = volume; //TEMP
					PlayAudio ();
				} else {
					source.volume = 1;
					PlayAudio ();
				}


			}
		}
	}

	void PlayAudio () {

		if (!source.isPlaying) {

			//source.PlayOneShot (sound, volume);
			source.PlayOneShot (sound);
		}
	}

	void OnTriggerEnter (Collider col) {

		if (onContact && col.gameObject.tag == "Player") {

			PlayAudio ();
		}
	}

	void OnDestroy () {

		if (onDestroy) {

			PlayAudio ();
		}
	}
}
