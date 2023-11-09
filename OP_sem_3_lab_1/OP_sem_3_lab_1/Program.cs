using System.Security.Cryptography.X509Certificates;

namespace OP_sem_3_lab_1
{
    internal class Program
    {
        static void GenerateTrash()
        {
            object small = new byte[1024];
            for (int i = 0; i < 100; i++)
            {
                object objTrash = new byte[85000]; // 84976
                Console.WriteLine("MEMORY: " + GC.GetTotalMemory(false) / 1024);
                Console.WriteLine("Generation of small object: {0}", GC.GetGeneration(small));
            }
            GC.Collect(1);
            Console.WriteLine(GC.CollectionCount(0));
            Console.WriteLine(GC.CollectionCount(1));
            Console.WriteLine(GC.CollectionCount(2));
        }
        static void Main(string[] args)
        {

            //new Thread(GenerateTrash).Start();


            //With Dispose()
            for (int i = 0; i < 100; i++)
            {
                Animal animal = new Animal();
                animal.Dispose();
                GC.ReRegisterForFinalize(animal);
                Console.WriteLine("MEMORY: " + GC.GetTotalMemory(false) / 1024);
            }

            GC.Collect(1);
            GC.WaitForPendingFinalizers();
            Console.WriteLine("MEMORY: " + GC.GetTotalMemory(false) / 1024);

            Thread.Sleep(1000);




            // ======= About classes =========

            //Zoo zoo = Zoo.GetInstance(10);

            //zoo.AddAnimal(new Dolphin());
            //zoo.AddAnimal(new Parrot());
            //zoo.AddAnimal(new Primate());

            //Console.WriteLine(zoo);

            //foreach (var item in zoo.Animals)
            //{
            //    if (item == null) break;
            //    Console.WriteLine(item.Voice());
            //}

            // ======= About classes END =========

            //Console.WriteLine("Tread:" + Thread.CurrentThread.ManagedThreadId);

            //Console.WriteLine("Generation before collection: " + GC.GetGeneration(zoo));
            //GC.Collect();
            //Console.WriteLine("Generation after collection: " + GC.GetGeneration(zoo));
            //Console.WriteLine("Generation of big object: " + GC.GetGeneration(obj));
            //Console.WriteLine("PRIMATE: " + GC.GetGeneration(p));
            //Console.WriteLine("MEMORY: " + GC.GetTotalMemory(false) / 1024);
            //Console.WriteLine("Max Generation: " + GC.MaxGeneration);
            //Console.WriteLine("Gen 0: " + GC.CollectionCount(0));
            //Console.WriteLine("Gen 1: " + GC.CollectionCount(1));
            //Console.WriteLine("Gen 2: " + GC.CollectionCount(2));
            //GC.Collect();

            //for (int i = 0; i < 2; i++)
            //{
            //    Animal animal = new Animal();
            //    animal.Dispose();
            //    GC.ReRegisterForFinalize(animal);
            //}

            //Console.WriteLine("Memory before garbage collection: {0}", GC.GetTotalMemory(false) / 1024);
            //GC.Collect(2, GCCollectionMode.Forced);
            //GC.WaitForPendingFinalizers();
            //Console.WriteLine("Memory after garbage collection: {0}", GC.GetTotalMemory(false) / 1024);

            //Thread.Sleep(100);



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
                output += $"{animal.GetTypeOfAnimal()}, ";
            }

            return output + " ]";
        }
    }

    class Animal : IDisposable
    {
        private static int totalAmount;
        private string habitat;
        private string type;
        private bool disposed = false;

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

        public virtual string GetTypeOfAnimal()
        {
            return type;
        }

        public void Dispose()
        {
            CleanUp(true);

            GC.SuppressFinalize(this);
        }

        private void CleanUp(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Console.WriteLine("I am from dispose");
                }
                Console.WriteLine("Logic from destructor in CleanUp");
            }
            this.disposed = true;
        }

        ~Animal()
        {
            Console.WriteLine("I am from destructor (finalize)");
            CleanUp(false);
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

        public override string GetTypeOfAnimal()
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

        public override string GetTypeOfAnimal()
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

        public override string GetTypeOfAnimal()
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

        public override string GetTypeOfAnimal()
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

        public override string GetTypeOfAnimal() => type;
    }

    class Primate : OverLand
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

        static Primate() => totalAmount = 400000000;

        public Primate()
        {
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

        public override string GetTypeOfAnimal() => type;
    }
}