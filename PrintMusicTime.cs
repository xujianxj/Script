using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PrintMusicTime : MonoBehaviour {
	public AudioSource music;
	float minuteForTotalTime;
	float secondsForTotalTime;
	float minuteForNowTime;
	float secondsForNowTime;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		minuteForTotalTime = (int)(music.clip.length) / 60;
		secondsForTotalTime = (int)(music.clip.length) % 60;
		minuteForNowTime = (int)(music.time) / 60;
		secondsForNowTime = (int)(music.time) % 60;
		this.GetComponent<Text> ().text = intToString(minuteForNowTime) + ":" + intToString( secondsForNowTime )+ " / " + intToString( minuteForTotalTime )+ ":" + intToString( secondsForTotalTime);
	}

	string intToString(float intNumber){
		string stringNumber;
		if (intNumber < 10) {
			stringNumber = "0" + intNumber.ToString();
		} else {
			stringNumber=intNumber.ToString();
		}
		return stringNumber;
	}
}
