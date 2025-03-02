using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public static Entity main;
    public float hitPoints;
    public GameObject gameover;
    public int currency;
    
    public virtual void takeDamage(float damage)
    {
        hitPoints -= damage;
        Debug.Log(hitPoints + " HP remaining");
        if (hitPoints <= 0)
        {
            Die();
        }
    }
    
    public virtual void Die()
    {      
        Debug.Log("Dead");
        Destroy(gameObject);
        
    }

    void Awake()
    {
        main = this;
    }

}
