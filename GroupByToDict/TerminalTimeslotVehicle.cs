using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
//using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GroupByToDict
{
    public class TerminalTimeslotVehicle
    {
        public TerminalTimeslotVehicle()
        {
            Version = 0;
        }
        [NotMapped]
        public int TerminalTimeslotVehicleId { get; set; }

        [NotMapped]
        public int Id { get; set; }

        [JsonIgnore]
        public int TerminalTimeslotId { get; set; }

        [JsonProperty("ReservationId")]
        public int TerminalTimeslotReservationId { get; set; }

        public bool ShouldSerializeTerminalTimeslotReservationId() => TerminalTimeslotReservationId > 0;

        /// <summary>
        /// Версия
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public int Version { get; set; }

        [JsonProperty("Restrictions")]
        public IEnumerable<int> RestrictionIds { get; set; } = new List<int>();

        [NotMapped]
        public IEnumerable<int> RestrictionsIdsInfo { get; set; } = new List<int>();
        public DateTime? Deleted { get; set; }
        public virtual int? CropId { get; set; }
        public virtual int CombinationId { get; set; }
    }
}
