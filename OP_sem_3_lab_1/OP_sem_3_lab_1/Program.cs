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
            //Console.WriteLine();

            Zoo zoo = Zoo.GetInstance();

            zoo.AddAnimal(new Dolphin());
            zoo.AddAnimal(new Parrot());
            zoo.AddAnimal(new Primate());

            Console.WriteLine(zoo);
        }
    }

    class Zoo
    {
        private static Zoo instance;
        private Animal[] animals;
        private int pointer = 0;

        private Zoo() => animals = new Animal[2000];

        private Zoo(int capacity) 
        {
            animals = new Animal[capacity];
        }

        public static Zoo GetInstance(int capacity = 2000)
        {
            if (instance == null)
                instance = new Zoo(capacity);
            return instance;
        }

        public void AddAnimal(Animal animal)
        {
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

        public static int TotalAmount
        {
            get { return totalAmount; }
            set
            {
                if (totalAmount < 0)
                {
                    totalAmount = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public string Habitat { get; }

        public int Amount
        {
            get { return totalAmount; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                else
                {
                    totalAmount = value;
                }
            }
        }

        static Animal()
        {
            totalAmount = 2000000000;
        }

        public Animal()
        {
            habitat = "Earth";
        }

        public virtual string Voice()
        {
            return "I am animal";
        }

        public virtual string GetType()
        {
            return "Animal";
        }
    }

    class WaterAnimal : Animal
    {
        private static int amountOfWaterAnimals;

        private string habitat;

        public static int AmountOfWaterAnimals
        {
            get { return amountOfWaterAnimals; }
            set
            {
                if (amountOfWaterAnimals < 0)
                {
                    amountOfWaterAnimals = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        static WaterAnimal() => amountOfWaterAnimals = 1500000000;

        public string Habitat
        {
            get => habitat;
        }

        public WaterAnimal()
        {
            habitat = "Water";
        }

        public override string Voice()
        {
            return "I am water animal";
        }

        public virtual double GetPercentOfAmount()
        {
            Console.WriteLine("A: {0};\tT: {1}", amountOfWaterAnimals, Animal.TotalAmount);
            return ((double)amountOfWaterAnimals / (double)Animal.TotalAmount) * 100;
        }
    }

    class Dolphin : WaterAnimal
    {
        private static int amount;
        private string habitat;
        private string type = "dolphin";

        public static int Amount
        {
            get { return amount; }
            set
            {
                if (amount < 0)
                {
                    amount = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public string Type { get; }

        public string Habitat
        {
            get => habitat;
        }

        static Dolphin() => amount = 1300000000;

        public Dolphin()
        {
            habitat = "All ponds";
        }

        public override string Voice()
        {
            return "I am fish";
        }

        public override double GetPercentOfAmount()
        {
            Console.WriteLine("A: {0};\tT: {1}", amount, Animal.TotalAmount);
            return ((double)amount / (double)Animal.TotalAmount) * 100;
        }

        public override string GetType()
        {
            return "Dolphin";
        }
    }

    class JellyFish : WaterAnimal
    {
        private static int amount;
        private string habitat;


        public static int Amount
        {
            get { return amount; }
            set
            {
                if (amount < 0)
                {
                    amount = value;
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

        static JellyFish() => amount = 200000000;

        public JellyFish()
        {
            habitat = "All oceans";
        }
        public override string Voice()
        {
            return "I am jellyfish";
        }

        public override double GetPercentOfAmount()
        {
            Console.WriteLine("A: {0};\tT: {1}", amount, Animal.TotalAmount);
            return ((double)amount / (double)Animal.TotalAmount) * 100;
        }
    }


    class OverLand : Animal
    {
        private static int amountOfOverlandAnimals;
        private string habitat;

        public static int AmountOfOverlandAnimals
        {
            get { return amountOfOverlandAnimals; }
            set
            {
                if (amountOfOverlandAnimals < 0)
                {
                    amountOfOverlandAnimals = value;
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

        static OverLand() => amountOfOverlandAnimals = 500000000;

        public OverLand()
        {
            habitat = "Land";
        }
        public override string Voice()
        {
            return "I am overland animal";
        }

        public virtual double GetPercentOfAmount()
        {
            Console.WriteLine("A: {0};\tT: {1}", amountOfOverlandAnimals, Animal.TotalAmount);
            return ((double)amountOfOverlandAnimals / (double)Animal.TotalAmount) * 100;
        }
    }

    class Parrot : OverLand
    {
        private static int amount;
        private string habitat;

        public static int Amount
        {
            get { return amount; }
            set
            {
                if (amount < 0)
                {
                    amount = value;
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

        static Parrot() => amount = 100000000;

        public Parrot()
        {
            habitat = "All continents";
        }
        public override string Voice()
        {
            return "I am bird";
        }

        public override double GetPercentOfAmount()
        {
            Console.WriteLine("A: {0};\tT: {1}", amount, Animal.TotalAmount);
            return ((double)amount / (double)Animal.TotalAmount) * 100;
        }
    }
    class Primate : OverLand
    {
        private static int amount;
        private string habitat;

        public static int Amount
        {
            get { return amount; }
            set
            {
                if (amount < 0)
                {
                    amount = value;
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

        static Primate() => amount = 100000000;

        public Primate()
        {
            habitat = "All continents";
        }
        public override string Voice()
        {
            return "I am primate";
        }

        public override double GetPercentOfAmount()
        {
            Console.WriteLine("A: {0};\tT: {1}", amount, Animal.TotalAmount);
            return ((double)amount / (double)Animal.TotalAmount) * 100;
        }
    }
}