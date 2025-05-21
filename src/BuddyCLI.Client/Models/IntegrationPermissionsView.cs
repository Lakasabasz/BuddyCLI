using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BuddyCLI.Client.Models
{
    /// <summary>
    /// Reprezentuje uprawnienia integracji.
    /// </summary>
    public class IntegrationPermissionsView
    {
        /// <summary>
        /// Poziom dostępu dla pozostałych użytkowników.
        /// </summary>
        [JsonPropertyName("others")]
        public string Others { get; set; }

        /// <summary>
        /// Uprawnienia użytkowników.
        /// </summary>
        [JsonPropertyName("users")]
        public List<UserPermissionView> Users { get; set; }

        /// <summary>
        /// Uprawnienia grup.
        /// </summary>
        [JsonPropertyName("groups")]
        public List<GroupPermissionView> Groups { get; set; }

        /// <summary>
        /// Poziom dostępu dla administratorów.
        /// </summary>
        [JsonPropertyName("admins")]
        public string Admins { get; set; }
    }
}
