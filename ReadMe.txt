NTier Proje Ad�mlar�

1)NTierProject.Core C# Library a��l�r. Entity Framework y�klenir.
	1.1)Entity klas�r� a��l�r.
		1.1.1)IEntity a��l�r. Core Entity buradan miras alacakt�r.
		1.1.2)Core Entity a��l�r. T�m entitylerin kullanaca�� property'ler burada tan�mlan�r.
	1.2)Enum a��l�r. ��erisine status'ler eklenir.
	1.3)Map a��l�r temel entity property'lerinin mapleme i�lemleri yap�l�r.
	1.4)Servis a��l�r. ��erisine ICoreService interface a��l�r. Her entity �zernde �al��acak olan methotlar tan�mlan�r. G�vdeleri bo� b�rak�l�r sadece isimlendirilir.

2)Model C# Library a��l�r. NTier.Core referans eklenir.
	2.1)Option kals�r� a��l�r.
		2.1.1)AppUser,Category ve Product ...... entityleri olu�turulur. Hepsi CoreEntity s�n�f�ndan miras al�mal�d�r. Bu sayede ortak propertylere eri�im sa�lanacakt�r.

3)Map C# Library a��l�r. Entity Framework y�klenir. Referanc'lara Core ve Model eklenir.
	3.1)Iption klas�r� a��l�r.
		3.1.1)Her entit i�in map i�lemleri ger�ekle�tirilir. (Category ve product aras�ndaki ili�ki durumu belirtilir.

4)Utility katman� C# Library eklenir. Referanslara Core katman� verilir. Criptografi, Imageloader or ImageResizer, RemoteIp gibi ortak i�lemler bu katmanda class'lar oalrak te�ekk�l ettirilir. B�t�n bir projede yaarlanaca��m yukar�da belirtilen yap�lar in�a edilir.

5)DAl katman� C# Library eklenir olu�turulur. Entity Framework y�klenir. Referans'lara Core, Map, Model, Utility katmanlar� eklenir. Context klas�r� a��l�r i�erisine Project Context s�n�f� olu�turulur.
	5.1)Constructor ile db connection yaz�l�r.
	5.2)OnModelCreating override edilir ve map'ler konfigurasyonlara eklenir.
	5.3)SaveChanges override edilir ve y�kleme a�amas�nda temel property'ler i�erisinde de�erler eklenir.

6)Console �zerinden DAL projesi se�ilerek enable-migrations edilir.

7)Service katman� C# Library eklenir yaz�l�r. EntityFramework y�klenir. Referance'lere Core,DAl, Model eklenir. Sevice Base i�erisinde genel oalrak kullan�lacak olan metotlar genel kullanlacak metotlar generic (genel) �ekilde yaz�l�r. ICOreService interface'ten miras al�narak devam edilir.
	7.1)Option klas�r� a��l�r. ��erisnde t�m entitylerimiz service s�n�flar� a��l�r ve ServiceBase'den miras al�n�r. Entity'e �ezel bir metoot var ise (checkCredentails, sortby categoryname vb)bu metotlar s�n�flar�n i�erisine eklenir.