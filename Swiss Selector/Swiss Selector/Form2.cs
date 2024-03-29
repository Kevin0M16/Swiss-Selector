﻿using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Swiss_Selector //version 1.5
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();            
        }
        private void Form2_Shown(object sender, EventArgs e)
        {
            StartUp();
            if (checker == 0)
            {
                AppendLine(textBox1, "Swiss Selector loaded Successfully... Code: " + checker);
            }
            else
            {
                AppendLine(textBox1, "Swiss Selector loaded but with ERRORS! read log! Code: " + checker);
            }
        }
        private void StartUp()
        {
            dllPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            if (File.Exists(dllPath + @"..\..\Managed\Assembly-CSharp-firstpass.dll"))
            {
                listBox1.Items.Clear();
                //UnLockKeys(false);
                savePath = Application.CommonAppDataPath + "\\save.txt";
                //startPrefPath = Application.CommonAppDataPath + "\\startPref.txt";
                BuildSaveFile();
                //BuildStartFile();
                ReloadSave();
                //ReloadStart();
                Pref();
                //SetKeys();
                SetNums();
                listBox3.Items.Clear();
                ModName(listBox2, listBox3, swissPath);
                //ModName(listBox4, listBox5, keysPath);
                GetPlate(textBox2, swissPath);                
            }
            else
            {
                checker = 1;
                AppendLine(textBox1, "Swiss Selector not in \\Managed folder...");
                //UnLockKeys(false);
            }
        }
        public void BuildiniFile(string ini)
        {
            string path = dllPath;
            if (ini == swissPath)
            {
                if (!File.Exists(ini) && File.Exists(path + @"..\..\Managed\Assembly-CSharp-firstpass.dll"))
                {
                    DialogResult dialogResult = MessageBox.Show("No swiss.ini exits. Create file?", "swiss.ini Creator", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        File.Create(ini).Close();
                        TextWriter tw = new StreamWriter(ini);
                        tw.WriteLine("car=car_boltatlanta");
                        tw.WriteLine("quality=200");
                        tw.WriteLine("mileage=4000");
                        tw.WriteLine("condition=1");
                        tw.WriteLine("addMoneyAmount=10000");
                        tw.WriteLine("setMoneyAmount=1100000");
                        tw.WriteLine("addXPAmount=2500");
                        tw.WriteLine("showInventory=true");
                        tw.WriteLine("showIntro=true");
                        tw.WriteLine("spawnIsExamined=true");
                        tw.WriteLine("licensePlate=Kevin0M16");
                        tw.WriteLine("spawnLocation=garage1");
                        tw.Close();

                        swissPath = path + @"\swiss.ini";
                        Writeini("swissPath", swissPath, savePath);

                        if (checker == 0)
                        {
                            AppendLine(textBox1, "The swiss.ini was created Successfully...");
                            AppendLine(textBox1, "The swiss.ini has no errors...");
                        }
                        else
                        {
                            AppendLine(textBox1, "The swiss.ini Error");
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        AppendLine(textBox1, "Canceled! No ini was created...");
                        return;
                    }
                }
                else if (File.Exists(ini) && File.Exists(path + @"..\..\Managed\Assembly-CSharp-firstpass.dll"))
                {
                    DialogResult dialogResult1 = MessageBox.Show("swiss.ini already exits. Overwrite?", "swiss.ini Creator", MessageBoxButtons.YesNo);
                    if (dialogResult1 == DialogResult.Yes)
                    {
                        File.Create(ini).Close();
                        TextWriter tw = new StreamWriter(ini);
                        tw.WriteLine("car=car_boltatlanta");
                        tw.WriteLine("quality=200");
                        tw.WriteLine("mileage=4000");
                        tw.WriteLine("condition=1");
                        tw.WriteLine("addMoneyAmount=10000");
                        tw.WriteLine("setMoneyAmount=1100000");
                        tw.WriteLine("addXPAmount=2500");
                        tw.WriteLine("showInventory=true");
                        tw.WriteLine("showIntro=true");
                        tw.WriteLine("spawnIsExamined=true");
                        tw.WriteLine("licensePlate=Kevin0M16");
                        tw.WriteLine("spawnLocation=garage1");
                        tw.Close();

                        if (checker == 0)
                        {
                            AppendLine(textBox1, "The swiss.ini was created Successfully...");
                            AppendLine(textBox1, "The swiss.ini has no errors...");
                        }
                        else
                        {
                            AppendLine(textBox1, "The swiss.ini Error");
                        }
                    }
                    else if (dialogResult1 == DialogResult.No)
                    {
                        AppendLine(textBox1, "Canceled! No ini was created...");
                        return;
                    }
                }
            }
            if (ini == swissPath && !File.Exists(path + @"..\..\Managed\Assembly-CSharp-firstpass.dll"))
            {
                AppendLine(textBox1, "Swiss Selector not in \\Managed folder...");
            }
            if (ini == keysPath)
            {
                if (!File.Exists(ini) && File.Exists(path + @"..\..\Managed\Assembly-CSharp-firstpass.dll"))
                {
                    DialogResult dialogResult2 = MessageBox.Show("No keys.ini exits. Create file?", "keys.ini Creator", MessageBoxButtons.YesNo);
                    if (dialogResult2 == DialogResult.Yes)
                    {

                        File.Create(ini).Close();
                        TextWriter tw = new StreamWriter(ini);
                        tw.WriteLine("SpawnCar=1");
                        tw.WriteLine("IncreaseConfig=2");
                        tw.WriteLine("DecreaseConfig=3");
                        tw.WriteLine("RandomChangeCondition=4");
                        tw.WriteLine("RandomChangeColor=5");
                        tw.WriteLine("ReloadLiveries=6");
                        tw.WriteLine("SetMileage=7");
                        tw.WriteLine("GenerateJunkyard=8");
                        tw.WriteLine("FullyRepairCar=9");
                        tw.WriteLine("PhotoMode=/");
                        tw.WriteLine("DuplicateEngine=0");
                        tw.WriteLine("IncreaseSpeed=+");
                        tw.WriteLine("DecreaseSpeed=-");
                        tw.WriteLine("AddAllEngineParts=F6");
                        tw.WriteLine("RepairAllItems=F7");
                        tw.WriteLine("AddBarn=F8");
                        tw.WriteLine("AddMoney=F9");
                        tw.WriteLine("SetMoney=Home");
                        tw.WriteLine("AddXP=F10");
                        tw.WriteLine("UnlockAllUpgrades=F11");
                        tw.WriteLine("OpenShop=End");
                        tw.WriteLine("AddThisPart=Insert");
                        tw.WriteLine("RotateEngineRight=]");
                        tw.WriteLine("RotateEngineLeft=[");
                        tw.WriteLine("CarIsExamined=PageUp");
                        tw.WriteLine("PartIsExamined=PageDown");
                        tw.Close();

                        keysPath = path + @"\keys.ini";
                        Writeini("keysPath", keysPath, savePath);

                        if (checker == 0)
                        {
                            AppendLine(textBox1, "The keys.ini was created Successfully...");
                            AppendLine(textBox1, "The keys.ini has no errors...");
                            //UnLockKeys(true);
                        }
                        else
                        {
                            AppendLine(textBox1, "The keys.ini Error");
                        }
                    }
                    else if (dialogResult2 == DialogResult.No)
                    {
                        AppendLine(textBox1, "Canceled! No ini was created...");
                        //UnLockKeys(false);
                        return;
                    }

                }
                else if (File.Exists(ini) && File.Exists(path + @"..\..\Managed\Assembly-CSharp-firstpass.dll"))
                {
                    DialogResult dialogResult3 = MessageBox.Show("keys.ini already exits. Overwrite?", "keys.ini Creator", MessageBoxButtons.YesNo);
                    if (dialogResult3 == DialogResult.Yes)
                    {
                        File.Create(ini).Close();
                        TextWriter tw = new StreamWriter(ini);
                        tw.WriteLine("SpawnCar=1");
                        tw.WriteLine("IncreaseConfig=2");
                        tw.WriteLine("DecreaseConfig=3");
                        tw.WriteLine("RandomChangeCondition=4");
                        tw.WriteLine("RandomChangeColor=5");
                        tw.WriteLine("ReloadLiveries=6");
                        tw.WriteLine("SetMileage=7");
                        tw.WriteLine("GenerateJunkyard=8");
                        tw.WriteLine("FullyRepairCar=9");
                        tw.WriteLine("PhotoMode=/");
                        tw.WriteLine("DuplicateEngine=0");
                        tw.WriteLine("IncreaseSpeed=+");
                        tw.WriteLine("DecreaseSpeed=-");
                        tw.WriteLine("AddAllEngineParts=F6");
                        tw.WriteLine("RepairAllItems=F7");
                        tw.WriteLine("AddBarn=F8");
                        tw.WriteLine("AddMoney=F9");
                        tw.WriteLine("SetMoney=Home");
                        tw.WriteLine("AddXP=F10");
                        tw.WriteLine("UnlockAllUpgrades=F11");
                        tw.WriteLine("OpenShop=End");
                        tw.WriteLine("AddThisPart=Insert");
                        tw.WriteLine("RotateEngineRight=]");
                        tw.WriteLine("RotateEngineLeft=[");
                        tw.WriteLine("CarIsExamined=PageUp");
                        tw.WriteLine("PartIsExamined=PageDown");
                        tw.Close();

                        if (checker == 0)
                        {
                            AppendLine(textBox1, "The keys.ini was created Successfully...");
                            AppendLine(textBox1, "The keys.ini has no errors...");
                            //UnLockKeys(true);
                        }
                        else
                        {
                            AppendLine(textBox1, "The keys.ini Error");
                        }
                    }
                    else if (dialogResult3 == DialogResult.No)
                    {
                        AppendLine(textBox1, "Canceled! No ini was created...");
                        return;
                    }
                }
            }
            if (ini == keysPath && !File.Exists(path + @"..\..\Managed\Assembly-CSharp-firstpass.dll"))
            {
                AppendLine(textBox1, "Swiss Selector not in \\Managed folder...");
            }
        }
        public void BuildSaveFile()
        {
            if (!File.Exists(savePath))
            {
                File.Create(savePath).Close();
                TextWriter tw = new StreamWriter(savePath);
                tw.WriteLine("swissPath=D:\\Steam\\steamapps\\common\\Car Mechanic Simulator 2018\\cms2018_Data\\Managed\\swiss.ini");
                tw.WriteLine("keysPath=D:\\Steam\\steamapps\\common\\Car Mechanic Simulator 2018\\cms2018_Data\\Managed\\keys.ini");
                tw.WriteLine("carsPath=D:\\Steam");
                tw.Close();
            }
            else if (File.Exists(savePath))
            {
                return;
            }
        }
        public void LookForDefaults(string file)
        {
            AppendLine(textBox1, "Path to " + file + " not set!");
            AppendLine(textBox1, "Searching for " + file + " at default locations.....");
            if (file == "keysPath")
            {
                string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                keysPath = Path.GetFullPath(path + @"\keys.ini");
                if (File.Exists(keysPath))
                {
                    Writeini("keysPath", keysPath, savePath);
                    AppendLine(textBox1, "Path to keys.ini Set Successfully...");
                    //LoadKeys();
                }
                else if (!File.Exists(keysPath))
                {
                    AppendLine(textBox1, "dll path found, creating keys.ini");
                    BuildiniFile(keysPath);
                }
            }
            if (file == "swissPath")
            {
                string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                swissPath = Path.GetFullPath(path + @"\swiss.ini");
                if (File.Exists(swissPath))
                {
                    Writeini("swissPath", swissPath, savePath);
                    AppendLine(textBox1, "Path to swiss.ini Set Successfully...");
                    LoadSwiss();
                    LoadPng();
                }
                else if (!File.Exists(swissPath))
                {
                    AppendLine(textBox1, "dll path found, creating swiss.ini");
                    BuildiniFile(swissPath);
                }
            }
            if (file == "carsPath")
            {
                try
                {
                    string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                    //string path = @"D:\Steam\steamapps\common\Car Mechanic Simulator 2018\cms2018_Data\Managed";
                    carsPath = Path.GetFullPath(Path.Combine(path, @"..\..\..\..\..\"));

                    if (Directory.Exists(carsPath))
                    {
                        DirectoryInfo dinfo = new DirectoryInfo(carsPath);
                        FileInfo[] Files = dinfo.GetFiles("*.cms", SearchOption.AllDirectories);
                        if (Files.Length != 0)
                        {
                            Writeini("carsPath", carsPath, savePath);
                            AppendLine(textBox1, "Path to Cars Set Successfully...");
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                catch
                {
                    AppendLine(textBox1, "CarsPath error!");
                    checker = 1;
                    return;
                }
            }
        }
        public void ReloadSave()
        {
            Read("keysPath", savePath);
            keysPath = currentKey;
            Read("swissPath", savePath);
            swissPath = currentKey;
            Read("carsPath", savePath);
            carsPath = currentKey;

            if (File.Exists(keysPath))
            {
                AppendLine(textBox1, "Path to keys.ini found...");
                //UnLockKeys(true);
            }
            else
            {
                AppendLine(textBox1, "Path to keys.ini not found!");
                LookForDefaults("keysPath");
            }
            if (File.Exists(swissPath))
            {
                AppendLine(textBox1, "Path to swiss.ini found...");
            }
            else
            {
                AppendLine(textBox1, "Path to swiss.ini not found!");
                LookForDefaults("swissPath");
            }
            if (Directory.Exists(carsPath))
            {
                LoadCars();
                LoadPng();
            }
            else
            {
                AppendLine(textBox1, "Path to cars not found!");
                LookForDefaults("carsPath");
                LoadCars();
            }
        }
        public void Pref()
        {
            if (File.Exists(swissPath))
            {
                Read("showInventory", swissPath);
                if (currentKey == "true")
                {
                    openInvToolStripMenuItem.Checked = true;
                    dontOpenInvToolStripMenuItem.Checked = false;
                }
                else if (currentKey == "false")
                {
                    openInvToolStripMenuItem.Checked = false;
                    dontOpenInvToolStripMenuItem.Checked = true;
                }
                Read("showIntro", swissPath);
                if (currentKey == "true")
                {
                    showIntroToolStripMenuItem.Checked = true;
                    dontShowIntroToolStripMenuItem.Checked = false;
                }
                else if (currentKey == "false")
                {
                    showIntroToolStripMenuItem.Checked = false;
                    dontShowIntroToolStripMenuItem.Checked = true;
                }
                Read("spawnIsExamined", swissPath);
                if (currentKey == "true")
                {
                    examinedOnSpawnToolStripMenuItem.Checked = true;
                    notExaminedOnSpawnToolStripMenuItem.Checked = false;
                }
                else if (currentKey == "false")
                {
                    examinedOnSpawnToolStripMenuItem.Checked = false;
                    notExaminedOnSpawnToolStripMenuItem.Checked = true;
                }
            }
            else if (!File.Exists(swissPath))
            {
                openInvToolStripMenuItem.Checked = false;
                dontOpenInvToolStripMenuItem.Checked = false;
                showIntroToolStripMenuItem.Checked = false;
                dontShowIntroToolStripMenuItem.Checked = false;
                examinedOnSpawnToolStripMenuItem.Checked = false;
                notExaminedOnSpawnToolStripMenuItem.Checked = false;
            }
        }
        public static void AppendLine(TextBox source, string value)
        {
            if (source.Text.Length == 0)
                source.Text = value;
            else
                source.AppendText("\r\n" + value);
        }
        private void GetPlate(TextBox txtb1, string path)
        {
            try
            {
                if (File.Exists(path))
                {

                    string[] array = File.ReadAllLines(path).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
                    for (int i = 0; i < array.Length; i++)
                    {
                        string a = array[i].Substring(0, array[i].IndexOf("="));
                        string s = array[i].Substring(array[i].IndexOf("=") + 1);

                        if (a == "licensePlate")
                        {
                            txtb1.Text = s;
                        }

                    }
                    return;
                }
            }
            catch
            {
                AppendLine(textBox1, "ini File Corrupted! See Log!");
                checker = 1;
                return;
            }
        }
        private void ModName2(ListBox lsb1, string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    string[] array = File.ReadAllLines(path).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
                    for (int i = 0; i < array.Length; i++)
                    {
                        string a = array[i].Substring(0, array[i].IndexOf("="));
                        string s = array[i].Substring(array[i].IndexOf("=") + 1);

                        lsb1.Items.Add(s);
                    }
                    return;
                }
            }
            catch
            {
                AppendLine(textBox1, "ini File Corrupted! See Log!");
                checker = 1;
                return;
            }
        }
        private void ModName(ListBox lsb1, ListBox lsb2, string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    string[] array = File.ReadAllLines(path).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
                    for (int i = 0; i < array.Length; i++)
                    {
                        string a = array[i].Substring(0, array[i].IndexOf("="));
                        string s = array[i].Substring(array[i].IndexOf("=") + 1);

                        lsb1.Items.Add(a);
                        lsb2.Items.Add(s);
                    }
                    return;
                }
            }
            catch
            {
                AppendLine(textBox1, "ini File Corrupted! See Log!");
                checker = 1;
                return;
            }
        }
        private void PopulateCarListBox(ListBox lsb, string Folder)
        {
            if (!Directory.Exists(Folder))
            {
                AppendLine(textBox1, "Cars path not Found!, try manually selecting root location of ALL Cars. Ex. D:\\Steam");
                return;
            }
            else
            {
                try
                {
                    DirectoryInfo dinfo = new DirectoryInfo(Folder);
                    FileInfo[] Files = dinfo.GetFiles("*.cms", SearchOption.AllDirectories);
                    if (Files.Length != 0)
                    {
                        AppendLine(textBox1, "Car Files found...");

                        foreach (FileInfo file in Files)
                        {
                            lsb.Items.Add(new FInfo(file));
                        }

                        AppendLine(textBox1, Files.Length.ToString() + " files added of type: *.cms");
                    }
                    else
                    {
                        AppendLine(textBox1, "Cars path Not Found!, try manually selecting root location of ALL Cars. Ex. D:\\Steam");
                        return;
                    }
                }
                catch
                {
                    AppendLine(textBox1, "Cars path problem!");
                    checker = 1;
                    return;
                }
            }
        }
        private void WriteCar(string key, string newKey, string path)
        {
            try
            {
                if (File.Exists(path))
                {

                    string[] array = File.ReadAllLines(path).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

                    for (int i = 0; i < array.Length; i++)
                    {
                        string a = array[i].Substring(0, array[i].IndexOf("="));
                        string s = array[i].Substring(array[i].IndexOf("=") + 1);
                        if (a == key)
                        {
                            string text = File.ReadAllText(path);
                            text = text.Replace(s, newKey);
                            File.WriteAllText(path, text);
                        }

                    }
                    return;
                }
            }
            catch
            {
                AppendLine(textBox1, "Error swiss.ini File Corrupted! See Log!");
                checker = 1;
                return;
            }
        }
        private void Writeini(string key, string newKey, string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    string[] array = File.ReadAllLines(path).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
                    int result = array.GetLength(0);
                    if (result < 8 && path == swissPath)
                    {
                        AppendLine(textBox1, "Please build new swiss.ini for more features!");
                        numericUpDown1.Enabled = false;
                        numericUpDown6.Enabled = false;
                        numericUpDown5.Enabled = false;
                    }
                    else
                    {
                        numericUpDown1.Enabled = true;
                        numericUpDown6.Enabled = true;
                        numericUpDown5.Enabled = true;
                    }

                    for (int i = 0; i < array.Length; i++)
                    {
                        string a = array[i].Substring(0, array[i].IndexOf("="));
                        string s = array[i].Substring(array[i].IndexOf("=") + 1);
                        if (a == key)
                        {
                            string text = File.ReadAllText(path);
                            text = text.Replace(key + "=" + s, key + "=" + newKey);
                            File.WriteAllText(path, text);
                        }

                    }
                    return;
                }
                else
                {
                    AppendLine(textBox1, "Error File not found!");
                }
            }
            catch
            {
                AppendLine(textBox1, "ini File Corrupted! See Log!");
                checker = 1;
                return;
            }
        }
        private void Read(string key, string path)
        {
            try
            {
                if (File.Exists(path))
                {

                    string[] array = File.ReadAllLines(path).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
                    for (int i = 0; i < array.Length; i++)
                    {
                        string a = array[i].Substring(0, array[i].IndexOf("="));
                        string s = array[i].Substring(array[i].IndexOf("=") + 1);

                        if (a == key)
                        {
                            currentKey = s;
                        }

                    }
                    return;
                }
            }
            catch
            {
                AppendLine(textBox1, "ini File Corrupted! See Log!");
                checker = 1;
                return;
            }
        }
        class FInfo
        {
            public FileInfo Info { get; set; }
            public FInfo(FileInfo fi) { Info = fi; }
            public override string ToString()
            {
                return Path.GetFileNameWithoutExtension(Info.FullName);
            }
        }
        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            object selecteditem = listBox1.SelectedItem;
            string carname = selecteditem.ToString();
            string carpng = carname + "-" + carname + ".png";

            if (File.Exists(swissPath))
            {
                GetPNG(carpng);
                WriteCar("car", carname, swissPath);
                AppendLine(textBox1, "Car updated...");
            }
            else
            {
                AppendLine(textBox1, "Error swiss.ini file not found!");
                ClearSwissBoxes();
                ClearNums();
            }
            listBox3.Items.Clear();
            ModName2(listBox3, swissPath);
        }
        private void CarsPath(string cms)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                try
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        DirectoryInfo dinfo = new DirectoryInfo(fbd.SelectedPath);
                        FileInfo[] Files = dinfo.GetFiles(cms, SearchOption.AllDirectories);

                        if (Files.Length != 0)
                        {
                            MessageBox.Show("Files found: " + Files.Length.ToString(), cms);
                            ChosenPath = fbd.SelectedPath;
                        }
                        else
                        {
                            MessageBox.Show("No Files found! ", "Message");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\r\n\r\n Cars path problem!");
                    checker = 1;
                    return;
                }
            }
        }
        private void IniPath(string ini)
        {
            try
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        string[] files = Directory.GetFiles(fbd.SelectedPath, ini);

                        if (files.Length != 0)
                        {
                            if (File.Exists(fbd.SelectedPath + @"..\..\Managed\Assembly-CSharp-firstpass.dll"))
                            {
                                MessageBox.Show("Files found: " + files.Length.ToString(), ini);
                                dllPath = fbd.SelectedPath;
                            }
                            else
                            {
                                AppendLine(textBox1, "ini files have to be in \\Managed directory!");
                                MessageBox.Show("ini files have to be in \\Managed directory ", "Message");
                            }
                        }
                        else
                        {
                            if (File.Exists(fbd.SelectedPath + @"..\..\Managed\Assembly-CSharp-firstpass.dll"))
                            {
                                AppendLine(textBox1, "\\Managed directory set...");
                                dllPath = fbd.SelectedPath;
                            }
                            else
                            {
                                AppendLine(textBox1, "ini files have to be in \\Managed directory!");
                                MessageBox.Show("ini files have to be in \\Managed directory ", "Message");
                            }
                        }
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        MessageBox.Show("Cancelled no path set!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n\r\n ini path problem!");
                checker = 1;
                return;
            }
        }
        private void ClearSwissBoxes()
        {
            listBox2.Items.Clear();
            listBox3.Items.Clear();
        }
        private void ClearKeysBoxes()
        {
            //listBox4.Items.Clear();
            //listBox5.Items.Clear();
        }
        private void Selectini(string ini)
        {
            if (File.Exists(dllPath + @"..\..\Managed\Assembly-CSharp-firstpass.dll"))
            {
                IniPath("*.ini");
                if (ini == "swissPath")
                {
                    if (File.Exists(dllPath + "\\swiss.ini"))
                    {
                        swissPath = dllPath + "\\swiss.ini";
                        Writeini("swissPath", swissPath, savePath);
                        AppendLine(textBox1, "Path to swiss.ini Set Successfully...");
                    }
                    else if (!File.Exists(dllPath + "\\swiss.ini"))
                    {
                        swissPath = dllPath + "\\swiss.ini";
                        BuildiniFile(swissPath);
                        ClearSwissBoxes();
                        LoadSwiss();
                        LoadPng();
                    }
                }
                if (ini == "keysPath")
                {
                    if (File.Exists(dllPath + "\\keys.ini"))
                    {
                        keysPath = dllPath + "\\keys.ini";
                        Writeini("keysPath", keysPath, savePath);
                        AppendLine(textBox1, "Path to keys.ini Set Successfully...");
                    }
                    else if (!File.Exists(dllPath + "\\keys.ini"))
                    {
                        keysPath = dllPath + "\\keys.ini";
                        BuildiniFile(keysPath);
                        ClearKeysBoxes();
                        //LoadKeys();
                    }
                }
                if (ini == "both")
                {
                    if (File.Exists(dllPath + "\\swiss.ini"))
                    {
                        swissPath = dllPath + "\\swiss.ini";
                        Writeini("swissPath", swissPath, savePath);
                        AppendLine(textBox1, "Path to swiss.ini Set Successfully...");
                    }
                    else if (!File.Exists(dllPath + "\\swiss.ini"))
                    {
                        swissPath = dllPath + "\\swiss.ini";
                        BuildiniFile(swissPath);
                        ClearSwissBoxes();
                        LoadSwiss();
                        LoadPng();
                    }
                    if (File.Exists(dllPath + "\\keys.ini"))
                    {
                        keysPath = dllPath + "\\keys.ini";
                        Writeini("keysPath", keysPath, savePath);
                        AppendLine(textBox1, "Path to keys.ini Set Successfully...");
                    }
                    else if (!File.Exists(dllPath + "\\keys.ini"))
                    {
                        keysPath = dllPath + "\\keys.ini";
                        BuildiniFile(keysPath);
                        ClearKeysBoxes();
                        //LoadKeys();
                    }
                }
            }
            else
            {
                AppendLine(textBox1, "Swiss Selector not in \\Managed folder...");
            }
        }
        private void SelectiniLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Selectini("both");
        }
        private void LoadPng()
        {
            Read("car", swissPath);
            int index = listBox1.FindString(currentKey);
            if (index != -1)
            {
                listBox1.SetSelected(index, true);
                object selecteditem = listBox1.SelectedItem;
                string carname = selecteditem.ToString();
                string carpng = carname + "-" + carname + ".png";
                GetPNG(carpng);
            }
            else
            {
                return;
            }
        }
        private void LoadCars()
        {
            checker = 0;
            listBox1.Items.Clear();
            PopulateCarListBox(listBox1, carsPath);
        }
        private void LoadSwiss()
        {
            checker = 0;
            Pref();
            SetNums();
            listBox3.Items.Clear();
            ModName(listBox2, listBox3, swissPath);
        }
        private void SetNums()
        {
            ReadNums("addMoneyAmount", numericUpDown1);
            ReadNums("quality", numericUpDown2);
            ReadNums("mileage", numericUpDown3);
            ReadNums("condition", numericUpDown4);
            ReadNums("addXPAmount", numericUpDown5);
            ReadNums("setMoneyAmount", numericUpDown6);
        }
        private void ReadNums(string key, NumericUpDown numbox)
        {
            try
            {
                if (File.Exists(swissPath))
                {
                    string[] array = File.ReadAllLines(swissPath).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
                    for (int i = 0; i < array.Length; i++)
                    {
                        string a = array[i].Substring(0, array[i].IndexOf("="));
                        string s = array[i].Substring(array[i].IndexOf("=") + 1);
                        if (a == key)
                        {
                            decimal mon = Convert.ToDecimal(s);
                            if (mon < numbox.Maximum)
                            {
                                numbox.Value = mon;
                            }
                            else
                            {
                                numbox.Value = numbox.Maximum;
                            }
                        }
                    }
                    return;
                }
            }
            catch
            {
                AppendLine(textBox1, "swiss.ini File Corrupted! Rebuild swiss.ini file!");
                checker = 1;
                return;
            }
        }
        private void WriteNum(string key, NumericUpDown numbox)
        {
            decimal num = numbox.Value;
            string nam = num.ToString();
            Writeini(key, nam, swissPath);
            listBox3.Items.Clear();
            ModName2(listBox3, swissPath);
        }
        private void ClearNums()
        {
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;
            numericUpDown6.Value = 0;
            ClearSwissBoxes();
        }
        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (File.Exists(swissPath))
            {
                WriteNum("addMoneyAmount", numericUpDown1);
                AppendLine(textBox1, "Add money amount updated...");
            }
            else
            {
                ClearNums();
            }
        }
        private void NumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (File.Exists(swissPath))
            {
                WriteNum("quality", numericUpDown2);
                AppendLine(textBox1, "Set quality amount updated...");
            }
            else
            {
                ClearNums();
            }
        }
        private void NumericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            if (File.Exists(swissPath))
            {
                WriteNum("mileage", numericUpDown3);
                AppendLine(textBox1, "Set Mileage number updated...");
            }
            else
            {
                ClearNums();
            }
        }
        private void NumericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            if (File.Exists(swissPath))
            {
                WriteNum("condition", numericUpDown4);
                AppendLine(textBox1, "Condition percent updated...");
            }
            else
            {
                ClearNums();
            }
        }
        private void NumericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            if (File.Exists(swissPath))
            {
                WriteNum("addXPAmount", numericUpDown5);
                AppendLine(textBox1, "Add XP amount updated...");
            }
            else
            {
                ClearNums();
            }
        }
        private void NumericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            if (File.Exists(swissPath))
            {
                WriteNum("setMoneyAmount", numericUpDown6);
                AppendLine(textBox1, "Set money amount updated...");
            }
            else
            {
                ClearNums();
            }
        }
        private void ExaminedOnSpawnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(swissPath))
            {
                examinedOnSpawnToolStripMenuItem.Checked = true;
                notExaminedOnSpawnToolStripMenuItem.Checked = false;
                Writeini("spawnIsExamined", "true", swissPath);
                listBox3.Items.Clear();
                ModName2(listBox3, swissPath);
            }
            else
            {
                examinedOnSpawnToolStripMenuItem.Checked = false;
            }
        }
        private void NotExaminedOnSpawnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(swissPath))
            {
                examinedOnSpawnToolStripMenuItem.Checked = false;
                notExaminedOnSpawnToolStripMenuItem.Checked = true;
                Writeini("spawnIsExamined", "false", swissPath);
                listBox3.Items.Clear();
                ModName2(listBox3, swissPath);
            }
            else
            {
                notExaminedOnSpawnToolStripMenuItem.Checked = false;
            }
        }
        private void ShowIntroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(swissPath))
            {
                showIntroToolStripMenuItem.Checked = true;
                dontShowIntroToolStripMenuItem.Checked = false;
                Writeini("showIntro", "true", swissPath);
                listBox3.Items.Clear();
                ModName2(listBox3, swissPath);
            }
            else
            {
                showIntroToolStripMenuItem.Checked = false;
            }
        }

        private void DontShowIntroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(swissPath))
            {
                showIntroToolStripMenuItem.Checked = false;
                dontShowIntroToolStripMenuItem.Checked = true;
                Writeini("showIntro", "false", swissPath);
                listBox3.Items.Clear();
                ModName2(listBox3, swissPath);
            }
            else
            {
                dontShowIntroToolStripMenuItem.Checked = false;
            }
        }
        private void DontOpenInvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(swissPath))
            {
                openInvToolStripMenuItem.Checked = false;
                dontOpenInvToolStripMenuItem.Checked = true;
                Writeini("showInventory", "false", swissPath);
                listBox3.Items.Clear();
                ModName2(listBox3, swissPath);
            }
            else
            {
                dontOpenInvToolStripMenuItem.Checked = false;
            }
        }
        private void OpenInvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(swissPath))
            {
                dontOpenInvToolStripMenuItem.Checked = false;
                openInvToolStripMenuItem.Checked = true;
                Writeini("showInventory", "true", swissPath);
                listBox3.Items.Clear();
                ModName2(listBox3, swissPath);
            }
            else
            {
                openInvToolStripMenuItem.Checked = false;
            }
        }
        private void ManuallySetCarFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarsPath("*.cms");
            if (!Directory.Exists(ChosenPath))
            {
                AppendLine(textBox1, "No Cars Found in Selected Path!");
                return;
            }
            else
            {
                carsPath = ChosenPath;
                Writeini("carsPath", carsPath, savePath);
                AppendLine(textBox1, "Path to Cars Set Successfully...");
                listBox1.Items.Clear();
                LoadCars();
                LoadPng();
            }
        }
        private void BuildIniFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = dllPath; //System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            swissPath = Path.GetFullPath(path + @"\swiss.ini");
            BuildiniFile(swissPath);
            ClearSwissBoxes();
            LoadSwiss();
            LoadPng();
        }
        private void BuildKeysiniFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = dllPath; //System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            keysPath = Path.GetFullPath(path + @"\keys.ini");
            BuildiniFile(keysPath);
            ClearKeysBoxes();
            //UnLockKeys(true);
            //LoadKeys();
        }
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About About = new About();
            About.Show();
        }
        private void GetPNG(string picname)
        {
            if (!Directory.Exists(carsPath))
            {
                return;
            }
            else
            {
                try
                {
                    DirectoryInfo dinfo = new DirectoryInfo(carsPath);
                    FileInfo[] Files = dinfo.GetFiles(picname, SearchOption.AllDirectories);
                    if (Files.Length != 0)
                    {
                        foreach (FileInfo file in Files)
                        {
                            string pngPath = file.FullName;
                            pictureBox1.ImageLocation = pngPath;
                            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                    }
                    else
                    {
                        pictureBox1.Image = null;
                        return;
                    }
                }
                catch
                {
                    AppendLine(textBox1, "Cars path problem!");
                    checker = 1;
                    return;
                }
            }
        }
        private async void RemoveAllCreatedFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(dllPath + @"\swiss.ini"))
            {
                File.Delete(dllPath + @"\swiss.ini");
                AppendLine(textBox1, "swiss.ini deleted.");
                ClearNums();
                ClearSwissBoxes();
            }
            else
            {
                AppendLine(textBox1, "swiss.ini not found, nothing deleted");
            }

            if (File.Exists(dllPath + @"\keys.ini"))
            {
                File.Delete(dllPath + @"\keys.ini");
                AppendLine(textBox1, "keys.ini deleted.");
                ClearKeysBoxes();
                //UnLockKeys(false);
            }
            else
            {
                AppendLine(textBox1, "keys.ini not found, nothing deleted");
            }

            if (File.Exists(Application.CommonAppDataPath + "\\startPref.txt"))
            {
                File.Delete(Application.CommonAppDataPath + "\\startPref.txt");
                AppendLine(textBox1, "startPref.txt deleted.");
            }
            else
            {
                AppendLine(textBox1, "startPref.txt not found, nothing deleted");
            }

            if (File.Exists(Application.CommonAppDataPath + "\\save.txt"))
            {
                File.Delete(Application.CommonAppDataPath + "\\save.txt");
                AppendLine(textBox1, "Save.txt deleted.");
                if (!File.Exists(Application.CommonAppDataPath + "\\save.txt"))
                {
                    await Task.Delay(3000);
                    DialogResult dialogResult1 = MessageBox.Show("save.txt not found!, Create save.txt?", "save.txt Creator", MessageBoxButtons.YesNo);
                    if (dialogResult1 == DialogResult.Yes)
                    {
                        BuildSaveFile();
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("File save.txt not created and missing!\r\n\r\n Exiting Swiss Selector", "Warning!");
                        Application.Exit();
                    }
                }
            }
            else
            {
                AppendLine(textBox1, "Save.txt not found, nothing deleted");
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("steam://rungameid/645630");
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            if (File.Exists(swissPath))
            {
                Writeini("licensePlate", textBox2.Text, swissPath);
                textBox2.Clear();
                GetPlate(textBox2, swissPath);
                AppendLine(textBox1, "License Plate updated...");
                ClearSwissBoxes();
                LoadSwiss();
            }
        }
        private void BigModeToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            Form1 f1 = new Form1();
            Writeini("startPref", "bigmode", MyProperty);
            f1.Show();
            this.Hide();
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
