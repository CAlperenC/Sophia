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
    private PhilosophyDataManager manager;

    public void KurulumYap(FelsefeDugumu veri)
    {
        benimVerim = veri;
        butonMetni.text = veri.isim;
        
        rectTransform = GetComponent<RectTransform>();
        manager = FindFirstObjectByType<PhilosophyDataManager>();
        //GetComponent<Button>().onClick.AddListener(Tiklandiginda);
    }

    public void Tiklandiginda()
    {
        if(!isOpen){
            //alt dallar açılacak 
            altButonlar = manager.AltDallariAc(benimVerim, rectTransform.anchoredPosition);
            isOpen = true;
        }
        else
        {
            AltButonlarıKapat();
            // alt dallar kapanacak
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