namespace OP_sem_3_lab_4.Task4
{
    abstract class Character
    {
        protected int _hp;
        protected int _mana;
        protected int _iq;
        protected int _physycphysicalPower;
        protected int _magicianPower;
        public int HP
        {
            get { return _hp; }
            set { _hp = GetCheckedValue(value); }
        }
        public int Mana
        {
            get { return _mana; }
            set { _mana = GetCheckedValue(value); }
        }
        public int IQ
        {
            get { return _iq; }
            set { _iq = GetCheckedValue(value); }
        }
        public int PhysycphysicalPower
        {
            get { return _physycphysicalPower; }
            set { _physycphysicalPower = GetCheckedValue(value); }
        }
        public int MagicianPower
        {
            get { return _magicianPower; }
            set { _magicianPower = GetCheckedValue(value); }
        }

        private int GetCheckedValue(int value)
        {
            return (value > 0 && value <= 200) ? value : 0;
        }

        public abstract void Attack();
    }
}
