namespace OP_sem_3_lab_4.Task4
{
    class Magician : Character
    {
        public Magician()
        {
            this._hp = 60;
            this._mana = 200;
            this._iq = 115;
            this._physycphysicalPower = 30;
            this._magicianPower = 200;
        }

        public override void Attack()
        {
            Console.WriteLine("Magician damage by spell: -150 HP");
        }
    }
}
