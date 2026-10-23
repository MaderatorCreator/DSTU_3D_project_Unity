using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("жызни")]
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    //повідомлення про зміни
    public System.Action<int> OnHealthChanged;
    public System.Action OnDeath;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    //нанесення урону
    public void TakeDamage(int damageAmount)
    {
        if (currentHealth <= 0) return;
        currentHealth -= damageAmount;
        currentHealth = Mathf.Max(currentHealth, 0);
        OnHealthChanged?.Invoke(currentHealth); //виклик події зміни здоров'я

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    //лікарство
    public void Heal(int healAmount)
    {
        if (currentHealth <= 0) return; //мертвий? і навіщо тобі лікар?
        currentHealth += healAmount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
        OnHealthChanged?.Invoke(currentHealth);
    }

    private void Die()
    {
        OnDeath?.Invoke();
        Destroy(gameObject); //приїбати анімку чи щось таке можно
    }

    //впізнати, скільки ХП (інфа для UI)
    public int GetCurrentHealth() => currentHealth;
    public int GetMaxHealth() => maxHealth;
}
