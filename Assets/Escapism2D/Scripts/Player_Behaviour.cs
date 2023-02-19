using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Behaviour : MonoBehaviour
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

        if (collision.gameObject.CompareTag("AngryPig"))
        {
            Die();
        }

        if (collision.gameObject.CompareTag("Mushroom"))      
        {
            TakeDamage(20);
            CheckHealth();
            if(CheckHealth() == true)
            {
                Die();
            }
        }

        if (collision.gameObject.CompareTag("BlueBird"))      
        {
            TakeDamage(10);
            CheckHealth();
            if(CheckHealth() == true)
            {
                Die();
            }
        }
        
    }
    
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    private void Die()
    {
        deathSoundEffect.Play();  
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    public bool CheckHealth()
    {
        bool deadPlayer = false;

        if(currentHealth <= 0)
        {
            deadPlayer = true;
        }
        
        return deadPlayer;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    
    
}
