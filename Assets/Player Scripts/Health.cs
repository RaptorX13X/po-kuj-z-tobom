using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health;

    public event Action OnDeath;

    public void Damage()
    {
        health -= 1;

        if (health == 0)
        {
            OnDeath?.Invoke();
            Destroy(gameObject);
        }
    }
}
