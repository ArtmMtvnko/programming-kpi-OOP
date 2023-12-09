namespace OP_sem_3_lab_4.Task4
{
    class Miner : Character
    {
        public Miner()
        {
            this._hp = 120;
            this._mana = 30;
            this._iq = 200;
            this._physycphysicalPower = 50;
            this._magicianPower = 60;
        }

        public override void Attack()
        {
            Console.WriteLine("Miner build the gun tower: -40 HP, +25 defence");
        }
    }
}
