using UnityEngine;

public class Damage : MonoBehaviour
{
    //Health 
    [SerializeField] private float health, maxHealth = 3f;
    private Transform target;

    [SerializeField] private FloatingHealthBar healthBar;

    private void Awake()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        healthBar.UpdateHealthBar(health,maxHealth);
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        transform.root.GetComponent<EndGame>().TankDied();
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(10f);
        }
    }
}