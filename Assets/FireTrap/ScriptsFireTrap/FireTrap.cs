using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    Animator anim;
    public GameObject fireDamage;
    [SerializeField] Transform pos;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("Fire");
            Instantiate(fireDamage, pos.transform.position, transform.rotation);
        }
    }
}
