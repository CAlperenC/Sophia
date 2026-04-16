# Test Sonuçları Raporu
## İçindekiler:
1. Test Sonuçlarına Genel Bakış
2. Test Sonuçları Analizi
3. Log ve Output'lar
## Katkıda Bulunanlar:
- Mustafa Alperen Coşkun
- Osman Kuru
- Emre Karaduman
## Test Sonuçlarına Genel Bakış
### Test 1: 
**Test Durumu: Başarılı**
İlgili test Unity içerisinde ve mobil cihazda olmak üzere iki platformda gerçekleştirilmiştir. Node ağacına dair istenilen sonuca her iki platformda da ulaşılmıştır. Script’e eklenen süre ölçmek için kullanılan kod bloğu sayesinde düzleştir özelliğinin çalışma süresinin kabul edilebilirliği doğrulanmıştır.
### Test 2: 
**Test Durumu: Başarılı**
Test için dummy filozof oluşturulup içerisine uzun bir metin koyulmuştur. Taşma işleminin engellenmesi için auto-sizing ayarı açılmıştır ancak bu yeterli olmayınca truncate özelliği de eklenip text’in ilgili alanda kalması sağlanmıştır.
### Test 3: 
**Test Durumu: Başarılı**
Testte sözü edilen ağaç üzerinde gezinme mekanizmasının beklenildiği gibi çalıştığı doğrulanmıştır. Fps ölçümü Unity Editor’de yapılmıştır, farklı platformlarda gerçekleştirmek testin doğruluğunu artıracak olsa da yeterli zaman kalmadığı için yapılamamıştır. Editor’de fps 550-600 arasında değişkenlik göstermektedir, en karmaşık sahne yapısında ise yaklaşık 50 fps düşüş olmuştur. Verinin daha anlamlı hale gelmesi için platform sayısının artırılması gerekir ancak ilk ölçümlerde bir sıkıntıya rastlanmamıştır.
### Test 4: 
**Test Durumu: Başarılı** 
Ana menüden "Test Yourself" butonuna tıklandığında quiz sahnesi sorunsuz bir şekilde yüklenmiştir. Hazırlanan test JSON dosyasındaki sorular, cevap şıklarıyla birlikte UI bileşenlerine eksiksiz bir şekilde aktarılmıştır. Kullanıcı bir şıkkı seçtiğinde, sistem anında renk değişimi (doğru için yeşil, yanlış için kırmızı) ile geri bildirim vermiş ve ardından ekranın altındaki buton ile bir sonraki soruya başarılı bir şekilde geçiş yapılmıştır. Sol üstteki buton ile ana menüye dönüş işlemi de herhangi bir takılma yaşanmadan gerçekleşmiştir.  
## Test Sonuçları Analizi
### Test 1:
Yapılan test başarılı olmuş, fonksiyonalite beklendiği gibi sağlanmıştır. Ölçülen sürelere bakıldığında en yoğun düzleştirme işleminin 7.7 ms sürdüğü gözlemlenmiştir. Bu uygulamanın veri setinin daha büyük bir boyuta ulaştığı durumda da performanslı şekilde çalışabileceğini gösterir.
### Test 2: 
Test başarılı olmuştur. Auto-sizing ile yazının olabileceği en küçük boyut 18 punto olarak belirlenmiştir.
### Test 3: 
Yapılan test başarılı olmuş denilebilir, uygulamanın testin gerçekleştirildiği cihazın Unity Editor environment’ında, test edilen şartlar altında kritik bir performans düşüşüne sebep olmadığı gözlemlenilmiştir. Lakin test sonucunun geçerliliğinin arttırılabilmesi açısından hedeflenilen mobil platformlar üzerinden de test edilmesi faydalı olacaktır. 
### Test 4: 
Yapılan test başarılı olmuş ve quiz modülünün uçtan uca eksiksiz çalıştığı doğrulanmıştır. JSON dosyasından veri okuma (deserialization) ve bu verilerin UI bileşenlerine aktarılması işlemi gecikme yaşanmadan, eşzamanlı olarak gerçekleşmiştir. Soru cevaplama mekanizması sırasındaki durum (state) yönetimi doğru çalışmış, sıradaki soruya geçilirken önceki sorunun verileri temizlenip yeni veriler arayüze hatasız bir şekilde yüklenmiştir. Sahne geçişleri (Scene Management) sırasında memory leak veya veri kaybı gözlemlenmemiştir. 
## Log ve Output'lar
![TestLog1]([https://github.com/CAlperenC/Sophia/blob/main/Dok%C3%BCmanlar/Dok%C3%BCman%20G%C3%B6rselleri/AnaMen%C3%BCAray%C3%BCz%C3%BC.jpeg](https://github.com/CAlperenC/Sophia/blob/main/Dok%C3%BCmanlar/Dok%C3%BCman%20G%C3%B6rselleri/testlog1.png)
![TestLog2]([https://github.com/CAlperenC/Sophia/blob/main/Dok%C3%BCmanlar/Dok%C3%BCman%20G%C3%B6rselleri/AnaMen%C3%BCAray%C3%BCz%C3%BC.jpeg](https://github.com/CAlperenC/Sophia/blob/main/Dok%C3%BCmanlar/Dok%C3%BCman%20G%C3%B6rselleri/testlog2.png)
![TestLog3]([https://github.com/CAlperenC/Sophia/blob/main/Dok%C3%BCmanlar/Dok%C3%BCman%20G%C3%B6rselleri/AnaMen%C3%BCAray%C3%BCz%C3%BC.jpeg](https://github.com/CAlperenC/Sophia/blob/main/Dok%C3%BCmanlar/Dok%C3%BCman%20G%C3%B6rselleri/testlog3.png)
## Görev Matrisi

| Döküman Gereksinimleri       | Görev Alan Üye                       |
| ---------------------------- | ------------------------------------ |
| Test Sonuçlarına Genel Bakış | Mustafa Alperen Coşkun               |
| Test Sonuçları Analizi       | Mustafa Alperen Coşkun ve Osman Kuru |
| Log ve Output'lar            | Mustafa Alperen Coşkun               |
