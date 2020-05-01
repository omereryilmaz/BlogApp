# BlogApp
## N-Tier Architecture in ASP.NET Core MVC &amp; React Native

Bu proje, `Bilge Adam Teknoloji` tarafından `Murat Vuranok` eğitmenliğinde gerçekleştirilen 5 günlük `.Net Core ile Uygulama Geliştirme` başlıklı eğitim süresince oluşturulmuştur.

### Proje Yapısı
![Katmanlı Mimari](https://github.com/omereryilmaz/BlogApp/blob/master/readme_img/blogapp_katman.png)

**Data Access Layer:** Veri katmanına erişim sağlayacak. İçerisinde modeller ve veritabanıyla haberleşilen context yapısı yer aldığı katmandır.

**Business Logic Layer:** Servisler ve contract’lar yer aldığı katmandır.

**Root:** Proje WebUI ve Web API olarak iki bölümden oluşmaktadır. Bu iki projeden de servislerin inject edilebildiği katmandır.

**WebUI:** Blog kontrol panelinin oluşturulacağı katmandır. 
	
**Web API:** Bilgilerin servis olarak dışarıya sunulacağı katmandır.
	

### Proje Geliştirme Ortamı
[Visual Studio Code](https://code.visualstudio.com/)


### WebUI
**Tasarım:** [SB Admin](https://startbootstrap.com/templates/sb-admin/).

**Kategori kontrol paneli:**
![WebUI-Kategori](https://github.com/omereryilmaz/BlogApp/blob/master/readme_img/webui_1.png)

**Post kontrol paneli:** 
Çoklu kategori seçimi
![WebUI-Kategori](https://github.com/omereryilmaz/BlogApp/blob/master/readme_img/webui_2.png)

Sürükle bırak çoklu resim yükleme
![WebUI-Kategori](https://github.com/omereryilmaz/BlogApp/blob/master/readme_img/webui_3.png)


### WebAPI
![WebUI-Kategori](https://github.com/omereryilmaz/BlogApp/blob/master/readme_img/webapi_1.png)

![WebUI-Kategori](https://github.com/omereryilmaz/BlogApp/blob/master/readme_img/webapi_2.png)


### React-Native Mobil Uygulama
![WebUI-Kategori](https://github.com/omereryilmaz/BlogApp/blob/master/readme_img/react-native.gif)


