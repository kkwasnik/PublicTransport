using System;        

namespace ApplicationDatabase.ResultData
{
    public class OpUser_Result
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool Status { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool isAdmin { get; set; }

        public int POK { get; set; }
    }
}
