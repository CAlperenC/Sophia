# Kabul Testleri ve Kabul Kriterleri
## İçindekiler:
1. Kabul Kriterleri Tanımları
2. Kabul Testleri
3. Test Kriter İlişkileri
## Katkıda Bulunanlar:
- Mustafa Alperen Coşkun
- Osman Kuru
- Emre Karaduman
## Kabul Kriterleri Tanımları
### Senaryo: Sıradaki Filtre Katmanını Atlama
**Kriter 1:** Kullanıcı kullanmak istemediği bir katmanı atlayabilmeli ve onun altındaki katmandan gezinme işlemine devam edebilmelidir. Bu atlama işlemi 0.7 saniyenin altında gerçekleşmelidir.
### Senaryo: Filozofa Tıklandığı Zaman Detaylı Görünümünü Vermesi
**Kriter 2:** Kullanıcı filozofa tıkladığında gerekli panelin açılması ve açıklama metninin taşmayacak şekilde panel içerisinde göstermeli, detaylı bilgi butonlarına tıklayınca kullanıcının cihazında tarayıcı üzerinden ilgili linke yönlendirmelidir. En önemlisi ilgili filozof için JSON dosyasından doğru verinin çekilmiş olması gerekmektedir.
### Senaryo: Node Ağacında Gezinme
**Kriter 3:** Kullanıcı ağaç sayfasında bir butona tıklayınca bir sonraki katmandaki alt butonları açılmalıdır. Hiçbir buton birbiriyle üst üste binmemelidir, butonların tanımlanmış formüldeki konumlarda instantiate edildiği doğrulanmalıdır. Kullanıcı açık bir butona tıkladığında altındaki bütün butonlarla beraber kapanmalıdır. Kullanıcı aynı katmanda açık bir buton varken farklı bir butona tıklarsa diğer buton ve altındaki butonlar kapanmalıdır. Bu işlemlerin hepsi butona tıklandığında 0.5 saniye altında gerçekleşmelidir. Fonksiyonel olmayan gereksinimlerden uygulamanın akıcı ve sorunsuz çalıştığını doğrulamak için fps değerinin 25 üzerinde olması gerekmektedir.
### Senaryo: Felsefe Quizi
**Kriter 4:** Kullanıcı ana menüden “Test Yourself” butonuna tıklayınca quiz menüsüne erişebilmelidir. JSON dosyasından soruların doğru bir şekilde okunması ve arayüze yazılması gerekmektedir. Quiz menüsünde şıklara tıklayarak sorulara cevap verebilmeli ve cevabının doğru olup olmadığını görebilmelidir. Soruya cevap verdikten sonra ekranın alt kısmından bir sonraki soruya geçebilmelidir. Ekranın sol üst köşesindeki butona basarak ana menüye dönebilmelidir.
## Kabul Testleri
### Test 1: Katman Atlama Testi
Uygulamada ağaç sayfası açılır, en üstte felsefe butonu bulunmaktadır. Bu felsefe butonuna tıklanır, 6 alt felsefe dalı ve ana butonda düzleştir kısmının gelmesi gerekir. Bu düzleştir kısmına tıklanır ve daha önce açılmış olan alt dallar yerine onların alt dalları gelmelidir. Düzleştir butonuna tıklama işlemi tekrarlanmaya devam eder, en son bütün filozoflar ana butonun alt dalı olarak ekrana gelmelidir. Son bir kez daha tıklanınca daha fazla atlanacak katman olmadığı için ana butonun bilgi paneli açılmalıdır. Test sırasında scripte eklenecek zaman ölçme kodlarıyla işlemin ne kadar hızlı gerçekleştirildiği bulunacaktır, bilgisayar üzerinde 0.4 saniyenin altında olması beklenmektedir.
### Test 2: Filozofa Tıklandığı Zaman Detaylı Görünümün Verilmesi
Uzun bir placeholder açıklamaya sahip dummy filozof verisi yaratılır. Ağaç yapısında bu filozofun olduğu kısım açılıp butonuna tıklanır. Ekranda Bilgi Paneli’nin açılması ve uzun text’in panel dışına çıkmadan gösterilmiş olması beklenmektedir. Ayrıca detaylı bilgi butonuna tıklanınca filozofa ait placeholder linki açmaya çalışması gerekmektedir.
### Test 3: Node Ağacında Gezinme
Ağaç sayfası açılır ve şu işlemler gerçekleştirilir:
- Felsefe butonuna tıklanır. Bunun sonucunda alt dalların açılması beklenmektedir.
- Açılan alt dalların ikisine sırayla tıklanır. İkinciye tıklandığı zaman ilk tıklananın kapanması beklenmektedir.
- En tepedeki Felsefe butonuna tekrar tıklanır. Bütün açılmış butonların kapanması beklenmektedir.
- Felsefe butonuna tekrar tıklanır ve açılan düzleştir butonuna filozof katmanına inene kadar tıklanır. Bu tıklamaların hepsinin sonucunda yeni oluşan butonların tamamen ayrık şekilde instantiate edilmesi beklenmektedir.
Bu işlemler gerçekleştirilirken script’e eklenecek zaman ölçme kodlarıyla işlemin ne kadar hızlı gerçekleştirildiği bulunacaktır. 0.3 saniyenin altında olması beklenmektedir. Unity Profiler yardımıyla fps analizi yapılacak ve 25 üzerinde olması beklenecektir.
### Test 4: Quiz Arayüzü
Uygulamanın ana menüsü açılır ve "Test Yourself" butonuna tıklanır. Quiz arayüzünün sorunsuz bir şekilde açıldığı doğrulanır. Test amaçlı hazırlanmış bir JSON dosyasından çekilen ilk sorunun ve ilgili şıkların ekrandaki UI bileşenlerine (metin kutuları, butonlar vb.) doğru bir şekilde aktarıldığı kontrol edilir. Rastgele bir şıka tıklanır; sistemin cevabın doğruluğunu veya yanlışlığını arayüz üzerinden (örneğin renk değişimi veya ikonlar aracılığıyla) anında gösterdiği doğrulanır. Ekranın alt kısmında bulunan buton kullanılarak bir sonraki soruya geçilir ve JSON'dan sıradaki sorunun arayüze başarıyla yüklendiği gözlemlenir. Son olarak, ekranın sol üst köşesindeki butona tıklanarak uygulamanın ana menüye eksiksiz bir şekilde geri döndüğü test edilir.
## Test Kriter İlişkileri
### Test 1 - Kriter 1: 
Bu test, katman düzleştirme mantığına odaklanmaktadır. Felsefe butonunun altındaki sıradaki katmanları atlayarak düzleştirme özelliğini test eder ve kriter 1’de istenilen özelliğin doğru çalıştığını doğrular.
### Test 2 - Kriter 2:
Bu test, veri bütünlüğünü sağlar. Belirli bir filozofun sayfasını açarak, Bilgi Panelinin Kriter 2‘de belirtilen biyografi verilerini tam olarak gösterdiğini doğrudan doğrular ve veri bağlama mekanizmasının ve text sığdırma işleminin doğru çalıştığını kanıtlar.
### Test 3 - Kriter 3:
Bu test, hiyerarşik yapıyı doğrular. Düğümler arasında gezinerek, Kriter 3'ün ebeveyn-çocuk ilişkilerinin ve tıklanabilirlik gereksinimlerinin kullanıcı arayüzü hatası olmadan korunduğuna dair kanıt sağlar. Ayrıca kullanımın akıcılığını ölçülen metriklerle doğrular.
### Test 4 - Kriter 4: 
Bu test, felsefe quiz modülünün uçtan uca işlevselliğini doğrular. Kriter 4'te belirtilen sahne/menü geçişlerinin (ana menüden quiz'e ve quiz'den ana menüye dönüş), JSON dosyasındaki soru verilerinin UI bileşenlerine hatasız aktarımının, kullanıcı etkileşimine verilen anlık geri bildirimlerin (doğru/yanlış kontrolü) ve soru atlama mekanizmasının hedeflendiği gibi çalıştığını kanıtlar.
## Görev Matrisi

| Döküman Gereksinimleri | Görev Alan Üye         |
| ---------------------- | ---------------------- |
| Kriter Tanımları       | Osman Kuru             |
| Kabul Testleri         | Mustafa Alperen Coşkun |
| Test Kriter İlişkileri | Emre Karaduman         |