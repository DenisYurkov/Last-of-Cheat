using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resultOfGame : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite GameOver, UWin;
    public GameObject ResWin;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B)) {
           Debug.Log("hgfhfhgfhf");
            GameOverFuction();
            
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            ResWin.SetActive(true);
            GameObject.Find("ResIm").GetComponent<Image>().sprite = UWin;
        }
    }
   void GameOverFuction() {
        
        ResWin.SetActive(true);
        GameObject.Find("GameOverBG").GetComponent<Image>().sprite = GameOver;
    }

}
