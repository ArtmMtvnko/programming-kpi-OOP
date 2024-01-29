using System.Text.Json;

namespace OP_sem_3_lab_4.Task3
{
    class PresentPack : IPresentPack
    {
        private Dictionary<string, object> _giftSet = new Dictionary<string, object>()
        {
            {"Toy", new Toy("Lightning McQueen") },
            {"Candys", new CandysPack()},
            {"Constructor", new KidConstructor("LEGO") },
        };
        public Dictionary<string, object> GiftSet { get { return _giftSet; } }

        public IPresentPack DeepClone()
        {
            string json = JsonSerializer.Serialize(this);
            Console.WriteLine(json);
            return JsonSerializer.Deserialize<PresentPack>(json);
        }
    }

    class RunInProgram
    {
        public static void MyMain()
        {
            PresentPack pack = new PresentPack();

            PresentPack clone = pack.DeepClone() as PresentPack;
            PresentPack clone1 = pack.DeepClone() as PresentPack;
            PresentPack clone2 = pack.DeepClone() as PresentPack;

            Console.WriteLine("Original: " + pack.GiftSet);

            Console.WriteLine("Clone1: " + clone.GiftSet);
            Console.WriteLine("Clone2: " + clone1.GiftSet);
            Console.WriteLine("Clone3: " + clone2.GiftSet);

            CandysPack gottenPack = clone.GiftSet["Candys"] as CandysPack;
            gottenPack.Eat();
            Console.WriteLine(gottenPack.CandyAmount);
        }
    }
}
