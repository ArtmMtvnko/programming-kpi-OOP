using System.Text.Json;

namespace OP_sem_3_lab_4.Task3
{
    class PresentPack : IPresentPack
    {
        private Dictionary<string, object> _giftSet = new Dictionary<string, object>()
        {
            {"Toy", new Toy("Lightning McQueen") },
            {"Candys", new CandysPack() },
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
}
