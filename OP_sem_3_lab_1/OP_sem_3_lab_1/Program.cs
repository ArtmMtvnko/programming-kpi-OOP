namespace OP_sem_3_lab_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Animal animal = new Animal();
            //Console.WriteLine(animal);

            //WaterAnimal waterAnimal = new WaterAnimal();
            //OverLand overlandAnimal = new OverLand();

            //Console.WriteLine(waterAnimal.GetPercentOfAmount());
            //Console.WriteLine(waterAnimal.Habitat);
            //Console.WriteLine(overlandAnimal.GetPercentOfAmount());
            //Console.WriteLine(Animal.TotalAmount);

            for (int i = 0; i < 2; i++)
            {
                Primate p = new Primate();
                p = null;
                GC.Collect();
            }
            Thread.Sleep(100);
            for (int i = 0; i < 100; i++)
            {
                object objTrash = new byte[85000]; // 84976
                Console.WriteLine("MEMORY: " + GC.GetTotalMemory(false) / 1024);
            }
            Thread.Sleep(1000);

            Zoo zoo = Zoo.GetInstance(10);

            zoo.AddAnimal(new Dolphin());
            zoo.AddAnimal(new Parrot());
            zoo.AddAnimal(new Primate());

            Console.WriteLine(zoo);

            foreach (var item in zoo.Animals)
            {
                if (item == null) break;
                Console.WriteLine(item.Voice());
            }

            //Console.WriteLine("Tread:" + Thread.CurrentThread.ManagedThreadId);

            object obj = new byte[85000];//84976

            //Console.WriteLine("Generation before collection: " + GC.GetGeneration(zoo));
            //GC.Collect();
            //Console.WriteLine("Generation after collection: " + GC.GetGeneration(zoo));
            //Console.WriteLine("Generation of big object: " + GC.GetGeneration(obj));
            //Console.WriteLine("PRIMATE: " + GC.GetGeneration(p));
            Console.WriteLine("MEMORY: " + GC.GetTotalMemory(false) / 1024);
            Console.WriteLine("Gen 0: " + GC.CollectionCount(0));
            Console.WriteLine("Gen 1: " + GC.CollectionCount(1));
            Console.WriteLine("Gen 2: " + GC.CollectionCount(2));
            //GC.Collect();
        }
    }

    class Zoo
    {
        private static Zoo instance;
        private Animal[] animals;
        private int pointer = 0;

        public Animal[] Animals { get => animals; }

        private Zoo() => animals = new Animal[200];

        private Zoo(int capacity) 
        {
            animals = new Animal[capacity];
        }

        public static Zoo GetInstance(int capacity)
        {
            if (instance == null)
                instance = new Zoo(capacity);
            return instance;
        }

        public void AddAnimal(Animal animal)
        {
            if (pointer == animals.Length) return;
            animals[pointer++] = animal;
        }

        public override string ToString()
        {
            string output = "[ ";

            foreach (var animal in animals)
            {
                if (animal == null) break;
                output += $"{animal.GetType()}, ";
            }

            return output + " ]";
        }
    }

    class Animal
    {
        private static int totalAmount;
        private string habitat;
        private string type;

        public static int TotalAmount { get => totalAmount; }

        public string Habitat { get => habitat; }

        static Animal()
        {
            totalAmount = WaterAnimal.TotalAmount + OverLand.TotalAmount;
        }

        public Animal()
        {
            habitat = "Earth";
            type = "Animal";
        }

        public virtual string Voice()
        {
            return "I am animal";
        }

        public virtual string GetType()
        {
            return type;
        }
    }


    class WaterAnimal : Animal
    {
        private static int totalAmount;
        private string habitat;
        private string type;

        public static int TotalAmount { get => totalAmount; }

        static WaterAnimal() => totalAmount = Dolphin.TotalAmount + JellyFish.TotalAmount;

        public string Habitat
        {
            get => habitat;
        }

        public WaterAnimal()
        {
            habitat = "Water";
            type = "Water Animal";
        }

        public override string Voice()
        {
            return "I am water animal";
        }

        public virtual double GetPercentOfAmount()
        {
            Console.WriteLine("A: {0};\tT: {1}", totalAmount, Animal.TotalAmount);
            return ((double)totalAmount / (double)Animal.TotalAmount) * 100;
        }

        public override string GetType()
        {
            return type;
        }
    }

    class Dolphin : WaterAnimal
    {
        private static int totalAmount;
        private string habitat;
        private string type;

        public static int TotalAmount
        {
            get { return totalAmount; }
            set
            {
                if (value >= 0)
                {
                    totalAmount = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }


        public string Habitat
        {
            get => habitat;
        }

        static Dolphin() => totalAmount = 1300000000;

        public Dolphin()
        {
            habitat = "All ponds";
            type = "Dolphin";
        }

        public override string Voice()
        {
            return "*squeak*";
        }

        public override double GetPercentOfAmount()
        {
            Console.WriteLine("A: {0};\tT: {1}", totalAmount, Animal.TotalAmount);
            return ((double)totalAmount / (double)Animal.TotalAmount) * 100;
        }

        public override string GetType()
        {
            return type;
        }
    }

    class JellyFish : WaterAnimal
    {
        private static int totalAmount;
        private string habitat;
        private string type;

        public static int TotalAmount
        {
            get { return totalAmount; }
            set
            {
                if (value >= 0)
                {
                    totalAmount = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public string Habitat
        {
            get => habitat;
        }

        static JellyFish() => totalAmount = 200000000;

        public JellyFish()
        {
            habitat = "All oceans";
            type = "Jellyfish";
        }
        public override string Voice()
        {
            return "*mute*";
        }

        public override double GetPercentOfAmount()
        {
            Console.WriteLine("A: {0};\tT: {1}", totalAmount, Animal.TotalAmount);
            return ((double)totalAmount / (double)Animal.TotalAmount) * 100;
        }

        public override string GetType()
        {
            return type;
        }
    }


    class OverLand : Animal
    {
        private static int totalAmount;
        private string habitat;
        private string type;

        public static int TotalAmount { get => totalAmount; }

        public string Habitat
        {
            get => habitat;
        }

        static OverLand() => totalAmount = Parrot.TotalAmount + Primate.TotalAmount;

        public OverLand()
        {
            habitat = "Land";
            type = "Overland Animal";
        }
        public override string Voice()
        {
            return "I am overland animal";
        }

        public virtual double GetPercentOfAmount()
        {
            Console.WriteLine("A: {0};\tT: {1}", totalAmount, Animal.TotalAmount);
            return ((double)totalAmount / (double)Animal.TotalAmount) * 100;
        }

        public override string GetType()
        {
            return type;
        }
    }

    class Parrot : OverLand
    {
        private static int totalAmount;
        private string habitat;
        private string type;

        public static int TotalAmount
        {
            get { return totalAmount; }
            set
            {
                if (value >= 0)
                {
                    totalAmount = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public string Habitat
        {
            get => habitat;
        }

        static Parrot() => totalAmount = 100000000;

        public Parrot()
        {
            habitat = "All continents";
            type = "Parrot";
        }
        public override string Voice()
        {
            return "Ahrrr";
        }

        public override double GetPercentOfAmount()
        {
            Console.WriteLine("A: {0};\tT: {1}", totalAmount, Animal.TotalAmount);
            return ((double)totalAmount / (double)Animal.TotalAmount) * 100;
        }

        public override string GetType() => type;
    }
    class Primate : OverLand
    {
        private static int totalAmount;
        private string habitat;
        private string type;
        byte[] a = new byte[1024 * 1000];

        public static int TotalAmount
        {
            get { return totalAmount; }
            set
            {
                if (value >= 0)
                {
                    totalAmount = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public string Habitat
        {
            get => habitat;
        }

        static Primate() => totalAmount = 400000000;

        public Primate()
        {
            //Console.WriteLine("I was bonr 0_0");
            habitat = "All continents";
            type = "Primate";
        }

        ~Primate() { Console.WriteLine("I am done...... x_x"); }
        public override string Voice()
        {
            return "U-u-u-a-a-a";
        }

        public override double GetPercentOfAmount()
        {
            Console.WriteLine("A: {0};\tT: {1}", totalAmount, Animal.TotalAmount);
            return ((double)totalAmount / (double)Animal.TotalAmount) * 100;
        }

        public override string GetType() => type;
    }
}