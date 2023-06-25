using System;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private int health;
    private int currentHealth;
    [SerializeField] private EnemyHealthbar healthBar;
    [SerializeField] private bool isPlayer;
    [SerializeField] private float invincibleTime = 0.1f;

    public event Action OnDeath;
    public event Action OnDamaged;

    public int Value => currentHealth;
    public float Percent => (float)currentHealth / health;

    private float remainingInvincibleTime = 0f;

    private void Awake()
    {
        currentHealth = health;
        if (!isPlayer)
            healthBar.SetMaxHealth(health);
    }

    private void Update()
    {
        remainingInvincibleTime -= Time.deltaTime;
    }

    public void Damage()
    {
        if (remainingInvincibleTime > 0)
            return;

        remainingInvincibleTime = invincibleTime;

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
    }
}
