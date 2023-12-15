namespace OP_sem_3_lab_5.Task5
{
    abstract class State
    {
        protected Server _server;

        public void SetServer(Server server)
        {
            _server = server;
        }

        public abstract void AddUser();

        public abstract void RemoveUser();
    }

    class RunInProgram1
    {
        public static void MyMain()
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
