# Deployment Planı
## İçindekiler:
1. Deployment'a Genel Bakış
2. Deployment Süreci
3. Konfigürasyon Planı
## Katkıda Bulunanlar:
- Mustafa Alperen Coşkun
- Osman Kuru
- Emre Karaduman
## Deployment'a Genel Bakış
Proje Unity oyun motoru ile geliştirilmiştir, bunun sonucu olarak Unity’nin sunduğu build aracı ile kolay şekilde build alınabilmektedir. Proje demosu için geliştirilen uygulamanın Unity build aracı ile android için build’i alınmıştır ve mobil cihaza kurulumu gerçekleştirilmiştir.

Ayrıca teknik detayların açıklanmasını kolaylaştırdığı için Unity oyun motorunun çalıştırma ekranında da çalışan hali sunulmuştur.

**Kullanılan araçlar:** Unity Engine 6.3 LTS (6000.3.8f1), Android SDK (oyun motoru içerisine kurulmuştur)
**Sunulduğu Platform:** Android
**Minimum İşletim Sistemi:** Android 7.1 (API 25)
**Hedef İşletim Sistemi:** Android 14.0+ (API 34+)
**Donanım Mimarisi:** 64-bit (ARM64)
## Deployment Süreci
Github sayfası kullanılarak projenin demoya hazırlanması için şu süreç izlenir:
1. Github üzerinden proje bilgisayara indirilir.
2. Proje Unity ile açılır. Proje Unity Engine 6.3 LTS sürümünde yapılmıştır. Editör sürümü olarak (6000.3.8f1) kullanıldığından bu Unity sürümü kullanılmalıdır. Proje Unity Hub üzerinden başlatıldığında otomatik olarak, manifest.json dosyasında tanımlı olan paketleri ve asset meta verileri çözümlenerek yerel library dizini oluşturulur.
3. Build işlemi için gerekli ayarlar yapılır. File > Build Settings üzerinden platform “Android” olarak değiştirilir. Uygulama ikonu, paket adı (com.Sophia.App) ve minimum API seviyesi ayarları kontrol edilir.
4. Build butonuna basılarak .apk dosyası oluşturulur.
5. Oluşturulan dosya USB kablosu ile hedef android cihaza ulaştırılır ve kurulumu yapılır (Android cihazda “bilinmeyen kaynaklar” seçeneğine izin verilmesi gereklidir).
## Konfigürasyon Planı
Uygulamanın çalışabileceği en düşük Android sürümü API 25 olarak belirlenmiştir. Bu durum uyuglamanın geniş bir android cihaz yelpazesinde çalışabileceğini göstermektedir. Hedeflenen API seviyesi ise 34 olarak belirlenmiştir. Bu da demonun gerçekleştirileceği cihaz için uygun bir üst seviye sunmaktadır. Debug logs disabled olarak işaretlenmiştir. UI hizalamasının bozulmaması için Player Settings menüsünden Default Orientation seçeneği Portrait Only olarak değiştirilmiştir. Build app bundle seçeneği demo için işaretlenmemiştir (İlerleyen süreçte Play Store’a yüklemek için bu seçenekle build alınacaktır). Build almak için doldurulması gereken Package Name alanına, “com.SophiaTeam.Sophia” yazılmıştır.
## Task Matrix

| Doküman Gereksinimleri   | Görev Alan Üye         |
| ------------------------ | ---------------------- |
| Deployment'a Genel Bakış | Mustafa Alperen Coşkun |
| Deployment Süreci        | Mustafa Alperen Coşkun |
| Konfigürasyon Planı      | Emre Karaduman         |
