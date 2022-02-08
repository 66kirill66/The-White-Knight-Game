using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEngine : MonoBehaviour
{
    [SerializeField] int enemyLives = 5;
    public int currentLives;
    public EnemyHelthBar enemyHelthBar;
    [SerializeField] float range;
    PlayerEngine playerEngine;
    Animator animator;
    Transform playerTransform;
    float distance = Mathf.Infinity;
    bool isAttacet = false;
    bool death = false;


    void Start()
    {
        currentLives = enemyLives;
        playerTransform = GameObject.FindObjectOfType<PlayerEngine>().transform;
        playerEngine = FindObjectOfType<PlayerEngine>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        distance = Vector2.Distance(playerTransform.position, transform.position);
        ProvokeEnemy();
        NoTarget();
        EnemyDeath();
    }

    private void EnemyDeath()
    {
        if (currentLives <= 0 && death == false)
        {
            death = true;
            animator.SetTrigger("dying");
            Destroy(gameObject, 1f);
            enabled = false;
        }
    }
    
    private void follow()         // Chenge scale if go left & rigth
    {

        if (playerTransform.position.x <= transform.position.x)
        {
            animator.SetBool("Attack", false);
            animator.SetBool("run", true);
            transform.localScale = new Vector2(-0.4f, 0.4f);
            transform.Translate(-1f * Time.deltaTime, 0, 0);
        }
        else if (playerTransform.position.x >= transform.position.x)
        {
            animator.SetBool("Attack", false);
            animator.SetBool("run", true);
            transform.localScale = new Vector2(0.4f, 0.4f);
            transform.Translate(1f * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.Translate(0, 0, 0);
            animator.SetBool("run", false);
        }
    }
    private void NoTarget()
    {
        if (playerEngine.currentHealth <= 0)
        {
            animator.SetBool("Attack", false);
            animator.SetBool("run", false);
            enabled = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void ProvokeEnemy()   // checks the boundaries of the sphere & Chek distance & attack false
    {
        if (isAttacet == false)
        {
            if (distance <= range)  // Attack target
            {
                follow();
            }
            else if (distance >= range)  // Not Attack
            {
                animator.SetBool("run", false);
            }
        }
        else if (distance >= 2)  // follow true
        {
            isAttacet = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerSword")
        {
            animator.SetTrigger("hart");
            Destroy(collision.gameObject);
            currentLives -= 1;
            enemyHelthBar.SetHelthValue(currentLives, enemyLives);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isAttacet = true;
            animator.SetBool("run", false);
            animator.SetBool("Attack", true);          
        }
    }
    public void EnemyAttack()      // Anim Event
    {
        animator.SetBool("run", false);
        animator.SetBool("Attack", true);
        playerEngine.TakeDamage(10);
    }

}