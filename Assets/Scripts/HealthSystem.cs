using UnityEngine;

public class HealthSystem : MonoBehaviour, IDamagable
{
    [SerializeField] protected Healthbar healthbar;
    [SerializeField] protected float maxHealth;
    [SerializeField] protected float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        healthbar.UpdateHealtbar(maxHealth, currentHealth);
    }

    public virtual void Die()
    {
        if (gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Destroy(gameObject);
            GameManager.Instance.PlayerDied.Invoke();
        }
        else if (gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            gameObject.SetActive(false);
            GameManager.Instance.EnemyDied.Invoke();
        }
        else if (gameObject.layer == LayerMask.NameToLayer("House"))
        {
            gameObject.SetActive(false);
            GameManager.Instance.HouseDestroyed.Invoke();
        }
    }

    public virtual void TakeDamage(float dmg)
    {
        currentHealth -= dmg;
        healthbar.UpdateHealtbar(maxHealth, currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }
}
