using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CustomColorRules : MonoBehaviour
{
    [SerializeField]
    private InputField inpf; 
    // Start is called before the first frame update
    void Start()
    {
        inpf.characterLimit = 3;
        inpf.contentType = InputField.ContentType.IntegerNumber;
        inpf.text = "255";
    }
    public void OnEndEdit()
    {
        if(int.Parse(inpf.text) > 255)
        {
            inpf.text = "255";
        }
    }
}
