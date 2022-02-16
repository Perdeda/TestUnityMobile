using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScrollingPanel : MonoBehaviour, IPointerClickHandler
{
    private float picSize = 620f;
    private float offset = 10f;
    private float lastMax = 0;
    private RectTransform sv;
    // Start is called before the first frame update
    void Start()
    {
        lastMax = picSize * 3;
        sv = GetComponent<RectTransform>();
        Debug.Log(lastMax);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("XDD");
    }

}
