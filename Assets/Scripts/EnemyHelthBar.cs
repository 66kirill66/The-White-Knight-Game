using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHelthBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Vector3 offset;

    void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
        if(slider.value == 0)
        {
            Destroy(gameObject);
        }
    }
    public void SetHelthValue(int currentHelth, int maxHelth)
    {      
        slider.value = currentHelth;
        slider.maxValue = maxHelth;
    }
}
