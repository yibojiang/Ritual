using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	private static AudioManager instance ;
	public static  AudioManager Instance(){
		if (instance == null)
			instance =GameObject.FindObjectOfType<AudioManager>();
		return instance;
	}

	public AudioClip buttonClip;
	public AudioClip colorChangeClip;

	public AudioSource audio;

	public void PlaySound(AudioClip _clip){
		audio.PlayOneShot(_clip);
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
