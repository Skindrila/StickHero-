using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour 
{
	#region Fields
	[SerializeField]
	private Sprite mus_on, mus_off;

	private GameObject screen;
	private  AudioSource audioClickButton;
	#endregion

	#region Unity lifecycle
	void Start()
	{
		audioClickButton = GameObject.Find ("clickButton").GetComponent<AudioSource> ();
		if (gameObject.name == "Music") 
		{
			if(PlayerPrefs.GetString ("Music") == "Off")
			{
				GetComponent<Image> ().sprite = mus_off;
				Camera.main.GetComponent<AudioListener> ().enabled = false;
			}
		}
	}

	void OnMouseDown ()
	{
		transform.localScale = new Vector3 (1.1f, 1.1f, 1.1f);
	}

	void OnMouseUp ()
	{
		transform.localScale = new Vector3 (1f, 1f, 1f);
	}

	void OnMouseUpAsButton()
	{
		audioClickButton.Play ();
		switch (gameObject.name) 
		{
		case "Home":
			SceneManager.LoadScene ("main");
			break;
		case "Restart":
			screen = GameObject.FindGameObjectWithTag ("DetectClicks");
			screen.GetComponent<Main> ().Restart ();
			break;
		case "Music":
			if (PlayerPrefs.GetString ("Music") == "Off")
			{
				GetComponent<Image> ().sprite = mus_on;
				PlayerPrefs.SetString ("Music", "On");
				Camera.main.GetComponent<AudioListener> ().enabled = true;
			} 
			else
			{
				Camera.main.GetComponent<AudioListener> ().enabled = false;
				GetComponent<Image> ().sprite = mus_off;
				PlayerPrefs.SetString ("Music", "Off");
			}
			break;
		}
	}
	#endregion
}
