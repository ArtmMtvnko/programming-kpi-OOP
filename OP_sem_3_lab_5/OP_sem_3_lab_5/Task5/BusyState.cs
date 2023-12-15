namespace OP_sem_3_lab_5.Task5
{
    class BusyState : State
    {
        public override void AddUser() { Console.WriteLine("I have no more free space :("); }

        public override void RemoveUser()
        {
            Console.WriteLine("Deleting user from server...");
            _server.SwitchStateTo(new FreeState());
            Console.WriteLine("User successfuly deleted, now we have free space!");
        }
    }
}
