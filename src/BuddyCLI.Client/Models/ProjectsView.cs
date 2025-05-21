using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BuddyCLI.Client.Models
{
    /// <summary>
    /// Reprezentuje widok listy projektów z API Buddy.
    /// </summary>
    public class ProjectsView
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
        /// Lista projektów.
        /// </summary>
        [JsonPropertyName("projects")]
        public List<ProjectView> Projects { get; set; }
    }
}
