using System;

using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace Swiss_Selector
{

    public partial class Form1 : Form
    {     
        public Form1()
        {             
            InitializeComponent();           
        }
        private void Form1_Shown(object sender, EventArgs e)
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
            listBox1.Items.Clear();
            savePath = Application.CommonAppDataPath + "\\save.txt";
            BuildSaveFile();
            ReloadSave();
            Pref();            
            SetKeys();
            SetNums();
            listBox3.Items.Clear();
            ModName(listBox2, listBox3, swissPath);
            ModName(listBox4, listBox5, keysPath);
        }
        public void BuildiniFile(string ini)
        {
            string path = dllPath; //System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            //AppendLine(textBox1, path + " build dll path");
            if (ini == swissPath)
            {
                if (!File.Exists(ini) && File.Exists(path + @"\Assembly-CSharp-firstpass.dll"))
                {
                    DialogResult dialogResult = MessageBox.Show("No swiss.ini exits. Create file?", "swiss.ini Creator", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        File.Create(ini).Close();
                        TextWriter tw = new StreamWriter(ini);
                        tw.WriteLine("car=car_bentleycontinentalgt");
                        tw.WriteLine("quality=200");
                        tw.WriteLine("mileage=4000");
                        tw.WriteLine("condition=1");
                        tw.WriteLine("addMoneyAmount=10000");
                        tw.WriteLine("setMoneyAmount=1100000");
                        tw.WriteLine("addXPAmount=2500");
                        tw.WriteLine("showInventory=true");
                        tw.Close();
                        ClearSwissBoxes();
                        LoadSwiss();                                               
                        
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
                else if (File.Exists(ini) && File.Exists(path + @"\Assembly-CSharp-firstpass.dll"))
                {
                    DialogResult dialogResult1 = MessageBox.Show("swiss.ini already exits. Overwrite?", "swiss.ini Creator", MessageBoxButtons.YesNo);
                    if (dialogResult1 == DialogResult.Yes)
                    {
                        File.Create(ini).Close();
                        TextWriter tw = new StreamWriter(ini);
                        tw.WriteLine("car=car_bentleycontinentalgt");
                        tw.WriteLine("quality=200");
                        tw.WriteLine("mileage=4000");
                        tw.WriteLine("condition=1");
                        tw.WriteLine("addMoneyAmount=10000");
                        tw.WriteLine("setMoneyAmount=1100000");
                        tw.WriteLine("addXPAmount=2500");
                        tw.WriteLine("showInventory=true");
                        tw.Close();                        
                        ClearSwissBoxes();
                        LoadSwiss();
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
            if (ini == swissPath && !File.Exists(path + @"\Assembly-CSharp-firstpass.dll"))
            {
                DialogResult dialogResult4 = MessageBox.Show("Swiss Selector not in \\Managed folder, Would you like to manually select \\Managed location?", "Message", MessageBoxButtons.YesNo);
                if (dialogResult4 == DialogResult.Yes)
                {
                    Selectini("swissPath");
                    //SelectiniFolder();
                }
                else
                {
                    AppendLine(textBox1, "Swiss Selector not in \\Managed folder...");
                    System.Windows.Forms.MessageBox.Show("Swiss Selector not in \\Managed folder...\r\n\r\nNo path set!");
                }
            }
            if (ini == keysPath)
            {
                if (!File.Exists(ini) && File.Exists(path + @"\Assembly-CSharp-firstpass.dll"))
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
                        tw.Close();                        
                        ClearKeysBoxes();
                        LoadKeys();
                        if (checker == 0)
                        {
                            AppendLine(textBox1, "The keys.ini was created Successfully...");
                            AppendLine(textBox1, "The keys.ini has no errors...");
                        }
                        else
                        {
                            AppendLine(textBox1, "The keys.ini Error");
                        }
                    }
                    else if (dialogResult2 == DialogResult.No)
                    {
                        AppendLine(textBox1, "Canceled! No ini was created...");
                        return;
                    }
                    
                }
                else if (File.Exists(ini) && File.Exists(path + @"\Assembly-CSharp-firstpass.dll"))
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
                        tw.Close();                        
                        ClearKeysBoxes();
                        LoadKeys();
                        if (checker == 0)
                        {
                            AppendLine(textBox1, "The keys.ini was created Successfully...");
                            AppendLine(textBox1, "The keys.ini has no errors...");
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
            if (ini == keysPath && !File.Exists(path + @"\Assembly-CSharp-firstpass.dll"))
            {
                DialogResult dialogResult4 = MessageBox.Show("Swiss Selector not in \\Managed folder, Would you like to manually select \\Managed location?", "Message", MessageBoxButtons.YesNo);
                if (dialogResult4 == DialogResult.Yes)
                {
                    Selectini("keysPath");
                    //SelectiniFolder();
                }
                else
                {
                    AppendLine(textBox1, "Swiss Selector not in \\Managed folder...");
                    System.Windows.Forms.MessageBox.Show("Swiss Selector not in \\Managed folder...\r\n\r\nNo path set!");
                }
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
            if(file == "keysPath")
            {
                string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                keysPath = Path.GetFullPath(path + @"\keys.ini");
                if (File.Exists(keysPath))
                {                    
                    Writeini("keysPath", keysPath, savePath);
                    AppendLine(textBox1, "Path to keys.ini Set Successfully...");  
                }
                else if (!File.Exists(keysPath))
                {
                    AppendLine(textBox1, "Path to keys.ini not found! Please create or manually select \\Managed directory location...");
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
                }
                else if (!File.Exists(swissPath))
                {
                    AppendLine(textBox1, "Path to swiss.ini not found! Please create or manually select \\Managed directory location...");
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
                    AppendLine(textBox1, "Please set Cars directory manually, Swiss Selector not in \\Managed  folder...");                    
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
            }
            else
            {
                AppendLine(textBox1, "Path to keys.ini not found!");
                LookForDefaults("keysPath");
            }
            if (File.Exists(swissPath))
            {
                AppendLine(textBox1, "Path to swiss.ini found...");
                dllPath = System.IO.Path.GetDirectoryName(swissPath);
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
                else
                {
                    openInvToolStripMenuItem.Checked = false;
                    dontOpenInvToolStripMenuItem.Checked = true;
                }
            }
            else if(!File.Exists(swissPath))
            {
                openInvToolStripMenuItem.Checked = false;
                dontOpenInvToolStripMenuItem.Checked = false;
                
            }
        }
        public static void AppendLine(TextBox source, string value)
        {
            if (source.Text.Length == 0)
                source.Text = value;
            else
                source.AppendText("\r\n" + value);
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
        private void ReadKeys(string key, ComboBox cmbbx)
        {
            try
            {
                if (File.Exists(keysPath))
                {
                    string[] array = File.ReadAllLines(keysPath).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
                    for (int i = 0; i < array.Length; i++)
                    {
                        string a = array[i].Substring(0, array[i].IndexOf("="));
                        string s = array[i].Substring(array[i].IndexOf("=") + 1);
                        if (a == key)
                        {
                            cmbbx.SelectedItem = s;
                        }
                    }
                    return;
                }                
            }
            catch
            {
                AppendLine(textBox1, "keys.ini File Corrupted! Rebuild key.ini file!");
                checker = 1;                
                return;
            }            
        }
        private void SetKeys()
        {            
                ReadKeys("SpawnCar", comboBox1);
            if (checker == 0)
            {
                ReadKeys("IncreaseConfig", comboBox2);
                ReadKeys("DecreaseConfig", comboBox3);
                ReadKeys("RandomChangeCondition", comboBox4);
                ReadKeys("RandomChangeColor", comboBox5);
                ReadKeys("ReloadLiveries", comboBox6);
                ReadKeys("SetMileage", comboBox7);
                ReadKeys("GenerateJunkyard", comboBox8);
                ReadKeys("FullyRepairCar", comboBox9);
                ReadKeys("PhotoMode", comboBox10);
                ReadKeys("DuplicateEngine", comboBox11);
                ReadKeys("IncreaseSpeed", comboBox12);
                ReadKeys("DecreaseSpeed", comboBox13);
                ReadKeys("AddAllEngineParts", comboBox14);
                ReadKeys("RepairAllItems", comboBox15);
                ReadKeys("AddBarn", comboBox16);
                ReadKeys("AddMoney", comboBox17);
                ReadKeys("SetMoney", comboBox24);
                ReadKeys("AddXP", comboBox18);
                ReadKeys("UnlockAllUpgrades", comboBox19);
                ReadKeys("OpenShop", comboBox20);
                ReadKeys("AddThisPart", comboBox21);
                ReadKeys("RotateEngineRight", comboBox22);
                ReadKeys("RotateEngineLeft", comboBox23);
            }
            else
            {
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
        private void Update(string key, ComboBox cmb)
        {
            if(cmb.SelectedItem != null)
            {
                Object selectedItem1 = cmb.SelectedItem;
                string newkey1 = selectedItem1.ToString();
                Writeini(key, newkey1, keysPath);
            }
            else
            {
                return;
            }            
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(keysPath))
            {
                Update("SpawnCar", comboBox1);
                Update("IncreaseConfig", comboBox2);
                Update("DecreaseConfig", comboBox3);
                Update("RandomChangeCondition", comboBox4);
                Update("RandomChangeColor", comboBox5);
                Update("ReloadLiveries", comboBox6);
                Update("SetMileage", comboBox7);
                Update("GenerateJunkyard", comboBox8);
                Update("FullyRepairCar", comboBox9);
                Update("PhotoMode", comboBox10);
                Update("DuplicateEngine", comboBox11);
                Update("IncreaseSpeed", comboBox12);
                Update("DecreaseSpeed", comboBox13);
                Update("AddAllEngineParts", comboBox14);
                Update("RepairAllItems", comboBox15);
                Update("AddBarn", comboBox16);
                Update("AddMoney", comboBox17);
                Update("SetMoney", comboBox24);
                Update("AddXP", comboBox18);
                Update("UnlockAllUpgrades", comboBox19);
                Update("OpenShop", comboBox20);
                Update("AddThisPart", comboBox21);
                Update("RotateEngineRight", comboBox22);
                Update("RotateEngineLeft", comboBox23);

                listBox5.Items.Clear();
                ModName2(listBox5, keysPath);
                if(checker == 0)
                {
                    AppendLine(textBox1, "Key mappings updated...");
                    System.Windows.Forms.MessageBox.Show("Changes have been saved");
                }
                else
                {
                    AppendLine(textBox1, "No keys updated! keys.ini problem!");
                }    
            }
            else if (!File.Exists(keysPath))
            {
                //listBox5.Items.Clear();
                AppendLine(textBox1, "Error keys.ini file not found!");
                ClearKeysBoxes();
                return;
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
                    if(result < 8 && path == swissPath)
                    {
                        AppendLine(textBox1, "Please build new swiss.ini for more features!");
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
                            if (File.Exists(fbd.SelectedPath + @"\Assembly-CSharp-firstpass.dll"))
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
                            if (File.Exists(fbd.SelectedPath + @"\Assembly-CSharp-firstpass.dll"))
                            {
                                AppendLine(textBox1,"\\Managed directory set...");
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
                MessageBox.Show(ex.Message + "\r\n\r\n ini path problem!" );
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
            listBox4.Items.Clear();
            listBox5.Items.Clear();
        }
        //private void ClearBoxes()
        //{            
        //    listBox2.Items.Clear();
        //    listBox3.Items.Clear();
        //    listBox4.Items.Clear();
        //    listBox5.Items.Clear();
        //}
        private void SelectiniFolder()
        {
            try
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        string[] files = Directory.GetFiles(fbd.SelectedPath, "Assembly-CSharp-firstpass.dll");
                        //string[] files2 = Directory.GetFiles(fbd.SelectedPath, "keys.ini");
                        //string[] files3 = Directory.GetFiles(fbd.SelectedPath, "swiss.ini");

                        if (files.Length != 0)
                        {
                            keysPath = (fbd.SelectedPath + @"\keys.ini");
                            AppendLine(textBox1, "Path to keys.ini Set Successfully...");
                            swissPath = (fbd.SelectedPath + @"\swiss.ini");                            
                            AppendLine(textBox1, "Path to swiss.ini Set Successfully...");
                            MessageBox.Show("ini files Path Set Successfully...\r\n\r\n Now close and move Swiss Selector to \\Managed directory", "Message");                            
                        }
                        else
                        {
                            MessageBox.Show("ini files have to be built in \\Managed directory", "Message");
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

        private void Selectini(string ini)
        {
            IniPath("*.ini");
            if (File.Exists(dllPath + @"\Assembly-CSharp-firstpass.dll"))
            {
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
                        //AppendLine(textBox1, "No swiss.ini Found in selected path!");
                        swissPath = dllPath + "\\swiss.ini";
                        BuildiniFile(swissPath);
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
                        //AppendLine(textBox1, "No keys.ini Found in selected path!");
                        //return;
                        keysPath = dllPath + "\\keys.ini";
                        BuildiniFile(keysPath);
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
                        //AppendLine(textBox1, "No swiss.ini Found in selected path!");
                        swissPath = dllPath + "\\swiss.ini";
                        BuildiniFile(swissPath);
                    }
                    if (File.Exists(dllPath + "\\keys.ini"))
                    {
                        keysPath = dllPath + "\\keys.ini";
                        Writeini("keysPath", keysPath, savePath);
                        AppendLine(textBox1, "Path to keys.ini Set Successfully...");
                    }
                    else if (!File.Exists(dllPath + "\\keys.ini"))
                    {
                        //AppendLine(textBox1, "No keys.ini Found in selected path!");
                        //return;
                        keysPath = dllPath + "\\keys.ini";
                        BuildiniFile(keysPath);
                    }
                }
                //ClearBoxes();
                //LoadIni();
            }
        }
        private void SelectiniLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Selectini("both");            
            //SelectiniFolder();
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
        private void LoadKeys()
        {
            checker = 0;
            SetKeys();            
            ModName(listBox4, listBox5, keysPath);
        }
        //private void LoadIni()
        //{
        //    checker = 0;
        //    Pref();
        //    SetKeys();
        //    SetNums();
        //    listBox3.Items.Clear();
        //   ModName(listBox2, listBox3, swissPath);
        //    ModName(listBox4, listBox5, keysPath);            
        //}
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
            Writeini("swissPath", swissPath, savePath);
        }
        private void BuildKeysiniFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = dllPath; //System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            keysPath = Path.GetFullPath(path + @"\keys.ini");
            BuildiniFile(keysPath);
            Writeini("keysPath", keysPath, savePath);
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
                            //AppendLine(textBox1, pngPath);

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
    }

}
