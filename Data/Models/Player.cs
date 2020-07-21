using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class Player
    {
        public string Id { get; set; }
        public string name { get; set; }

        public ICollection<CompletedRoom> CompletedRooms { get; set; }
    }
}
