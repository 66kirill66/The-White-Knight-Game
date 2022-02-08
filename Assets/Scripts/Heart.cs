using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    PlayerEngine playerHP;

    private void Start()
    {
        playerHP = FindObjectOfType<PlayerEngine>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            playerHP.currentHealth += 20;
            Destroy(gameObject);        
        }
    }
}
