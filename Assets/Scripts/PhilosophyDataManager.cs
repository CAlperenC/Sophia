using UnityEngine;
using System.Collections.Generic;

// --- 1. VERİ MODELLERİ ---
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
    // Not: Buradaki isim "dugumler", JSON dosyasındaki liste adıyla BİREBİR aynı olmalıdır.
    public List<FelsefeDugumu> dugumler;
}


// --- 2. YÖNETİCİ SINIF ---
public class PhilosophyDataManager : MonoBehaviour
{
    // Uygulama boyunca kullanacağımız ana veri listemiz
    public List<FelsefeDugumu> tumVeriler = new List<FelsefeDugumu>();

    void Start()
    {
        VerileriYukle();
        
    }

    void VerileriYukle()
    {
        // Adım 1: Resources klasöründeki JSON dosyasını okuyoruz.
        // DİKKAT: Uzantıyı (.json) YAZMIYORUZ, sadece dosyanın adını veriyoruz.
        TextAsset jsonDosyasi = Resources.Load<TextAsset>("FilozofVerileri");

        // Null kontrolü: Takım projelerinde biri yanlışlıkla dosyayı siler veya adını değiştirirse
        // uygulamanın çökmesini engellemek için bu kontrol hayat kurtarır.
        if (jsonDosyasi == null)
        {
            Debug.LogError("FilozofVerileri.json dosyası Resources klasöründe bulunamadı!");
            return;
        }

        // Adım 2: JSON metnini (string) C# nesnesine dönüştürüyoruz (De-serialization)
        FelsefeVeritabani veritabani = JsonUtility.FromJson<FelsefeVeritabani>(jsonDosyasi.text);

        // Adım 3: Çektiğimiz veriyi güvenli bir şekilde ana listemize aktarıyoruz
        if (veritabani != null && veritabani.dugumler != null)
        {
            tumVeriler = veritabani.dugumler;
            Debug.Log($"<color=green>Başarılı!</color> Toplam {tumVeriler.Count} adet felsefe düğümü yüklendi.");

            // Verinin doğru geldiğinden emin olmak için test fonksiyonumuzu çağırıyoruz
            TestIcinKonsolaYazdir();
        }
        else
        {
            Debug.LogError("JSON dosyası bulundu ama içi boş veya format hatalı!");
        }
    }

    // Konsol üzerinden verilerin doğru eşleşip eşleşmediğini kontrol eden test fonksiyonu
    void TestIcinKonsolaYazdir()
    {
        foreach (FelsefeDugumu dugum in tumVeriler)
        {
            Debug.Log($"ID: {dugum.id} | Parent: {dugum.parentId} | İsim: {dugum.isim} | Seviye: {dugum.seviye}");
            
            // Veri yapımızda bazı mottoların boş ("") olduğunu biliyoruz.
            // Sadece mottosu olanları yazdırıyoruz.
            if (!string.IsNullOrEmpty(dugum.motto))
            {
                Debug.Log($"   --> Motto: {dugum.motto}");
            }
        }
    }
}