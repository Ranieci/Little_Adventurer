using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public Slider healthslider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(currentHealth <= 0)
        {
            currentHealth = maxHealth;
        }
        healthslider.maxValue = maxHealth;
        healthslider.value = currentHealth;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth < 0)
        {
            currentHealth = 0;
        }
        healthslider.value = currentHealth;
        Debug.Log("Player health: " + currentHealth);

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameManager.instance.GameOver();
        PlayerMovement movement = GetComponent<PlayerMovement>();
        if(movement != null)
        {
            movement.enabled = false;
        }
        Animator anim = GetComponent<Animator>();
        if(anim != null)
        {
            anim.enabled = false;
        }
        CharacterController controller = GetComponent<CharacterController>();
        if(controller != null)
        {
            controller.enabled = false;
        }
        
    }
}
