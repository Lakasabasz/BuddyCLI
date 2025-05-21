using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BuddyCLI.Client.Models
{
    /// <summary>
    /// Reprezentuje widok pipeline'a.
    /// </summary>
    public class PipelineView
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
        /// ID pipeline'a.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// ID pipeline'a źródłowego.
        /// </summary>
        [JsonPropertyName("sourcePipelineId")]
        public int? SourcePipelineId { get; set; }

        /// <summary>
        /// Identyfikator.
        /// </summary>
        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }

        /// <summary>
        /// Nazwa pipeline'a.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Źródło definicji pipeline'a.
        /// </summary>
        [JsonPropertyName("definitionSource")]
        public string DefinitionSource { get; set; }

        /// <summary>
        /// Referencja konfiguracji Git.
        /// </summary>
        [JsonPropertyName("gitConfigRef")]
        public string GitConfigRef { get; set; }

        /// <summary>
        /// Referencje.
        /// </summary>
        [JsonPropertyName("refs")]
        public List<string> Refs { get; set; }

        /// <summary>
        /// Lista zdarzeń pipeline'a.
        /// </summary>
        [JsonPropertyName("events")]
        public List<PipelineEventView> Events { get; set; }

        /// <summary>
        /// Folder.
        /// </summary>
        [JsonPropertyName("folder")]
        public string Folder { get; set; }

        /// <summary>
        /// Priorytet.
        /// </summary>
        [JsonPropertyName("priority")]
        public string Priority { get; set; }

        /// <summary>
        /// Czy wyłączony.
        /// </summary>
        [JsonPropertyName("disabled")]
        public bool Disabled { get; set; }

        /// <summary>
        /// Powód wyłączenia.
        /// </summary>
        [JsonPropertyName("disabledReason")]
        public string DisabledReason { get; set; }

        /// <summary>
        /// Status ostatniego wykonania.
        /// </summary>
        [JsonPropertyName("lastExecutionStatus")]
        public string LastExecutionStatus { get; set; }

        /// <summary>
        /// Rewizja ostatniego wykonania.
        /// </summary>
        [JsonPropertyName("lastExecutionRevision")]
        public string LastExecutionRevision { get; set; }

        /// <summary>
        /// URL docelowej witryny.
        /// </summary>
        [JsonPropertyName("targetSiteUrl")]
        public string TargetSiteUrl { get; set; }

        /// <summary>
        /// Szablon wiadomości wykonania.
        /// </summary>
        [JsonPropertyName("executionMessageTemplate")]
        public string ExecutionMessageTemplate { get; set; }

        /// <summary>
        /// Data utworzenia.
        /// </summary>
        [JsonPropertyName("createDate")]
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// Projekt, do którego należy pipeline.
        /// </summary>
        [JsonPropertyName("project")]
        public ProjectView Project { get; set; }

        /// <summary>
        /// Twórca pipeline'a.
        /// </summary>
        [JsonPropertyName("creator")]
        public MemberView Creator { get; set; }

        /// <summary>
        /// Czy zawsze od nowa.
        /// </summary>
        [JsonPropertyName("alwaysFromScratch")]
        public bool AlwaysFromScratch { get; set; }

        /// <summary>
        /// Czy ignorować niepowodzenia ze statusu projektu.
        /// </summary>
        [JsonPropertyName("ignoreFailOnProjectStatus")]
        public bool IgnoreFailOnProjectStatus { get; set; }

        /// <summary>
        /// Czy nie pomijać do najnowszego.
        /// </summary>
        [JsonPropertyName("noSkipToMostRecent")]
        public bool NoSkipToMostRecent { get; set; }

        /// <summary>
        /// Czy zakończyć nieaktualne uruchomienia.
        /// </summary>
        [JsonPropertyName("terminateStaleRuns")]
        public bool TerminateStaleRuns { get; set; }

        /// <summary>
        /// Zakres cache'u.
        /// </summary>
        [JsonPropertyName("cacheScope")]
        public string CacheScope { get; set; }

        /// <summary>
        /// Czy automatycznie czyścić cache.
        /// </summary>
        [JsonPropertyName("autoClearCache")]
        public bool AutoClearCache { get; set; }

        /// <summary>
        /// Czy wstrzymany.
        /// </summary>
        [JsonPropertyName("paused")]
        public bool Paused { get; set; }

        /// <summary>
        /// Wstrzymuj po powtarzających się niepowodzeniach.
        /// </summary>
        [JsonPropertyName("pauseOnRepeatedFailures")]
        public int? PauseOnRepeatedFailures { get; set; }

        /// <summary>
        /// Czy pobierać wszystkie referencje.
        /// </summary>
        [JsonPropertyName("fetchAllRefs")]
        public bool FetchAllRefs { get; set; }

        /// <summary>
        /// Czy niepowodzenie przy ostrzeżeniu przygotowania środowiska.
        /// </summary>
        [JsonPropertyName("failOnPrepareEnvWarning")]
        public bool FailOnPrepareEnvWarning { get; set; }

        /// <summary>
        /// Czy zezwalać na równoległe uruchomienia pipeline'ów.
        /// </summary>
        [JsonPropertyName("concurrentPipelineRuns")]
        public bool ConcurrentPipelineRuns { get; set; }

        /// <summary>
        /// Głębokość klonowania.
        /// </summary>
        [JsonPropertyName("cloneDepth")]
        public int? CloneDepth { get; set; }

        /// <summary>
        /// Czy nie tworzyć statusów commit.
        /// </summary>
        [JsonPropertyName("doNotCreateCommitStatus")]
        public bool DoNotCreateCommitStatus { get; set; }

        /// <summary>
        /// Warunek wyzwalacza.
        /// </summary>
        [JsonPropertyName("triggerCondition")]
        public string TriggerCondition { get; set; }

        /// <summary>
        /// Wartość zmiennej wyzwalacza.
        /// </summary>
        [JsonPropertyName("triggerVariableValue")]
        public string TriggerVariableValue { get; set; }

        /// <summary>
        /// Klucz zmiennej wyzwalacza.
        /// </summary>
        [JsonPropertyName("triggerVariableKey")]
        public string TriggerVariableKey { get; set; }

        /// <summary>
        /// ID strefy.
        /// </summary>
        [JsonPropertyName("zoneId")]
        public string ZoneId { get; set; }

        /// <summary>
        /// Godziny wyzwalacza.
        /// </summary>
        [JsonPropertyName("triggerHours")]
        public List<int> TriggerHours { get; set; }

        /// <summary>
        /// Dni wyzwalacza.
        /// </summary>
        [JsonPropertyName("triggerDays")]
        public List<int> TriggerDays { get; set; }

        /// <summary>
        /// Nazwa projektu wyzwalacza.
        /// </summary>
        [JsonPropertyName("triggerProjectName")]
        public string TriggerProjectName { get; set; }

        /// <summary>
        /// Nazwa pipeline'a wyzwalacza.
        /// </summary>
        [JsonPropertyName("triggerPipelineName")]
        public string TriggerPipelineName { get; set; }

        /// <summary>
        /// Użytkownik wyzwalacza.
        /// </summary>
        [JsonPropertyName("triggerUser")]
        public string TriggerUser { get; set; }

        /// <summary>
        /// Grupa wyzwalacza.
        /// </summary>
        [JsonPropertyName("triggerGroup")]
        public string TriggerGroup { get; set; }

        /// <summary>
        /// Ścieżki warunku wyzwalacza.
        /// </summary>
        [JsonPropertyName("triggerConditionPaths")]
        public List<string> TriggerConditionPaths { get; set; }

        /// <summary>
        /// Lista warunków wyzwalacza.
        /// </summary>
        [JsonPropertyName("triggerConditions")]
        public List<TriggerConditionView> TriggerConditions { get; set; }

        /// <summary>
        /// Lista zmiennych środowiskowych.
        /// </summary>
        [JsonPropertyName("variables")]
        public List<EnvironmentVariableView> Variables { get; set; }

        /// <summary>
        /// Lista środowisk.
        /// </summary>
        [JsonPropertyName("environments")]
        public List<EnvironmentYaml> Environments { get; set; }

        /// <summary>
        /// Czy czyścić cache.
        /// </summary>
        [JsonPropertyName("clearCache")]
        public bool ClearCache { get; set; }

        /// <summary>
        /// Czy nieaktualny.
        /// </summary>
        [JsonPropertyName("stale")]
        public bool Stale { get; set; }

        /// <summary>
        /// Czy oczekuje na push.
        /// </summary>
        [JsonPropertyName("waitingForPush")]
        public bool WaitingForPush { get; set; }

        /// <summary>
        /// Zasoby.
        /// </summary>
        [JsonPropertyName("resources")]
        public string Resources { get; set; }

        /// <summary>
        /// Ścieżka zdalna.
        /// </summary>
        [JsonPropertyName("remotePath")]
        public string RemotePath { get; set; }

        /// <summary>
        /// Gałąź zdalna.
        /// </summary>
        [JsonPropertyName("remoteBranch")]
        public string RemoteBranch { get; set; }

        /// <summary>
        /// Nazwa zdalnego projektu.
        /// </summary>
        [JsonPropertyName("remoteProjectName")]
        public string RemoteProjectName { get; set; }

        /// <summary>
        /// Parametry zdalne.
        /// </summary>
        [JsonPropertyName("remoteParameters")]
        public List<PipelinePropertyView> RemoteParameters { get; set; }

        /// <summary>
        /// Konfiguracja Git.
        /// </summary>
        [JsonPropertyName("gitConfig")]
        public YamlDefinitionView GitConfig { get; set; }

        /// <summary>
        /// Tagi.
        /// </summary>
        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        /// <summary>
        /// Cele.
        /// </summary>
        [JsonPropertyName("targets")]
        public List<TargetView> Targets { get; set; }

        /// <summary>
        /// Uprawnienia.
        /// </summary>
        [JsonPropertyName("permissions")]
        public PermissionsView Permissions { get; set; }

        /// <summary>
        /// Baza zmian.
        /// </summary>
        [JsonPropertyName("changeSetBase")]
        public string ChangeSetBase { get; set; }

        /// <summary>
        /// Baza zmian Git.
        /// </summary>
        [JsonPropertyName("gitChangesetBase")]
        public string GitChangesetBase { get; set; }

        /// <summary>
        /// Baza zmian systemu plików.
        /// </summary>
        [JsonPropertyName("filesystemChangesetBase")]
        public string FilesystemChangesetBase { get; set; }

        /// <summary>
        /// Procesor.
        /// </summary>
        [JsonPropertyName("cpu")]
        public string Cpu { get; set; }

        /// <summary>
        /// Czy opis jest wymagany.
        /// </summary>
        [JsonPropertyName("descriptionRequired")]
        public bool DescriptionRequired { get; set; }

        /// <summary>
        /// Czy zarządzać zmiennymi przez YAML.
        /// </summary>
        [JsonPropertyName("manageVariablesByYaml")]
        public bool ManageVariablesByYaml { get; set; }

        /// <summary>
        /// Czy zarządzać uprawnieniami przez YAML.
        /// </summary>
        [JsonPropertyName("managePermissionsByYaml")]
        public bool ManagePermissionsByYaml { get; set; }

        /// <summary>
        /// Lista akcji.
        /// </summary>
        [JsonPropertyName("actions")]
        public List<ActionView> Actions { get; set; }
    }
}
