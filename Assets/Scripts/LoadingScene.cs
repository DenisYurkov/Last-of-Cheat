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
public Image loadingSl;
public int random;
private string loading;
void Start()
{
	loading = "Loading";
	StartCoroutine(LoadingText());
	StartCoroutine(AsyncLoad());
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
IEnumerator LoadingText()
{
	yield return new WaitForSeconds(1f);
	loading = loading + ".";

	if (loading == "Loading....")
	{
		loading = "Loading";
		GameObject.Find("Text Loading").GetComponent<TextMeshProUGUI>().text = loading;
	}
	else { GameObject.Find("Text Loading").GetComponent<TextMeshProUGUI>().text = loading; }
	StartCoroutine(LoadingText());
}
IEnumerator AsyncLoad()
{
	AsyncOperation oper = SceneManager.LoadSceneAsync(2);
	while (!oper.isDone)
	{
			
			loadingSl.fillAmount = oper.progress;
			Debug.Log("hdtrhyh");
		yield return null;
	}
}
}
