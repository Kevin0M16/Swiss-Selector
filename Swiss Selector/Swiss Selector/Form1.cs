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
            //StartUp();
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
            if (ini == swissPath)
            {
                if (!File.Exists(ini))
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
                else if (File.Exists(ini))
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
            if (ini == keysPath)
            {
                if (!File.Exists(ini))
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
                else if (File.Exists(ini))
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
        }
        public void BuildSaveFile()
        {
            if (!File.Exists(savePath))
            {
                File.Create(savePath).Close();
                TextWriter tw = new StreamWriter(savePath);
                tw.WriteLine("swissPath=D:\\Steam\\steamapps\\common\\Car Mechanic Simulator 2018\\cms2018_Data\\Managed\\swiss.ini1");
                tw.WriteLine("keysPath=D:\\Steam\\steamapps\\common\\Car Mechanic Simulator 2018\\cms2018_Data\\Managed\\keys.ini1");
                tw.WriteLine("carsPath=D:\\Steam1");
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
                    //AppendLine(textBox1, "Path to keys.ini found...");
                    Writeini("keysPath", keysPath, savePath);
                    AppendLine(textBox1, "Path to keys.ini Set Successfully...");  
                }
                else if (!File.Exists(keysPath))
                {
                    AppendLine(textBox1, "Path to keys.ini not found! Please create or manually select ini location...");
                }
            }
            if (file == "swissPath")
            {
                string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                swissPath = Path.GetFullPath(path + @"\swiss.ini");
                if (File.Exists(swissPath))
                {
                    //AppendLine(textBox1, "Path to swiss.ini found...");
                    Writeini("swissPath", swissPath, savePath);
                    AppendLine(textBox1, "Path to swiss.ini Set Successfully...");
                }
                else if (!File.Exists(swissPath))
                {
                    AppendLine(textBox1, "Path to swiss.ini not found! Please create or manually select ini location...");
                }
            }
            if (file == "carsPath")
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
            }
            else
            {
                AppendLine(textBox1, "Path to swiss.ini not found!");
                LookForDefaults("swissPath");
            }
            if (Directory.Exists(carsPath))
            {               
                LoadCars();     
            }
            else
            {                
                AppendLine(textBox1, "Cars Not Found!");
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
                    openShopToolStripMenuItem.Checked = true;
                    dontOpenShopToolStripMenuItem.Checked = false;
                }
                else
                {
                    openShopToolStripMenuItem.Checked = false;
                    dontOpenShopToolStripMenuItem.Checked = true;
                }
            }
            else if(!File.Exists(swissPath))
            {
                openShopToolStripMenuItem.Checked = false;
                dontOpenShopToolStripMenuItem.Checked = false;
                
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
            catch //(Exception ex)
            {
                    AppendLine(textBox1, "ini File Corrupted! See Log!");
                    checker = 1;
                    //MessageBox.Show(ex.Message + "\r\n\r\nini File Corrupted! Rebuild ini files!");
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
            catch //(Exception ex)
            {
                AppendLine(textBox1, "ini File Corrupted! See Log!");
                checker = 1;
                //MessageBox.Show(ex.Message + "\r\n\r\nini File Corrupted! Rebuild ini files!");
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
            catch //(Exception ex)
            {
                AppendLine(textBox1, "keys.ini File Corrupted! Rebuild key.ini file!");
                checker = 1;
                //MessageBox.Show(ex.Message + "\r\n\r\nini File Corrupted! Rebuild ini files!");
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
                catch //(Exception ex)
                {
                    AppendLine(textBox1, "Cars path problem! Restart!");
                    checker = 1;
                    //MessageBox.Show(ex.Message + "\r\n\r\nini File Corrupted! Rebuild ini files!");
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
                listBox5.Items.Clear();
                AppendLine(textBox1, "Error File not found!");
                return;
            }            
        }
        private void WriteCar(string key, string newKey, string path)
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
            catch //(Exception ex)
            {
                AppendLine(textBox1, "ini File Corrupted! See Log!");
                checker = 1;
                //MessageBox.Show(ex.Message + "\r\n\r\nini File Corrupted! Rebuild ini files!");
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
            catch //(Exception ex)
            {
                AppendLine(textBox1, "ini File Corrupted! See Log!");
                checker = 1;
                //MessageBox.Show(ex.Message + "\r\n\r\nini File Corrupted! Rebuild ini files!");
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
            if (File.Exists(swissPath))
            {
                WriteCar("car", carname, swissPath);
            }
            else
            {
                AppendLine(textBox1, "Error File not found!");
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
        private void iniPath(string ini)
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
                            MessageBox.Show("Files found: " + files.Length.ToString(), ini);
                            ChosenPath = fbd.SelectedPath;
                        }
                        else
                        {
                            MessageBox.Show("No Files found! ", "Message");
                        }
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
        private void SaveFileIni(string ininame, string ininame2, string inipath, string inipath2)
        {            
            if (!File.Exists(savePath))
            {
                File.Create(savePath).Close();
                TextWriter tw = new StreamWriter(savePath);
                tw.WriteLine(ininame + "=" + inipath);
                tw.WriteLine(ininame2 + "=" + inipath2);
                tw.Close();
            }
            else if (File.Exists(savePath))
            {
                TextWriter tw = new StreamWriter(savePath);
                tw.WriteLine(ininame + "=" + inipath);
                tw.WriteLine(ininame2 + "=" + inipath2);
                tw.Close();                
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
        private void ClearBoxes()
        {            
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
        }
        private void SelectiniLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iniPath("*.ini");           

            if (File.Exists(ChosenPath + "\\swiss.ini"))
            {
                swissPath = ChosenPath + "\\swiss.ini";
                Writeini("swissPath", swissPath, savePath);
                AppendLine(textBox1, "Path to swiss.ini Set Successfully...");
            }
            else
            {
                AppendLine(textBox1, "No swiss.ini Found in selected path!");
                
            }
            if (File.Exists(ChosenPath + "\\keys.ini"))
            {
                keysPath = ChosenPath + "\\keys.ini";
                Writeini("keysPath", keysPath, savePath);
                AppendLine(textBox1, "Path to keys.ini Set Successfully...");
            }
            else
            {
                AppendLine(textBox1, "No keys.ini Found in selected path!");
                return;
            }
            ClearBoxes();            
            LoadIni();
            //LoadCars();
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
        private void LoadIni()
        {
            checker = 0;
            Pref();
            SetKeys();
            SetNums();
            listBox3.Items.Clear();
            ModName(listBox2, listBox3, swissPath);
            ModName(listBox4, listBox5, keysPath);            
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
            catch //(Exception ex)
            {
                AppendLine(textBox1, "swiss.ini File Corrupted! Rebuild swiss.ini file!");
                checker = 1;
                //MessageBox.Show(ex.Message + "\r\n\r\nini File Corrupted! Rebuild ini files!");
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
        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            WriteNum("addMoneyAmount", numericUpDown1);
        }
        private void NumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            WriteNum("quality", numericUpDown2);
        }
        private void NumericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            WriteNum("mileage", numericUpDown3);
        }
        private void NumericUpDown4_ValueChanged(object sender, EventArgs e)
        {            
            WriteNum("condition", numericUpDown4);
        }
        private void NumericUpDown5_ValueChanged(object sender, EventArgs e)
        {            
            WriteNum("addXPAmount", numericUpDown5);
        }
        private void NumericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            WriteNum("setMoneyAmount", numericUpDown6);
        }
        private void DontOpenShopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(swissPath))
            {
                openShopToolStripMenuItem.Checked = false;
                dontOpenShopToolStripMenuItem.Checked = true;
                Writeini("showInventory", "false", swissPath);
                listBox3.Items.Clear();
                ModName2(listBox3, swissPath);
            }
            else
            {
                dontOpenShopToolStripMenuItem.Checked = false;
            }
        }
        private void OpenShopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(swissPath))
            {
                dontOpenShopToolStripMenuItem.Checked = false;
                openShopToolStripMenuItem.Checked = true;
                Writeini("showInventory", "true", swissPath);
                listBox3.Items.Clear();
                ModName2(listBox3, swissPath);
            }
            else
            {
                openShopToolStripMenuItem.Checked = false;
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
            }
        }
        private void BuildIniFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            swissPath = Path.GetFullPath(path + @"\swiss.ini");
            BuildiniFile(swissPath);
            Writeini("swissPath", swissPath, savePath);
        }
        private void BuildKeysiniFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            keysPath = Path.GetFullPath(path + @"\keys.ini");
            BuildiniFile(keysPath);
            Writeini("keysPath", keysPath, savePath);
        }
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About About = new About();
            About.Show();
        }
    }
}
