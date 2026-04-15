# Delta Tasarım & İmplementasyon Raporu
## İçindekiler:
1. Seçilen Geliştirme
2. Efor Tahmini ve Gerekçelendirme
3. Tasarım Tercihleri Hakkında Açıklama
4. Kalite Faktörlerine ve Metriklerine Etkisi
## Katkıda Bulunanlar:
- Mustafa Alperen Coşkun
- Osman Kuru
- Emre Karaduman
## Seçilen Geliştirme
Bekir Ata Yıldırım, Emre İnci ve Orhan Faruk Demir’in yaptığı review'da PhilosophyDataManager sınıfının SRP prensibini ihlal eder bir noktaya geldiğini tespit etmiştir. Geliştirme sırasında fark edilmeyen bu ihlal review sonrası tekrar incelendiğinde daha net algılanmıştır ve düzeltilmesi için review raporunda yazılmış madde 9 Improvement Assessment başlığı altında belirtilen PhilosophyDataManager sınıfının NodeFactory ve JsonParser gibi alt bileşenlere ayrılması önerisinin projeye eklenmesine karar verilmiştir.
## Efor Tahmini ve Gerekçelendirme
Yapılacak geliştirme tasarım mimarisinde bir değişiklik ya da projeyi kökünden değiştirme gibi bir etkiye sahip olmayacaktır. PhilosophyDataManager sınıfı SRP (Single Responsibility Principle) doğrultusunda parçalara bölünecektir. Bu sebeple efor tahmini için COCOMO ve benzeri geniş kapsamlı modellerin kullanılması uygun görülmemiştir. Efor tahmininde Uzman Değerlendirmesi ve Buttom-Up yaklaşımıyla bileşenler ayrı ayrı değerlendirilip toplam efor için toplanmıştır, yazılımın mevcut geliştiricileri olarak koda olan hakimliğimiz ve değişecek bileşenler hakkındaki bilgimiz uzman görüşü olarak sürelerin tahmininde kullanılmıştır.

**Bileşen 1:** JsonParse sınıfı: Tahmini implementasyon süresi 1 saat.

**Bileşen 2:** NodeFactory sınıfı: Tahmini implementasyon süresi 2 saat.

**Bileşen 3:** PhilosophyDataManager sınıfının güncellenmesi: Tahmini implementasyon süresi 1 saat.

**Bileşen 4:** Entegrasyon ve regresyon testleri: Tahmini gerçekleştirme süresi 1 saat.

**Toplam Tahmini Efor Maliyeti:** 5 person-hours.  
 Günlük 2.5 saatlik efor ile 2 günlük sürede yapılması öngörülmektedir.
## Tasarım Tercihleri Hakkında Açıklama
Yapılacak iyileştirmeler için şu tasarım kararları (Design Decisions) alınmış ve uygulanmıştır:

**Sorumlulukların Ayrılması:** Veri Katmanı (Data Layer) ve Sunum Katmanı (Presentation Layer) birbirinden tamamen izole edilmiştir. JsonParser sınfı sadece veri okuma işlevini üstlenirken, ağaçtaki UI butonlarının instantiation sorumluluğu PhilosophyDataManager sınıfından alınmıştır.

**Tasarım Örüntüleri:** Düğüm (Node) prefablerinin Unity sahnesinde dinamik olarak instantiate edilmesi işlemi için fabrika tasarım deseni seçilmiş ve NodeFactory sınıfı üzerinden uygulanmıştır. NodeFactory sınıfı aynı zamanda Singleton olarak implement edilmiştir.

**Veri Yapılarının Ayrı Sınıfa Alınması:** FelsefeDugumu ve FelsefeVeriTabani yapıları operasyonel sınıflardan (PhilosophyDataManager sınıfından) koparılarak, kendi C# dosyasına taşınmıştır.

## Kalite Faktörlerine ve Metriklerine Etkisi
Yapılan geliştirmelerin kalite faktörlerine etkisi yapılacak ölçümlerin ve testlerin kolaylaşmasını sağlamak yönünde olmuştur. Sınıfların LOC (Line of Code) değerleri azaltılarak okunması ve maintain edilmesi daha kolay hale getirilmiştir. Programın fonksiyonalitesine doğrudan bir etkisi olmadığı için kullanılacak metriklerde ve kalite faktörlerinde bir değişiklik öngörülmemiştir. Sınıflar artık farklı unit testler uygulamak için daha uygun bir yapıya sahip olmuştur.
## Görev Matrisi

| Döküman Gereksinimleri                     | Görev Alan Üye         |
| ------------------------------------------ | ---------------------- |
| Seçilen Geliştirme                         | Mustafa Alperen Coşkun |
| Efor Tahmini ve Gerekçelendirme            | Mustafa Alperen Coşkun |
| Tasarım Tercihleri Hakkında Açıklama       | Mustafa Alperen Coşkun |
| Kalite Faktörlerine ve Metriklerine Etkisi | Osman Kuru             |