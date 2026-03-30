# Tasarım Dokümanı
## İçindekiler:
1. Sisteme Genel Bakış
2. İmplementasyon Detayları
3. Tasarımda Senaryo Desteği
4. Tasarım Kararları
## Katkıda Bulunanların Listesi:
- Mustafa Alperen Coşkun
- Osman Kuru
- Emre Karaduman
## Sisteme Genel Bakış
### Projenin Özeti
Sophia, felsefeye ilgi duyan giriş seviyesindeki insanların filozoflar ve felsefenin farklı dalları hakkındaki bilgisini genişletmesini ve felsefe spektrumunda kendi fikirlerinin nerede konumlandığını anlamasını sağlamayı, dolayısıyla kendini keşfetmesini amaçlayan bir uygulamadır. 
Uygulama içerisinde kullanıcı; felsefe dalları ve filozoflar arasında kullanıcı dostu bir arayüz vasıtası ile dolanabilir, bunları sıralayabilir, filtreleyebilir ve içerikleri görüntüleyebilir, bununla beraber menüden tıklayarak açabileceği, bilgisini sınayan quizler ve kendi ideolojik konumunu anlamasını sağlayan testler ile etkileşime geçebilir.
### Sistem Mimarisi
Projede katmanlı bir mimari uygulanması planlanmaktadır. Projenin yapısı; filozof ve felsefe verilerinin tutulacağı bir veri katmanı, bu verilerden yararlanılarak uygulamanın fonksiyonlarının gerçekleştirildiği bir mantık katmanı, kullanıcının filozof ve felsefe sayfaları, quiz'ler ve testler ile etkileşebilmesini sağlayan arayüz için bir sunum katmanı şeklinde birbirinden bağımsız Unity sahnelerinden oluşmaktadır.
### Kullanılan Teknolojiler
Uygulamanın geliştirilmesinde kullanılacak ana teknoloji Unity oyun motorudur. Uygulama arayüzü için Unity UI kullanılacak, uygulama fonksiyonlarının script'leri C# dili ile yazılacaktır. Bu script'lerde Unity kütüphanelerinden yararlanılacaktır. Filozof ve felsefe verilerini saklamak için JSON veri formatı ile tercih edilecek, düz dosya veritabanı şeklinde organize edilecek ve veriyi okumak için JsonUtility veya Newtonsoft.Json kütüphanelerinden yararlanılacaktır. Sürüm kontrolü için Git kullanılacaktır.
## İmplementasyon Detayları
### Codebase Yapısı
Projede Unity'nin yapısına uygun bir klasör sistemi kullanılacaktır.
Scenes klasörü içerisinde Unity sahneleri; Main_Menu, Test_Scene ve Tree_Scene bulunacaktır.
Scripts klasörü içerisinde C# script'leri bulunacaktır.
Assets klasörü içerisinde arayüzde kullanılan asset'ler bulunacaktır.
```
.
├── Scenes/
│   ├── Main_Menu
│   ├── Test_Scene
│   └── Tree_Scene
├── Scripts/
│   ├── TestManager.cs
│   ├── PhilosophyDataManager.cs
│   └── BilgiPanel.cs
└── Assets
```
### Ana İmplementasyonlar
`TestManager:` Uygulamadaki test özelliğiyle ilgili metotları içerir. Test oluşturma, Soru oluşturma, Sorular arasında geçme gibi işlemleri yönetir.
`PhilosophyDataManager:` Filozof ağacı ile ilgili metotlara sahiptir. Alt nodeları açma gibi işlemleri yönetir. JSON dosyalarına yazma ve okuma işlemlerinin metotlarını içerir.
`BilgiPanel:` Filozofların bilgilerini görüntüleme ile ilgili metotlara sahiptir.

### Bileşen Arayüzleri
#### TestManager:
`public void makeQuestion():` Veritabanından bilgiler alarak bunlara göre sorular oluşturur.
`public boolean evaluateAnswer():` Bir soruya verilen cevabın doğru olup olmadığını değerlendirir.
`public void goToMain():` Test arayüzünden ana arayüze geçişi sağlar.   
#### PhilosophyDataManager:
`public void AltDallariAc():` Alt node'ları olan bir node’a tıklandığında alt node'ların görünmesini sağlar.
`public void displayInfoCards():` Bilgi kartına sahip olan bir node’a tıklandığında bu node’un bilgi kartının gösterilmesini sağlar. Bilgi kartı arayüzüne geçer.
`public void skipFilter():` Sıradaki aşamanın atlanmasını sağlar.
`public GameObject DugumOlustur(FelsefeDugumu veri, Vector2 pozisyon):` Ağaca eklenecek yeni düğümü oluşturur.
`void VerileriYukle():` JSON dosyasındaki verileri okur.
`public void filter(String filter):` Filtreleme kriterine göre ağacı filtreler.
#### BilgiPanel:
`public void PaneliAc(FelsefeDugumu filozofVerisi):` Konuyla ilgili bilgilerin verileceği paneli oluşturup bilgileri yazar.
`public void LinkeGit():` Konuyla ilgili detaylı bilginin verildiği internet adresine yönlendirir.
### Görsel Arayüzler
Buradaki görseller uygulamanın planlanan arayüzüne örneklerdir.

![Main Menu](https://github.com/CAlperenC/Sophia/blob/main/D%C3%B6k%C3%BCmanlar/D%C3%B6k%C3%BCman%20G%C3%B6rselleri/AnaMen%C3%BCAray%C3%BCz%C3%BC.jpeg)
![Test Menu](https://github.com/CAlperenC/Sophia/blob/main/D%C3%B6k%C3%BCmanlar/D%C3%B6k%C3%BCman%20G%C3%B6rselleri/TestMen%C3%BCs%C3%BCAray%C3%BCz%C3%BC.jpeg)
![Node Tree](https://github.com/CAlperenC/Sophia/blob/main/D%C3%B6k%C3%BCmanlar/D%C3%B6k%C3%BCman%20G%C3%B6rselleri/A%C4%9Fa%C3%A7Aray%C3%BCz%C3%BC.jpeg)
## Tasarımda Senaryo Desteği
### Senaryo Seçimi
- Akıma göre filozof filtreleme.
- Filozofa tıklandığı zaman detaylı görünümünü vermesi.
- Node ağacında gezinme. 
- Felsefe quiz'i.

### Gereksinim Planlaması
**Akıma Göre Filozof Filtreleme:**
- Kullanıcı, filozofları ve felsefe konularını sıralayabilmeli veya filtreleyebilmeli.

**Filozofa Tıklandığı Zaman Detaylı Görünümünü Vermesi:**
- Kullanıcı filozoflara veya felsefe konularına tıklayarak onlar hakkında bilgi edinebilmeli.

**Node Ağacında Gezinme:**
- Kullanıcı filozof kategorileri arasında dolanabilmeli.
- Kullanıcı farklı felsefe dalları arasında dolanabilmeli.

**Felsefe Quiz'i:**
- Kullanıcı felsefe konularına ait quiz’lerle kendini sınayabilmeli.
- Kullanıcı bu quiz'lerde şıklara tıklayarak cevap verebilmeli.
- Kullanıcı quiz bitince ekranda başarı sonucunu görebilmeli.

### Senaryo Tasarımı
Aşağıda tüm senaryoların tasarımı ile ilgili bilgiler verilmiştir.

**Ağaç Benzeri Yapıda Gezinme:** Arayüz katmanında `Agac` arayüzü ile gerçekleştirilir. Ana arayüzdeyken `Agac` butonuna basılınca `Agac` arayüzüne geçilir. `Agac` arayüzünde ağacın dallarına tıklandığında mantık katmanından `AltDallariAc()` fonksiyonu çağrılır ve veri katmanından veriler alınarak arayüze yazılır.

**Filozofa Tıklandığı Zaman Detaylı Görünümünü Vermesi:** Bu senaryonun gerçekleştirilmesi için `Agac` arayüzünde bir filozofa tıklandığında `PaneliAc()` fonksiyonu çağrılarak ilgili bilgi okunur ve arayüzde bilgi paneline yazılır.

**Akıma Göre Filozof Filtreleme:** `Agac` arayüzünde iken filtreleme kriterleri seçildikten sonra `Filtrele` butonuna basınca mantık katmanından `filter()` fonksiyonunu çağırarak `Agac` arayüzünde gerekli değişiklikler yapılacaktır.

**Filozof Quiz'i:** Arayüz katmanında `Test` arayüzü ile gerçekleştirilir. Ana arayüzdeyken `Quiz` butonuna basıldığında `Test` arayüzüne geçilir. Mantık katmanından `makeQuestion()` fonksiyonu çağrılarak veri katmanındaki verilerden rastgele testler oluşturulur ve `Test` arayüzüne yazılır. Test bittikten sonra testin sonucu mantık katmanından `writeJSON()` fonksiyonu ile veri katmanından ilgili JSON dosyasına yazılır.
## Tasarım Kararları
### Teknoloji Kıyaslamaları
Burada verileri saklamak kullandığımız JSON formatı ile diğer alternatifleri karşılaştırdık.

| **Nitelikler**            | **JSON**                   | **ScriptableObjects**       | **SQL**                              |
| ------------------------- | -------------------------- | --------------------------- | ------------------------------------ |
| **Düzenleme Ortamı**      | Herhangi bir metin editörü | Sadece Unity editörü        | Veritabanı Tarayıcısı                |
| **Okunabilirlik**         | Yüksek                     | Düşük (Binary dosyası)      | Düşük (Binary dosyası)               |
| **Runtime’da Değiştirme** | Mümkün                     | Mümkün değil                | Mümkün                               |
| **Sürüm Kontrolü**        | Git’e uygun, metin dosyası | Binary dosyası              | Binary dosyası                       |
| **Performans**            | Orta (parsing overhead)    | En hızlı (hafızada duruyor) | Yüksek (arama için optimize edilmiş) |
| **Karışıklık**            | Düşük                      | Düşük                       | Yüksek                               |

### Karar Gerekçeleri
Ana framework’ümüz olan Unity’i tercih etme sebeplerimiz: 
- kullanım deneyimine sahip üyelerimiz olması, dolayısıyla tasarıma daha fazla vakit ayırabilmemiz.
- Aynı codebase ile çoğu farklı platforma build edebilmemiz.
- Standart olmayan 2D tasarımları desteklemesi. (Felsefe dallarının bulunduğu node ağacı gibi)

Kodlama dili olarak C# tercih etme sebeplerimiz:
- Alışık olduğumuz dillere yakın olması (OOP dili, Java).
- Unity’nin hazır olarak desteklemesi.

Veri saklama formatı olarak JSON tercih etme sebeplerimiz:
- Herhangi bir metin editörü ile düzenlenebilmesi.
- Basit bir organizasyonunun olması.

### Tasarım Örüntüsü ile İlgili Kararlar
- Karşılaşılan problem: Unity scriptlerinin birbirlerinin referansına ihtiyaç duyması. 
- Çözüm olarak kullanılan tasarım örüntüsü: Ağaç sahnesindeki manager scriptleri singleton tasarım örüntüsüne göre yazılmıştır. Bu sayede sahneye bir instance eklenerek diğer objelerin bu managerın static instanceına erişmesi sağlanmıştır. 
UML diyagramı bu örüntüye uygun olarak manager objesinin birden fazla instanceının olmamasına dikkat edilerek hazırlanmıştır.

- Karşılaşılan problem: Ağaç sahnesinde yeni dallar oluşturulurken butonları instantiate etmemiz gerkemektedir.
- Çözüm olarak kullanılan tasarım örüntüsü: Ağaç sahnesinde kullanılan PhilosophyDataManager scriptine factory olarak kullanılacak bir DugumOlustur() metodu eklenmiştir. Bu metod çağrıldığında kendine verilen pozisyonda buton oluşturup o butonun scriptine
parametre olarak aldığı verileri koyup butonu return eder.

## Görev Matrisi

| **Doküman Gereksinimleri** | **Görev Alan Üye**                       |
| -------------------------- | ---------------------------------------- |
| Projenin Özeti             | Mustafa Alperen Coşkun ve Emre Karaduman |
| Sistem Mimarisi            | Mustafa Alperen Coşkun ve Emre Karaduman |
| Kullanılan Teknolojiler    | Mustafa Alperen Coşkun ve Emre Karaduman |
| Codebase Yapısı            | Mustafa Alperen Coşkun                   |
| Ana İmplementasyonlar      | Mustafa Alperen Coşkun ve Osman Kuru     |
| Bileşen Arayüzleri         | Mustafa Alperen Coşkun ve Osman Kuru     |
| Görsel Arayüzler           | Emre Karaduman                           |
| Senaryo Seçimi             | Osman Kuru                               |
| Gereksinim Planlaması      | Osman Kuru                               |
| Senaryo Tasarımı           | Osman Kuru                               |
| Teknoloji Kıyaslamaları    | Emre Karaduman                           |
| Karar Gerekçeleri          | Emre Karaduman                           |







