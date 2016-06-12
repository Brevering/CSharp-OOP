namespace DefineClass
{
    public class GSMTest
    {
        public static GSM[] testArr =
            {
            new GSM("Lumia 920", "Nokia", 890.95, "Gosho", new Battery("Unknown", 543, 14, BatteryType.LiIon), new Display(5, 16777216)),
            new GSM("Galaxy S7", "Samsung", 1235.54, "Pesho", new Battery("SomeModel", 317, 11, BatteryType.LiPolymer), new Display(5.5, 16777216)),
            new GSM("Vibe", "Lenovo", 850.35, "Atanas", new Battery("LenovoBatt", 635, 17, BatteryType.LiPolymer), new Display(5.5, 16777216))
            };
        public static void DisplayGsmInfo()
        {
            foreach (var phone in testArr)
            {
                phone.ShowPhoneInfo();
            }

            GSM.iPhone4S.ShowPhoneInfo();
        }
    }
}
