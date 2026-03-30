# Kalite Güvence Planı
## İçindekiler:
1. Kalite Güvence Stratejisi
2. Kalite Faktörleri ve Metrikleri
3. Test Planı
## Katkıda Bulunanların Listesi:
- Mustafa Alperen Coşkun
- Osman Kuru
- Emre Karaduman
## Kalite Güvence Stratejisi
### Genel Bakış
Agile metodolojisine uygun olarak ürünün geliştirilme sürecinde aynı anda testler de gerçekleştirilecektir. Belirlenecek kalite faktörlerine göre ölçümler gerçekleştirerek eksiklerin giderilmesi ile kullanıcı deneyiminin geliştirilmesi hedeflenmektedir.
### Uygulanan Test Metotlar
#### İşlevsel Testler
**Unit Testing:** Unity’de geliştirme sürecinde farklı sahnelerdeki farklı özellikler kendi içlerinde çalışıp çalışmadıklarını kontrol etmek amacıyla test edilecektir. Unity Test Runner kullanılarak gerçekleştirilmesi planlanmaktadır.

**Integration Testing:** Farklı özellikler ve sahneler tamamlandıkça bir araya getirilerek bütün halinde çalışıp çalışmadıkları test edilecektir.

**Regression Testing:** Uygulamanın farklı parçaları bir araya gelmeye başladıkça devam eden testlerle birlikte yeni özellikler de ekleneceği için önceki özelliklerin bozulmadığının tekrar test edilmesi gerekmektedir.
#### İşlevsel Olmayan Testler
**Usability Testing:** Uygulamanın en önemli noktalarından biri kullanım kolaylığıdır. Bunun sağlanması için eklenen özelliklerden sonra ve geliştirme bittikten sonra son kullanıcıya uygulama test ettirilerek kullanımının doğal ve içgüdüsel olması test edilecektir.

**Compatibility Testing:** Mobil platform için geliştirilen uygulamanın geniş ürün yelpazesinde sorunsuz çalışabilmesi gerekmektedir. Arayüzün cihaza göre uygun şekilde ölçeklenebilmesi gerekmektedir. Bunlar için compatibility testleri gerçekleştirilecektir.
### Manuel ve Otomatik Test
Uygulamanın ölçeğinin küçük olması sebebiyle testlerin büyük bir kısmının manuel olarak gerçekleştirilmesine karar verilmiştir. Json dosyasının okuma metotlarının NUnit kullanılıp, bunun editör ile arasındaki iletişimi sağlayan Unity Test Framework’unun, Test Runner özelliği ile otomatik olarak test edilmesine karar verilmiştir. Ayrıca verinin panelde görüntülenmesini sağlayan metot için de unit test yazılıp otomatik olarak test edilecektir.
## Kalite Faktörleri ve Metrikleri
Tanımlanan kalite faktörleri, açıklamaları ve metrikleri:

**İçerik Kapsamı ve Doğruluğu:**
- Sunulan içerik miktarının yeterli, verilen bilginin doğru olması.
- **Ölçüm:** Kullanıcı içerik feedback skorları.

**Kullanılabilirlik:**
- Uygulamanın kullanıcı arayüzünün bireyler için elverişliliği ve güncel tasarım standartlarına uygunluğu.
- **Ölçüm:** System Usability Scale (SUS) skoru, tasarım standartlarına uygunluk miktarı (Material Design, Apple Human Interface Guidelines gibi).

**Performans:**
- Uygulama fonksiyonlarının ne kadar hızlı gerçekleştiği ve input’lara tepkiselliği.
- **Ölçüm:** Uygulamanın tepki ve yükleme süresi (ms).

**Ölçeklenebilirlik:**
- Uygulamanın codebase’inin yeni özelliklerin eklenilmesine uygunluğu ve var olan içeriğin büyütülebilirliği.
- **Ölçüm:** Algoritmik zaman kompleksitesi ve siklomatik kompleksite.

## Test Planı
### Test Senaryoları
**Test Senaryosu 1:** Ağaç sahnesinde butona tıklayınca alt dalların açılması
	Test Adımları: Ağaç sahnesine git, felsefe butonuna tıklayarak alt dalları aç, alt dallara tıklayarak onların alt dallarını aç.
	Beklenen Sonuç: Alt dalların çizgiler ile birlikte hizalı şekilde oluşturulması.

**Test Senaryosu 2:** Ağaç sahnesinde filozof butonuna tıklayınca bilgi panelinin açılması
	Test Adımları: Ağaç sahnesine git, filozoflara ulaşana kadar alt dalları aç, filozofa tıkla.
	Beklenen Sonuç: Ekrana filozofa ait verilerin gösterildiği bir panel gelmesi.

**Test Senaryosu 3:** Json dosyasını okumada kullanılan metotların unit testleri.
	Test adımları: Assets/Tests klasörü içerisine gerekli testlerin yazılacağı C# script'i NUnit kullanılarak oluşturulacak. Unit testler yazıldıktan sonra Test Runner kullanılarak testler gerçekleştirilecek.
	Beklenen sonuç: Test Runner’ın yazılan testler için yeşil tik vermesi.

**Test Senaryosu 4:** Veritabanındaki verilere göre quiz ve test oluşturmak için yazılan script'lerin unit testleri
	Test Adımları: Assets/Tests klasörü içerisine gerekli testlerin yazılacağı C# scripti NUnit kullanılarak oluşturulacak. Unit testler yazıldıktan sonra Test Runner kullanılarak testler gerçekleştirilecek
	Beklenen sonuç: Test Runner’ın yazılan testler için yeşil tik vermesi.

**Test Senaryosu 5:** Sahneler arası geçişin test edilmesi
	Test Adımları: Ana menüden başlayarak sahne geçişini sağlayan butonlara basılarak sahne geçişi yapılır. Menülerin içindeki geri butonlarına tıklanarak ana menüye geçişin çalışıp çalışmadığı kontrol edilir.
	Beklenen sonuç: Tüm sahneler arası geçişlerin doğru çalışması.
### Hata Takibi
Hata takibi için Github Issues kullanılacaktır. Test sırasında ortaya çıkan hatalar şu formatla Github Issues’a yazılacaktır: ID-Ciddiyet-Yeniden Üretme Adımları-Beklenen vs. Gerçekleşen Sonuç-Ekran Görüntüsü/Log. Hatalar raporlandıktan sonra İnceleme-Çözülme-Doğrulama işlemlerinden geçirilerek hatanın çözümü sağlanacaktır.
## Görev Matrisi

| **Doküman Gereksinimleri**      | **Görev Alan Üye**                   |
| ------------------------------- | ------------------------------------ |
| Genel Bakış                     | Mustafa Alperen Coşkun               |
| Uygulanan Test Metotlar         | Mustafa Alperen Coşkun               |
| Manuel ve Otomatik Test         | Mustafa Alperen Coşkun               |
| Kalite Faktörleri ve Metrikleri | Emre Karaduman                       |
| Test Senaryoları                | Mustafa Alperen Coşkun ve Osman Kuru |
| Hata Takibi                     | Osman Kuru                           |

