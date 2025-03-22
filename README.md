# Bee - Arı Kovanı Yönetim Sistemi

## Proje Amacı

Hazırlanan projenin amacı, arıcılıkta verimliliği artırmak ve daha kaliteli ürünler ortaya çıkarmaktır. Bu sistem, periyodik bakımlar, muayeneler, uygulamalar ve veri tabanına eklenen kayıtlar üzerinden analiz yaparak "Nasıl daha verimli bir dönem geçiririz?" sorusuna yanıt aramaktadır. Amaç, geçmiş dönemlerde yapılan hataları ve eksiklikleri düzenleyerek her dönem daha fazla gelişim sağlamaktır.

Bu proje, önceden Windows Form uygulaması olarak geliştirilmiş bir arıcılık yönetim sisteminin yeniden tasarlanarak, daha gelişmiş bir web projesi haline getirilmiş versiyonudur.

## Proje İçeriği

Projede, kovanları görüntüleme, inceleme, belirli dönemlerde veya anlık olarak muayene ekleme, uygulama yapma ve iş planları düzenleme gibi işlemler bulunmaktadır.

### **Anasayfa**
Sisteme giriş yapıldığında ilk olarak karşıya çıkan sayfa burasıdır. Bu sayfada:
- Kovanlar hakkında anlık bilgiler
- Hangi arıcılık döneminde olunduğu ve bitimine kaç gün kaldığını gösteren bar
- Tarım ve Hayvancılık Bakanlığı tarafından verilen kovan etiketi için barkod/karekod okuyucu

### **Kullanıcı Menüsü**
- **Login**: Sisteme sadece yetkilendirilmiş kullanıcıların giriş yapabileceği sayfa.
- **Şifre Yenileme**: Şifresini unutan kullanıcılar için şifre yenileme sayfası.
- **Kullanıcı Ekleme**: Büyük çiftlikler ve işletmeler için ek kullanıcı ekleme sayfası.
- **Kullanıcı Listesi**: Kıdemli kullanıcıların diğer kullanıcıları görüntüleyip yönetebileceği sayfa.
- **Profil**: Her kullanıcının kendi bilgilerini görüp düzenleyebileceği sayfa.

### **Koloni Menüsü**
- **Koloni Kayıt**: Sisteme yeni kovan ekleme sayfası.
- **Koloni Listesi**: Sistemde kayıtlı kovanları listeleyip düzenleme yapma sayfası.

### **Muayene/Uygulama Menüsü**
- **Muayene/Uygulama Ekleme**: Sistemde kayıtlı kovanlara muayene ve uygulamalar ekleme sayfası.
- **Muayene/Uygulama Görüntüle**: Kayıtlı muayene ve uygulamaların listelendiği sayfa.

### **Hata Sayfaları**
- **Page 404**: 404 hatalarını gösteren sayfa.
- **Page 500**: 500 hatalarını gösteren sayfa.
- **Genel Hata**: Diğer hataların gösterildiği sayfa.

### **Shared**
- **Layout**: Projede tüm sayfalarda kullanılacak ortak tasarım bileşenlerini içeren sayfa.

---

## Projede Kullanılan Araçlar

- **Zircos** – Dashboard Admin Template
- **BytesCout Online Barcode Reader**

### **Geliştirme Ortamı, Programlama Dili ve Veri Tabanı**
- **Geliştirme Ortamı**: Visual Studio
- **Programlama Dili**: ASP.NET - MVC
- **Veri Tabanı**: Microsoft SQL Server

