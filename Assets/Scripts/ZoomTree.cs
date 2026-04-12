using UnityEngine;
using UnityEngine.EventSystems;
//using UnityEngine.InputSystem;
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
/*
using UnityEngine;
using UnityEngine.InputSystem; // Yeni kütüphaneyi ekledik
using UnityEngine.UI;

public class ZoomTree : MonoBehaviour
{
    [Header("Zoom Ayarları")]
    public RectTransform icerikPaneli;
    public ScrollRect scrollRect;
    public float zoomHiziFare = 0.01f;
    public float zoomHiziDokunmatik = 0.001f;
    public float minZoom = 0.2f;
    public float maxZoom = 2f;

    void Update()
    {
        // --- 1. MOUSE SCROLL (PC) ---
        if (Mouse.current != null)
        {
            float scrollY = Mouse.current.scroll.ReadValue().y;
            if (scrollY != 0)
            {
                // Yeni sistemde scroll değerleri daha yüksek geldiği için hızı dengeledik
                ZoomUygula(scrollY * zoomHiziFare * 0.1f);
            }
        }

        // --- 2. PINCH TO ZOOM (ANDROID / DOKUNMATİK) ---
        if (Touchscreen.current != null && Touchscreen.current.touches.Count == 2)
        {
            // İki parmak ekrandaysa ScrollView'u kapat ki ekran kaymasın
            scrollRect.enabled = false;

            var parmak1 = Touchscreen.current.touches[0];
            var parmak2 = Touchscreen.current.touches[1];

            // Parmakların şu anki ve önceki pozisyonlarını al
            Vector2 p1Poz = parmak1.position.ReadValue();
            Vector2 p2Poz = parmak2.position.ReadValue();
            
            Vector2 p1EskiPoz = p1Poz - parmak1.delta.ReadValue();
            Vector2 p2EskiPoz = p2Poz - parmak2.delta.ReadValue();

            // Mesafeleri hesapla
            float eskiMesafe = (p1EskiPoz - p2EskiPoz).magnitude;
            float yeniMesafe = (p1Poz - p2Poz).magnitude;

            float fark = yeniMesafe - eskiMesafe;
            ZoomUygula(fark * zoomHiziDokunmatik);
        }
        else
        {
            // İki parmak yoksa scroll tekrar aktif
            if (!scrollRect.enabled) scrollRect.enabled = true;
        }
    }

    void ZoomUygula(float artisMiktari)
    {
        Vector3 yeniScale = icerikPaneli.localScale + Vector3.one * artisMiktari;

        yeniScale.x = Mathf.Clamp(yeniScale.x, minZoom, maxZoom);
        yeniScale.y = Mathf.Clamp(yeniScale.y, minZoom, maxZoom);
        yeniScale.z = 1f; // 2D ağaçta Z her zaman 1 kalmalı

        icerikPaneli.localScale = yeniScale;
    }
}*/