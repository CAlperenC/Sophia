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
    public string resimDosyaAdi; 
    public string wikiLinki;
}

[System.Serializable]
public class FelsefeVeritabani
{
    //isim  JSON dosyasındaki liste adıyla aynı olmalıdır.
    public List<FelsefeDugumu> dugumler;
}
