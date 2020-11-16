/*Denis Yurkov*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int health = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public Sprite GameOver, UWin;
    public GameObject ResWin;


    public GameObject player;


    void Start()
    {
        currentHealth = health;
        healthBar.SetMaxHealth(health);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            AudioListener.Destroy(player.GetComponent<AudioListener>());
            player.GetComponent<Gun>().enabled = false;
            GameObject.Find("Person").SetActive(false);

            ResWin.SetActive(true);
            GameObject.Find("Level").SetActive(false);

            GameObject.Find("ResIm").GetComponent<Image>().sprite = GameOver;
            Cursor.lockState = CursorLockMode.Confined;


        }
        if (GameObject.Find("Enem") == null)
        {
            AudioListener.Destroy(player.GetComponent<AudioListener>());
            player.GetComponent<Gun>().enabled = false;
            GameObject.Find("Person").SetActive(false);

            ResWin.SetActive(true);
            GameObject.Find("Level").SetActive(false);

            GameObject.Find("ResIm").GetComponent<Image>().sprite = UWin;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
