using System.Text.Json.Serialization;

namespace BuddyCLI.Client.Models
{
    /// <summary>
    /// Reprezentuje uprawnienia użytkownika.
    /// </summary>
    public class UserPermissionView
    {
        /// <summary>
        /// ID użytkownika.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Poziom dostępu.
        /// </summary>
        [JsonPropertyName("accessLevel")]
        public string AccessLevel { get; set; }
    }
}
