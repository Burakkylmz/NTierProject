NTier Proje Adýmlarý

1)NTierProject.Core C# Library açýlýr. Entity Framework yüklenir.
	1.1)Entity klasörü açýlýr.
		1.1.1)IEntity açýlýr. Core Entity buradan miras alacaktýr.
		1.1.2)Core Entity açýlýr. Tüm entitylerin kullanacaðý property'ler burada tanýmlanýr.
	1.2)Enum açýlýr. Ýçerisine status'ler eklenir.
	1.3)Map açýlýr temel entity property'lerinin mapleme iþlemleri yapýlýr.
	1.4)Servis açýlýr. Ýçerisine ICoreService interface açýlýr. Her entity üzernde çalýþacak olan methotlar tanýmlanýr. Gövdeleri boþ býrakýlýr sadece isimlendirilir.

2)Model C# Library açýlýr. NTier.Core referans eklenir.
	2.1)Option kalsörü açýlýr.
		2.1.1)AppUser,Category ve Product ...... entityleri oluþturulur. Hepsi CoreEntity sýnýfýndan miras alýmalýdýr. Bu sayede ortak propertylere eriþim saðlanacaktýr.

3)Map C# Library açýlýr. Entity Framework yüklenir. Referanc'lara Core ve Model eklenir.
	3.1)Iption klasörü açýlýr.
		3.1.1)Her entit için map iþlemleri gerçekleþtirilir. (Category ve product arasýndaki iliþki durumu belirtilir.

4)Utility katmaný C# Library eklenir. Referanslara Core katmaný verilir. Criptografi, Imageloader or ImageResizer, RemoteIp gibi ortak iþlemler bu katmanda class'lar oalrak teþekkül ettirilir. Bütün bir projede yaarlanacaðým yukarýda belirtilen yapýlar inþa edilir.

5)DAl katmaný C# Library eklenir oluþturulur. Entity Framework yüklenir. Referans'lara Core, Map, Model, Utility katmanlarý eklenir. Context klasörü açýlýr içerisine Project Context sýnýfý oluþturulur.
	5.1)Constructor ile db connection yazýlýr.
	5.2)OnModelCreating override edilir ve map'ler konfigurasyonlara eklenir.
	5.3)SaveChanges override edilir ve yükleme aþamasýnda temel property'ler içerisinde deðerler eklenir.

6)Console üzerinden DAL projesi seçilerek enable-migrations edilir.

7)Service katmaný C# Library eklenir yazýlýr. EntityFramework yüklenir. Referance'lere Core,DAl, Model eklenir. Sevice Base içerisinde genel oalrak kullanýlacak olan metotlar genel kullanlacak metotlar generic (genel) þekilde yazýlýr. ICOreService interface'ten miras alýnarak devam edilir.
	7.1)Option klasörü açýlýr. Ýçerisnde tüm entitylerimiz service sýnýflarý açýlýr ve ServiceBase'den miras alýnýr. Entity'e öezel bir metoot var ise (checkCredentails, sortby categoryname vb)bu metotlar sýnýflarýn içerisine eklenir.