using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitImages : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject DoNotInitialize;
    void Start()
    {
        ImageCatcher imCatcher = GameObject.FindObjectOfType(typeof(ImageCatcher)) as ImageCatcher;
        RawImage[] initArr;
        
        DoNotInitialize.SetActive(false);
        //Downloading initial images
        initArr = GameObject.FindObjectsOfType<RawImage>();
        int i = 1;
        foreach (var o in initArr)
        {
            imCatcher.GetImage(o,i);
            i++;
        }
        DoNotInitialize.SetActive(true);
    }
}
