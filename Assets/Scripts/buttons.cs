using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttons : MonoBehaviour
{
    
    public GameObject BgSet;
    
    public GameObject BgMenu;

    private bool music = true;
    private float music_scale, sound_scale;
    public Slider sliderMusic, sliderSound;
    public Sprite music_on, music_off; 
    public Sprite Sound_on, Sound_off;
    void Start()
    {
       
    }
    void Update()
    {
       if (BgSet.activeSelf == true) { 
        GameObject.Find("Main Camera").GetComponent<AudioSource>().volume = sliderMusic.value;
        GameObject.Find("Canvas").GetComponent<AudioSource>().volume = sliderSound.value;
        if (sliderMusic.value == 0)
        {
            GameObject.Find("Music").GetComponent<Image>().sprite = music_off;
        }
        else
        {

            GameObject.Find("Music").GetComponent<Image>().sprite = music_on;

        }
            if (sliderSound.value == 0)
            {
                GameObject.Find("Sound").GetComponent<Image>().sprite = Sound_off;
            }
            else
            {

                GameObject.Find("Sound").GetComponent<Image>().sprite = Sound_on;

            }

        }

    }
    public void OnMouseUpAsButton() {
         switch (gameObject.name)
         {
            case "Back":
                BgMenu.SetActive(true);
                BgSet.SetActive(false);
                break;
             case "Settings":
                BgMenu.SetActive(false);
                BgSet.SetActive(true);
                
                 break;
             case "Quit":
                Application.Quit();
                 
                     break;
            case "Music":
                if (music == true)
                {
                    GameObject.Find("Music").GetComponent<Image>().sprite = music_off;
                    music_scale = sliderMusic.value;
                    Debug.Log(music_scale);
                    sliderMusic.value = 0;
                    music = false;
                }
                else if (music == false)
                {
                    GameObject.Find("Music").GetComponent<Image>().sprite = music_on;
                    sliderMusic.value = music_scale;
                    music = true;
                }
                break;
            case "Sound":
                if (music == true)
                {
                    GameObject.Find("Sound").GetComponent<Image>().sprite = Sound_off;
                    sound_scale = sliderMusic.value;
                    Debug.Log(music_scale);
                    sliderSound.value = 0;
                    music = false;
                }
                else if (music == false)
                {
                    GameObject.Find("Sound").GetComponent<Image>().sprite = Sound_on;
                    sliderSound.value = sound_scale;
                    music = true;
                }
                break;
        }

    }

    
}
