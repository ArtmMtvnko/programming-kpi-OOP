namespace OP_sem_3_lab_5.Task5
{
    class Server
    {
        private State _state;

        public Server(State state)
        {
            _state = state;
            SwitchStateTo(state);
        } 

        public void SwitchStateTo(State state)
        {
            _state = state;
            _state.SetServer(this);
        }

        public void AddUser()
        {
            _state.AddUser();
        }

        public void RemoveUser()
        {
            _state.RemoveUser();
        }
    }
}
