# 📊 Entity Framework Core Masterclass Dashboard

![C#](https://img.shields.io/badge/C%23-%23239120.svg?style=flat-square&logo=csharp&logoColor=white)
![.NET 10](https://img.shields.io/badge/.NET%2010-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![Entity Framework Core](https://img.shields.io/badge/EF%20Core%2010-339933?style=flat-square&logo=nuget&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=flat-square&logo=microsoftsqlserver&logoColor=white)
![HTML5](https://img.shields.io/badge/HTML5-%23E34F26.svg?style=flat-square&logo=html5&logoColor=white)
![CSS3](https://img.shields.io/badge/CSS3-%231572B6.svg?style=flat-square&logo=css3&logoColor=white)
![JavaScript](https://img.shields.io/badge/JavaScript-%23323330.svg?style=flat-square&logo=javascript&logoColor=%23F7DF1E)

## 📖 Proje Hakkında

Bu proje, Entity Framework Core'un sunduğu LINQ sorgu metodlarını, asenkron işlemleri, varlık takibini (entity tracking) ve diğer temel yapıları gerçek bir veritabanı üzerinde pratik yapmak amacıyla geliştirdiğim bir masterclass dashboard uygulamasıdır. 

Projede ürün, sipariş, müşteri ve kategori yönetimini kapsayan işlevsel bir CRUD paneli oluşturdum. Ayrıca, 62 ayrı EF Core metodunu canlı olarak çalıştıran ve sonuçlarını ekranda gösteren özel bir "Entity Framework Core" sayfası tasarladım.

## 🚀 Kullanılan Teknolojiler 

* **C# & ASP.NET Core MVC (.NET 10):** Web uygulamasının temel iskeletini ve modüler arayüzünü oluşturmak için kullandım.
* **Entity Framework Core & SQL Server:** Veritabanı işlemlerini, tabloları C# nesneleri üzerinden yönetmek ve LINQ sorgularını çalıştırmak için ORM olarak kullandım.
* **X.PagedList:** Sipariş, müşteri ve ürün gibi listelerin bulunduğu sayfalarda veri gösterimini düzenlemek adına sayfalama (pagination) işlemlerini gerçekleştirdim.

## ✨ Özellikler

* **Dashboard:** Özet istatistikler ve aktivite akışını anlık olarak gösteren ana panel.
* **Temel CRUD Modülleri:** Kategori, Ürün, Sipariş ve Müşteri yönetimleri için tam kapsamlı listeleme, ekleme, silme ve güncelleme işlemleri.
* **Görev Yöneticisi (Todo):** Öncelik durumu, bitiş tarihi ve tamamlanma durumunu takip ettiğim görev yönetim sayfası.
* **İstatistikler:** Sipariş, ürün ve müşteri verileri üzerinden hesaplanan analizleri sunduğum raporlama sayfaları.
* **Entity Framework Core:** 62 farklı Entity Framework Core metodunun (sorgulama, asenkron, entity takibi) test edilebildiği uygulamalı demo sayfası.


## 🔬 EF Core Metod Referansları (62 Örnek)

Projede `EntityFrameworkCoreController` üzerinden aşağıdaki metodları gerçek verilerle kullandım ve sonuçlarını panelde listeledim:

#### 📊 Sorgulama Metodları
```text
1.  ToList()            : Tüm kayıtları listeye çevirir               | 2.  Add() / SaveChanges() : Yeni kayıt ekler ve işler
3.  Find()              : Primary key ile kayıt bulur                 | 4.  Remove() / SaveChanges: Kaydı siler
5.  SaveChanges()       : Değiştirilmiş entity'yi günceller           | 6.  Count()               : Kayıt sayısını döner
7.  Min()               : En küçük değeri bulur                       | 8.  Max()                 : En büyük değeri bulur
9.  Sum()               : Toplam hesaplar                             | 10. Average()             : Ortalama hesaplar
11. LongCount()         : long türünde sayım döner                    | 12. CountBy()             : Gruba göre sayım döner
13. Where()             : Filtreleme                                  | 14. Select()              : Projeksiyon
15. Include()           : İlişkili veri yükleme (Eager Loading)       | 16. FirstOrDefault()      : İlk veya varsayılan kaydı döner
17. First()             : İlk kaydı döner                             | 18. Last()                : Son kaydı döner
19. SingleOrDefault()   : Tekil sonuç döner                           | 20. Any()                 : Koşula uyan kayıt var mı?
21. All()               : Tüm kayıtlar koşulu sağlıyor mu?            | 22. Contains()            : İçerik kontrolü
23. StartsWith()        : Başlangıç kontrolü                          | 24. EndsWith()            : Bitiş kontrolü
25. AsQueryable()       : Sorgu oluşturma için IQueryable döner       | 26. AsNoTracking()        : Değişiklik takibini kapatır
27. DefaultIfEmpty()    : Boş koleksiyon için varsayılan değer        | 28. OrderBy()             : Artan sıralama
29. OrderByDescending() : Azalan sıralama                             | 30. Take()                : İlk N kaydı alır
31. Skip()              : İlk N kaydı atlar                           | 32. TakeLast()            : Son N kaydı alır
33. SkipLast()          : Son N kaydı atlar                           | 34. Reverse()             : Sıralamayı tersine çevirir
35. Chunk()             : Koleksiyonu parçalara böler                 | 36. Index()               : İndeksli projeksiyon (Select ile)
37. Distinct()          : Tekrarsız kayıtlar döner                    | 38. Union()               : İki sorguyu birleştirir (tekrarsız)
39. UnionBy()           : Belirtilen alana göre birleştirir           | 40. Concat()              : İki sorguyu birleştirir (tekrarlı)
41. Except()            : Fark kümesi döner                           | 42. ExceptBy()            : Alana göre fark kümesi
43. Intersect()         : Kesişim kümesi döner                        | 44. GroupBy()             : Gruplama yapar
45. GroupJoin()         : Sol dış birleşim (Left Outer Join)          | 46. Join()                : İç birleşim (Inner Join)
47. Append()            : Koleksiyonun sonuna eleman ekler            | 48. Prepend()             : Koleksiyonun başına eleman ekler
49. Aggregate()         : Birleştirici işlem uygular                  | 50. Cast<T>()             : Tip dönüşümü
51. OfType<T>()         : Belirtilen tipteki elemanları filtreler     | 52. AsParallel()          : Paralel sorgu işleme
```

#### ⚡ Asenkron Metodlar
```text
53. ToListAsync()       : Asenkron liste dönüşümü                     | 54. AddAsync()            : Asenkron ekleme ve işleme
55. FindAsync()         : Asenkron arama                              | 56. AddRange()            : Toplu ekleme
57. AddRangeAsync()     : Asenkron toplu ekleme ve işleme             | 58. AnyAsync()            : Asenkron var mı kontrolü
59. AllAsync()          : Asenkron tümü kontrolü 
```

#### 🔍 Entity Takibi (Change Tracker)
```text
60. Attach()            : Entity'yi Unchanged durumuyla takibe alır   | 61. AttachRange()         : Birden fazla entity'yi takibe alır
62. Entry()             : Entity'nin durum bilgisini sorgular
```

# 🏠 Dashboard

<img width="1901" height="939" alt="Image" src="https://github.com/user-attachments/assets/75871124-edfc-47ff-81db-e7016e06baa8" />
<img width="1898" height="939" alt="Image" src="https://github.com/user-attachments/assets/0eb07eab-86cc-4872-8b06-f046d8aae80b" />
<img width="1901" height="940" alt="Image" src="https://github.com/user-attachments/assets/14e748da-2d7f-4bc9-80d8-a71ae45d66e1" />
<img width="1898" height="938" alt="Image" src="https://github.com/user-attachments/assets/444903ec-2fd5-45ae-ba02-138af22b4021" />
<img width="1896" height="939" alt="Image" src="https://github.com/user-attachments/assets/269841c1-9bf5-4840-8e98-e3bb6108de04" />
<img width="1902" height="940" alt="Image" src="https://github.com/user-attachments/assets/387b7bbc-320b-49eb-a872-5e0fb8b89ce0" />
<img width="1899" height="943" alt="Image" src="https://github.com/user-attachments/assets/a968b368-d5cd-42a3-9cdf-e5b57c518071" />
<img width="1902" height="936" alt="Image" src="https://github.com/user-attachments/assets/f7506ad9-df24-4885-95fe-925d8a601f93" />
<img width="1900" height="938" alt="Image" src="https://github.com/user-attachments/assets/d2df555d-9ba9-44c1-89a7-d144339fc38e" />
<img width="1901" height="941" alt="Image" src="https://github.com/user-attachments/assets/83840224-2376-43c1-81dc-2ea33a47de85" />
<img width="1900" height="835" alt="Image" src="https://github.com/user-attachments/assets/c7d7794f-5d66-4312-a59c-0138527c64f9" />
<img width="1903" height="892" alt="Image" src="https://github.com/user-attachments/assets/f185da16-01f3-497a-8827-803354ac640c" />
<img width="1902" height="655" alt="Image" src="https://github.com/user-attachments/assets/2dc5297d-d60c-4f5d-9bf4-7b58bea62a9c" />
<img width="1896" height="919" alt="Image" src="https://github.com/user-attachments/assets/8fb4ce9a-e10e-4957-80b7-d830f1bde2f7" />
