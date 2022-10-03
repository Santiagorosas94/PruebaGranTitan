namespace PruebaGranTitan.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;
    public class ResultBet
    {
        [Key]
        public int Id { get; set; }
        public double PaymentValue { get; set; }

        public int BetId { get; set; }
        [JsonIgnore]
        public virtual Bet Bet { get; set; }
    }
}
