using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RazorLeaf : MonoBehaviour
{
    public float speed; // Speed of the razor leaf
    public float timelife;

    public DamageType DamageType; // Configure this in the Inspector
    private DamageDealer DamageDealer; // Reference to the DamageDealer script

    private Vector3 moveDirection;
    void Start()
    {
        Destroy(gameObject, timelife);
        // Get the DamageDealer component from the parent GameObject
        DamageDealer = GetComponentInParent<DamageDealer>();

        moveDirection = transform.localScale.x > 0 ? Vector3.right : Vector3.left;

        if (moveDirection == Vector3.left)
        {
            transform.localScale = new Vector3(-1 * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
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
