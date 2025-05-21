using System.Text.Json.Serialization;

namespace BuddyCLI.Client.Models
{
    /// <summary>
    /// Reprezentuje widok członka z API Buddy.
    /// </summary>
    public class MemberView
    {
        /// <summary>
        /// URL zasobu API.
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        /// <summary>
        /// URL interfejsu WWW zasobu.
        /// </summary>
        [JsonPropertyName("htmlUrl")]
        public string HtmlUrl { get; set; }

        /// <summary>
        /// ID członka.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Nazwa członka.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// URL avatara członka.
        /// </summary>
        [JsonPropertyName("avatarUrl")]
        public string AvatarUrl { get; set; }

        /// <summary>
        /// URL przestrzeni roboczych.
        /// </summary>
        [JsonPropertyName("workspaces_url")]
        public string WorkspacesUrl { get; set; }

        /// <summary>
        /// Email członka.
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// Czy członek jest administratorem.
        /// </summary>
        [JsonPropertyName("admin")]
        public bool Admin { get; set; }

        /// <summary>
        /// Czy członek jest właścicielem przestrzeni roboczej.
        /// </summary>
        [JsonPropertyName("workspaceOwner")]
        public bool WorkspaceOwner { get; set; }

        /// <summary>
        /// Zestaw uprawnień członka.
        /// </summary>
        [JsonPropertyName("permissionSet")]
        public PermissionSetView PermissionSet { get; set; }

        /// <summary>
        /// Czy automatycznie przypisywać do nowych projektów.
        /// </summary>
        [JsonPropertyName("autoAssignToNewProjects")]
        public bool AutoAssignToNewProjects { get; set; }

        /// <summary>
        /// ID zestawu uprawnień do automatycznego przypisywania.
        /// </summary>
        [JsonPropertyName("autoAssignPermissionSetId")]
        public int? AutoAssignPermissionSetId { get; set; }
    }
}
