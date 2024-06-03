# Valks Minecraft Helper
Simplifies the tedious process of adding required dependency mods back to the mods folder when debugging faulty Minecraft mods.

![Untitled](https://github.com/Valks-Minecraft-Plugins/ValksMinecraftHelper/assets/6277739/e62f3eee-6085-49f2-bd3e-cdce914b0b38)

## Why make this?
The Hero Proof (v5.1.2) Minecraft mod transforms all console "Preparing spawn area: x%" messages to "menu.preparingSpawn". If you try to do the 'list' command you will get a similar unhelpful output. But I didn't know that it was this mod causing the problems at the time. I have a modpack called "The Energy Race" with over 400 mods. I wasn't going to remove half the mods, spend 10 minutes adding back all the required dependency mods needed, check if it works, repeat the same steps over and over again until I find  the culprit mod. Adding back all the required dependency mods takes a lot of time. So that's why I made "Valks Minecraft Helper". I couldn't think of a better name because the tool might evolve into something more later. Anyways this tool will add back all the dependencies needed with the click of a button. Much precious time is saved!

## GUI Explained
"Set Minecraft Folder" - This should be set to the minecraft instance folder. The folder where the mods, scripts, resourcepacks, shaderpacks folders are.
"Set Dependencies Folder" - This should be set to a new folder you create yourself in the mods folder. Name the folder something like temp.
"Set Minecraft Exe" - This should be set to run.bat if its a server or if not a server; whatever exe launches minecraft and generates logs for latest.log file.
"Move Dependencies" - This will move all the needed dependencies from "temp" back to "mods"
"Run Minecraft" - This will try to execute whatever file you set it to with the "Set Minecraft Exe" button. Saves extra clicks if you don't want to constantly try to find run.bat in the server folder.

## How to use this
1. Create a new folder called "temp" in your mods folder.
2. Set the dependencies folder to "temp".
3. Set the minecraft folder to the folder where the mods folder is.
4. Cut half of your mods and put them in "temp" folder.
5. Run minecraft and wait for latest.log file to generate
6. If minecraft failed to start because of missing required dependency mods, click on "Move Dependencies" button and try to run Minecraft again
7. Keep repeating step 6 until there are no dependency mods missing
8. Repeat steps 4 to 7 until you find the mod that is causing problems for you

## Tips
Alongside the "temp" folder you created for the "Set Dependencies Folder", create a new folder called "not culprit". If you run minecraft and the problem does not appear then move all the mods from "temp" to "not culprit".
