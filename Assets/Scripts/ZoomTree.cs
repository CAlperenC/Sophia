using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ZoomTree : MonoBehaviour
{
    [Header("Zoom Ayarları")]
    public RectTransform icerikPaneli;
    public ScrollRect scrollRect;
    public float zoomHiziFare = 0.1f;
    public float zoomHiziDokunmatik = 0.001f;
    public float minZoom = 0.2f; 
    public float maxZoom = 2f; 

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            ZoomUygula(scroll * zoomHiziFare * 10f);
        }

        if (Input.touchCount == 2)
        {
            scrollRect.enabled = false;
            Touch parmak1 = Input.GetTouch(0);
            Touch parmak2 = Input.GetTouch(1);

            Vector2 parmak1EskiPoz = parmak1.position - parmak1.deltaPosition;
            Vector2 parmak2EskiPoz = parmak2.position - parmak2.deltaPosition;

            float eskiMesafe = (parmak1EskiPoz - parmak2EskiPoz).magnitude;
            float yeniMesafe = (parmak1.position - parmak2.position).magnitude;

            float fark = yeniMesafe - eskiMesafe;
            ZoomUygula(fark * zoomHiziDokunmatik);
        }
        else
        {
            scrollRect.enabled = true;
        }
    }

    void ZoomUygula(float artisMiktari)
    {

        Vector3 yeniScale = icerikPaneli.localScale;

        yeniScale += Vector3.one * artisMiktari;

        yeniScale.x = Mathf.Clamp(yeniScale.x, minZoom, maxZoom);
        yeniScale.y = Mathf.Clamp(yeniScale.y, minZoom, maxZoom);

        icerikPaneli.localScale = new Vector3(yeniScale.x,yeniScale.y,icerikPaneli.localScale.z);//yeniScale;
    }

}