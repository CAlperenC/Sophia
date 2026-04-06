using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class FelsefeDugumu
{
    public int id;
    
    public int parentId;
    public string seviye;
    public string isim;
    public string motto;
    public string aciklama;
    public string resimDosyaAdi; 
    public string wikiLinki;
}

[System.Serializable]
public class FelsefeVeritabani
{
    //isim  JSON dosyasındaki liste adıyla aynı olmalıdır.
    public List<FelsefeDugumu> dugumler;
}

public class PhilosophyDataManager : MonoBehaviour
{
    public static PhilosophyDataManager philosophyDataManager;
    public List<FelsefeDugumu> tumVeriler = new List<FelsefeDugumu>();//jsondaki verilerli tutacak 
    public List<ButtonControl> ekrandakiAktifDugumlerListesi = new List<ButtonControl>();//bir butona tıklanınca kardeş butondaki dalları kapatacak

    [Header("UI Ayarları")]
    public GameObject butonPrefab;
    public RectTransform icerikPaneli;
    
    [Header("Ağaç Boşluk Ayarları")]
    public float yatayBosluk = 500f; 
    public float dikeyBosluk = 200f; 

    [Header("Çizgi Ayarları")]
    public GameObject cizgiPrefab; 
    public float cizgiKalinligi = 8f;

    void Start()
    {
        if(philosophyDataManager== null)
        {
            philosophyDataManager = this;
        }
        VerileriYukle();//jsonu oku verileri listeye at
        //root dugumu bulup oluşturuyoruz
        FelsefeDugumu rootDugum = tumVeriler.Find(x => x.parentId == 0);
        if (rootDugum != null)
        {
            DugumOlustur(rootDugum, new Vector2(0, 3600/2-100));//3600 icerik paneli uzunluğudur.
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
        ekrandakiAktifDugumlerListesi.Add(yeniButon.GetComponent<ButtonControl>());
        return yeniButon;
    }

    public List<GameObject> AltDallariAc(FelsefeDugumu parentVeri, Vector2 parentPozisyon)
    {
        BaskaDallariKapat(parentVeri.parentId,parentVeri.id);// aynı seviyedeki diğer dalları kapadık
        //bu ebeveyne ait çocukları listeden bul
        List<GameObject> olusturulanButonlar = new List<GameObject>();
        List<FelsefeDugumu> cocuklar = tumVeriler.FindAll(x => x.parentId == parentVeri.id);
        int cocukSayisi = cocuklar.Count;

        if (cocukSayisi == 0) 
        {
            BilgiPanel.bilgiPanel.PaneliAc(parentVeri);
            return olusturulanButonlar;
        }

        float cocukY = parentPozisyon.y - dikeyBosluk;

        for (int i = 0; i < cocukSayisi; i++)
        {
            float cocukX = parentPozisyon.x + (i - (cocukSayisi - 1) / 2f) * yatayBosluk;
            Vector2 cocukPozisyon = new Vector2(cocukX, cocukY);

            //Çizgi hesap bölümü
            GameObject yeniCizgi = Instantiate(cizgiPrefab, icerikPaneli);
            yeniCizgi.transform.SetAsFirstSibling(); 
            
            RectTransform cizgiRect = yeniCizgi.GetComponent<RectTransform>();

            Vector2 yon = cocukPozisyon - parentPozisyon;
            float mesafe = yon.magnitude;
            float aci = Mathf.Atan2(yon.y, yon.x) * Mathf.Rad2Deg;

            // çizgiyi butonların ortasına yerleştir
            cizgiRect.anchoredPosition = parentPozisyon + (yon / 2f);
            
            //uzunluk ve kalınlık ayarla
            cizgiRect.sizeDelta = new Vector2(mesafe, cizgiKalinligi);
            
            // açıyı ayarla
            cizgiRect.localRotation = Quaternion.Euler(0, 0, aci);
            //

            GameObject yenibuton = DugumOlustur(cocuklar[i], cocukPozisyon);
            olusturulanButonlar.Add(yenibuton);
            yenibuton.GetComponent<ButtonControl>().cizgi = yeniCizgi;//çizgiyi işaret ettiği butonun scriptine referansını ekliyoruz ki butonu silerken çizgiyi de silebilelim
        }
        return olusturulanButonlar;
    }

    public void BaskaDallariKapat(int tiklananDugumParentId, int tiklananDugumId)
    {
        foreach (var dugum in ekrandakiAktifDugumlerListesi)
        {
            if (dugum.benimVerim.parentId == tiklananDugumParentId && dugum.benimVerim.id != tiklananDugumId)
            {
                dugum.AltButonlarıKapat(); 
            }
        }
    }
}