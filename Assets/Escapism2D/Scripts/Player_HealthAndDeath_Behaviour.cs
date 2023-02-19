using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_HealthAndDeath_Behaviour : MonoBehaviour
{
    [SerializeField] public int maxHealth = 100;
    [SerializeField] public int currentHealth;
    [SerializeField] private AudioSource deathSoundEffect;

    public HealthBar healthBar;
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Traps"))
        {
            Die();
        }
        else if(collision.gameObject.CompareTag("AngryPig"))
        {
            Die();
        }

        else if (collision.gameObject.CompareTag("Mushroom"))      
        {
            TakeDamage(20);
        }
    }
    
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void Die()
    {
        deathSoundEffect.Play();  
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    
    
}
