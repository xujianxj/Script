using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PrintMusicName : MonoBehaviour {
	public AudioSource music;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<Text>().text=music.clip.name;
	}
}
