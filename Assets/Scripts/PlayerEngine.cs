using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerEngine : MonoBehaviour
{

    // [SerializeField] Control from the unity Inspector

    public int currentHealth;
    public float timeToAttack;
    float startTimeToAttack = 1;
    public int jumpForce = 450;
    public HealthBar healthbar;
  
    [SerializeField] GameObject playerHit;

    // Coins
    public static int numCoins;
    public TextMeshProUGUI coinText;

    // Movment
    float x;
    [SerializeField] float speed = 5;

    // Jump
    Rigidbody2D rb;
    bool isFloor;
    bool isDead;
    bool isFind;

    //animator
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        healthbar.SetMaxHealth(currentHealth);
        rb = GetComponent<Rigidbody2D>();    // Jump
        isFloor = true;    
        anim = GetComponent<Animator>();    // Animator
    }

    // Update is called once per frame
    void Update()
    {     
        coinText.text =  numCoins.ToString(); // convert form numbers to text
        PlayerAtack();
        MovmentLogic();
        JumpLogic();
        PlayerDeath();
        PlayerAnim();
        healthbar.SetHealth(currentHealth);
    }

    public void TakeDamage(int damage)
    {
        if(isDead == false)
        {
            currentHealth -= damage;           
            anim.SetTrigger("IsHurt"); // Trigger for the death animation
        }        
    }

    private void MovmentLogic()
    {
        if(isDead == false)
        {
            x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            transform.Translate(x, 0, 0);

            if (x == 0)
            {
                anim.SetBool("IsRunning", false);
            }
            else if (x > 0)
            {
                transform.localScale = new Vector2(1, transform.localScale.y);
            }
            else if (x < 0)
            {
                transform.localScale = new Vector2(-1, transform.localScale.y);
            }
        }     
    }
    private void JumpLogic()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isFloor == true && isDead == false) 
        {
            anim.SetBool("IsRunning", false);
            anim.SetTrigger("IsJump");
            rb.AddForce(new Vector2(0, jumpForce));
            isFloor = false;        
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") // Ground Trigger for more jumps
        {
            isFloor = true;
        }
        else if(collision.gameObject.tag == "Fire")
        {
            TakeDamage(20);
          
        }
        else if (collision.gameObject.tag == "Key")
        {
            Destroy(collision.gameObject);
            isFind = true;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Door" && isFind == true)
        {
            SceneManager.LoadScene("Win");
        }
    }

    private void PlayerDeath()
    {
        if(currentHealth <= 0 && isDead == false)
        {
            isDead = true;
            
            anim.SetTrigger("IsDead");
            Collider2D poly2D = GetComponent<PolygonCollider2D>();
            Collider2D collider2D = GetComponent<BoxCollider2D>();
            poly2D.enabled = true;       
            collider2D.enabled = false;
            Invoke("EndGame", 1f);           
        }
    }

    private void PlayerAnim()   // Walk Anime
    {
        if (isFloor == true && x != 0)
        {
            anim.SetBool("IsRunning", true);
        }
    }
    private void PlayerAtack()
    {
        if (timeToAttack <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Z) && isDead == false)
            {
                anim.SetTrigger("Attack");
                timeToAttack = startTimeToAttack;
            }
        }
        else
        {
            timeToAttack -= Time.deltaTime;
        }

    }
    private void InstantiateHit()    // wen anim Attack work
    {     
        Instantiate(playerHit, transform.position, transform.rotation);
    }
    private void EndGame()
    {
        SceneManager.LoadScene("GameOver");
    }
}
