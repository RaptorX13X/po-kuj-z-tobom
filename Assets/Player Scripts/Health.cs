using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health;

    public event Action OnDeath;
    public event Action OnDamaged;

    public int Value => health;

    public void Damage()
    {
        health -= 1;
        OnDamaged?.Invoke();

        if (health == 0)
        {
            OnDeath?.Invoke();
            if (gameObject.TryGetComponent(out PlayerMenager playerM)) gameObject.SetActive(false); 
            else Destroy(gameObject);
        }
    }
}
