namespace OP_sem_3_lab_5.Task5
{
    class FreeState : State
    {
        public override void AddUser()
        {
            Console.WriteLine("Registering user in server...");
            _server.SwitchStateTo(new BusyState());
            Console.WriteLine("User successfuly added!");
        }

        public override void RemoveUser() { Console.WriteLine("We have no one user, so nothing to remove"); }
    }
}
