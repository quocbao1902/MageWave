using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI; // Add this for UI elements

public class PlayerHealth : MonoBehaviour
{
    public float MaxHealth;
    public float CurrentHealth;
    private Animator m_Animator;

    private Color hitColor = Color.red; // Color to change to when hit
    private float flashDuration = 0.5f; // Duration of the flash effect
    private SpriteRenderer spriteRenderer;

    public AudioClip HurtAudioClip;

    public Image healthBarFill; // Use Image type for the health bar

    //-----------------------------------------------------------------------------------------------------------
    //END GAME

    public GameObject gameOverObject; // Assign in the Inspector

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        m_Animator = GetComponent<Animator>();
        UpdateHealthBar();
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void Heal(float amount)
    {
        CurrentHealth += amount;
        UpdateHealthBar();

        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }

        Debug.Log("Healed by " + amount + ". Current Health: " + CurrentHealth);
    }


    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
        UpdateHealthBar(); // update healthbar display

        if (CurrentHealth > 0)
        {
            StartCoroutine(FlashEffect()); // Start the color change effect
            AudioSource.PlayClipAtPoint(HurtAudioClip, transform.position, 1f);
        }
        else
        {
            spriteRenderer.enabled = false; // Disable the SpriteRenderer to make the player invisible
            gameOverObject.SetActive(true);
            Time.timeScale = 0;

        }
    }

    //---------------------------------------------------------------------------------------------
    //healthbar
    private void UpdateHealthBar()
    {
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = CurrentHealth / MaxHealth; // Update fill amount
        }
    }

    //---------------------------------------------------------------------------------------------
    //Flash
    private IEnumerator FlashEffect()
    {
        Color originalColor = spriteRenderer.color; // Store the original color
        spriteRenderer.color = hitColor; // Change to hit color

        yield return new WaitForSeconds(flashDuration); // Wait for the duration

        spriteRenderer.color = originalColor; // Restore the original color
    }
}



