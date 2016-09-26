using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Start_Btn : MonoBehaviour {
	public AudioSource music;
	public AudioClip[] audioClipArray;
	int audioClipArray_index = 0;
	int lastMusicWay=0;
	public Slider volumeSlider;
	public Slider musicTimeSlider;
	bool MTSPointState=true;

	// Use this for initialization
	void Start () {
		music.clip = audioClipArray [audioClipArray_index];
	}

	public void Play_Btn_Click(){
		music.Play ();
		this.transform.FindChild ("Play_Btn").gameObject.SetActive (false);
		this.transform.FindChild ("Pause_Btn").gameObject.SetActive (true);
	}

	public void Pause_Btn_Click(){
		music.Pause ();
		this.transform.FindChild ("Play_Btn").gameObject.SetActive (true);
		this.transform.FindChild ("Pause_Btn").gameObject.SetActive (false);
	}

	public void NextBtn_Click(){
		Pause_Btn_Click ();
		music.time = 0;
		if (lastMusicWay == 0) {
			audioClipArray_index++;
		} else if (lastMusicWay == 1) {
			audioClipArray_index += Random.Range (1, audioClipArray.Length);
		} else if (lastMusicWay == 2) {
			
		}
		audioClipArray_index = audioClipArray_index % audioClipArray.Length;
		music.clip = audioClipArray [audioClipArray_index];
		Play_Btn_Click ();
	}

	public void LastBtn_Click(){
		Pause_Btn_Click ();
		music.time = 0;
		if (lastMusicWay == 0) {
			audioClipArray_index--;
		} else if (lastMusicWay == 1) {
			audioClipArray_index -= Random.Range (1, audioClipArray.Length);
		} else if (lastMusicWay == 2) {
			
		}
		if (audioClipArray_index < 0) {
			audioClipArray_index = audioClipArray.Length + audioClipArray_index;
		}
		audioClipArray_index = audioClipArray_index % audioClipArray.Length;
		music.clip = audioClipArray [audioClipArray_index];
		Play_Btn_Click ();
	}

	public void OneLoop_To_Loop(){
		lastMusicWay = 0;
		this.transform.FindChild ("MusicList_OneLoop").gameObject.SetActive (false);
		this.transform.FindChild ("MusicList_Loop").gameObject.SetActive (true);
	}

	public void Loop_To_Random(){
		lastMusicWay = 1;
		this.transform.FindChild ("MusicList_Loop").gameObject.SetActive (false);
		this.transform.FindChild ("MusicList_Random").gameObject.SetActive (true);
	}

	public void Random_To_OneLoop(){
		lastMusicWay = 2;
		this.transform.FindChild ("MusicList_Random").gameObject.SetActive (false);
		this.transform.FindChild ("MusicList_OneLoop").gameObject.SetActive (true);
	}

	// Update is called once per frame
	void Update () {
		music.volume = volumeSlider.value;
		if (MTSPointState) {
			mt_Change_mTSv();
		}
		if (music.time / music.clip.length > 0.998) {
			NextBtn_Click();
		}
	}

	//music.time change musicTimeSlider.value
	void mt_Change_mTSv(){
		musicTimeSlider.value = music.time / music.clip.length;
	}

	void mTSv_Change_mt(){
		music.time = music.clip.length * musicTimeSlider.value;
	}

	public void mTS_Down(){
		MTSPointState = false;
	}

	public void mTS_up(){
		mTSv_Change_mt ();
		MTSPointState = true;
	}
}
