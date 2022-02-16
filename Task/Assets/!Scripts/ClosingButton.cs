using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosingButton : MonoBehaviour
{
    // Start is called before the first frame update
    private ImageEnhance imEnhancer;
    void Start()
    {
        imEnhancer = GameObject.FindObjectOfType(typeof(ImageEnhance)) as ImageEnhance;
        GetComponent<Button>().onClick.AddListener(EhSwitch);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            EhSwitch();
        }
    }
    private void EhSwitch()
    {
        imEnhancer.SwitchToGallery();
    }
}
