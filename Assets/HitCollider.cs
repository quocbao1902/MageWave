using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollider : MonoBehaviour
{
    public DamageType DamageType; // Configure this in the Inspector
    private DamageDealer DamageDealer; // Reference to the DamageDealer script

    // Start is called before the first frame update
    void Start()
    {
        // Get the DamageDealer component from the parent GameObject
        DamageDealer = GetComponentInParent<DamageDealer>();
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
            if (playerHealth != null && DamageDealer != null)
            {
                DamageDealer.DealDamage(playerHealth, DamageType); // Deal damage based on type
            }
        }
    }
}
