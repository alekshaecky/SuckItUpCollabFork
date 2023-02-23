# SuckItUpGame Instructions and Tips
Spring 2023 Collab Project

Learning to work with Git/GitHub is learning another major tool. 
It's also a valued professional skill. 
Everything is straightforward, but small things can get you snagged, or the instructions may be imperfect.
Ask for Help in Discord! Report documentation issues, so they can be fixed. 

There is no table of contents, because we want folks to read the whole thing! (Then just use Search...)

# <a name="Setup"></a> Setup Steps for working with Unity and Git for MART450

* This should take about 30 minutes, but give yourself a solid hour.
* You must have a 64-bit computer.
* Instructions are for a PC with Windows 10 (and Mac).
* If you have any issues or questions, ask in the mart450-github Discord. 

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

## 5. Getting the MART450 Project for the first time

You will be asked to authenticate during this process. 
Use your email/username and password.
If using the password does not work, use the Access Token instead of your password. 

To get the code for the first time, you need to "clone" the repository. 

You need a URL to the repository for this.
1. Go to the Repository for the class code at https://github.com/MART450Spring/SuckItUpGame
1. Click the green **Code** button and copy the HTTPS URL.

Then, working with GitHub Desktop:
1. Open GitHub Desktop if it's not open yet.
1. Make sure you are logged in.
1. Select **File > Clone Repository.**
1. Click the **URL** tab.
1. Paste the URL that you just copied from GitHub. 
1. Set the local path for storing the project. That's, where you want the project to go on your computer.
1. Click **Clone**. 
1. You should get an **Initialize Git LFS** popup. DO NOT INITILIAZIE LFS (OK, nothing bad happens, but less potential for trouble.)

This is what it should look like. 
![image](https://user-images.githubusercontent.com/7841348/219176667-c00daaf6-195d-43d4-b11e-54b3da7a2d0a.png)

You can click **Show in Explorer** (or it Finder) to see the project files on your computer if you wish, and verify it's all there.
Your project is now ready to work with. 

## 6. Open your project in Unity to verify it all worked.

1. Start Unity and open the project. 
1. There are 2 Unity settings that need to be adjusted to use version control.
* Switch to Visible Meta Files in Edit → Project Settings → Editor → Version Control Mode.
* Switch to Force Text in Edit → Project Settings → Editor → Asset Serialization Mode.
1. Build and run the project.

### Unity Tools
Verify that you have the following tools in your project. 
If they are missing, use the Package Manager to install them. 

* WebGL Publisher (... you've used this in every class)
* ProBuilder (for modeling)
* TextMeshPro (3D Text objects)

1. Open **Windows > Package Manager**
2. Select **Packages: In Project** to see what you still need to install.
3. Select **Packages: Unity Registry**. 
4. Use Search to find the tool to install. 
5. Verify it's the right tool. 
6. On the bottom right, click the **Install** button. (If it says Remove, then you already have the tool installed.)
7. For WebGL Publisher: Verify that you have the **Publish > WebGL Project** menu in the toolbar. 
8. For ProBuilder: There should be a **Tools > Pro Builder** menu in the toolbar. 
9. For TextMeshPro look for this menu item: **GameObject > 3D Object > Text - TextMeshPro**.

If you have no errors, you are now set up. 

# <a name="Tips"></a> Working on the SuckItUpGame Tips

## Always **Repository > Pull** the latest changes before you start work. 

IMPORTANT: Always pull the latest changes from GitHub before you start work. This makes sure that you have the latest work, and that your work will not overwrite someone else's. Always push your changes when you are done working on something. Untanglingf small changes is much easier to sort out if there are issues.

## Conflicting changes and what to do.

When more than one user changes the same file, this can cause big problems for Unity projects (that is, us).

* For text files (like Scripts), Git can resolve conflicts for you, or help you do this manually. This can be tedious, and requires good understanding of the code, but there are tools to help.
* For binary files, such as image files (think Textures), merging changes is pretty impossible. Only one person should change those files at a time. If you see a conflict with such a file, find out who owns it, and work with them. Discord is your good friend here.
* For other complex files, such as Scenes, there are no tools to help, and resolving conflicts manually is not feasible. If two people make conflicting changes to a Scene, we'll have to deal with it when we get there. See Best Practice below. 

## Some Best Practices 

* If you are not sure who "owns" an asset, find out and talk to them before changing it. If you follow your Kanban assignments, you can minimize conflicts.
* Use Prefabs whenever possible. 
* You can create a "working Scene" for you in the Project for experimenting, showcasing, and sharing your work. 
* You can and should also create a "working side project" (a full copy of the SuckItUpGame) for you to try out stuff before adding it to the official SuckItUpGame project. 
* Never download assets from the Store into the SuckItUpGame project. See below.

## DO NOT download assets from the store into the SuckItUpGame project.

These asset packages always contain a lot more than what you need. 
Instead:
* Download the assets into a separate project. 
* Sort them out, figure out what you need (usually there will be the Prefabt plus Materials, Textures, maybe Shaders and other stuff) and then only copy that into the SuckItUpGame Unity Project. 

### Here are the full instructions from M5.

**Do NOT install into the class project from the store - EVER.**
1. Create a new empty project.
1. Import the asset unitypackage you want into the empty project.
1. Review the folders and files created using the Project View.
1. If there are scripts or shaders at all - reconsider if this is a good asset to include, 90% of the time you don't need scripts or shaders. As you become more proficient, you can include riskier assets.
1. Move files & folders a round until you get a clean asset with the art, audio, animations, prefabs, textures, materials, etc. all under one descriptive folder like "SyntyBeans" (notice no spaces).
1. Coders who know what they are doing can bring scripts or shaders over - but be CAREFUL.
1. You may find that you need to create new prefabs of some elements in the scene files, in order to transfer them together.
1. In the **Project View**, select the folder with only the assets you want.
1. Now use **Assets > Export Package** to create a new unitypackage with only the required parts.
1. Close your Temporary Unity Project, quit the Unity Editor.
1. Open the folder where you exported the unitypackage in your OS file system (File Explorer / Finder).
1. Make sure your SuckItUpGame is up-to-date and you have no pending commits / changes. To verify, open in GitHub Desktop, commit or stash (see below) your changes, pull the latest update. You want this to be squeaky clean!
1. Open the SuckItUpGame Project in the Unity Editor.
1. Drag & Drop the unitypackage to the class Project View or use **Assets > Import Package > Custom Package** and select your new unitypackage from the file dialog.
1, The Import dialog box will show allowing you to verify which files are being imported - check to be sure.
1. Actually click the **Import** button.

==> TaDa - now do that simple 16 step process for dozens to hundreds of assets. There are no shortcuts in GameDev. Good Luck.

## Advanced Features
* If you want to make absolutely sure no-one else works on your file, you can lock it. This is an advanced feature that you are set up for, and you can learn more about it below and in the documentation. 

### Stashing (cool beans....)

If you made changes to the project, and you want or need to (literally) stash them away for later, you can use the Stash command. 
You can later un-Stash those changes to put them back into the project. 

* See the documentation to learn more. 
* Stashing happens on a FIFO Stack, that is, you can stash things on top of each other, and the last one stashed will be the first one unstashed. 
* This may sound complicated, but it becomes handy when you need to deal with conflicts. 
* You can only stash uncommitted changes. 
* If there are files in your changes that you do not want to push (yet), you can stash those files, commit your changes, push, and then unstash. 
* You can't break the project using stashing, so you can experiment with it. 

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

### The Log / History

Git and GitHub track everything you and everyone else does on the Project. 
This is a good thing!
Your comments become part of the Log, which is why it's so important to have good comments!!!

* In GitHub Desktop, choose **View > History** to see the Log. 
* From the command line, it's **git log**


## Pushing your changes to GitHub

1. Make sure your project builds and runs in Unity WTHOUT ANY ERRORS. If you upload Errors, everyone else will have to deal with them as well.
1. Save your project in Unity. 
1. In GitHub Desktop, look at your Changes. Verify there are no errors. 
1. Commit your changes (locally). If everything looks good, go to the next step. 
1. Push your changes to GitHub.

## Keep local backups

1. Use **Assets > Back Up Unity Project** via the included `DIYVCS.cs` editor script. 
1. Store backups in an entirely different folder (not below a folder with .git file) so it doesn't go to GitHub. 
1. Make regular backups to an external drive or to the cloud. Something will go wrong, and you will need your backups. 

## More GitHub Desktop Tips

* Work on the main branch only. (You can experiment making branches for yourself, but do not push them.)
* A "Pull Request" is not the same as "Repository > Pull". Always use **Repository > Pull**.

## More Git Tips

* To authenticate from the command line, always use your Token. 
* You can use Git Bash as your command line tool (nicer), or from GitHub Desktop, choose Repository > Open in Command Prompt for the default terminal. 
* The top level of your local Repository for your project is the Folder that contains the .git file. You need to be in that folder (or a subfolder) for git commands to work on your project.

## Glossary of Terminology

* **Repository** / ** Repo ** - A project or collection of code stored on GitHub (or git) with version conotrol set up. 
* **Git** - A tool for applying version control to a Repository installed on your local computer or on a remote server.
* **GitHub** - A Git Repository in the "cloud" (backed by Git and other tools) that can be managed over the web. Allows for easily sharing projects. 
* **Organization** - In the context of GitHub, a group of people that have access privileges to a collection of Repositories. 
* **Project** - Here, used interchangeably with *Repository*, because Unity has Projects...though it's not the same. 
* **Branches** - Git lets you create multiple versions of a project in branches. All your work is going to be on the **main** branch. Do not create branches in GitHub. See the documentation if you want to learn more. 

**Setup:**
* **Create** / *Init* - Make and set up new repositories - Do not use this as your project is already set up.
* **Clone** - Get the repository copied and set up on your local computer. You only do this once (or to start with a clean slate after deleting your local repo)

**Working:**
* **Pull** - Download the latest version of the stuff in the GitHub Repository and integrate it with your local project. 
* **Commit** - Adds changes to your local repository, documents it with comments, and prepares it for pushing/uploading. You must resolve any issues with a commit before you can push the files. 
* **Push** - Uplod your committed changes to the GITHUB Repository. If there are "conflicts" or "merge conflicts", ask for Help on Discord. 

## Learning more.
There are many more commands and terminology. 
* There is an extensive [Glossary of terms for GITHUB](https://docs.github.com/en/get-started/quickstart/github-glossary)... super technical.
* [Git documentation](https://git-scm.com/doc) and [GitHub documentation](https://docs.github.com/en) are extensive and if you want to learn more on how it works, just start reading. There are also many, many tutorials on YouTube and other websites. 

## FAQ - Questions answered as they show up...

* Nothing here yet....


