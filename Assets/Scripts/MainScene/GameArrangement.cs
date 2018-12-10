using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameArrangement : MonoBehaviour 
{
	#region Fields
	[SerializeField]
	private Text playText;
	[SerializeField]
	private GameObject buttons;
	[SerializeField]
	private GameObject allObjects;

	private bool isStartPlay;
	#endregion

	#region Unity lifecycle
	void start()
	{
		isStartPlay = false;
	}

	void OnMouseUp()
	{
		if (!isStartPlay)
		{
			isStartPlay = true;
			playText.gameObject.SetActive (false);
			buttons.gameObject.SetActive (false);
			allObjects.GetComponent<Animator> ().Play ("StartGame");
			StartCoroutine (WaitAnimation());
			this.GetComponent<Main> ().enabled = true;
		}
	}
	#endregion

	#region Private methods
	IEnumerator WaitAnimation()
	{
		yield return new WaitForSeconds(1.5f);
		allObjects.GetComponent<Animator> ().enabled = false;
		allObjects.transform.position = new Vector3 (-2.6f,1.25f,0f);
	}
	#endregion
}
