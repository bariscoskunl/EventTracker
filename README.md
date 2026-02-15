# 📅 EventTracker - Etkinlik Yönetim Sistemi

Etkinliklerinizi dijital ortamda planlamanıza, yönetmenize ve kritik olanları en başa sabitlemenize (pin) olanak tanıyan profesyonel bir **Full-Stack ASP.NET Core MVC** uygulaması.

---

## 🚀 Öne Çıkan Özellikler

* **Dinamik Sabitleme (Pinning System):** Önemli etkinlikleri ana sayfada kart görünümüyle en üstte tutun.
* **Tam CRUD Döngüsü:** Etkinlik oluşturma, düzenleme, detaylı görüntüleme ve güvenli silme operasyonları.
* **Gelişmiş Tablo Yönetimi:** Bootstrap 5 ile dikey hizalanmış (align-middle), gölge efektli (shadow) ve responsive liste yapısı.
* **Hukuki Uyumluluk:** Profesyonel bir uygulama standardı olan yerleşik "Gizlilik Politikası" sayfası.
* **Veri Yönetimi:** Entity Framework Core ile sağlam veritabanı mimarisi ve `DbSeeder` ile otomatik örnek veri üretimi.

---

## 📸 Uygulama Görselleri

### 🏠 Ana Sayfa (Sabitlenmiş Etkinlikler)
![Sabitlenmiş Etkinlikler](main.png)

### 📊 Etkinlik Listesi
![Tüm Etkinlikler](list.png)

### 📝 Detay ve Düzenleme
![Etkinlik Detayları](details.png)
![Etkinlik Düzenle](edit.png)

### 🔐 Gizlilik Politikası
![Gizlilik Politikası](privacy.png)

### 🗑️ Silme Onayı
![Etkinliği Sil](delete.png)

---

## 🛠️ Teknolojik Altyapı

* **Backend:** C#, ASP.NET Core 8.0 MVC
* **Data Access:** Entity Framework Core 
* **Frontend:** Bootstrap 5, HTML5, CSS3
* **Veritabanı:** SQL Server (LocalDB)

---

## 🔧 Kurulum ve Çalıştırma

1. **Repo'yu Klonlayın:** `git clone https://github.com/bariscoskunl/EventTracker.git`
2. **Veritabanı Hazırlığı:** `appsettings.json` dosyasındaki bağlantı dizesini kontrol edin.
3. **Migration & Seed:** Projeyi doğrudan başlatın; `DbSeeder` sayesinde örnek veriler otomatik olarak yüklenecektir.
4. **Uygulamayı Başlatın:** Visual Studio üzerinden `F5` veya `dotnet run`.


