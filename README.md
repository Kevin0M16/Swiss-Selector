![Alt text](/SwissSelector1.4.png?raw=true "Optional Title")

# Swiss-Selector
CMS 2018 Mod</br>
Swiss Selector is a tool for Car Mechanic Simulator 2018. It uses a modded versoin of the original dll file.

## Update Notes
* <i>**Updated to 1.4** -- added start game button, fixed junkyard generator, added ability to delete car at garage entrance 1 and delete barns </i>
* <i>**Updated to 1.3** -- Added entire car is examined and part is examined. Fixed some file locating issues</i>
* <i>**Updated to 1.2** -- on first startup, tool now prompts to create ini files and comboboxes are greyed out
Added a select under File to delete all files created by tool</i>
* <i>**Updated to 1.1** -- added small image preview of mod cars and added 24 cars to junkyard</i>

## Getting Started
Here is an overview of what you need to get started with Swiss Selector

### Requirements

The current version of Swiss Selector requires Car Mechanic Simulator 2018 version 1.6.1

:exclamation: **Always back up all your game data and saves before any mods**

### Installation and setup
1. Backup your Managed Folder:  Steam\steamapps\common\Car Mechanic Simulator 2018\cms2018_Data\Managed<br />
2. Backup your saves folder: User\AppData\LocalLow\Red Dot Games\Car Mechanic Simulator 2018<br />
3. Backup your dll file: Assembly-CSharp-firstpass.dll in the \Managed Folder<br />
4. Place Swiss Selector.exe in Steam\steamapps\common\Car Mechanic Simulator 2018\cms2018_Data\Managed folder<br />
5. Replace Assembly-CSharp-firstpass.dll with the dll from this repository<br />
6.  Create a shortcut to Swiss Selector.exe and place it on your desktop<br />
7. Remove any existing ini files from the \Managed directory<br />
8. Run Swiss Selector.exe<br />
9. When prompted, build swiss.ini and keys.ini note: Swiss Selector must be in \Managed folder!<br />
10. If all fields populate then continue, otherwise manually select \Managed folder under File<br />
11. Check if the car names have populated on the left. If car names listbox is empty, click Advanced\manually select \Managed location and Select your root directory of all your car files.<br />
12. Now you can select your car to spawn, money and xp amounts, and key mapping. Be sure to save your key bindings!<br />
13. Leave Swiss Selector Open and then Open CMS 2018. Action keys are listed on Main Form.<br />
14. Enjoy!<br />


```
Give examples
```
## Default Key Functions

* :grey_exclamation: **MAKE A BACKUP OF YOUR SAVE-GAME AND DLL!**
* :grey_exclamation: **SPAWN CAR DELETES ANY CAR AT GARAGE ENTRANCE A/1! MAKE SURE ITS EMPTY FIRST!**

#### :computer: :key: Keys:
* Keypad 1 - Spawn car at Garage Entrance A or 1
* Keypad 2 - Increase Config version of the car
* Keypad 3 - Decrease Config version of the car
* Keypad 4 - Randomly change the condition of the car under the mouse
* Keypad 5 - Randomly change the color of the car under the mouse (also works in editor)
* Keypad 6 - Reload Liveries (also works in editor)
* Keypad 7 - Set mileage of car under mouse as set on Swiss Selector
* KeyPad 8 - Generate Junkyard
* Keypad 9 - Fully repair car under the mouse
* Keypad 0 - Duplicate Engine on Engine Stand add to inventory and set condition/quality from ini file
* Keypad + - Increase speed
* Keypad - - Decrease speed
* Keypad / - Photo Mode
* F6 - Add all Engine parts from Engine on Engine Stand to inventory and set condition/quality on Swiss Selector
* F7 - Repair all items in inventory and set condition/quality from ini file.
* F8 - Add Barn
* F9 - Add (x) dollars -- Set in Swiss Selector
* F10 - Add (x) XP -- Set in Swiss Selector
* F11 - Unlock all upgrades (Re-enter garage to activate)
* End - Open Shop (also works in assembly mode)
* Insert - Add the selected part (not body parts!) to inventory
* ] - Rotate Engine Right on stand
* [ - Rotate Engine Left on stand
* PageUP - Entire Car under mouse is Examined
* PageDown - Part under mouse is Examined
* Delete - Delete car at Garage Entrance 1
* Shift + Delete - Delete all barns after save reload

## Built With

* [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/) - For the Windows 10 UI
* [dnSpy](https://github.com/0xd4d/dnSpy) - To edit the dll file

## Authors

* **Kevin Lozano** - *Initial work* - [Kevin0M16](https://github.com/Kevin0M16)

## License

This project is licensed under the MIT License - see the [LICENSE](/LICENSE) file for details

## Acknowledgments

* Thanks to the people of the Car Mechanic Simulator Modding forum on Steam

