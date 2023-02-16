using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public List<GameObject> hearts;

    private void Start()
    {
        currentHealth = maxHealth;

        GameObject liveBar = GameObject.FindWithTag("LiveBar");
        if (liveBar != null)
        {
            for (int i = 0; i < maxHealth; i++)
            {
                hearts.Add(liveBar.transform.GetChild(i).gameObject);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        UpdateLiveBar();

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void UpdateLiveBar()
    {
        int heartIndex = currentHealth - 1;
        if (heartIndex >= 0 && heartIndex < hearts.Count)
        {
            GameObject heart = hearts[heartIndex];
            hearts.RemoveAt(heartIndex);
            Destroy(heart);
        }
    }

    private void Die()
{
    Rigidbody2D rb = GetComponent<Rigidbody2D>();
    if (rb != null)
    {
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
    }
    
    Animation anim = GetComponent<Animation>();
    if (anim != null && anim.GetClip("Death") != null)
    {
        anim.Play("Death");
    }
    
    StartCoroutine(DestroyAfterAnimation(anim.GetClip("Death").length));
}

private IEnumerator DestroyAfterAnimation(float delay)
{
    yield return new WaitForSeconds(delay);
    Destroy(gameObject);
}
}