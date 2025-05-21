using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BuddyCLI.Client.Models
{
    /// <summary>
    /// Reprezentuje widok integracji z API Buddy.
    /// </summary>
    public class IntegrationView
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
        /// Identyfikator integracji.
        /// </summary>
        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }

        /// <summary>
        /// Hash ID integracji.
        /// </summary>
        [JsonPropertyName("hashId")]
        public string HashId { get; set; }

        /// <summary>
        /// Nazwa integracji.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Email integracji.
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// Typ integracji.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Typ uwierzytelniania.
        /// </summary>
        [JsonPropertyName("authType")]
        public string AuthType { get; set; }

        /// <summary>
        /// Zakres integracji (WORKSPACE, PROJECT, ENVIRONMENT).
        /// </summary>
        [JsonPropertyName("scope")]
        public string Scope { get; set; }

        /// <summary>
        /// Nazwa projektu.
        /// </summary>
        [JsonPropertyName("projectName")]
        public string ProjectName { get; set; }

        /// <summary>
        /// ID dzierżawcy (np. dla integracji Azure).
        /// </summary>
        [JsonPropertyName("tenantId")]
        public string TenantId { get; set; }

        /// <summary>
        /// ID aplikacji.
        /// </summary>
        [JsonPropertyName("appId")]
        public string AppId { get; set; }

        /// <summary>
        /// Projekt Google.
        /// </summary>
        [JsonPropertyName("googleProject")]
        public string GoogleProject { get; set; }

        /// <summary>
        /// Sklep (np. dla integracji Shopify).
        /// </summary>
        [JsonPropertyName("shop")]
        public string Shop { get; set; }

        /// <summary>
        /// URL docelowy.
        /// </summary>
        [JsonPropertyName("targetUrl")]
        public string TargetUrl { get; set; }

        /// <summary>
        /// Token integracji.
        /// </summary>
        [JsonPropertyName("token")]
        public string Token { get; set; }

        /// <summary>
        /// Token partnera.
        /// </summary>
        [JsonPropertyName("partnerToken")]
        public string PartnerToken { get; set; }

        /// <summary>
        /// Klucz API.
        /// </summary>
        [JsonPropertyName("apiKey")]
        public string ApiKey { get; set; }

        /// <summary>
        /// Konfiguracja.
        /// </summary>
        [JsonPropertyName("config")]
        public string Config { get; set; }

        /// <summary>
        /// Klucz dostępu.
        /// </summary>
        [JsonPropertyName("accessKey")]
        public string AccessKey { get; set; }

        /// <summary>
        /// Klucz tajny.
        /// </summary>
        [JsonPropertyName("secretKey")]
        public string SecretKey { get; set; }

        /// <summary>
        /// ID chatu (np. dla integracji Telegram).
        /// </summary>
        [JsonPropertyName("chatId")]
        public string ChatId { get; set; }

        /// <summary>
        /// ID użytkownika GitHub.
        /// </summary>
        [JsonPropertyName("gitHubUserId")]
        public string GitHubUserId { get; set; }

        /// <summary>
        /// Nazwa użytkownika.
        /// </summary>
        [JsonPropertyName("username")]
        public string Username { get; set; }

        /// <summary>
        /// Hasło.
        /// </summary>
        [JsonPropertyName("password")]
        public string Password { get; set; }

        /// <summary>
        /// URL hosta.
        /// </summary>
        [JsonPropertyName("hostUrl")]
        public string HostUrl { get; set; }

        /// <summary>
        /// Adres webhooka.
        /// </summary>
        [JsonPropertyName("webhookAddress")]
        public string WebhookAddress { get; set; }

        /// <summary>
        /// ID klienta.
        /// </summary>
        [JsonPropertyName("clientId")]
        public string ClientId { get; set; }

        /// <summary>
        /// Token klienta.
        /// </summary>
        [JsonPropertyName("clientToken")]
        public string ClientToken { get; set; }

        /// <summary>
        /// ID serwera.
        /// </summary>
        [JsonPropertyName("serverId")]
        public string ServerId { get; set; }

        /// <summary>
        /// Token serwera.
        /// </summary>
        [JsonPropertyName("serverToken")]
        public string ServerToken { get; set; }

        /// <summary>
        /// ID klucza.
        /// </summary>
        [JsonPropertyName("keyId")]
        public string KeyId { get; set; }

        /// <summary>
        /// Klucz aplikacji.
        /// </summary>
        [JsonPropertyName("applicationKey")]
        public string ApplicationKey { get; set; }

        /// <summary>
        /// Audytorium (audience).
        /// </summary>
        [JsonPropertyName("audience")]
        public string Audience { get; set; }

        /// <summary>
        /// Założenia ról (dla AWS).
        /// </summary>
        [JsonPropertyName("roleAssumptions")]
        public List<RoleAssumptionView> RoleAssumptions { get; set; }

        /// <summary>
        /// URL ATOP.
        /// </summary>
        [JsonPropertyName("atopUrl")]
        public string AtopUrl { get; set; }

        /// <summary>
        /// Region.
        /// </summary>
        [JsonPropertyName("region")]
        public string Region { get; set; }

        /// <summary>
        /// Uprawnienia integracji.
        /// </summary>
        [JsonPropertyName("permissions")]
        public IntegrationPermissionsView Permissions { get; set; }

        /// <summary>
        /// Czy wszystkie pipeline'y są dozwolone.
        /// </summary>
        [JsonPropertyName("allPipelinesAllowed")]
        public bool AllPipelinesAllowed { get; set; }

        /// <summary>
        /// Dozwolone pipeline'y.
        /// </summary>
        [JsonPropertyName("allowedPipelines")]
        public List<PipelineView> AllowedPipelines { get; set; }
    }
}
