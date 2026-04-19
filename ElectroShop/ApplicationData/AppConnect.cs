using ElectroShop.ApplicationData;

namespace ElectroShop.ApplicationData
{
    public class AppConnect
    {
        public static ElectroShopDBEntities model01 = new ElectroShopDBEntities();
        public static Users CurrentUser;
    }
}