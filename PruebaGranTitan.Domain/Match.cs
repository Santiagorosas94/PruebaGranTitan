namespace PruebaGranTitan.Domain
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class Match
    {
        
        public int Id { get; set; }
        public int BetId { get; set; }
        [JsonIgnore]
        public virtual Bet Bet { get; set; }
    }
}
