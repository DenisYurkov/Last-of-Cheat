﻿/*Denis Yurkov*/
using UnityEngine;

// Скрипт для оружия. 
public class Gun : MonoBehaviour
{
    [Header("Gun")]
    [SerializeField] float damage = 10f;
    [SerializeField] float range = 100f;

    [Header("Camera")]
    [SerializeField] Camera fpsCam;

    [Header("Particle")]
    [SerializeField] ParticleSystem shotEffect;
    [SerializeField] ParticleSystem explosionAndDieEffect;
    [SerializeField] public float timeParticleDie = 1f;

    [Header("Audio")]
    [SerializeField] AudioSource audioShot;
    [SerializeField] AudioSource barrelExplosion;

    [Header("UI")]
    [SerializeField] GameObject DarkBG;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // Запускает эффект выстрела и звук выстрела.
        
        if (DarkBG.activeSelf == true)
        { 

            shotEffect.Stop();
            audioShot.Stop();
        
        }
        else {
            shotEffect.Play();
            audioShot.Play();
            // Структура, используемая для получения информации из рейкаста.
            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                //Debug.Log(hit.transform.name);
                Target target = hit.transform.GetComponent<Target>();

                // Если target не равен пустому объекту, то отнимать у объекты HP.
                if (target != null)
                {
                    target.TakeDamage(damage);
                }

                if (hit.transform.gameObject.tag == "barrel roll" || hit.transform.gameObject.tag == "die effect")
                {
                    Instantiate(explosionAndDieEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(explosionAndDieEffect, timeParticleDie);
                }

                if (hit.transform.gameObject.tag == "barrel explosion")
                {
                    Instantiate(explosionAndDieEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(explosionAndDieEffect, timeParticleDie);
                    barrelExplosion.Play();
                }
            }
        }
    }
}
