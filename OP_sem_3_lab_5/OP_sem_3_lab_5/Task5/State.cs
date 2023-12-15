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
}
