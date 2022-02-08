using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackBall : MonoBehaviour
{
    [SerializeField] float timeToDestroy;
    Transform playerEngine;
    float speed = 5;
 
    private void Start()
    {       
        playerEngine = GameObject.FindObjectOfType<PlayerEngine>().transform;
    }
    // Update is called once per frame
    void Update()
    {
        DestroyPlayerHit();

        if (playerEngine.transform.localScale.x <= transform.localScale.x)
        {
            transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
            timeToDestroy = timeToDestroy - 0.5f * Time.deltaTime;
        }
        else
        {
            transform.Translate(1 * speed * Time.deltaTime, 0, 0);
            timeToDestroy = timeToDestroy - 0.5f * Time.deltaTime;
        }  
    }
    private void DestroyPlayerHit()
    {
        if(timeToDestroy <= 0)
        {
            Destroy(gameObject);
        }
    }
}
