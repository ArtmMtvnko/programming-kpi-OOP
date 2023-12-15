using OP_sem_3_lab_5.Task5;

namespace OP_sem_3_lab_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            State state = new FreeState();
            Server server = new Server(state);
            server.AddUser();
            Console.WriteLine("--------------------");
            server.AddUser();

            Console.WriteLine("\n====================\n");

            server.RemoveUser();
            Console.WriteLine("--------------------");
            server.RemoveUser();

            Console.WriteLine("\n====================\n");
            server.AddUser();
        }
    }
}