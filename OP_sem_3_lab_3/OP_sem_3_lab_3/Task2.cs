using System;

namespace OP_sem_3_lab_3
{
    class RunScript1
    {
        public static void MyMain()
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
    class Accountant
    {
        public string firstname;
        public string lastname;
        public string thirdname;

        public Accountant(string firstname, string lastname, string thirdname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.thirdname = thirdname;
        }
    }
    abstract class Report
    {
        protected string title;
        protected string description;

        public Report(string title, string description)
        {
            this.title = title;
            this.description = description;
        }

        public abstract void GetReport(Accountant accountant);
    }

    class AccountantReport : Report
    {
        public AccountantReport(string title, string description) : base(title, description)
        {
            this.title = title.Trim();
            this.description = description.Trim();
        }

        public override void GetReport(Accountant accountant)
        {
            Console.WriteLine($"Title: {title}\n\n" +
                            $"Description: {description}\n\n" +
                            $"\t\t\t{DateTime.Now.Date};\t" +
                            $"{accountant.firstname}.{accountant.lastname[0]}.{accountant.thirdname[0]}");
        }
    }

    class PaymentControl : Report
    {
        private const int _minimalPayment = 500;
        private int _currentPayment = 0;
        private AccountantReport _accountantReport;

        public PaymentControl(string title, string description) : base(title, description)
        {
            this.title = title.Trim();
            this.description = description.Trim();
            _accountantReport = new AccountantReport(title, description);
        }

        public override void GetReport(Accountant accountant)
        {
            if (_currentPayment >= _minimalPayment)
                _accountantReport.GetReport(accountant);
            else
                Console.WriteLine($"Sorry, you need to pay {_minimalPayment - _currentPayment} $ yet :(");
        }

        public void Pay(int payment)
        {
            _currentPayment += payment;
        }
    }
}
