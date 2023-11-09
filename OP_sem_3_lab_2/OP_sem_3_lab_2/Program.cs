using System.Globalization;

namespace OP_sem_3_lab_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MyMethod <=> = new Test(MyMethod)
            //test() <=> test.Invoke()

            IFlyable parrot = new Parrot();
            parrot.Fall();

            IFalling parrot2 = new Parrot();
            parrot2.Fall();

            Zoo zoo = Zoo.GetInstance(3); // 3 => 2
            Employee employee = new Employee(zoo);

            zoo.AddAnimal(new Parrot());
            zoo.AddAnimal(new Primate());
            zoo.AddAnimal(new Dolphin());

            Console.WriteLine(employee.ToDoList);

            employee.CompleteTask(() => Console.WriteLine("Also make some extra tasks"));

            Console.WriteLine(employee.ToDoList);
            //Console.WriteLine(employee.GetTimeLeft(() => DateTime.Now.TimeOfDay));
            Console.WriteLine(employee.GetTimeLeft(() => DateTime.Today.AddHours(15).TimeOfDay));

            Primate p = new Primate();
            p.Eat();
        }
    }
}