using UnityEngine;
using UnityEngine.EventSystems;

public class DragUI : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        //this.GetComponent<RectTransform>().anchoredPosition = eventData.delta;
        GetComponent<RectTransform>().anchoredPosition += eventData.delta / GetComponent<RectTransform>().GetComponentInParent<Canvas>().scaleFactor;

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
