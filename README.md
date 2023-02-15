# SuckItUpGame
Spring 2023 Collab Project

Learning to work with Git/GitHub is learning another major tool. 
It's also a valued professional skill. 
Everything is straightforward, but small things can get you snagged, or the instructions may be imperfect.
Ask for Help in Discord! Report documentation issues, so they can be fixed. 

# Setup for working with Unity and Git for MART450

* This should take about 30 minutes, but give yourself a solid hour.
* You must have a 64-bit computer.
* Instructions are for a PC with Windows 10 (adapt accordingly for other platforms).

## 1. Join the MART450Spring organization

1. When you receive the invitation from the Professor, join the organization 
   https://github.com/MART450Spring
1. Go to the organization and do any setup you may be prompted to do. 
1. Do NOT setup 2-factor authentication, even if prompted to do so. 
1. Go to the Repository for the class code at https://github.com/MART450Spring/SuckItUpGame
1. Click the green **Code** button and copy the HTTPS URL. Save it somewhere, or just remember how to get it.

Note: Even if you have a GitHub account, join via the invitation. 

## 2. Create a CLASSIC Personal Access Token

Because of the way security works, you cannot just use your password to allow the git scripts to access the remote repositories. 
An access token is a unique and complex passcode. 

1. Click on your portrait and choose Settings. 
1. Scroll to the end of the left-hand-navigation and click Developer Settings.
1. Click Personal Access tokens.
1. Select Tokens (classic) in the top right. - You must create a CLASSIC Token.
1. Click Generate new token. 
1. Give it a name.
1. Set the expiration time; you can use Custom and set it to the end of the semester date. 
1. Check ALL the options (because it's easier than pick-and-choose-the-right-ones.
1. Generate the token. 
1. Copy the token and save it in a secure place. (It will disappear once you are done with the page.)


## 3. Install GitHub Desktop 

1. Go to https://desktop.github.com/ and follow the instructions for your Platform.
1. Open GitHub Desktop.
1. Select File > Options > Accounts and sign in / verify with your GitHub account.

## 4a. Install Git - WINDOWS

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

## 4b. Install Git - MAC

Official instructions: https://git-scm.com/download/mac

Use Software Update in System Settings to stay up to date.

* Use Terminal to install Apple's Command Line Developer Tools:
`xcode-select --install`

1. Install **homebrew** if you don't already have it: https://brew.sh/
2. Install git: `$ brew install git`
3. Install git-lfs:`brew install git-lfs` (on Mac, it does not come with GitHub Desktop)

If you have any Mac spefic issues, post in Discord and ping Jesse B. who has offered to help. 

## 5. Getting the 450 Project for the first time

You will be asked to authenticate along this process. 
Use your email/username and password.
If that doesn't work, use the Access Token for your password. 

If you haven' done so:
1. Go to the Repository for the class code at https://github.com/MART450Spring/SuckItUpGame
1. Click the green **Code** button and copy the HTTPS URL.

Then, working with GitHub Desktop:
1. Open GitHub Desktop if it's not open yet.
1. Make sure you are logged in.
1. Select **File > Clone Repository.**
1. Click the **URL** tab.
1. Paste the URL that you copied from GitHub. 
1. Set the local path for storing the project. That's, where you want the project to go on your computer.
1. Click **Clone**. 
1. You should get an **Initialize Git LFS** popup. You must click **Initialize Git LFS**. 

This is what it will look like. 
![image](https://user-images.githubusercontent.com/7841348/219176667-c00daaf6-195d-43d4-b11e-54b3da7a2d0a.png)

You can click **Show in Explorer** (or it Finder) to see the project files on your computer if you wish, and verify it's all there.


## 6. Open your project in Unity

1. Start Unity and open the project. 
2. Build and run the project.

You can now work with the project locally. 
(Don't do that quite yet.)

## Workflow, LOCKING and UNLOCKING files

IMPORTANT: Always pull the latest changes from GitHub before you start work. This makes sure that you have the latest work, and that your work will not overwrite someone else's. Always push your changes when you are done working on something. Untanglingf small changes is much easier to sort out if there are issues.

### Conflicting changes
When more than one user changes a file, this can cause bit problems. 

* For text files (like Scripts), git can resolve conflicts automatically, or semi-automatically, or it's manually doable. This can be tedious, but there are tools to help. 
* For binary files, such as image files, merging changes is pretty impossible. 
* For other complex files, such as Scenes, there are no tools to help, and resolving conflicts manually is not feasible. 

### Locking (Experimental)

We are going to try and use locking to avoid conflicting changes. 
When you lock a file, no-one else can change it. 
The file types that can be locked are: TBD

Do the following: 
1. Pull 
1. Open the command line tool. 
1. Go to your project directory. 
1. Type: git lfs locks (this shows you all the files that are currently locked)
1. Autheticate with your Token, if necessary. 
1. git lfs lock <path/filename> (this locks the file so only you can edit it)

After you are done and have pushed your changes:
1. git unlock <path/filename>


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

## GitHub Desktop Tips

* Work on the main branch only. (You can experiment making branches for yourself, but do not push them.)

## Git Tips

* To authenticate from the command line, always use your Token. 
* You can use Git Bash as your command line tool (nicer), or from GitHub Desktop, choose Repository > Open in Command Prompt for the default terminal. 
* The top level of your local Repository for your project is the Folder that contains the .git file. You need to be in that folder (or a subfolder) for git commands to work on your project.

