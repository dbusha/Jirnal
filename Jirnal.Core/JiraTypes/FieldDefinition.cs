using Newtonsoft.Json;

namespace Jirnal.Core.JiraTypes
{
    public class FieldDefinition
    {
        public FieldDefinition() { }

        public FieldDefinition(string name, int displayColumn, int rank)
        {
            Name = name;
            DisplayColumn = displayColumn;
            Rank = rank;
        }
        
        
        [JsonIgnore]
        public int DisplayColumn { get; set; }
        
        [JsonIgnore]
        public int Rank { get; set; }
        
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("custom")]
        public bool IsCustomField { get; set; }

        [JsonProperty("orderable")]
        public bool Orderable { get; set; }

        [JsonProperty("navigable")]
        public bool Navigable { get; set; }

        [JsonProperty("searchable")]
        public bool Searchable { get; set; }

        [JsonProperty("clauseNames")]
        public string[] ClauseNames { get; set; }

        [JsonProperty("schema")]
        public Schema Schema { get; set; }
    }
}