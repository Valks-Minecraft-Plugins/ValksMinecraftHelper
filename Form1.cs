using System.Diagnostics;
using System.Text.RegularExpressions;

namespace ValksMinecraftHelper;

public partial class Form1 : Form
{
    public static Config Config { get; set; }

    public Form1()
    {
        InitializeComponent();

        Config = Config.Get();

        string mc_folder = string.IsNullOrWhiteSpace(Config.MinecraftFolder) ?
            "Not Set" : Config.MinecraftFolder;

        string mc_dependencies = string.IsNullOrWhiteSpace(Config.DependenciesFolder) ?
            "Not Set" : Config.DependenciesFolder;

        string mc_exe = string.IsNullOrWhiteSpace(Config.MinecraftExe) ?
            "Not Set" : Config.MinecraftExe;

        Log($"Minecraft Instance Folder: {mc_folder}");
        Log($"Dependencies Folder: {mc_dependencies}");
        Log($"Minecraft Exe: {mc_exe}");
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void panel2_Paint(object sender, PaintEventArgs e)
    {

    }

    #region Buttons
    private void btnMoveDependencies_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Config.MinecraftFolder))
        {
            Log("Please fill out the minecraft instance folder path in the config. This is where" +
                " all the mods, scripts, resourcepacks, shaderpack folders are located.");
            return;
        }

        if (string.IsNullOrWhiteSpace(Config.DependenciesFolder))
        {
            Log("Please fill out the dependencies folder path in the config. This is where" +
                " all the temporary mods are located.");
            return;
        }

        List<string> dependency_names = FindDependencyNames();

        // These names are going to cause problems. Lets just move them back to the mods folder
        // Think of this as a mod whitelist. A list of mods to ignore.
        string[] problematic_mod_names = new string[]
        {
            "player-animation-lib-fabric", // Not the same name in latest.log
            "ftb-teams-fabric", // Not the same name in latest.log
            "fabric-api" // The key phrase that is copied from latest.log is just "fabric" and lots of mod names
            // have 'fabric' in their names so this will break the code
        };

        foreach (FileInfo file in new DirectoryInfo(Config.DependenciesFolder).GetFiles())
        {
            foreach (string name in problematic_mod_names)
            {
                if (file.Name.ToLower().Contains(name))
                {
                    Log($"Moved {file.Name} to mods folder as it is in the whitelist of mods to ignore");
                    file.MoveTo($@"{Config.MinecraftFolder}\mods\{file.Name}");
                    break;
                }
            }
        }

        if (dependency_names.Count == 0)
        {
            Log("Could not find any dependencies to move to the mods folder");
            return;
        }

        // Deep clone of dependency_names list
        List<string> missingDependencyNames = new(dependency_names);

        foreach (FileInfo file in new DirectoryInfo(Config.DependenciesFolder).GetFiles())
        {
            foreach (string name in dependency_names)
            {
                if (file.Name.ToLower().Contains(name))
                {
                    missingDependencyNames.Remove(name);
                    Log($"Moved {file.Name} to mods folder");
                    file.MoveTo($@"{Config.MinecraftFolder}\mods\{file.Name}");
                    break;
                }
            }
        }

        foreach (FileInfo file in new DirectoryInfo($@"{Config.MinecraftFolder}\mods").GetFiles())
        {
            for (int i = 0; i < missingDependencyNames.Count; i++)
            {
                if (file.Name.ToLower().Contains(missingDependencyNames[i]))
                {
                    //MessageBox.Show(file.Name + " " + missingDependencyNames[i]);

                    missingDependencyNames.RemoveAt(i);
                }
            }
        }

        if (missingDependencyNames.Count != 0)
        {
            Log($"Failed to move {string.Join(", ", missingDependencyNames)} mod(s) from dependencies folder. " +
                $"This could be because the mod name retrieved in latest.log differs slightly " +
                $"from the actual mod file name OR it failed because for example lets say the mod" +
                $" name retrieved from latest.log was called 'fabric'. Well lots of mod names have " +
                $"fabric in their names. So the code could be thinking that it moved another mod " +
                $"when it in fact did not. This is obviously a bug in the code.");
        }
    }

    private void btnRunMinecraft_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Config.MinecraftExe))
        {
            Log("Minecraft Exe path has not been set to anything yet");
            return;
        }

        File.Delete($@"{Config.MinecraftFolder}\logs\latest.log");

        Process.Start(new ProcessStartInfo()
        {
            WorkingDirectory = new FileInfo(Config.MinecraftExe).Directory.FullName,
            FileName = Config.MinecraftExe
        });

        Log("Started Minecraft process");
    }

    private void btnSetMinecraftExe_Click(object sender, EventArgs e)
    {
        OpenFileDialog dialog = new();

        if (!string.IsNullOrWhiteSpace(Config.MinecraftExe))
        {
            dialog.InitialDirectory = new FileInfo(Config.MinecraftExe).Directory.FullName;
        }

        DialogResult result = dialog.ShowDialog();

        if (result == DialogResult.OK)
        {
            Config.MinecraftExe = dialog.FileName;
            Config.Save();
        }

        Log($"Minecraft Exe set to {Config.MinecraftExe}");
    }

    private void btnSetMinecraftFolder_Click(object sender, EventArgs e)
    {
        SetFolder(Config.MinecraftFolder, "Minecraft Instance", (dialog) =>
        {
            Config.MinecraftFolder = dialog.SelectedPath;
        });
    }

    private void btnSetDependenciesFolder_Click(object sender, EventArgs e)
    {
        SetFolder(Config.DependenciesFolder, "Dependencies", (dialog) =>
        {
            Config.DependenciesFolder = dialog.SelectedPath;
        });
    }

    private void button_Exit(object sender, EventArgs e)
    {
        Close();
    }
    #endregion

    #region Utils
    void Log(string text)
    {
        textBox1.AppendText($"{text}\r\n");
    }

    void SetFolder(string folder, string folderName, Action<FolderBrowserDialog> setConfigFolder)
    {
        FolderBrowserDialog dialog = new();

        if (!string.IsNullOrWhiteSpace(folder))
        {
            dialog.InitialDirectory = folder;
        }

        DialogResult result = dialog.ShowDialog();

        if (result == DialogResult.OK)
        {
            Log($"{folderName} folder set to {dialog.SelectedPath}");
            setConfigFolder(dialog);
            Config.Save();
        }
    }

    // This will scan the dependencies folder for all the dependencies that are needed in order
    // for the mods to work properly. All mod names are converted to lowercase.
    List<string> FindDependencyNames()
    {
        List<string> mod_names = new();

        const string SOLUTION_FOUND = "A potential solution has been determined, this may resolve your problem:";

        IEnumerable<string> lines = File.ReadLines($@"{Config.MinecraftFolder}\logs\latest.log");
        bool solution_found = true;

        foreach (string line in lines)
        {
            if (solution_found)
            {
                if (line.Contains("Install"))
                {
                    Match regex = Regex.Match(line, "Install (?<mod_name>.+), ");

                    string mod_name = regex.Groups["mod_name"].Value.ToLower();

                    if (!mod_names.Contains(mod_name))
                        mod_names.Add(mod_name);
                }

                else if (line.Contains("requires any version of"))
                {
                    Match regex = Regex.Match(line, "requires any version of (?<mod_name>.+), which is missing");

                    string mod_name = regex.Groups["mod_name"].Value.ToLower();

                    if (!mod_names.Contains(mod_name))
                        mod_names.Add(mod_name);
                }

                else if (line.Contains("or later of"))
                {
                    /*Match regex = Regex.Match(line, "or later of (?<mod_name>.+), which is missing");
                    
                    string mod_name = regex.Groups["mod_name"].Value.ToLower();

                    if (!mod_names.Contains(mod_name))
                        mod_names.Add(mod_name);
                    */
                }
            }

            if (line.Contains(SOLUTION_FOUND))
                solution_found = true;
        }

        return mod_names;
    }
    #endregion

    #region Make Window Draggable
    // https://stackoverflow.com/questions/1592876/make-a-borderless-form-movable
    public const int WM_NCLBUTTONDOWN = 0xA1;
    public const int HT_CAPTION = 0x2;

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    public static extern bool ReleaseCapture();

    private void panel3_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
    }
    #endregion
}
