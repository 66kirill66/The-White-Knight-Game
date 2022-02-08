using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornsTrap : MonoBehaviour
{
    Animator animator;
    PlayerEngine pl;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        pl = FindObjectOfType<PlayerEngine>();
    }   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            animator.SetTrigger("Thorns");
            pl.currentHealth -= 20;
        }
    }
}
