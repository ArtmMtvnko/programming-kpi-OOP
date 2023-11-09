using System;

namespace OP_sem_3_lab_2
{
    interface IFlyable
    {
        void Fly();

        void Fall();
    }

    interface IFalling
    {
        void Fall();
    }

    internal class MyEventArgs : EventArgs
    {
        public Animal Animal { get; }

        public MyEventArgs(Animal animal)
        {
            Animal = animal;
        }
    }

    class Employee
    {
        List<Animal> toDoList = new List<Animal>();
        TimeSpan endOfShift = DateTime.Today.AddHours(20).TimeOfDay;

        public string ToDoList
        {
            get
            {
                string output = "[ ";
                toDoList.ForEach(animal =>
                {
                    output += $"{animal.GetTypeOfAnimal()}, ";
                });
                return output + "]";
            }
        }

        public int ToDoCount { get => toDoList.Count; }

        public Employee(Zoo zoo)
        {
            zoo.AnimalAdded += AddTask; // += new AnimalAddHandler(AddTask);
        }

        public void AddTask(Zoo sender, MyEventArgs e)
        {
            toDoList.Add(e.Animal);
            Console.WriteLine("In zoo came new animal. I have more work :(");
        }

        public void CompleteTask()
        {
            try
            {
                if (toDoList.Count == 0)
                    throw new EmptyTaskExeption("There are no more tasks to do", this);

                toDoList.RemoveAt(0);
                Console.WriteLine("I have Done task!");
            }
            catch (EmptyTaskExeption ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Current count of tasks: {0}", ex.TasksCount);
                Console.WriteLine("Take more tasks or check stack of calling CompleteTask() method");
            }
        }

        public void CompleteTask(Action action)
        {
            toDoList.RemoveAt(0);
            Console.WriteLine("I have Done task!");
            action?.Invoke();
        }

        public TimeSpan GetTimeLeft(Func<TimeSpan> func)
        {
            try
            {
                TimeSpan current = (TimeSpan)func?.Invoke();

                if (current > endOfShift)
                    throw new NegativeTimeExeption("Shift has already ended", new TimeExeptionArgs(endOfShift, current));

                return endOfShift - current;

            }
            catch (NegativeTimeExeption ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"Value of current time <{ex.TimeExeptionArgs.Current}>" +
                    $", value of shift end time <{ex.TimeExeptionArgs.EndOfShift}>\n" +
                    $"Current time more than end of shift time: " +
                    $"{ex.TimeExeptionArgs.EndOfShift} > {ex.TimeExeptionArgs.Current}");
            }

            return default(TimeSpan);
        }
    }

    class Zoo
    {
        public delegate void AnimalAddHandler(Zoo sender, MyEventArgs e);

        public event AnimalAddHandler AnimalAdded;

        private static Zoo instance;
        private Animal[] animals;
        private int pointer = 0;

        public Animal[] Animals { get => animals; }

        public int Capacity { get => animals.Length; }

        public int AnimalsAmount { get => pointer; }

        private Zoo(int capacity)
        {
            animals = new Animal[capacity];
        }

        public static Zoo GetInstance(int capacity = 50)
        {
            if (instance == null)
                instance = new Zoo(capacity);
            return instance;
        }

        public void AddAnimal(Animal animal)
        {
            try
            {
                if (pointer >= animals.Length)
                    throw new ZooOverflowExeption("Your Zoo is overflowed", this);

                animals[pointer++] = animal;
            }
            catch(ZooOverflowExeption ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"Capacity of your zoo: {ex.Capacity},");
                Console.WriteLine($"Current amount of your animals: {ex.AnimalsAmount}");
                Console.WriteLine("Expand your zoo or left rest of animals");
            }

            AnimalAdded?.Invoke(this, new MyEventArgs(animal));
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

    abstract class Animal
    {
        private static int totalAmount;
        private string habitat;

        public static int TotalAmount { get => totalAmount; }

        public string Habitat { get => habitat; }

        static Animal()
        {
            totalAmount = WaterAnimal.TotalAmount + OverLand.TotalAmount;
        }

        public abstract string Voice();

        public abstract string GetTypeOfAnimal();
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

    class Parrot : OverLand, IDisposable, IFlyable, IFalling
    {
        private static int totalAmount;
        private string habitat;
        private string type;
        private bool disposed = false;

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

        public void Fly()
        {
            Console.WriteLine("I am fling...");
        }

        public void Fall()
        {
            Console.WriteLine("I am falling...");
        }

        void IFlyable.Fall()
        {
            Console.WriteLine("This Fall() from IFlyable");
        }

        void IFalling.Fall()
        {
            Console.WriteLine("This Fall() from IFalling");
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

                // this.disposed = true;
                // Don't know proper way, this.disposed = true; -- inside "if" block
                // or outside like below?
            }
            this.disposed = true;
        }

        ~Parrot()
        {
            Console.WriteLine("I am from destructor (finalize)");
            CleanUp(false);
        }
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
            //Console.WriteLine("I have borned 0_0");
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
