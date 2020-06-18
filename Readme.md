# MultiLauncher
Tool allowing you to select one of multiple configurable programs to launch. Simply click on the button for the program you want to launch, or press escape to cancel.

![Example Image](https://i.imgur.com/TY0yaTg.png)

Intended to be used to select between multiple different installs of a game on Steam.

### Usage
1. Set the launch options for the game to `cmd /c start MultiLauncher.exe "%command%"`
2. Run the launcher once to generate an example config file
3. Edit the config file to point to the programs you want to launch instead

#### Config File
The config file is an XML file with the same name as the executable - you can store multiple launchers in the same folder by renaming them.

The root element is an array `Profiles`, containing one `Profile` element for each program. Each profile contains the following elements.

##### Name
The text to display on the button for this program.

##### Program
The program to launch.

##### Arguments
Any command line arguments to launch the program with. The string `%args%` will be replaced with the command line arguments the launcher was called with.

##### SkipFirstArg
A boolean value. If true, when substituting command line arguments it will skip the first one. Due to how Steam launch options must be set up, this argument will be the expansion of `%command%`, whatever the intended game executable is. If false, this argument will be substituted along with the rest of them.
