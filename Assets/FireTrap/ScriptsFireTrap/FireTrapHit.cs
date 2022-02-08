using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrapHit : MonoBehaviour
{
    public float timeTodestroy = 0.1f;
    private float speed = 3f;
   
    void Update()
    {
        if(timeTodestroy <= 0)
        {
            Destroy(gameObject);
        }
        transform.Translate(1 * speed * Time.deltaTime, 0, 0);
        timeTodestroy = timeTodestroy - 0.5f * Time.deltaTime;
    }
}
