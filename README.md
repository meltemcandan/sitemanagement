## Proje Kurulumu
- Projeyi indirdikten sonra 'Package Manager Console' da update-database çalıştırınız.
- Mesaj Durumu / Kullanıcı Tipi / Daire Tipi / Ödeme Türü / Borç Yılları / Borç Ayları tabloları otomatik doldurulur

## Uygulama Kullanımı
- İlk olarak /api/sites/siteregister endpointini kullanarak site hesabınızı oluşturabilirsiniz
  ```json
  {
    "name": "Mevaşehir Sitesi",
    "address": "4048 nolu sokak No:79",
    "identificationNumber": "23268774365",
    "userEmail": "meltemcandan52@gmail.com",
    "userName": "Meltem",
    "userSurname": "Candan",
    "userPhone": "5425489152",
    "password": "Meltem1234*",
    "passwordRepeat": "Meltem1234*",
    "numberOfBlock": 4,
    "numberOfFloors" : 10
  }
  ```
- Yukarıdaki istek sonucunda site kaydı gerçekleşir. numberOfBlock sayısı kadar blok eklenir numberOfFloors sayısı kadar her bloğa daire eklenir ve yönetici hesabı oluşturulur.
- 2. adım olarak /api/auth/login ile kullanıcı girişi yapabilirsiniz.
- Oluşturulan daireler için oturan bilgisi ekleyebilirsiniz. /api/flats sorgusundan dönen her bir daire için flatId değiştirerek oturan bilgileri ekleyebilirsiniz.
  ```json
  {
    "flatId": 2,
    "userTypeId": 1,
    "name": "Mira",
    "surname": "Candan",
    "identificationNumber": "32424241313",
    "phone": "5425489152",
    "email": "miracandan52@gmail.com",
    "carPlate": "",
    "userRole": 3
  }
  ```
- Dairelere borç ekleyebilmek için /api/dept/addmultidebt veya tek bir borç ekleyebilmek için /api/debt/adddebt endpointlerini kullanabilirsiniz;
   
   /api/dept/addmultidebt
   ```json
  {
    "userIds": [
      1,2
    ],
    "yearId": 1,
    "monthIds": [
      1,2,3,4,5,6,7,8
    ],
    "price": 250,
    "debtTypeId": 1
  }
  ```
  /api/debt/adddebt
   ```json
  {
    "price": 250,
    "monthId": 1,
    "yearId": 1,
    "debtTypeId": 2,
    "userId": 1
  }
  ```
  
- Ödeme yapabilmek için /api/debts/adddebtpayment endpointini kullanmanız gerekmektedir. Ödeme yapabilmek için borç id bilgisine ve kabul edilecek bir kart bilgisine ihtiyacınız var. Payment api örnek 3 adet kart bilgisini ödeme için kabul etmektedir. Kabul görcek kart bilgisi aşağıdaki gibidir.
  ```json
  {
    "debtId": 1,
    "cardNumber": "4030403060506050",
    "customerName": "Meltem Candan",
    "expireMonth": 11,
    "expireYear": 2023
  }
  ```
