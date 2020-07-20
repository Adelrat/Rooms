using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string answer { get; set; }
        public string task { get; set; }

        [InverseProperty("RoomTo")]
        public ICollection<Door> DoorsIn { get; set; }
        [InverseProperty("RoomFrom")]
        public ICollection<Door> DoorOut { get; set; }
    }

}
