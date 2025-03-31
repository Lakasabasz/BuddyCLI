namespace BuddyCLI.Client.Models;

public class User
{
    public string url { get; set; }
    public string htmlUrl { get; set; }
    public int id { get; set; }
    public string name { get; set; }
    public string avatarUrl { get; set; }
    public string workspaces_url { get; set; }
    public string email { get; set; }
    public bool admin { get; set; }
    public bool workspaceOwner { get; set; }
    public PermissionSet permissionSet { get; set; }
    public bool autoAssignToNewProjects { get; set; }
    public int autoAssignPermissionSetId { get; set; }
}

public class PermissionSet
{

}

