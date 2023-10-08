namespace OP_sem_3_lab_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Animals animal = new Animals();

            WaterAnimal waterAnimal = new WaterAnimal();

            Console.WriteLine(waterAnimal.GetPercentOfAmount());
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
        private string _habitat;
        protected int _totalAmount;

        public string Habitat
        {
            get { return _habitat; }
        }

        public int Amount
        {
            get { return _totalAmount; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                else
                {
                    _totalAmount = value;
                }
            }
        }

        public Animals()
        {
            _habitat = "Earth";
            _totalAmount = 2000000000;
        }

        public Animals(int amount)
        {
            _habitat = "Earth";
            _totalAmount = amount;
        }

        public virtual string Voice()
        {
            return "I am animal";
        }
    }

    class WaterAnimal : Animals
    {
        private string _habitat;
        private int _amount;

        public WaterAnimal()
        {
            _habitat = "Water";
            _amount = 1500000000;
        }

        public override string Voice()
        {
            return "I am water animal";
        }

        public double GetPercentOfAmount()
        {
            Console.WriteLine("A: {0},    T: {1}", _amount, _totalAmount);
            return ((double)_amount / (double)_totalAmount) * 100;
        }
    }

    class Fish : WaterAnimal
    {
        private string _habitat;

        public Fish()
        {
            _habitat = "All ponds";
        }
        public override string Voice()
        {
            return "I am fish";
        }
    }

    class JellyFish : WaterAnimal
    {
        private string _habitat;

        public JellyFish()
        {
            _habitat = "All oceans";
        }
        public override string Voice()
        {
            return "I am jellyfish";
        }
    }


    class OverLand : Animals
    {
        
    }

    class Bird : OverLand
    {

    }
    class Primate : OverLand
    {

    }
}