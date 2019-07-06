using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HotelAdministrationSystem.Domain.Entities
{
    public class RoomState
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid RoomStateGuid { get; set; }
        [ForeignKey(nameof(Room))]
        public Guid RoomGuid { get; set; }
        [ForeignKey(nameof(Client))]
        public Guid ClientGuid { get; set; }

        public virtual Room Room { get; set; }

        public virtual Client Client { get; set; }
        public RoomState()
        {
            RoomStateGuid = Guid.NewGuid();
        }
    }
}
