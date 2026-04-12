using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
//using Unity.VisualScripting;
//using System.Linq;
//using PlasticPipe.PlasticProtocol.Messages;

public class ButtonControl : MonoBehaviour
{
    public GameObject duzlestirButonu;
    public TMP_Text butonMetni;
    public FelsefeDugumu benimVerim;
    
    public bool isOpen = false;
    public  List<GameObject> altButonlar = new List<GameObject>();
    private RectTransform rectTransform;
    
    public GameObject cizgi;

    public void KurulumYap(FelsefeDugumu veri)
    {
        duzlestirButonu.SetActive(false);
        benimVerim = veri;
        butonMetni.text = veri.isim;
        
        rectTransform = GetComponent<RectTransform>();
    }

    public void Tiklandiginda()
    {
        if(!isOpen){
            //alt dallar açılacak 
            altButonlar = PhilosophyDataManager.philosophyDataManager.AltDallariAc(benimVerim,rectTransform.anchoredPosition);
            if (altButonlar.Count >= 1)
            {
                altbutonlarAcildi_Kapandi(true);
            }
        }
        else
        {
            // alt dallar kapanacak
            AltButonlarıKapat();
            altbutonlarAcildi_Kapandi(false);
        }
    }

    public void altbutonlarAcildi_Kapandi(bool acildi)
    {
        if (acildi)
        {
            isOpen = true;
            duzlestirButonu.SetActive(true);
        }
        else
        {
            isOpen = false;
            duzlestirButonu.SetActive(false);
        }
    }
    public void AltButonlarıKapat()
    {
        foreach (var buton in altButonlar)
        {
            if (buton.TryGetComponent<ButtonControl>(out ButtonControl btncntrl))
            {
                if (btncntrl.altButonlar.Count > 0)
                {
                    btncntrl.AltButonlarıKapat();
                }
                Destroy(btncntrl.cizgi);
            }
            else
            {
                Debug.Log("sıkıntı kardeşim");
            }
            PhilosophyDataManager.philosophyDataManager.ekrandakiAktifDugumlerListesi.Remove(buton.GetComponent<ButtonControl>());
            Destroy(buton);
        }        
        altButonlar.Clear();
    }

    public void SeviyeyiDüzleştir()// alt dallarını kapatıp kapattığı alt dallara ait bütün alt dalları açacak
    {
        if(isOpen){
            List<int> idler = new List<int>();
            foreach (var item in altButonlar)
            {
                idler.Add(item.GetComponent<ButtonControl>().benimVerim.id);
            }
            AltButonlarıKapat();
            altButonlar = PhilosophyDataManager.philosophyDataManager.AltDallariAc(benimVerim,idler,rectTransform.anchoredPosition);
        }
    }
}