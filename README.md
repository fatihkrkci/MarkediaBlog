# Markedia Blog
Bu proje M&Y Yazılım Eğitim Akademi Danışmanlık bünyesinde Murat Yücedağ eğitmenliği tarafından verilen eğitim kapsamındaki 3. projedir.

## İnternet Sitesi
Markedia Blog internet sitesi; kullanıcılarına blogları görüntüleyebilecek, detay sayfasında okuma yapabilecek ve Markedia Blog Bülteni'ne abone olabilecek bir arayüz sunmaktadır.
Ayrıca hem sitenin sağ tarafında hem de footer'da bulunan "Son Eklenen Yazılar", "En Çok Okunanlar" ve "Kategoriler" başlıkları ile hızlı bakış atabiliyorlar. Bu başlıkların verileri veritabanından
dinamik olarak gelmektedir.

- Açılış ekranında "Son Eklenen Yazı"yı gösteren bir banner.
- Banner üzerinde "Bültenimize Abone Ol" alanı ile bültene kayıt.
- Her sayfada 3 blog olacak şekilde sayfalama.
- Listelenen blogların kategori, yazar, yayınlanma tarihi ve görüntülenme sayısını içeren dinamik alanlar.
- Blog Detay Sayfasında yazıyı yazan yazara ait kişisel bilgiler ve sosyal medya hesap alanı.
- Bloğun detay sayfasında o bloğa yazılan yorumların görüntülendiği alan ve yeni yorum bırakma alanı.
- Yorum yapabilme işlemi için hesap bulunması zorunluluğu ve bunun kontrolünün sağlanması.

## Admin Paneli
Sistemin adminlerinin erişebildiği bu panelde sistem yöneticisi "Kategori İşlemleri" ve "Makale İşlemleri" yapabilmektedir.

- Dashboard ekranında sisteme hızlı bakış atabilecekleri istatistikler bulunmaktadır.
- Kategori İşlemlerinde; temel ekleme/silme/güncelleme/listeleme işlemleri yapılabilmektedir.
- Makale İşlemlerinde ise admin; yazarların kendilerine ait panelleri üzerinden yazdıkları blog yazılarını görüntüleyip, "Onayla" veya "Reddet" seçenekleriyle yazının Markedia Blog internet sitesinde yayınlanıp
yayınlanmayacağına karar verdikleri işlemler bulunmaktadır. Yani bir yazarın yazdığı yazı internet sitesinde yayınlanmadan önce adminin onayından geçmesi gerekir.

## Yazar Paneli
Markedia Blog yazarlarının erişebildikleri bu panelde yazarlar "Kişisel Bilgilerini Güncelleme", "Makale İşlemleri", "Yorum İşlemleri", "Sosyal Medya Hesaplarım" gibi işlemleri gerçekleştirebilmektedirler.

- Dashboard ekranında sisteme hızlı bakış atabilecekleri istatistikler bulunmaktadır.
- Profilim sayfasından kişisel bilgilerini görüntüleyip, güncelleyebilirler.
- Makale İşlemleri sayfasında; yeni bir makale yazabilir veya yazdıkları makaleler üzerinde düzenleme/silme işlemleri yapabilirler.
- Yorum İşlemleri sayfasında; yazdıkları yorumları görüntüleyip düzenleme/silme işlemlerini yapabilirler.
- Sosyal Medya Hesapları sayfasında ise yeni bir sosyal medya hesabı ekleyebilir, varolanı güncelleyebilir veya silebilirler.

## Proje Özellikleri
- Projede 20'ye yakın tablo kullanıldı ve veritabanı olarak MSSQL tercih edildi.
- Entity Framework ile Code First yaklaşımıyla geliştirildi.
- Çeşitli scriptler (dinamik fatura ve fatura kalemleri oluşturma scriptleri, adedi ve fiyatı girilen ürünlerin toplam tutarının otomatik hesaplanmasını sağlayan scriptler) kullanıldı.
- Harici kütüphanelerin eklenmesiyle Karekod oluşturma işlemleri yapıldı.
- Oturum yönetimi Session ile gerçekleştirildi. Güvenlik için Authorize ve Authentication'lar kullanıldı.
- Google Charts ve Sweet Alert kullanıldı.
- Projemize özel hata sayfaları (403, 404, 500) oluşturuldu.

## Kullanılan Teknolojiler
- Asp.Net Core 6.0
- Repository Design Pattern
- Identity Kütüphanesi
- Entity Framework / Code First
- N Katmanlı Mimari
- MSSQL Veritabanı
- LINQ Sorguları / Sweet Alert
- DataTable / Pagination / Searching

## Ekran Görüntüleri
![default](https://github.com/user-attachments/assets/c9727753-947f-43b5-92af-385fe4943974)
![login](https://github.com/user-attachments/assets/bb93ebad-4cd6-42e5-a055-215ab8ac5b2a)
![admin-dashboard](https://github.com/user-attachments/assets/5956ed53-2c3b-41cb-97bc-bb71caf7a8a4)
![admin-kategorilistesi](https://github.com/user-attachments/assets/b02286c0-5ca9-44b4-8ae9-0b89d4e34595)
![admin-onaybekleyenler](https://github.com/user-attachments/assets/dbe2abe1-d702-4203-bdb2-05ee21a2994b)
![yazar-dashboard](https://github.com/user-attachments/assets/91154964-4c9c-418a-8d63-4bd6f8909ea9)
![yazar-profilim](https://github.com/user-attachments/assets/24a2e29d-75aa-4164-b20c-cd59e0e30260)
![yazar-makale](https://github.com/user-attachments/assets/c06bd4a7-936a-485a-bb41-11b15b591d55)
![yazar-yorum](https://github.com/user-attachments/assets/cacbcffe-a297-4736-bee9-fc753997e484)
![yazar-sosyalmedyaekle](https://github.com/user-attachments/assets/18832ae3-e55a-44c2-a666-29d87160f25f)
