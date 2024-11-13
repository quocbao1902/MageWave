using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public HealType HealType; // Configure this in the Inspector
    private HealDealer HealDealer; // Reference to the HealDealer script

    // Start is called before the first frame update
    void Start()
    {
        // Get the HealDealer component from the parent GameObject
        HealDealer = GetComponentInParent<HealDealer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //object tagged as "Player"
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null && HealDealer != null)
            {
                HealDealer.Heal(playerHealth, HealType); // Deal Heal based on type               
            }
            Destroy(gameObject);
        }
    }
}
