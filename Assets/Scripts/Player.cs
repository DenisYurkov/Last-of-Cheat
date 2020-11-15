/*Denis Yurkov*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public Sprite GameOver, UWin;
    public GameObject ResWin;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
        healthBar.SetMaxHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth == 0)
        {
          
            AudioListener.Destroy(player.GetComponent<AudioListener>());
            GameObject.Find("Main Camera").GetComponent<Gun>().enabled = false;

            GameObject.Find("Help Canvas").SetActive(false);
            Cursor.lockState = CursorLockMode.Confined;

            ResWin.SetActive(true);
            GameObject.Find("ResIm").GetComponent<Image>().sprite = GameOver;
           
            GameObject.Find("Person").SetActive(false);
            Time.timeScale = 0;
        }
     /*   if ()
        {
            ResWin.SetActive(true);
            GameObject.Find("ResIm").GetComponent<Image>().sprite = UWin;
        }*/
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
