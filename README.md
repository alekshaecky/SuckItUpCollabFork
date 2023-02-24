
# SuckItUpGame Instructions and Tips
Spring 2023 Collab Project

Learning to work with Git/GitHub is learning another major tool. 
It's also an extremely valued professional skill. 
Everything is straightforward, but small things can get you snagged, or the instructions may be imperfect. Understanding how things work under the hood helps. There is awesome Git documentation and there are many great tutorial videos on YouTube.
Ask for Help in Discord! Report documentation issues, so they can be fixed. 

# Setup Steps for working with Unity and Git for MART450

* This should take about 30 minutes, but give yourself a solid hour.
* You must have a 64-bit computer.
* Instructions are for a PC with Windows 10 (and Mac).
* If you have any issues or questions, ask in the mart450-github Discord. 

## 0. Overview
* Git is a distributed source code control system. Basically, it tracks changes and manages different versions of a project by one or more users, so everyone can work on the same project and mostly keep their sanity. 
* GitHub is a web and cloud based Git server. Basically, it's a server where we can create, store, and manage projects on the web. 
* GitHub Desktop is a tool installed on your computer for interacting with Git/GitHub. It's a little easier than working from the command line. 
* So, the golden version of a project is stored on GitHub. You then make local copies to work on, and synchronize your local copy with the golden copy as needed. 

## 1. Join the MART450Spring organization on GitHub

Note: Even if you have a GitHub account, you must join via the invitation.

1. When you receive the invitation from the Professor, join the Organization 
   https://github.com/MART450Spring. Follow the on-screen instructions.
1. Go to the Organization and do any setup you may be prompted to do. 
1. Do NOT setup 2-factor authentication, even if prompted to do so.
1. Go to the Repository for the class code at https://github.com/MART450Spring/SuckItUpGame.
1. Click the green **Code** button. Notice the HTTPS URL. This is the link to the Repository that you will use to access it.  Save this URL somewhere for later use, or just remember how to get it.

## 2. Create a CLASSIC Personal Access Token

Because of the way security works, and because you are using scripts to access the remote repositories, you cannot just use your GitHub password to access the GitHub repositories. 
Instead, you use a secure and unique Access Token. 

To create an Access Token, do the following.
1. Got to GitHub on the web and login if necessary.
2. Click on your portrait and choose **Settings**. 
3. In Settings, scroll to the end of the left-hand-navigation and click **Developer Settings**.
4. Click **Personal Access Tokens**.
5. On the top right, select **Tokens (classic)**. - You must create a CLASSIC Token.
6. Click **Generate new token**. 
7. Give your Access Token a name.
8. Set an expiration time for your token. 90 Days is a good choice. Or, you can use Custom and set it to the date of the end of the semester. 
9. Check ALL the options, because it's easier than pick-and-choose-the-right-ones.
10. Generate the token. 
11. Copy the token and save it in a secure place (like, your encrypted password file). This is very important as it will disappear once you are done with the page, and you can't get it back from the website.

## 3. Install GitHub Desktop 

GitHub Desktop is the tool you use to get (clone) the the project Repository from GitHub, manage (commit) and upload (push) your changes to the project, and download (pull) the changes other students have made.

1. Go to https://desktop.github.com/ and follow the instructions for your platform.
1. Open GitHub Desktop.
1. Select **File > Options > Accounts** and sign in / verify with your GitHub account.

## 4a. Install Git - WINDOWS

Certain functionality requires that you have Git installed on your computer as well. For example, you need this for using the command line to interact with Git. You won't need this for most tasks, but if something goes wrong, the command line is your best friend. 

1. Go to https://git-scm.com/download/win and follow the instructions and make the following choices during install:

* **Select components pane: Make sure GIT LFS is NOT checked. Uncheck if necessary.**
* When given the choice, do create the Desktop shortcut.
* When asked to choose a (text/code) editor, choose an editor you are familiar with and that you have installed. 
* When prompted, !! Make sure you Override the default branch name and call it **main**.
* When asked about line endings, The GIT line endings should be Load as is... and save as LF.
* … for everything else, use the recommended/default settings.

1. When done, find your Desktop for Git Bash and open Git Bash. This is a nice console window to use with Git. (You can use cmd or any other Terminal window, if you prefer.)
1. In Git Bash, type `which git` followed by Enter. This should return a directory. 

That's it for now.

## 4b. Install Git - MAC

Official instructions: https://git-scm.com/download/mac

Use Software Update in System Settings to stay up to date.

1. Use Terminal to install Apple's Command Line Developer Tools, if you don't already have them.
`xcode-select --install`

1. Install **homebrew** if you don't already have it: https://brew.sh/
2. Install git: `$ brew install git`

If you have any Mac spefic issues, post in Discord and ping Jesse B. who has offered to help. 

## 5. Get (clone) the MART450 Project for the first time

Getting a complete project from a GitHub Repository is called "cloning". 
Use this process when you get the project for the first time. Also, if you want to "reset" to a good state (clean copy), delete your local copy and get (clone) the complete project again. 

You need a URL to the Repository for this. If you didn't save it earlier, get it now.
1. Go to the Repository for the class code at https://github.com/MART450Spring/SuckItUpGame
1. Click the green **Code** button and copy the HTTPS URL. 

Then, working with GitHub Desktop, clone the project as follows.
1. Open GitHub Desktop if it's not open yet.
1. Make sure you are logged in. If your password doesn't work, use the Access Token to log in.
1. Select **File > Clone Repository.**
1. Click the **URL** tab.
1. Paste the URL that you just copied from GitHub. 
1. Set the local path for storing the project. That's, where you want the project to go on your computer.
1. Click **Clone**. 
1. You should get an **Initialize Git LFS** popup. Click **Not Now** as shown in the screenshot below. **DO NOT INITILIAZIE LFS**. (OK, nothing horrible happens, but less potential for trouble.)
![image](https://user-images.githubusercontent.com/7841348/221072028-2de35707-1ffb-4590-8435-a574f3e7f15a.png)


1. When you are done successfully, this is what GitHub Desktop should look like. 
![image](https://user-images.githubusercontent.com/7841348/219176667-c00daaf6-195d-43d4-b11e-54b3da7a2d0a.png)

1. You can click **Show in Explorer** (or Finder) to see the project files on your computer if you wish, and verify that all the folders and filers are present.

Your project is now ready to work with. 

## 6. Open your project in the Unity Editor

1. Start Unity, add the project to the Unity Hub, and open the project. 
2. Open **Project Settings**.
3. Adjust these two Unity settings for using version-controlled projects.
* Switch to **Visible Meta Files** in **Edit → Project Settings → Editor → Version Control Mode**.
* Switch to **Force Text** in **Edit → Project Settings → Editor → Asset Serialization Mode**.
4. Build and run the project.

### Unity Tools
Verify that you have the following tools/packages installed in your project. 
If they are missing, use the Package Manager to install them. 

* **WebGL Publisher** (... you've used this in every class)
* **ProBuilder** (for modeling)
* **TextMeshPro** (3D Text objects)

1. Open **Windows > Package Manager**
2. Select **Packages: In Project** to see what you already have.
3. Select **Packages: Unity Registry**. 
4. Use Search to find each tool you still need to install. 
5. Verify it's the right tool. 
6. On the bottom right, click the **Install** button. (If it says Remove, then you already have the tool installed.)

Verifying that you have the tools:
7. For WebGL Publisher: Verify that you have the **Publish > WebGL Project** menu in the toolbar. 
8. For ProBuilder: There should be a **Tools > Pro Builder** menu in the toolbar. 
9. For TextMeshPro look for this menu item: **GameObject > 3D Object > Text - TextMeshPro**.

If you have no errors, you are now set up. 

# Tips for Working on the SuckItUpGame

## Always **Repository > Pull** the latest changes before you start work. 

IMPORTANT: Always pull the latest changes from GitHub before you start work and before you push your changes. This makes sure that you have the latest work, and that your work will not overwrite someone else's. Always push your changes when you are done working on something. Untangling small changes is much easier to sort out if there are issues.

## Conflicting changes and what to do.

When more than one user changes the same file, this can cause big problems for Unity projects (that is, us).

* For text files (like Scripts), Git can resolve conflicts for you, or help you do this manually. This can be tedious, and requires good understanding of the code, but there are tools to help.
* For binary files, such as image files (think Textures), merging changes is pretty impossible. Only one person should change those files at a time. If you see a conflict with such a file, find out who owns it, and work with them. Discord is your good friend here.
* For other complex files, such as Scenes, there are no tools to help, and resolving conflicts manually is not feasible. If two people make conflicting changes to a Scene, we'll have to deal with it when we get there. See Best Practice below. 

## Some Best Practices 

* If you are not sure who "owns" an asset, find out and talk to them before changing it. If you follow your Kanban assignments, you can minimize conflicts.
* Use Prefabs whenever possible. 
* You can create a "working Scene" for you in the Project for experimenting, showcasing, and sharing your work. 
* You can and should also create a "working side project" (a full copy of the SuckItUpGame) for you to try out stuff before adding it to the official SuckItUpGame project. Make sure this uses the latest version of the project.
* Never download assets from the Store directly into the SuckItUpGame project. See below.

## DO NOT download assets from the store into the SuckItUpGame project.

These asset packages always contain a lot more than what you need. 
Instead:
* Download the assets into a separate project. 
* Sort them out, figure out what you need (usually there will be the Prefabt plus Materials, Textures, maybe Shaders, and other stuff) and then only copy that into the SuckItUpGame Unity Project. 

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

You don't need these to work with the project, but they can come in handy.

### Stashing (cool beans....)

If you made changes to the project, and you want or need to (literally) stash them away for later, you can use the Stash command. 
You can later un-Stash those changes to put them back into the project. 
Or you can just throw them away. 

* See the Git documentation to learn more. 
* Stashing happens on a FIFO Stack, that is, you can stash things on top of each other, and the last one stashed will be the first one unstashed. 
* This may sound complicated, but it becomes handy when you need to deal with conflicts. 
* You can only stash uncommitted changes. 
* If there are files in your changes that you do not want to push (yet), you can stash those files, commit your changes, push, and then unstash. 
* You cannot break the project using stashing, so you can experiment with it. But you can confuse yourself...

### The Log / History

Git and GitHub track everything you and everyone else does on the Project. 
This is a good thing!
Your comments become part of the Log, which is why it's so important to have good comments!!!

* In GitHub Desktop, choose **View > History** to see the Log. 
* From the command line, it's **git log**


## Pushing your changes to GitHub

1. Make sure your project builds and runs in Unity WTHOUT ANY ERRORS. If you upload Errors, everyone else will have to deal with them as well.
2. Save your project in the Unity Editor. 
3. In GitHub Desktop, look at your Changes. Verify there are no errors. 
4. Pull the latest version of the project. Make sure there are no conflicts.
5. Commit your changes (locally). Only if everything looks good, go to the next step. 
6. Push your changes to GitHub.

## Keep local backups

1. Use **Assets > Back Up Unity Project** via the included `DIYVCS.cs` editor script. 
1. Store backups in an entirely different folder (not below a folder with `.git` file) so it doesn't go to GitHub. 
1. Make regular backups to an external drive or to the cloud. Something will go wrong, and you will need your backups. 

## More Git/GitHub Desktop Tips

* Work on the **main** branch only. (You can experiment making branches for yourself, but do not push them.)
* A "Pull Request" is not the same as "Repository > Pull". Always use **Repository > Pull**.
* You can open the command line tool from GitHub Desktop. Choose **Repository > Open in Command Prompt** for the default terminal. 
* To authenticate from the command line, always use your Access Token. 
* The top level of your local Repository for your project is the Folder that contains the `.git `file. You need to be in that folder (or a subfolder) for Git commands to work on your project.

## Glossary of Terminology

* **Repository** / ** Repo ** - A project or collection of code stored on GitHub (or in Git) with version conotrol set up. 
* **Git** - A tool for applying version control to a Repository installed on your local computer or on a remote server.
* **GitHub** - A Git Repository in the "cloud" (backed by Git and other tools) that can be managed over the web. Allows for easily sharing projects. 
* **Organization** - In the context of GitHub, a group of people that have access privileges to a collection of Repositories. 
* **Project** - Here, used interchangeably with *Repository*, because Unity has Projects...though it's not the same. 
* **Branches** - Git lets you create multiple versions of a project in branches. All your work is going to be on the **main** branch. Do not create branches in GitHub. (There will be branches in the project. Ignore them. See the documentation if you want to learn more. 

**Setup:**
* **Create** / *Init* - Make and set up new repositories - Do not use this as your project is already set up.
* **Clone** - Get the whole repository copied and set up on your local computer. You only do this when you start a new project, or to start with a clean version of the code if things go wrong locally.

**Working:**
* **Pull** - Download the latest version of the project in the GitHub Repository and integrate it with your local project. 
* **Commit** - Add changes to your local repository, document it with comments, and prepare it for pushing/uploading. You must resolve any issues with a commit before you can push the files. 
* **Push** - Uplod your committed changes to the GitHub Repository. If there are "conflicts" or "merge conflicts", ask for Help on Discord. 

## Learning more.
There are many more commands and terminology. 
* There is an extensive [Glossary of terms for GITHUB](https://docs.github.com/en/get-started/quickstart/github-glossary)... super technical.
* [Git documentation](https://git-scm.com/doc) and [GitHub documentation](https://docs.github.com/en) are extensive and if you want to learn more on how it works, just start reading. 
* There are also many, many great tutorials on YouTube and other websites. 

## Special Instructions for removing LFS tools from your Project

You only have to do this ONCE, if you previously installed LFS, to remove the LFS tools, and to get the non-lfs files. The project you are pulling from GitHub has already been "cleaned". 

1. Open your command line tool
1. Use the `cd` command to go to your GIT project. (The folder/directory that has the `.git` file in it.)
1. Enter `lfs uninstall`
2. Enter `git pull` and wait for the pull to finish. There should be no errors.

**If you have any trouble, remove and clone the project instead.**

1. Delete your current project. *(You have a backup of the assets your created, yes? Otherwise, make one now!)*
1. Yes, that's deleting the whole local project. You can just do that in your File Explorer/Finder.
1. Open GitHub Desktop.
1. It will probably ask you about a non-existing repo. Just tell it to remove it.
1. Follow the instructions above for cloning the repository. It's Step 5.


