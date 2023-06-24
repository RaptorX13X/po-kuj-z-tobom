using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health;

    public void Damage()
    {
        health -= 1;
        Debug.Log(health);

        if (health == 0)
        {
            Destroy(gameObject);
        }
    }
    
    
}
