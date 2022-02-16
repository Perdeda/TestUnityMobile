using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ImageButton : MonoBehaviour
{
    // Start is called before the first frame update
    private ImageEnhance imEnhancer;
    void Start()
    {
        imEnhancer = GameObject.FindObjectOfType(typeof(ImageEnhance)) as ImageEnhance;
        GetComponent<Button>().onClick.AddListener(EhSwitch);
    }

    private void EhSwitch()
    {
        imEnhancer.SwitchToEnhanced(GetComponentInParent<RawImage>());
    }
}
