using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorDropdown : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Dropdown menu;
    [SerializeField]
    private PanelDraw panel;
    void Start()
    {
        panel = GameObject.FindObjectOfType(typeof(PanelDraw)) as PanelDraw;
        menu = menu.GetComponent<Dropdown>();
        OnDropDownValueChange();
    }
    public void OnDropDownValueChange()
    {
        switch (menu.value)
        {
            case 0: panel.ColorChange(Color.black); break;
            case 1: panel.ColorChange(Color.red); break;
            case 2: panel.ColorChange(Color.blue); break;
            case 3: panel.ColorChange(Color.green); break;
        }
    }
}
