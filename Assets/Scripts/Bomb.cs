using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explosionForce = 20f;
    public float explosionRadius = 5f;
    public GameObject explosionPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, 0.5f);

            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            Vector2 direction = playerRigidbody.transform.position - transform.position;
            playerRigidbody.AddForce(direction.normalized * explosionForce, ForceMode2D.Impulse);

            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
            }

            Destroy(gameObject);
        }
    }
}
