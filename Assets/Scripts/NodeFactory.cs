using UnityEngine;
using System.Collections.Generic;
using Codice.Client.Common.TreeGrouper;

public class NodeFactory : MonoBehaviour
{
    public static NodeFactory nodeFactory;//singleton

    [Header("UI Ayarları")]
    public GameObject butonPrefab;
    public RectTransform icerikPaneli;
    void Awake()
    {
        if(nodeFactory == null)
        {
            nodeFactory = this;
        }
        else if (nodeFactory != this)
        {
            Destroy(gameObject);
        }
    }
    public GameObject DugumOlustur(FelsefeDugumu veri, Vector2 pozisyon)
    {
        GameObject yeniButon = Instantiate(butonPrefab, icerikPaneli);
        RectTransform rect = yeniButon.GetComponent<RectTransform>();
        
        rect.anchoredPosition = pozisyon;
        
        yeniButon.GetComponent<ButtonControl>().KurulumYap(veri);
        PhilosophyDataManager.philosophyDataManager.ekrandakiAktifDugumlerListesi.Add(yeniButon.GetComponent<ButtonControl>());
        return yeniButon;
    }
}