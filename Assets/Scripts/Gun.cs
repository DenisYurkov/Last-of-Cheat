using UnityEngine;

// Скрипт для оружия. 
public class Gun : MonoBehaviour
{
    [SerializeField] float damage = 10f;
    [SerializeField] float range = 100f;
    
    [SerializeField] Camera fpsCam;
    [SerializeField] ParticleSystem shotEffect;
    [SerializeField] AudioSource audioShot;
    [SerializeField] ParticleSystem destroyEffect;

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
        shotEffect.Play();
        audioShot.Play();

        // Структура, используемая для получения информации из рейкаста.
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            
            // Если target не равен пустому объекту, то отнимать у объекты HP.
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            Instantiate(destroyEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
}
