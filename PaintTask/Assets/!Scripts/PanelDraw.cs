using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelDraw : MonoBehaviour, IPointerClickHandler,IPointerDownHandler,IPointerUpHandler
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private RectTransform panel;
    public void ColorChange(Color32 color)
    {
        prefab.GetComponent<Image>().color = color;
    }
    public void ThiccnessChange(int size)
    {
        prefab.GetComponent<RectTransform>().sizeDelta = new Vector2(size, size);
    }
    private void Draw(PointerEventData eventData)
    {
        Image img = Instantiate(prefab.GetComponent<Image>(), eventData.pointerCurrentRaycast.screenPosition, Quaternion.identity, panel);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Draw(eventData);
    }
    private bool isHolding = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        isHolding = true;
        StartCoroutine(DrawRoutine(eventData));
    }

    private IEnumerator DrawRoutine(PointerEventData eventData)
    {
        while (isHolding)
        {
            Draw(eventData);
            yield return null;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHolding = false;
    }
}
