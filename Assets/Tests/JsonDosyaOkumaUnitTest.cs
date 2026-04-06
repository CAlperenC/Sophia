using NUnit.Framework;
using UnityEngine;
using TMPro;

public class JsonDosyaOkumaUnitTest
{
    [Test]
    public void JsonVerisi_DogruOkunup_ListeyeCevriliyorMu()
    {
        string sahteJson = "{\"dugumler\": [{\"id\": 5, \"isim\": \"Sokrates\", \"wikiLinki\": \"\"}]}";

        FelsefeVeritabani sonuc = JsonUtility.FromJson<FelsefeVeritabani>(sahteJson);

        Assert.IsNotNull(sonuc, "HATA: veritabanı objesi oluşturulamadı, sonuç null döndü");
        Assert.AreEqual(1, sonuc.dugumler.Count, "HATA: listede 1 dügüm olmalıydı");
        Assert.AreEqual("Sokrates", sonuc.dugumler[0].isim, "HATA: dügüm ismi uanlış");
        Assert.AreEqual(5, sonuc.dugumler[0].id, "HATA: dügüm id değeri yanlış eşleşti");
    }

    [Test]
    public void HataliVeyaBosJson_CokmeyiEngelliyorMu()
    {
        string bosJson = "{}";
        FelsefeVeritabani sonuc = JsonUtility.FromJson<FelsefeVeritabani>(bosJson);

        Assert.IsNotNull(sonuc, "sistem çökmeden boş obje dönmelidir");

        bool listeBosVeyaNull = sonuc.dugumler == null || sonuc.dugumler.Count == 0;
        Assert.IsTrue(listeBosVeyaNull, "düğümler dizisi boş veya null olmalıdır.");

    }
    [Test]
    public void DetayPaneli_VeriyiDogruBagliyorMu_Ve_BosMottoyuGizliyorMu()
    {
        GameObject panelObjesi = new GameObject("SanalPanel");
        BilgiPanel panel = panelObjesi.AddComponent<BilgiPanel>();

        panel.anaPanel = new GameObject("AnaPanel");
        panel.isimText = new GameObject("IsimKutusu").AddComponent<TMPro.TextMeshProUGUI>();
        panel.aciklamaText = new GameObject("AciklamaKutusu").AddComponent<TMPro.TextMeshProUGUI>();
        panel.mottoText = new GameObject("MottoKutusu").AddComponent<TMPro.TextMeshProUGUI>();
        panel.konuResmi = new GameObject("Resim").AddComponent<UnityEngine.UI.Image>();
        panel.btnLink = new GameObject("Link");

        FelsefeDugumu sahteFilozof = new FelsefeDugumu
        {
            isim = "Aristoteles",
            aciklama = "Mantık biliminin kurucusudur.",
            motto = "", 
            resimDosyaAdi = "",
            wikiLinki = ""
        };

        panel.PaneliAc(sahteFilozof);

        
        Assert.AreEqual("Aristoteles", panel.isimText.text, "HATA: İsim text'e yanlış aktarıldı!");
        Assert.AreEqual("Mantık biliminin kurucusudur.", panel.aciklamaText.text, "HATA: Açıklama text'e yanlış aktarıldı!");
        
        Assert.IsFalse(panel.mottoText.gameObject.activeSelf, "HATA: Motto boş olmasına rağmen ekranda görünür kaldı!");
        
        Assert.IsTrue(panel.anaPanel.activeSelf, "HATA: Veri yüklendikten sonra ana panel açılmadı!");
        
        Object.DestroyImmediate(panelObjesi);
    }
}