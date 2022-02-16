using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomColorChange : MonoBehaviour
{
    [SerializeField]
    private PanelDraw panel;
    [SerializeField]
    private Text R;
    [SerializeField]
    private Text G;
    [SerializeField]
    private Text B;
    // Start is called before the first frame update
    void Start()
    {
        panel = GameObject.FindObjectOfType(typeof(PanelDraw)) as PanelDraw;
        InputField i;
    }

    public void OnEndEdit()
    {
        Debug.Log((float.Parse(R.text), float.Parse(G.text), float.Parse(B.text)));
        panel.ColorChange(new Color32(byte.Parse(R.text), byte.Parse(G.text), byte.Parse(B.text),255));
    }
}
