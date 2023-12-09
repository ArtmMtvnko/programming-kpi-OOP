using System.Text.Json;

namespace OP_sem_3_lab_4.Task3
{
    class PresentPack
    {
        private Dictionary<object, int> _giftSet = new Dictionary<object, int>()
        {
            { new Toy("Lightning McQueen"), 2 },
            { new CandysPack(), 3 },
            { new KidConstructor("LEGO"), 1 },
        };

        public int SUKA { get; set; } = 10;

        //private CandysPack cp = new CandysPack();
        //public CandysPack CandyPask { get { return cp; } }
        public Dictionary<object, int> GiftSet { get { return _giftSet; } }

        public PresentPack DeepClone()
        {
            string json = JsonSerializer.Serialize(this);
            Console.WriteLine(json);
            return JsonSerializer.Deserialize<PresentPack>(json);
        }
    }
}
