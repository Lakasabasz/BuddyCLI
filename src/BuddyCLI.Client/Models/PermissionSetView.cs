using System.Text.Json.Serialization;

namespace BuddyCLI.Client.Models
{
    /// <summary>
    /// Reprezentuje widok zestawu uprawnień z API Buddy.
    /// </summary>
    public class PermissionSetView
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
        /// ID zestawu uprawnień.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Nazwa zestawu uprawnień.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Opis zestawu uprawnień.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Typ zestawu uprawnień.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Poziom dostępu do repozytorium.
        /// </summary>
        [JsonPropertyName("repositoryAccessLevel")]
        public string RepositoryAccessLevel { get; set; }

        /// <summary>
        /// Poziom dostępu do pipeline'ów.
        /// </summary>
        [JsonPropertyName("pipelineAccessLevel")]
        public string PipelineAccessLevel { get; set; }

        /// <summary>
        /// Poziom dostępu do sandboxów.
        /// </summary>
        [JsonPropertyName("sandboxAccessLevel")]
        public string SandboxAccessLevel { get; set; }

        /// <summary>
        /// Poziom dostępu do zespołów projektowych.
        /// </summary>
        [JsonPropertyName("projectTeamAccessLevel")]
        public string ProjectTeamAccessLevel { get; set; }

        /// <summary>
        /// Poziom dostępu do środowisk.
        /// </summary>
        [JsonPropertyName("environmentAccessLevel")]
        public string EnvironmentAccessLevel { get; set; }
    }
}
