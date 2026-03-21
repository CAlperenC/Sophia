using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonControl : MonoBehaviour
{
    public TMP_Text butonMetni;
    public FelsefeDugumu benimVerim;
    
    private RectTransform rectTransform;
    private PhilosophyDataManager manager;

    public void KurulumYap(FelsefeDugumu veri)
    {
        benimVerim = veri;
        butonMetni.text = veri.isim;
        
        rectTransform = GetComponent<RectTransform>();
        manager = FindObjectOfType<PhilosophyDataManager>();

        GetComponent<Button>().onClick.AddListener(Tiklandiginda);
    }

    public void Tiklandiginda()
    {
        manager.AltDallariAc(benimVerim, rectTransform.anchoredPosition);
    }
}