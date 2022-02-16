using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThicknessDropdown : MonoBehaviour
{
    [SerializeField]
    private Dropdown menu;
    [SerializeField]
    private PanelDraw panel;
    // Start is called before the first frame update
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
            case 0:panel.ThiccnessChange(10); break;
            case 1:panel.ThiccnessChange(20); break;
            case 2:panel.ThiccnessChange(30); break;
        }
    }
}
