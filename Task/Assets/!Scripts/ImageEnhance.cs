using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ImageEnhance : MonoBehaviour
{
    [SerializeField]
    Canvas initCanvas;
    [SerializeField]
    Canvas enhCanvas;
    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        if (initCanvas == null)
        {
            initCanvas = GameObject.Find("IntitialCanvas").GetComponent<Canvas>();
        }
        if (enhCanvas == null)
        {
            enhCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        }
    }
    public void SwitchToEnhanced(RawImage im)
    {
        initCanvas.renderMode = RenderMode.WorldSpace;
        enhCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        GameObject ehimg = GameObject.Find("Canvas/EnhancedImage");
        ehimg.GetComponent<RawImage>().texture = im.texture;
        Screen.orientation = ScreenOrientation.AutoRotation;
    }
    public void SwitchToGallery()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        enhCanvas.renderMode = RenderMode.WorldSpace;
        enhCanvas.GetComponent<RectTransform>().position = new Vector3(-5000,-5000);
        initCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
    }
}