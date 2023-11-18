namespace OP_sem_3_lab_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string desctiption = "Lorem ipsum, dolor sit amet consectetur adipisicing elit.\n" +
                "Nesciunt nisi assumenda at.\n" +
                "Omnis, suscipit perferendis, quae aspernatur impedit porro,\n" +
                "minus facere mollitia consequuntur exercitationem harum tempora " +
                "fugit molestiae ea voluptatibus.";


            PaymentControl report = new PaymentControl("*Your advertisement could be here*", desctiption);

            report.Pay(100);
            report.Pay(400);

            Accountant accountant = new Accountant("Petrenko", "Petro", "Petrovich");

            report.GetReport(accountant);
        }
    }
}