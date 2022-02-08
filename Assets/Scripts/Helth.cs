using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helth : MonoBehaviour
{
    [SerializeField] Image bar;
    [SerializeField] float fill;
    
    void Update()
    {      
        bar.fillAmount = fill;
    }
    public void PlayerHelth(float damage)
    {
        fill = damage;
        bar.fillAmount = fill;
    }
}
