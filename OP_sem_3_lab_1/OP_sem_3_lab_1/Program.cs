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
            Animals.x = 10;
            Console.WriteLine(Animals.x);
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
        public static int x = 999999;
        private string habitat;
        protected int totalAmount;

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

        public Animals()
        {
            habitat = "Earth";
            totalAmount = 2000000000;
        }

        public Animals(int amount)
        {
            habitat = "Earth";
            totalAmount = amount;
        }

        public virtual string Voice()
        {
            return "I am animal";
        }
    }

    class WaterAnimal : Animals
    {
        private string habitat;
        protected int amountOfWaterAnimals;

        public string Habitat
        {
            get => habitat;
        }

        public WaterAnimal()
        {
            habitat = "Water";
            amountOfWaterAnimals = 1500000000;
        }

        public override string Voice()
        {
            return "I am water animal";
        }

        public virtual double GetPercentOfAmount()
        {
            Console.WriteLine("A: {0};\tT: {1}", amountOfWaterAnimals, totalAmount);
            return ((double)amountOfWaterAnimals / (double)totalAmount) * 100;
        }
    }

    class Fish : WaterAnimal
    {
        private string habitat;
        private int amount;

        public string Habitat
        {
            get => habitat;
        }

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
            Console.WriteLine("A: {0};\tT: {1}", amount, totalAmount);
            return ((double)amount / (double)totalAmount) * 100;
        }
    }

    class JellyFish : WaterAnimal
    {
        private string habitat;

        public string Habitat
        {
            get => habitat;
        }

        public JellyFish()
        {
            habitat = "All oceans";
        }
        public override string Voice()
        {
            return "I am jellyfish";
        }
    }


    class OverLand : Animals
    {
        private string habitat;
        protected int amountOfOverlandAnimals;

        public string Habitat
        {
            get => habitat;
        }

        public OverLand()
        {
            habitat = "All contitents";
            amountOfOverlandAnimals = 500000000;
        }
        public override string Voice()
        {
            return "I am overland animal";
        }

        public double GetPercentOfAmount()
        {
            Console.WriteLine("A: {0};\tT: {1}", amountOfOverlandAnimals, totalAmount);
            return ((double)amountOfOverlandAnimals / (double)totalAmount) * 100;
        }
    }

    class Bird : OverLand
    {

    }
    class Primate : OverLand
    {

    }
}