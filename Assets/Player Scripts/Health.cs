using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health;
    private int currentHealth;
    [SerializeField] private EnemyHealthbar healthBar;
    [SerializeField] private bool isPlayer;

    public event Action OnDeath;
    public event Action OnDamaged;

    public int Value => currentHealth;
    public float Percent => (float)currentHealth / health;

    private void Awake()
    {
        currentHealth = health;
        if (!isPlayer)
            healthBar.SetMaxHealth(health);
    }

    public void Damage()
    {
        currentHealth -= 1;
        OnDamaged?.Invoke();
        if (!isPlayer)
            healthBar.SetHealth(currentHealth);

        if (currentHealth == 0)
        {
            OnDeath?.Invoke();
            if (gameObject.TryGetComponent(out PlayerMenager playerM)) gameObject.SetActive(false); 
            else Destroy(gameObject);
        }
    }

    public void Heal(int value)
    {
        currentHealth = Mathf.Min(health, currentHealth + value);
        if (!isPlayer)
            healthBar.SetHealth(currentHealth);
        Debug.Log("Healed!");
    }
}
