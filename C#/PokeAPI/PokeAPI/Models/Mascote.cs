using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeAPI.Models
{
    internal class Mascote
    {
        [JsonProperty("abilities")]
        public List<Ability> Abilities { get; set; } = new List<Ability>();

        [JsonProperty("forms")]
        public List<Species> Forms { get; set; } = new List<Species>();

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("species")]
        public Species Species { get; set; }

        [JsonProperty("weight")]
        public long Weight { get; set; }
    }

    public class Ability
    {
        [JsonProperty("ability")]
        public Species AbilityAbility { get; set; }

        [JsonProperty("is_hidden")]
        public bool IsHidden { get; set; }

        [JsonProperty("slot")]
        public long Slot { get; set; }
    }

    public class Species
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }
}
