using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BilgiPanel : MonoBehaviour
{
    public static BilgiPanel bilgiPanel;//singleton

    [Header("UI Elemanları")]
    public GameObject anaPanel;
    public TMP_Text isimText;
    public TMP_Text mottoText;
    public TMP_Text aciklamaText;
    public Image konuResmi;
    public GameObject btnLink;
    private string gidilecekLink = "";
    void Awake()
    {
        bilgiPanel = this;
        anaPanel.SetActive(false); 
        
    }
    void Start()
    {
    }

    public void PaneliAc(FelsefeDugumu filozofVerisi)
    {
        isimText.text = filozofVerisi.isim;
        aciklamaText.text = filozofVerisi.aciklama;

        if (string.IsNullOrEmpty(filozofVerisi.motto))
        {
            mottoText.gameObject.SetActive(false);
        }
        else
        {
            mottoText.gameObject.SetActive(true);
            mottoText.text = "\"" + filozofVerisi.motto + "\"";
        }

        //
        if (!string.IsNullOrEmpty(filozofVerisi.resimDosyaAdi))
        {
            konuResmi.gameObject.SetActive(false); 
            //konuResmi.gameObject.SetActive(true);
            //Sprite yuklenenResim = Resources.Load<Sprite>(filozofVerisi.resimDosyaAdi);
            //konuResmi.sprite = yuklenenResim;
        }
        else
        {
            konuResmi.gameObject.SetActive(false); 
        }

        if (!string.IsNullOrEmpty(filozofVerisi.wikiLinki))
        {
            btnLink.SetActive(true);
            gidilecekLink = filozofVerisi.wikiLinki;
        }
        else
        {
            btnLink.SetActive(false); 
        }
        //
        anaPanel.SetActive(true);
    }
    public void LinkeGit()
    {
        if (!string.IsNullOrEmpty(gidilecekLink))
        {
            Application.OpenURL(gidilecekLink);
        }
    }

    public void PaneliKapat()
    {
        anaPanel.SetActive(false);
    }
}