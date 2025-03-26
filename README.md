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
| run | execution/exec | Manage runs |
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

## Required Parameters

Different objects require specific parameters when creating resources:

### Environment
```
bdycli environment add --project <name> [--workspace <name>]
```

### Pipeline
```
bdycli pipeline add --project <name> [--workspace <name>]
```

### Action
```
bdycli action add --pipeline <name> [--project <name> [--workspace <name>]]
```

## Workspace Handling

Workspace parameters follow these rules:

- If you have only one workspace, the `--workspace` parameter is optional
- If you have multiple workspaces and your projects/pipelines have unique names across workspaces, the `--workspace` parameter is optional
- If you have multiple workspaces with projects/pipelines that have the same name, you must specify the `--workspace` parameter

To avoid repeatedly specifying these parameters, you can set defaults:

```
bdycli workspace set-default
bdycli environment set-default
bdycli project set-default
bdycli pipeline set-default
```

## Object-Specific Operations

### Workspace

The `workspace` object has limited operations:
- `get` - View details of the current workspace
- `list` - Display all available workspaces
- `set-default` - Set the default workspace

```
bdycli workspace get
bdycli ws list
bdycli workspace set-default
```

### Pipeline

The `pipeline` object has additional operations:
- `execute`/`exec` - Run a pipeline

```
bdycli pipeline execute pipeline-123
bdycli pipeline exec pipeline-123  # Equivalent
```

## Authentication

To authenticate with the BDY platform, use the special login command:

```
bdycli login <personal-access-token>
```

## Examples

```bash
# Environment management
bdycli env create --name production --project my-project
bdycli environment update production --description "Production environment"
bdycli env delete staging

# Pipeline operations
bdycli pipeline list --project project-slug
bdycli pipeline get pipeline-123
bdycli pipeline add --project my-project --workspace dev-team

# Variable management
bdycli var add --name API_KEY --value "secret" --encrypted
bdycli variable list

# Action management
bdycli action add --pipeline deploy-pipeline --project web-app

# Running pipelines
bdycli pipeline execute pipeline-123 --param key=value
bdycli pipeline exec pipeline-123 --param key=value

# Project operations
bdycli project create --name "New Project"
bdycli project list

# Workspace information
bdycli ws get
bdycli workspace list

# Setting defaults
bdycli workspace set-default
bdycli project set-default --name "Primary Project"
```