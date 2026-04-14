using UnityEngine;
using System.Collections.Generic;

public class JsonParser : MonoBehaviour
{
    public TextAsset jsonDosyasi;

    // Sadece veriyi ayrıştırıp döndürme sorumluluğu var
    public List<FelsefeDugumu> VerileriYukle()
    {
        if (jsonDosyasi != null)
        {
            FelsefeVeritabani veritabani = JsonUtility.FromJson<FelsefeVeritabani>(jsonDosyasi.text);
            return veritabani.dugumler;
        }
        Debug.LogError("JSON dosyası bulunamadı!");
        return new List<FelsefeDugumu>();
    }
}