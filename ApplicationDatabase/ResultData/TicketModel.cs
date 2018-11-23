using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicationDatabase.ResultData
{
    public class TicketModel
    {
        public int TicketID { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public decimal Cost { get; set; }

        public int Zone { get; set; }

        public Nullable<bool> Student { get; set; }

        public Nullable<bool> Parking { get; set; }

        public bool Resident { get; set; }
    }
}