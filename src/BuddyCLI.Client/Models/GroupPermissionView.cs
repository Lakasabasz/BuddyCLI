using System.Text.Json.Serialization;

namespace BuddyCLI.Client.Models
{
    /// <summary>
    /// Reprezentuje uprawnienia grupy.
    /// </summary>
    public class GroupPermissionView
    {
        /// <summary>
        /// ID grupy.
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
