using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PrintVolume : MonoBehaviour {
	public Slider volumeSlide;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<Text>().text=(int)(volumeSlide.value*100)+"%";
	}
}
