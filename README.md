# SuckItUpGame
Spring 2023 Collab Project



# Setup for working with Unity and Git for MART450

* This should take about 30 minutes.
* You must have a 64-bit computer.
* Instructions are for a PC with Windows 10 (adapt accordingly)

## 1. Join the MART450Spring organization

1. When you receive the invitation from the Professor, join the organization 
   https://github.com/MART450Spring
1. Go to the organization and do any setup you may be prompted to do. 
1. Go to the Repository for the class code. 
1. Click the green **Code** button and copy the HTTPS URL. 

Note: Even if you have a GitHub account, join via the invitation. 

## 2. Install GitHub Desktop

1. Go to https://desktop.github.com/ and follow the instructions.
1. Open GitHub Desktop.
1. Select File > Options > Accounts and sign in / verify with your GitHub account.

## 3. Install Git [Optional but very useful]

1. Go to https://git-scm.com/download/win and follow the instructions and make choices:

* Select components pane: Make sure GIT LFS is checked.
* When given the choice, do create the Desktop shortcut.
* When asked to choose a (text/code) editor, choose an editor you are familiar with and that you have.
* When prompted, !! Make sure you Override the default branch name and call it main.
* When asked about line endings, use the default: Configure line ending conversions to make sure to commit with Unix-style endings.
* … for everything else, use the recommended/default settings.

1. When done, open Git Bash (from the Desktop shortcut that was created). This is a console window to use with Git. 
1. In the console, type `which git` followed by Enter. This should return a directory. 
1. In the console, type `which git-lfs` followed by Enter. This should return a directory.

That's it for now.

## 4. Getting the 450 Project for the first time

1. Open GitHub Desktop. 
1. Make sure you are logged in. 
1. Select File > Clone Repository.
1. Click the URL tab.
1. Paste the URL that you copied from GitHub.
1. Set the local path for storing the project.
1. Click Clone. 
1. You should get an **Initialize Git LFS** popup. You must click **Initialize Git LFS**. 

## 5. Open your project in Unity

1. Start Unity and open the project. 
2. Build and run the project.

You can now work with the project locally. 

## UNLOCKING and Changing files

1. Always pull the latest changes from GitHub before you start work. 

TBD.

## Pushing your changes to GitHub (More TBD)

1. Make sure your project builds and runs in Unity WTHOUT ANY ERRORS. If you upload Errors, everyone else will have to deal with them as well.
1. Save your project in Unity. 
1. In GitHub Desktop, look at your Changes. Verify there are no errors. 
1. Commit your changes (locally). If everything looks good, go to the next step. 
1. Push your changes to GitHub.

## Keep local backups

1. Use **Assets > Back Up Unity Project** via the included `DIYVCS.cs` editor script. 
1. Store backups in an entirely different folder (not below a folder with .git file) so it doesn't go to GitHub. 
1. Make regular backups to an external drive or to the cloud. Something will go wrong, and you will need your backups. 

