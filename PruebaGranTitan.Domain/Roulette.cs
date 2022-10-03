namespace PruebaGranTitan.Domain
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Roulette
    {
        [Key]
        public int Id { get; set; }
        public int StateId { get; set; }
        [JsonIgnore]
        public virtual State State { get; set; }
    }
}
