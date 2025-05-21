using System;
using System.Text.Json.Serialization;

namespace BuddyCLI.Client.Models
{
    /// <summary>
    /// Reprezentuje widok pojedynczego projektu z API Buddy.
    /// </summary>
    public class ProjectView
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
        /// Nazwa projektu.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Nazwa wyświetlana projektu.
        /// </summary>
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// ID zewnętrznego projektu.
        /// </summary>
        [JsonPropertyName("externalProjectId")]
        public string ExternalProjectId { get; set; }

        /// <summary>
        /// ID projektu w GitLab.
        /// </summary>
        [JsonPropertyName("gitLabProjectId")]
        public int? GitLabProjectId { get; set; }

        /// <summary>
        /// ID instalacji GitHub App.
        /// </summary>
        [JsonPropertyName("gitHubAppInstallationId")]
        public string GitHubAppInstallationId { get; set; }

        /// <summary>
        /// URL niestandardowego repozytorium.
        /// </summary>
        [JsonPropertyName("customRepoUrl")]
        public string CustomRepoUrl { get; set; }

        /// <summary>
        /// Użytkownik niestandardowego repozytorium.
        /// </summary>
        [JsonPropertyName("customRepoUser")]
        public string CustomRepoUser { get; set; }

        /// <summary>
        /// Hasło niestandardowego repozytorium.
        /// </summary>
        [JsonPropertyName("customRepoPass")]
        public string CustomRepoPass { get; set; }

        /// <summary>
        /// ID klucza SSH dla niestandardowego repozytorium.
        /// </summary>
        [JsonPropertyName("customRepoSshKeyId")]
        public int? CustomRepoSshKeyId { get; set; }

        /// <summary>
        /// Status projektu.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// Poziom dostępu do projektu (PRIVATE lub PUBLIC).
        /// </summary>
        [JsonPropertyName("access")]
        public string Access { get; set; }

        /// <summary>
        /// Data utworzenia projektu.
        /// </summary>
        [JsonPropertyName("createDate")]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Członek, który utworzył projekt.
        /// </summary>
        [JsonPropertyName("createdBy")]
        public MemberView CreatedBy { get; set; }

        /// <summary>
        /// URL repozytorium HTTP.
        /// </summary>
        [JsonPropertyName("httpRepository")]
        public string HttpRepository { get; set; }

        /// <summary>
        /// URL repozytorium SSH.
        /// </summary>
        [JsonPropertyName("sshRepository")]
        public string SshRepository { get; set; }

        /// <summary>
        /// Domyślna gałąź.
        /// </summary>
        [JsonPropertyName("defaultBranch")]
        public string DefaultBranch { get; set; }

        /// <summary>
        /// Integracja związana z projektem.
        /// </summary>
        [JsonPropertyName("integration")]
        public IntegrationView Integration { get; set; }

        /// <summary>
        /// Czy pobierać submoduły.
        /// </summary>
        [JsonPropertyName("fetchSubmodules")]
        public bool FetchSubmodules { get; set; }

        /// <summary>
        /// Klucz środowiskowy do pobierania submodułów.
        /// </summary>
        [JsonPropertyName("fetchSubmodulesEnvKey")]
        public string FetchSubmodulesEnvKey { get; set; }

        /// <summary>
        /// Czy zezwalać na pull requesty.
        /// </summary>
        [JsonPropertyName("allowPullRequests")]
        public bool AllowPullRequests { get; set; }

        /// <summary>
        /// Czy aktualizować domyślną gałąź z zewnętrznego źródła.
        /// </summary>
        [JsonPropertyName("updateDefaultBranchFromExternal")]
        public bool UpdateDefaultBranchFromExternal { get; set; }

        /// <summary>
        /// Czy projekt jest bez repozytorium.
        /// </summary>
        [JsonPropertyName("withoutRepository")]
        public bool WithoutRepository { get; set; }
    }
}
