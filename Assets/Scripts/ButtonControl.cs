using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using Unity.VisualScripting;

public class ButtonControl : MonoBehaviour
{
    public TMP_Text butonMetni;
    public FelsefeDugumu benimVerim;
    
    public bool isOpen = false;
    public  List<GameObject> altButonlar = new List<GameObject>();
    private RectTransform rectTransform;
    
    public GameObject cizgi;

    public void KurulumYap(FelsefeDugumu veri)
    {
        benimVerim = veri;
        butonMetni.text = veri.isim;
        
        rectTransform = GetComponent<RectTransform>();
    }

    public void Tiklandiginda()
    {
        if(!isOpen){
            //alt dallar açılacak 
            altButonlar = PhilosophyDataManager.philosophyDataManager.AltDallariAc(benimVerim,rectTransform.anchoredPosition);
            if(altButonlar.Count>=1){
                isOpen = true;
            }
        }
        else
        {
            // alt dallar kapanacak
            AltButonlarıKapat();
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
            Destroy(buton);
        }
        isOpen = false;
        altButonlar.Clear();
    }
}