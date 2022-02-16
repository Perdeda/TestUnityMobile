using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScrollingScrView : MonoBehaviour
{
    [SerializeField]
    private RectTransform panel;
    [SerializeField]
    private float _picSize = 620f;
    [SerializeField]
    private float _offset = 20f;
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private RectTransform lastImage;
    private bool eof = false;
    private ImageCatcher _imCatcher;
    private int _picCount = 6;
    private float _defaultSize;
    // Start is called before the first frame update
    void Start()
    {
        _defaultSize = panel.rect.height;
        _imCatcher = GameObject.FindObjectOfType(typeof(ImageCatcher)) as ImageCatcher;
        _imCatcher.GetImage(prefab.GetComponent<RawImage>(), _picCount + 1);
        ScrollRect sb = GetComponent<ScrollRect>();
        sb.onValueChanged.AddListener(OnScroll);
    }

    private void OnScroll(Vector2 args)
    {
        if (!eof)
        {
            RectTransform tmp;
            Debug.Log(panel.offsetMax.y);
            if (panel.offsetMax.y >= (_picSize + _offset) * _picCount / 2 - (_picSize + _offset) * 2)
            {
                panel.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _defaultSize + (_picSize + _offset) * _picCount/2);
                panel.offsetMax = new Vector2(panel.offsetMax.x, panel.offsetMax.y - (_picSize + _offset) * 2);
                //Левая картинка
                InstantiatePrefabImage(new Vector2(-lastImage.rect.x, lastImage.rect.y - (_picSize + _offset) * _picCount / 2), _picCount + 1);
                tmp = prefab.GetComponent<RectTransform>();
                //Правая картинка
                InstantiatePrefabImage(new Vector2(-lastImage.rect.x + lastImage.rect.width + _offset * 2, lastImage.rect.y - (_picSize + _offset) * _picCount / 2), _picCount + 2);
                lastImage = tmp;
                _picCount += 2;
            }
        }
    }
    private void InstantiatePrefabImage(Vector2 vec, int i)
    {
        prefab.GetComponent<RectTransform>().anchoredPosition = vec;
        RawImage img = Instantiate(prefab.GetComponent<RawImage>(), panel);
        StartCoroutine(LoadImage(img, i));
    }
    private IEnumerator LoadImage(RawImage im, int i)
    {
        eof = _imCatcher.GetImage(im, i);
        yield return null;
    }
}
