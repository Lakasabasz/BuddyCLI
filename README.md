# BuddyCLI Documentation

BuddyCLI is a command-line interface tool for managing resources in the BDY platform. It follows a consistent command structure for easy memorization and usage.

## Command Structure

```
bdycli <object> <operation> [params] [arguments]
```

The CLI follows a predictable pattern where you specify:
1. The resource object you want to work with
2. The operation you want to perform
3. Optional parameters and arguments

## Objects

BDY CLI works with the following objects:

| Object | Aliases | Description |
|--------|---------|-------------|
| environment | env | Manage environments |
| pipeline | - | Manage pipelines |  
| action | - | Manage actions |
| run | exec | Execute jobs or workflows |
| project | - | Manage projects |
| variable | var | Manage variables |
| workspace | ws | View workspace information |

## Common Operations

Most objects support these standard operations:

| Operation | Aliases | Description |
|-----------|---------|-------------|
| add | create | Create a new resource |
| update | - | Modify an existing resource |
| delete | - | Remove a resource |
| list | - | Display all resources of this type |
| get | - | Retrieve details about a specific resource |

## Object-Specific Operations

### Workspace

The `workspace` object has limited operations:
- `get` - View details of the current workspace
- `list` - Display all available workspaces

```
bdycli workspace get
bdycli ws list
```

### Run

The `run` object has special behavior:
- Does not support the `delete` operation
- Provides an `execute` alias for the `add` operation

```
bdycli run add pipeline-123
bdycli exec execute pipeline-123  # Equivalent
```

## Authentication

To authenticate with the BDY platform, use the special login command:

```
bdycli login <personal-access-token>
```

## Examples

```bash
# Environment management
bdycli env create --name production
bdycli environment update production --description "Production environment"
bdycli env delete staging

# Pipeline operations
bdycli pipeline list --project project-slug
bdycli pipeline get pipeline-123

# Variable management
bdycli var add --name API_KEY --value "secret" --encrypted
bdycli variable list

# Running jobs
bdycli run add job-456 --param key=value
bdycli exec execute job-456 --param key=value

# Project operations
bdycli project create --name "New Project"
bdycli project list

# Workspace information
bdycli ws get
bdycli workspace list
```

