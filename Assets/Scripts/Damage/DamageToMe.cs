using UnityEngine;

public class DamageToMe : MonoBehaviour
{
    //Health 
    [SerializeField] private float health, maxHealth = 3f;
    private Transform target;

    [SerializeField] private FloatingHealthBar healthBar;
    
    //UI
    public GameObject losePanel;
    public GameObject levelCam;

    private void Awake()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        healthBar.UpdateHealthBar(health, maxHealth);
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        losePanel.SetActive(true);
        levelCam.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        
        //SFX
        Debug.Log("Lose");
        AudioManager.Instance.PlaySFX("Lose");
        AudioManager.Instance.StopMusic("Theme");
        
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("EnemyTank"))
        {
            TakeDamage(10f);
        }
    }
}