namespace PruebaGranTitan.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;
    public class Bet
    {
        [Key]
        public int Id { get; set; }
        public int RouletteId { get; set; }
        public int? NumberId { get; set; }
        public int? ColorId { get; set; }
        public double ValueBet { get; set; }
        [JsonIgnore]
        public virtual Roulette Roulette { get; set; }        
        [JsonIgnore]
        public virtual Number Number { get; set; }
        [JsonIgnore]
        public virtual Color Color { get; set; }
    }
}
