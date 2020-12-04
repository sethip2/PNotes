using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PNotes.Models
{
    class UserInfo
    {
        [PrimaryKey, AutoIncrement]
        public int UserID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Contact { get; set; }

        public bool IsAdmin { get; set; }
    }
}
