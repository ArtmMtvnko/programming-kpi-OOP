namespace OP_sem_3_lab_4.Task4
{
    class Warrior : Character
    {
        public Warrior()
        {
            this._hp = 200;
            this._mana = 20; 
            this._iq = 80;
            this._physycphysicalPower = 200;
            this._magicianPower = 10;
        }

        public override void Attack()
        {
            Console.WriteLine("Warrior damage by sword: -50 HP");
        }
    }
}
