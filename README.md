# BlogApp
## N-Tier Architecture in ASP.NET Core MVC &amp; React Native

`Bilge Adam Teknoloji` tarafından `Murat Vuranok` eğitmenliğinde gerçekleştirilen 5 günlük `.Net Core ile Uygulama Geliştirme` baslikli eğitim süresince oluşturulmuştur.

### Proje Yapısı
![Katmanlı Mimari](https://github.com/omereryilmaz/Algorithms/blob/master/LongestCommonSubsequences/img/1.jpg)

**Data Access Layer:** Veri katmanına erişim sağlayacak. İçerisinde modeller ve veritabanıyla haberleşilen context yapısı yer aldığı katmandır.

**Business Logic Layer:** Servisler ve contract’lar yer aldığı katmandır.

**Root:** Proje WebUI ve Web API olarak iki bölümden oluşmaktadır. Bu iki projeden de servislerin inject edilebildiği katmandır.

**WebUI:** Blog kontrol panelinin oluşturulacağı katmandır. 
	
**Web API:** Bilgilerin servis olarak dışarıya sunulacağı katmandır.
	
### Proje Geliştirme Ortamı
Visual Studio Code

