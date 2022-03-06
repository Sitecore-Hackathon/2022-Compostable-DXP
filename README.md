![Hackathon Logo](docs/images/hackathon.png?raw=true "Hackathon Logo")
# Sitecore Hackathon 2022

- MUST READ: **[Submission requirements](SUBMISSION_REQUIREMENTS.md)**
- [Entry form template](ENTRYFORM.md)
- [Starter kit instructions](STARTERKIT_INSTRUCTIONS.md)
  

### ⟹ [Insert your documentation here](ENTRYFORM.md) <<

# Hackathon Submission Entry form

<!--
You can find a very good reference to Github flavoured markdown reference in [this cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet). If you want something a bit more WYSIWYG for editing then could use [StackEdit](https://stackedit.io/app) which provides a more user friendly interface for generating the Markdown code. Those of you who are [VS Code fans](https://code.visualstudio.com/docs/languages/markdown#_markdown-preview) can edit/preview directly in that interface too.
-->

## Team name
⟹ Compostable DXP

## Category
⟹ Extend the Sitecore Command Line Interface (CLI) plugin

## Description
⟹The purpose of our module is fun! Our end goal was simply to get anything at all running as a CLI plugin.
<!--
⟹ Write a clear description of your hackathon entry.  

  - Module Purpose
  - What problem was solved (if any)
    - How does this module solve it

    The purpose of our module is fun! Our end goal was simply to get anything at all running as a CLI plugin.

_You can alternately paste a [link here](#docs) to a document within this repo containing the description._
-->

## Video link
<!--
⟹ Provide a video highlighing your Hackathon module submission and provide a link to the video. You can use any video hosting, file share or even upload the video to this repository. _Just remember to update the link below_
-->

⟹ [Replace this Video link](video/GMT20220306-004826_Recording_1628x966.mp4)

## Pre-requisites and Dependencies
<!--
⟹ Does your module rely on other Sitecore modules or frameworks?

- List any dependencies
- Or other modules that must be installed
- Or services that must be enabled/configured

_Remove this subsection if your entry does not have any prerequisites other than Sitecore_
-->
Docker

## Installation instructions
<!--
⟹ Write a short clear step-wise instruction on how to install your module.  

> _A simple well-described installation process is required to win the Hackathon._  
> Feel free to use any of the following tools/formats as part of the installation:
> - Sitecore Package files
> - Docker image builds
> - Sitecore CLI
> - msbuild
> - npm / yarn
> 
> _Do not use_
> - TDS
> - Unicorn
 
f. ex. 
-->
1. Open up an elevated Terminal at the root of the project directory
2. Add your Sitecore license file to `.\docker\License`
3. Start docker environment using `.\Start-Hackathon.ps1`
4. Run the comman `dotnet sitecore plugin init`
5. Run login to Sitecore using the CLI `dotnet sitecore login --authority https://id.compostabledxp.localhost --cm https://cm.compostabledxp.localhost --allow-write true`

### Configuration
<!--
⟹ If there are any custom configuration that has to be set manually then remember to add all details here.

_Remove this subsection if your entry does not require any configuration that is not fully covered in the installation instructions already_
-->

## Usage instructions
<!--
⟹ Provide documentation about your module, how do the users use your module, where are things located, what do the icons mean, are there any secret shortcuts etc.

Include screenshots where necessary. You can add images to the `./images` folder and then link to them from your documentation:

![Hackathon Logo](docs/images/hackathon.png?raw=true "Hackathon Logo")

You can embed images of different formats too:

![Deal With It](docs/images/deal-with-it.gif?raw=true "Deal With It")

And you can embed external images too:

![Random](https://thiscatdoesnotexist.com/)
-->

Welcome to the Primo ![Primo](pinched-fingers_1f90c.png) CLI Plugin!

In order to make use of the plugin, you will first want to open your terminal and navigate to your project folder.

The Primo CLI plugin includes a `primo` command that allows developers to print hackathon ASCII art.
It also contains a visually enhanced version of the `index` command. Specifically, the `rebuild` subcommand has been visually enhanced.

> Note: You should not have the `Sitecore.DevEx.Extensibility.Indexing` plugin installed alongside of the Primo CLI plugin or you will receive errors.

To install the Primo CLI plugin, run the following code:

`dotnet sitecore plugin add -n Primo.DevEx.Extensibility.Hackathon --version 1.0.0`
`dotnet sitecore plugin add -n Primo.DevEx.Extensibility.Indexing --version 1.0.0`


### Usage
The Primo CLI plugin `primo` command is initiated within the Sitecore CLI by using the following:
> dotnet sitecore primo [options] [subcommand] [options] [Arguement]

### Subcommands
You can use the following subcommands:
| Subcommand | Description |
|-------|----------|
| hello | Prints text to the console. |

### Options
You can use the following options within the `primo` command:

| Option | Required? | Description |
|-------|-----|----------|
| liststyles | No | Lists all valid \-\-Style subcommand values. |
| \-\-help<br/>-?<br/>-h | No | Display developer help and usage information about the command. |

You can use the following options within the `hello` subcommand:

| Option | Required? | Description |
|-------|-----|----------|
| \-\-message \<message><br/>-m | No | The message text to be displayed. Default: `Hello World!` |
| \-\-style \<style><br/>-s | No | The following values are recognized as valid input: `plain`, `emoticon`, `emoji`, `wordart` Default: `plain`|
| \-\-verbose<br/>-v | No | Report additional diagnostic and performance data. |
| \-\-trace<br/>-t | No | Outputs additional diagnostics and detailed information about the command. |
| \-\-help<br/>-?<br/>-h | No | Display developer help and usage information about the command. |

### Examples

The following are examples of using the `hello` command to print message text.

| Command | Description |
|-------|----------|
| `dotnet sitecore hello --message 'Hackathon for the win!' --style wordart` | Prints the text `Hackathon for the win!` to the console in a wordart style. |

The following are examples of using the `hello` command to print Hackathaon ASCII art.

| Command | Description |
|-------|----------|
| `dotnet sitecore hello --message 'Sitecore Hackathon'` | Prints Hackathon ASCII art to the console. Try it and see how much fun it is! |

### Usage
The Primo CLI plugin includes an `index` command as well. This command automates indexing operations.

The Primo CLI plugin `index` command is initiated within the Sitecore CLI by using the following:
> dotnet sitecore index [subcommand] [options]

> Note: Unless otherwise specified below the functionality of the `index` command matches that found at [The CLI index command](https://doc.sitecore.com/xp/en/developers/101/developer-tools/the-cli-index-command.html).

You will need to authenticate against a Sitecore environment. The provided Docker package includes on at https://MISSING

You can authenticate to this environment by using the following code:
`dotnet sitecore login --authority https://<Sitecore identity server> --cm http://<Sitecore instance> --allow-write true`

> Note: You can follow the documentation at [Log in to a Sitecore instance with Sitecore Command Line Interface](https://doc.sitecore.com/xp/en/developers/101/developer-tools/log-in-to-a-sitecore-instance-with-sitecore-command-line-interface.html)

### Subcommands
The following subcommands have been altered:
| Subcommand | Description |
|-------|----------|
| rebuild | Rebuilds all the indexes.<br/>`Now: Displays the results in a table that is updated asynchronously while the process is working.` |

## Comments
<!--
If you'd like to make additional comments that is important for your module entry.
-->
