using System.Text.Json.Serialization;

namespace BuddyCLI.Client.Models
{
    /// <summary>
    /// Reprezentuje założenia roli AWS dla integracji.
    /// </summary>
    public class RoleAssumptionView
    {
        /// <summary>
        /// ARN roli.
        /// </summary>
        [JsonPropertyName("arn")]
        public string Arn { get; set; }

        /// <summary>
        /// Zewnętrzny identyfikator dla roli.
        /// </summary>
        [JsonPropertyName("externalId")]
        public string ExternalId { get; set; }

        /// <summary>
        /// Czas trwania sesji w sekundach.
        /// </summary>
        [JsonPropertyName("duration")]
        public int? Duration { get; set; }
    }
}
