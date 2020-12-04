using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PNotes.Models
{
    class ComplaintInfo
    {
        [PrimaryKey, AutoIncrement]
        public int ComplaintID { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public DateTime ComplaintDate { get; set; }

        public string Discription { get; set; }

        public string PropsedSolution { get; set; }

        public string Status { get; set; }

        public int UserID { get; set; }
    }
}
