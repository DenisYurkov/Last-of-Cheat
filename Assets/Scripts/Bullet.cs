using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float timeBulletDie = 1f;
    public GameObject bullet;


    public void Update()
    {
        Destroy(bullet, timeBulletDie);
    }

    void OnTriggerEnter(Collider col)
    {
        
        if (col.gameObject.tag == "Player")
        {
            col.GetComponent<Player>().TakeDamage(5);
            Destroy(this.gameObject);
        }
    }

}
