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

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
