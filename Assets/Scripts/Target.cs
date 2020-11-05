using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Скрипт для врагов или для объектов которые нужно уничтожить с помощью оружия.
public class Target : MonoBehaviour
{
    [SerializeField] float health = 50f;

    public void TakeDamage (float amout)
    {
        health -= amout;
        if (health <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
