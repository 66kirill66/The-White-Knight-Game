using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    public Transform playerTrn;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerTrn.position.x, playerTrn.position.y + 2 , -10);
    }
}
