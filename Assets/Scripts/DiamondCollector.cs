using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiamondCollector : MonoBehaviour
{
    private int diamondsCollected = 0;
    public Text diamondsCollectedText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Diamond"))
        {
            diamondsCollected++;
            Destroy(collision.gameObject);
            diamondsCollectedText.text = "x " + diamondsCollected;
        }
    }
}
