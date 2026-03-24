using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class FelsefeDugumu
{
    public int id;
    public int parentId;
    public string seviye;
    public string isim;
    public string motto;
    public string aciklama;
    public int[] baglantilar;
}

[System.Serializable]
public class FelsefeVeritabani
{
    //isim  JSON dosyasındaki liste adıyla aynı olmalıdır.
    public List<FelsefeDugumu> dugumler;
}

public class PhilosophyDataManager : MonoBehaviour
{
    public List<FelsefeDugumu> tumVeriler = new List<FelsefeDugumu>();//jsondaki verilerli tutacak 
    
    [Header("UI Ayarları")]
    public GameObject butonPrefab;
    public RectTransform icerikPaneli;
    
    [Header("Ağaç Boşluk Ayarları")]
    public float yatayBosluk = 500f; 
    public float dikeyBosluk = 200f; 

    void Start()
    {
        VerileriYukle();//jsonu oku verileri listeye at
        //root dugumu bulup oluşturuyoruz
        FelsefeDugumu rootDugum = tumVeriler.Find(x => x.parentId == 0);
        if (rootDugum != null)
        {
            DugumOlustur(rootDugum, new Vector2(0, Screen.height/2-100));
        }
    }

    void VerileriYukle()
    {
        TextAsset jsonDosyasi = Resources.Load<TextAsset>("FilozofVerileri");
        if (jsonDosyasi != null)
        {
            FelsefeVeritabani veritabani = JsonUtility.FromJson<FelsefeVeritabani>(jsonDosyasi.text);
            tumVeriler = veritabani.dugumler;
        }
    }

    public GameObject DugumOlustur(FelsefeDugumu veri, Vector2 pozisyon)
    {
        GameObject yeniButon = Instantiate(butonPrefab, icerikPaneli);
        RectTransform rect = yeniButon.GetComponent<RectTransform>();
        
        rect.anchoredPosition = pozisyon;
        
        yeniButon.GetComponent<ButtonControl>().KurulumYap(veri);
        
        return yeniButon;
    }

    public List<GameObject> AltDallariAc(FelsefeDugumu parentVeri, Vector2 parentPozisyon)
    {
        //bu ebeveyne ait çocukları listeden bul
        List<GameObject> olusturulanButonlar = new List<GameObject>();
        List<FelsefeDugumu> cocuklar = tumVeriler.FindAll(x => x.parentId == parentVeri.id);
        int cocukSayisi = cocuklar.Count;

        if (cocukSayisi == 0) 
        {
            return olusturulanButonlar;
        }

        float cocukY = parentPozisyon.y - dikeyBosluk;

        for (int i = 0; i < cocukSayisi; i++)
        {
            float cocukX = parentPozisyon.x + (i - (cocukSayisi - 1) / 2f) * yatayBosluk;
            Vector2 cocukPozisyon = new Vector2(cocukX, cocukY);

            olusturulanButonlar.Add(DugumOlustur(cocuklar[i], cocukPozisyon));
            
            // çizgi eklenecek
        }
        return olusturulanButonlar;
    }
}