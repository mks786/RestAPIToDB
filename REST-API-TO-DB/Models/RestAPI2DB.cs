using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace REST_API_TO_DB.Models
{
    public partial class RESTAPI2DB
    {
        [JsonProperty("ScheduleResult")]
        public ScheduleResult ScheduleResult { get; set; }
    }

    public partial class ScheduleResult
    {
        [JsonProperty("Schedules")]
        public Schedule[] Schedules { get; set; }
    }

    public partial class Schedule
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [JsonProperty("ContractTimeMinutes")]
        public long ContractTimeMinutes { get; set; }

        [JsonProperty("Date")]
        public string Date { get; set; }

        [JsonProperty("IsFullDayAbsence")]
        public bool IsFullDayAbsence { get; set; }

        [Column(TypeName = "varchar(100)")]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("PersonId")]
        public Guid PersonId { get; set; }

        [JsonProperty("Projection")]
        //public Projection[] Projection { get; set; }
        public ICollection<Projection> Projection { get; set; }

    }

    public partial class Projection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [JsonProperty("Color")]
        public string Color { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Start")]
        public string Start { get; set; }

        [JsonProperty("minutes")]
        public long Minutes { get; set; }

        [ForeignKey("Schedule")]
        public int ScheduleId { get; set; }

        public Schedule Schedule { get; set; }
    }

    public partial class UserInfo
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
