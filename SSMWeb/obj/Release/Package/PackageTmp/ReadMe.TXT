Uygulama internet Explorer da en verimli sekilde caismaktadir. Javascript vb betiklerin kosturulmasina izin verilmelidir.
Bunun icin su article daki ayar yapilmali (su an valid SSL sertifikamiz olmadigi icin bu ayari yapmak zorundayiz)
https://support.microsoft.com/en-us/kb/2625928



Uygulamanin kurulmasi icin adim adim asagidakiler yapilmalidir:

Azure uzerinde yeni bir veritabani olusturulur.
Olusturulan veritabaninin baglanti bilgileri WebConfig dosyasina girilir
Uygulama IIS e deploy edilerek calistirilir.
userManagement.sql dosyasi kosturulur.
admin ile login olunur, shipment ana sayfa bir kez goruntulenir
sampleLocation.sql komutu calistirilir.
functions.sql komutu calistirilir.
SQL Server Management Studio > Tools > Options > Designers > Prevent saving changes that require drop ile ilgili checkbox kaldirilir
Orders tablosuna gidilerek ([dbo].[getRequestedAmountRequested]([Id])) ve ([dbo].[getSoldAmountRequested]([Id])) bilgileri ilgili kolonlara computed field operation olarak tanimlanir.
!! Cost of goods tanimlamayi unutmayin aksi takdirde order tablosunda requested ve sold amount lar hesaplanmayacaktir !!