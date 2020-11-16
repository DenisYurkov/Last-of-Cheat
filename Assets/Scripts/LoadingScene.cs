using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadingScene : MonoBehaviour

{
	public Sprite Screen1;
	public Sprite Screen2;
	public Sprite Screen3;
	public Image loadingBG;

	public int random;


	private void Start()
	{

		StartCoroutine(LoadAsyncOperation());
		random = Random.Range(1, 4);
		if (random == 1)
		{
			
	    		loadingBG.GetComponent<Image>().sprite = Screen1;
		}
		if (random == 2)
		{
			
				loadingBG.GetComponent<Image>().sprite = Screen3;
		}
		if (random == 3)
		{
			
				loadingBG.GetComponent<Image>().sprite = Screen2;
		}
	}

	IEnumerator LoadAsyncOperation()
	{
		yield return new WaitForSeconds(3.0f);
		yield return new WaitForEndOfFrame();
		SceneManager.LoadSceneAsync(1);
		yield return new WaitForEndOfFrame();
	}
}
