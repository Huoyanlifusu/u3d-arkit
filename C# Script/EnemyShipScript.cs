using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipScript : MonoBehaviour
{
    public int health = 3;
    public int damage = 1;

    public float moveSpeed;
    public float attackRange;


    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, CoreLogic.instance.transform.position);

        if (distance > attackRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, CoreLogic.instance.transform.position, moveSpeed*Time.deltaTime);
            
        } else
        {
            CoreLogic.instance.TakeDamage(damage);
            Destroy(gameObject);
        }
        transform.LookAt(CoreLogic.instance.transform);
    }

    public void TakeDamage()
    {
        health--;
        if(health == 0)
        {
            Destroy(gameObject);
        }
    }
}
