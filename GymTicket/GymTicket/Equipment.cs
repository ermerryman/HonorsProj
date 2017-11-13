using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net.Attributes;

namespace GymTicket
{
    [Table("Equipment")]
    public class Equipment
    {
        [PrimaryKey, AutoIncrement]
        public int equipID
        { get; set; }

        [NotNull]
        public string equipName
        { get; set; }

        public string imageURL
        { get; set; }
    }
}
