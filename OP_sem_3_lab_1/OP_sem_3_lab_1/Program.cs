namespace OP_sem_3_lab_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Animals animal = new Animals();
            Console.WriteLine(animal);

            WaterAnimal waterAnimal = new WaterAnimal();
            OverLand overlandAnimal = new OverLand();

            Console.WriteLine(waterAnimal.GetPercentOfAmount());
            Console.WriteLine(waterAnimal.Habitat);
            Console.WriteLine(overlandAnimal.GetPercentOfAmount());
            Console.WriteLine();
        }
    }

    class Singleton
    {
        private static Singleton instance;

        private Singleton() { }

        public static Singleton GetInstance()
        {
            if (instance == null)
                instance = new Singleton();
            return instance;
        }
    }

    class Animals
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

        public string Habitat
        {
            get { return habitat; }
        }

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

        static Animals()
        {
            totalAmount = 2000000000;
        }

        public Animals()
        {
            habitat = "Earth";
        }

        public virtual string Voice()
        {
            return "I am animal";
        }
    }

    class WaterAnimal : Animals
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
            Console.WriteLine("A: {0};\tT: {1}", amountOfWaterAnimals, Animals.TotalAmount);
            return ((double)amountOfWaterAnimals / (double)Animals.TotalAmount) * 100;
        }
    }

    class Fish : WaterAnimal
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

        static Fish() => amount = 1300000000;

        public Fish()
        {
            habitat = "All ponds";
        }

        public override string Voice()
        {
            return "I am fish";
        }

        public override double GetPercentOfAmount()
        {
            Console.WriteLine("A: {0};\tT: {1}", amount, Animals.TotalAmount);
            return ((double)amount / (double)Animals.TotalAmount) * 100;
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
            Console.WriteLine("A: {0};\tT: {1}", amount, Animals.TotalAmount);
            return ((double)amount / (double)Animals.TotalAmount) * 100;
        }
    }


    class OverLand : Animals
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
            Console.WriteLine("A: {0};\tT: {1}", amountOfOverlandAnimals, Animals.TotalAmount);
            return ((double)amountOfOverlandAnimals / (double)Animals.TotalAmount) * 100;
        }
    }

    class Bird : OverLand
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

        static Bird() => amount = 100000000;

        public Bird()
        {
            habitat = "All continents";
        }
        public override string Voice()
        {
            return "I am bird";
        }

        public override double GetPercentOfAmount()
        {
            Console.WriteLine("A: {0};\tT: {1}", amount, Animals.TotalAmount);
            return ((double)amount / (double)Animals.TotalAmount) * 100;
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
            Console.WriteLine("A: {0};\tT: {1}", amount, Animals.TotalAmount);
            return ((double)amount / (double)Animals.TotalAmount) * 100;
        }
    }
}