using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThuderShot : MonoBehaviour
{
    public float speed; // Speed of the Thunder Shot
    public float timelife;

    public DamageType DamageType; // Configure this in the Inspector
    private DamageDealer DamageDealer; // Reference to the DamageDealer script

    void Start()
    {
        Destroy(gameObject, timelife);
        // Get the DamageDealer component from the parent GameObject
        DamageDealer = GetComponentInParent<DamageDealer>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (DamageDealer != null)
            {
                DamageDealer.DealDamage(playerHealth, DamageType); // Deal damage based on type
            }
            Destroy(gameObject);
        }
    }
}
