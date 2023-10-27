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

            Zoo zoo = Zoo.GetInstance(10);
            Employee employee = new Employee(zoo);

            zoo.AddAnimal(new Parrot());
            zoo.AddAnimal(new Primate());
            zoo.AddAnimal(new Dolphin());

            Console.WriteLine(employee.ToDoList);
        }

    }
}