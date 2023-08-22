# The Console Application<br>
Basically we start by creating a new console application. Here is a simple console application that simply just writes to a file.<br>

### Program.cs file<br>
### DataProcessor.cs file<br>
# Setting Up The Windows Service<br>
The next step would be to include the necessary libraries and write some code that are required in order to create a windows service. The steps are as follows:<br>

### Step 1: Add New Item<br>
In your Visual Studio Console Project ⇒ Right click the project ⇒ Add ⇒ New Item<br>

### Step 2 : Add a new Windows Service<br>
Search and select Windows Service ⇒ Provide a name eg: <b>‘Service.cs‘</b> ⇒ Click Add<br>
This will add a new file which will contain your code that needs to be executed by the windows service.<br>

The Windows service needs to be running continuously, else it will automatically stop after it has completed its execution. Hence, in order to make the service run continuously, we will introduce a simple timer.<br>

### Step 3 : Setup the Installer Class<br>
You first need to add a reference to the <b>System.Configuration.Install</b> assembly via Project ⇒ Add ⇒ Reference.<br>

Next, Add a new Class with a meaningful name eg <b>‘ServiceInstaller.cs‘</b> <br>

The above code will provide your windows service with the necessary foundation for custom installation like the Service name and description, service account type etc.<br>

# Configure Self Installer<br>
Adding a Self installer within the windows service itself, removes the hurdle of depending on a tool like <b>InstallUtil.exe</b> for installation. This makes the installation much easier and straight forward.<br>

In your project, create a new class file with the name <b>SelfInstaller.cs</b> <br>

# Customize Program.cs <br>
The final tweak would be to customize the Program.cs to support the functioning of both a console application and the windows service.<br>

Summary : If you install the application, it will work as a windows service and if you directly run it, it will behave as a console application.<br>
