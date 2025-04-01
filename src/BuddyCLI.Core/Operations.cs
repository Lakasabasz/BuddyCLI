namespace BuddyCLI.Core;

public enum Operations
{
    [Alias("add")] Add,
    Update,
    Delete,
    List,
    Get,
    [Alias("")] None
}