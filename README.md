## assignment-2-template


Odev kapsaminda sadece TransactionController uzerinde 1 tane GetByParameter apisi hazirlayiniz. Query Parameter olarak asagidaki filtre ozelliklerini ekleyiniz. 

Filtre kriterleri: AccountNumber, MinAmountCredit, MaxAmountCredit,MinAmountDebit,MaxAmountDebit,Description BeginDate,EndDate ve ReferenceNumber

AccountNumber ReferenceNumber alanlari == ile kullanilacak 

Min-Max amout alanlari aralik olarak arama yapacak.

BeginDate - EndDate alanlari aralik olarak arama yapacak.


Bu filtre kullanimi icin reposiroty katmaninda bu kriterleri dinamik olarak parametre verebilecegimiz bir fonksiyon hazirlayiniz. Bu fonksiyon gelen kriterleri execute ederek sonucu verecektir. 

GenericRepository uzerinde tek parametre alan Where func iplemantasyonunu yapip bu fonksiyona tum paramtreleri gecerek sorguyu calistiriniz. 

Generic reposiroty nin tek parametresi 

```Expression<Func<Entity, bool>> expression```  olacak. :)


