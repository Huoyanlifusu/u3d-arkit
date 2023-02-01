using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        EnemyShipScript enemy = other.GetComponent<EnemyShipScript>();

        if (enemy != null)
        {
            enemy.TakeDamage();

            Destroy(gameObject);
        }
    }
}
