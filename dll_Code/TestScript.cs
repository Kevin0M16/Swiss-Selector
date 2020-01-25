using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x020005F4 RID: 1524
public class TestScript : MonoBehaviour
{
	// Token: 0x06002A8A RID: 10890 RVA: 0x0001B25D File Offset: 0x0001945D
	public TestScript()
	{
		this.condition = 1f;
		this.version = 0;
		this.quality = 5;
		this.car = "car_boltatlanta";
		this.getFromIni();
		this.getFromKeysIni();
	}

	// Token: 0x06002A8B RID: 10891 RVA: 0x000F981C File Offset: 0x000F7A1C
	public virtual void Update()
	{
		this.KeyPress();
		if (this.keyListen(this.SpawnCarKey, this.finder))
		{
			base.StartCoroutine(this.SpawnCar());
			this.finder = null;
			return;
		}
		if ((Input.GetKey(KeyCode.LeftShift) & Input.GetKeyDown(KeyCode.Delete)) | (Input.GetKey(KeyCode.RightShift) & Input.GetKeyDown(KeyCode.Delete)))
		{
			int shedsAvailable = GlobalData.ShedsAvailable;
			for (int i = 0; i < GlobalData.ShedsVisible.Length; i++)
			{
				GlobalData.ShedsVisible[i] = false;
			}
			GlobalData.ShedsAvailable = 0;
			GlobalData.Save();
			GameLoader.Get().Save();
			UIManager.Get().ShowPopup("System:", "deleted " + shedsAvailable + " Barns, Now Reload Save", PopupType.Normal);
			return;
		}
		if (this.keyListen(this.IncreseConfigKey, this.finder))
		{
			if (this.version > 0)
			{
				this.version--;
				UIManager.Get().ShowPopup("System:", "Version set to " + this.version, PopupType.Normal);
			}
			UIManager.Get().ShowPopup("System:", "Can't set Version below 0", PopupType.Normal);
			this.finder = null;
			return;
		}
		if (this.keyListen(this.DecreaseConfigKey, this.finder))
		{
			this.version++;
			UIManager.Get().ShowPopup("System:", "Version set to " + this.version, PopupType.Normal);
			this.finder = null;
			return;
		}
		if (this.keyListen(this.RandomChangeCondition, this.finder))
		{
			if (GameScript.Get().GetIOMouseOverCarLoader2() != null)
			{
				((CarDebug)GameScript.Get().GetIOMouseOverCarLoader2().GetComponent(typeof(CarDebug))).Test_AuctionCar();
				UIManager.Get().ShowPopup("System:", "Random Condition Set", PopupType.Normal);
			}
			this.finder = null;
			return;
		}
		if (this.keyListen(this.RandomChangeColor, this.finder) && GameScript.Get().GetIOMouseOverCarLoader2())
		{
			if (GameScript.Get().GetIOMouseOverCarLoader2() != null)
			{
				GameScript.Get().GetIOMouseOverCarLoader2().SetRandomCarColor();
				UIManager.Get().ShowPopup("System:", "Random Color Set", PopupType.Normal);
			}
			this.finder = null;
			return;
		}
		if (this.keyListen(this.CarIsExamined, this.finder) && GameScript.Get().GetIOMouseOverCarLoader2())
		{
			if (GameScript.Get().GetIOMouseOverCarLoader2() != null)
			{
				GameScript.Get().GetIOMouseOverCarLoader2().ExamineAllParts();
				UIManager.Get().ShowPopup("System:", "Car is Examined", PopupType.Normal);
			}
			this.finder = null;
			return;
		}
		if (this.keyListen(this.PartIsExamined, this.finder) && GameScript.Get().GetPartMouseOver())
		{
			if (GameScript.Get().GetPartMouseOver() != null)
			{
				GameScript.Get().GetPartMouseOver().SetIsExamined(true);
				UIManager.Get().ShowPopup("System:", "Part is Examined", PopupType.Normal);
			}
			this.finder = null;
			return;
		}
		if (this.keyListen(this.ReloadLiveries, this.finder))
		{
			Singleton<LiverysManager>.Instance.Prepare();
			UIManager.Get().ShowPopup("System:", "Liveries reloaded", PopupType.Normal);
			this.finder = null;
			return;
		}
		if (this.keyListen(this.SetMileage, this.finder))
		{
			this.getFromIni();
			if (GameScript.Get().GetIOMouseOverCarLoader2() != null)
			{
				GameScript.Get().GetIOMouseOverCarLoader2().SetMileage(this.mileage);
				UIManager.Get().ShowPopup("System:", "Mileage set to " + this.mileage, PopupType.Normal);
			}
			this.finder = null;
			return;
		}
		if (this.keyListen(this.GenerateJunkyard, this.finder) && GameScript.Get().CurrentSceneType == SceneType.Junkyard)
		{
			Singleton<JunkyardGenerator>.Instance.GenerateNewJunkyard = true;
			Singleton<JunkyardGenerator>.Instance.Update();
			UIManager.Get().ShowPopup("System:", "Junkyard Generated", PopupType.Normal);
			this.finder = null;
			return;
		}
		if (this.keyListen(this.FullyRepairCar, this.finder) && GameScript.Get().GetIOMouseOverCarLoader2())
		{
			if (GameScript.Get().GetIOMouseOverCarLoader2() != null)
			{
				base.StartCoroutine(this.ReloadCar(GameScript.Get().GetIOMouseOverCarLoader2()));
				UIManager.Get().ShowPopup("System:", "All shiny and new again", PopupType.Normal);
			}
			this.finder = null;
			return;
		}
		if (this.keyListen(this.PhotoMode, this.finder))
		{
			GameMode.Get().SetCurrentMode(gameMode.PhotoMode);
			this.finder = null;
			return;
		}
		if (this.keyListen(this.DuplicateEngine, this.finder))
		{
			this.getFromIni();
			if (UIManager.Get().IsActive("Inventory"))
			{
				UIManager.Get().Hide("Inventory");
			}
			this.engine = new NewGroupItem(GameScript.Get().GetGroupOnEngineStand());
			GroupInventory.Get().Add(this.engine);
			string groupName = GameScript.Get().GetGroupOnEngineStand().GroupName;
			UIManager.Get().ShowPopup("System:", "Engine " + groupName + " added to inventory", PopupType.Normal);
			foreach (NewGroupItem newGroupItem in GroupInventory.Get().GetGroupInventory(groupName))
			{
				foreach (NewInventoryItem newInventoryItem in newGroupItem.ItemList)
				{
					newInventoryItem.Condition = this.condition;
					newInventoryItem.extraParameters.Add("Quality", this.quality);
					newInventoryItem.IsExamined = true;
				}
			}
			base.StartCoroutine(UIManager.Get().PrepareInventory());
			UIManager.Get().Show("Inventory");
			this.finder = null;
			return;
		}
		if (this.keyListen(this.AddAllEngineParts, this.finder))
		{
			this.getFromIni();
			if (UIManager.Get().IsActive("Inventory"))
			{
				UIManager.Get().Hide("Inventory");
			}
			string groupName2 = GameScript.Get().GetGroupOnEngineStand().GroupName;
			UIManager.Get().ShowPopup("System:", "Engine: " + groupName2, PopupType.Normal);
			foreach (NewInventoryItem newInventoryItem2 in GameScript.Get().GetGroupOnEngineStand().ItemList)
			{
				string normalID = newInventoryItem2.GetNormalID();
				Inventory.Get().Add(normalID, 1f, Color.white, true, true);
				foreach (NewInventoryItem newInventoryItem3 in Inventory.Get().GetItems(normalID))
				{
					newInventoryItem3.Condition = this.condition;
					newInventoryItem3.extraParameters.Add("Quality", this.quality);
				}
			}
			UIManager.Get().ShowPopup("System:", "Part " + groupName2 + "added to inventory", PopupType.Normal);
			base.StartCoroutine(UIManager.Get().PrepareInventory());
			UIManager.Get().Show("Inventory");
			this.finder = null;
			return;
		}
		if (this.keyListen(this.RepairAllItems, this.finder))
		{
			this.getFromIni();
			if (UIManager.Get().IsActive("Inventory"))
			{
				UIManager.Get().Hide("Inventory");
			}
			foreach (NewInventoryItem newInventoryItem4 in Inventory.Get().GetItems("All"))
			{
				newInventoryItem4.Condition = this.condition;
				newInventoryItem4.extraParameters.Add("Quality", this.quality);
			}
			foreach (NewGroupItem newGroupItem2 in GroupInventory.Get().GetGroupInventory())
			{
				foreach (NewInventoryItem newInventoryItem5 in newGroupItem2.ItemList)
				{
					newInventoryItem5.Condition = this.condition;
					newInventoryItem5.extraParameters.Add("Quality", this.quality);
				}
			}
			UIManager.Get().ShowPopup("System:", string.Concat(new object[]
			{
				"All items repaired to ",
				this.quality,
				" quality and ",
				this.condition * 100f,
				"% condition"
			}), PopupType.Normal);
			base.StartCoroutine(UIManager.Get().PrepareInventory());
			UIManager.Get().Show("Inventory");
			this.finder = null;
			return;
		}
		if (this.keyListen(this.AddBarn, this.finder))
		{
			GlobalData.AddShed(1);
			UIManager.Get().ShowPopup("System:", "Barn added", PopupType.Normal);
			this.finder = null;
			return;
		}
		if (this.keyListen(this.AddMoney, this.finder))
		{
			this.getFromIni();
			GlobalData.AddPlayerMoney(this.addMoneyAmount);
			UIManager.Get().ShowPopup("System:", this.addMoneyAmount + " Money added", PopupType.Normal);
			this.finder = null;
			return;
		}
		if (this.keyListen(this.SetMoney, this.finder))
		{
			this.getFromIni();
			GlobalData.SetPlayerMoney(this.setMoneyAmount);
			UIManager.Get().ShowPopup("System:", "Money set to: " + this.setMoneyAmount, PopupType.Normal);
			this.finder = null;
			return;
		}
		if (this.keyListen(this.AddXP, this.finder))
		{
			this.getFromIni();
			GlobalData.AddPlayerExp(this.addXPAmount);
			UIManager.Get().ShowPopup("System:", this.addXPAmount + " XP added", PopupType.Normal);
			this.finder = null;
			return;
		}
		if (this.keyListen(this.UnlockAllUpgrades, this.finder))
		{
			Singleton<UpgradeSystem>.Instance.UnlockAll();
			UIManager.Get().ShowPopup("System:", "All unlocked. Re-enter garage to activate", PopupType.Normal);
			this.finder = null;
			return;
		}
		if (this.keyListen(this.RotateEngineRight, this.finder))
		{
			GameScript.Get().IncraseEngineStandAngle(45f);
			this.finder = null;
			return;
		}
		if (this.keyListen(this.RotateEngineLeft, this.finder))
		{
			GameScript.Get().IncraseEngineStandAngle(-45f);
			this.finder = null;
			return;
		}
		if (this.keyListen(this.OpenShop, this.finder))
		{
			base.StartCoroutine(GameScript.Get().EnterToShop());
			this.finder = null;
			return;
		}
		if (this.keyListen(this.AddThisPart, this.finder))
		{
			this.getFromIni();
			this.finder = null;
			string id = GameScript.Get().GetPartMouseOver().GetID();
			if (id != null)
			{
				Inventory.Get().Add(id, 1f, Color.white, true, true);
				foreach (NewInventoryItem newInventoryItem6 in Inventory.Get().GetItems(id))
				{
					newInventoryItem6.Condition = this.condition;
					newInventoryItem6.extraParameters.Add("Quality", this.quality);
				}
			}
			if (this.showInventory == "false")
			{
				UIManager.Get().ShowPopup("System:", "Part " + id + " added to inventory", PopupType.Normal);
				return;
			}
			UIManager.Get().ShowPopup("System:", "Part " + id + " added to inventory", PopupType.Normal);
			base.StartCoroutine(UIManager.Get().PrepareInventory());
			UIManager.Get().Show("Inventory");
		}
		this.finder = null;
	}

	// Token: 0x06002A8C RID: 10892 RVA: 0x000FA480 File Offset: 0x000F8680
	public void getFromIni()
	{
		string path = Application.dataPath + "/Managed/swiss.ini";
		if (File.Exists(path))
		{
			string[] array = File.ReadAllLines(path);
			for (int i = 0; i < array.Length; i++)
			{
				string a = array[i].Substring(0, array[i].IndexOf("="));
				string s = array[i].Substring(array[i].IndexOf("=") + 1);
				if (a == "car")
				{
					this.car = s;
				}
				if (a == "quality")
				{
					this.quality = int.Parse(s);
				}
				if (a == "mileage")
				{
					this.mileage = int.Parse(s);
				}
				if (a == "condition")
				{
					this.condition = float.Parse(s);
				}
				if (a == "addMoneyAmount")
				{
					this.addMoneyAmount = int.Parse(s);
				}
				if (a == "setMoneyAmount")
				{
					this.setMoneyAmount = int.Parse(s);
				}
				if (a == "addXPAmount")
				{
					this.addXPAmount = int.Parse(s);
				}
				if (a == "showInventory")
				{
					this.showInventory = s;
				}
				if (a == "showIntro")
				{
					this.showIntro = s;
				}
				if (a == "spawnIsExamined")
				{
					this.spawnIsExamined = s;
				}
				if (a == "licensePlate")
				{
					this.licensePlate = s;
				}
				if (a == "spawnLocation")
				{
					this.spawnLocation = s;
				}
			}
			return;
		}
		UIManager.Get().ShowPopup("System:", "swiss.ini not found in /Managed folder", PopupType.Normal);
	}

	// Token: 0x06002A8D RID: 10893 RVA: 0x0001B295 File Offset: 0x00019495
	public IEnumerator ReloadCar(CarLoader reloadCar)
	{
		string name = reloadCar.GetRoot().name;
		base.StartCoroutine(reloadCar.LoadCar(name));
		while (!reloadCar.IsCarLoaded())
		{
			yield return new WaitForEndOfFrame();
		}
		yield return new WaitForEndOfFrame();
		reloadCar.PlaceAtPosition();
		reloadCar.SetRandomCarColor();
		reloadCar.SetOilLevelAndCondition(1f, 1f);
		reloadCar.SetMileage(this.mileage);
		yield break;
	}

	// Token: 0x06002A8E RID: 10894 RVA: 0x0001B2AB File Offset: 0x000194AB
	public IEnumerator SpawnCar()
	{
		this.getFromIni();
		if (!string.IsNullOrEmpty(this.car))
		{
			if (this.car == "car_random")
			{
				this.car = Singleton<CarBundleLoader>.Instance.RandomCarName();
			}
			int configCounts = Singleton<CarBundleLoader>.Instance.GetConfigCounts(this.car);
			if (this.version + 1 > configCounts)
			{
				UIManager.Get().ShowPopup("System:", string.Concat(new object[]
				{
					"There are only ",
					configCounts,
					" versions of this car, i'll set it to config",
					configCounts - 1,
					" for you."
				}), PopupType.Normal);
				this.version = configCounts - 1;
			}
			UIManager.Get().ShowPopup("System:", "Spawning Car " + this.car, PopupType.Normal);
			if (this.spawnLocation == "garage1")
			{
				if (CarLoaderPlaces.Get().GetOccupied(CarPlace.Entrance1))
				{
					UIManager.Get().ShowPopup("System:", "Car exists Garage 1, deleting", PopupType.Normal);
					this.carLoader = CarLoaderPlaces.Get().GetCarLoaderForPlace(CarPlace.Entrance1);
					this.carLoader.DeleteCar(true);
				}
				else
				{
					UIManager.Get().ShowPopup("System:", "Garage 1 Empty Spot", PopupType.Normal);
					this.carLoader = CarLoaderPlaces.Get().GetPlaceForLoadCar();
					this.carLoader.groundPosition = CarLoaderPlaces.Get().GetPlaceTransform(CarPlace.Entrance1);
				}
			}
			if (this.spawnLocation == "paintshop")
			{
				if (CarLoaderPlaces.Get().GetOccupied(CarPlace.Paintshop))
				{
					UIManager.Get().ShowPopup("System:", "Car exists Paintshop, deleting", PopupType.Normal);
					this.carLoader = CarLoaderPlaces.Get().GetCarLoaderForPlace(CarPlace.Paintshop);
					this.carLoader.DeleteCar(true);
				}
				else
				{
					UIManager.Get().ShowPopup("System:", "Paintshop Empty Spot", PopupType.Normal);
					this.carLoader = CarLoaderPlaces.Get().GetPlaceForLoadCar();
					this.carLoader.groundPosition = CarLoaderPlaces.Get().GetPlaceTransform(CarPlace.Paintshop);
				}
			}
			this.carLoader.ConfigVersion = this.version;
			base.StartCoroutine(this.carLoader.LoadCarFromFile(this.car));
			while (!this.carLoader.IsLoadedFromFile())
			{
				yield return new WaitForEndOfFrame();
			}
			base.StartCoroutine(this.carLoader.LoadCar(this.car));
			while (!this.carLoader.IsCarLoaded())
			{
				yield return new WaitForEndOfFrame();
			}
			yield return new WaitForEndOfFrame();
			this.carLoader.PlaceAtPosition();
			this.carLoader.SetRandomCarColor();
			this.carLoader.SetOilLevelAndCondition(1f, 1f);
			this.carLoader.SetMileage(this.mileage);
			this.carLoader.SetNewLicensePlateNumber(this.licensePlate, true);
			this.carLoader.SetNewLicensePlateNumber(this.licensePlate, false);
			if (this.spawnIsExamined == "true")
			{
				this.carLoader.ExamineAllParts();
			}
			yield break;
		}
		UIManager.Get().ShowPopup("System:", "No car found in swiss.ini or the name is wrong.", PopupType.Normal);
		yield break;
	}

	// Token: 0x06002A8F RID: 10895 RVA: 0x000FA614 File Offset: 0x000F8814
	private void getFromKeysIni()
	{
		this.keyValuePairs = new Dictionary<string, string>();
		string path = Application.dataPath + "/Managed/keys.ini";
		if (File.Exists(path))
		{
			string[] array = File.ReadAllLines(path);
			for (int i = 0; i < array.Length; i++)
			{
				string a = array[i].Substring(0, array[i].IndexOf("="));
				string text = array[i].Substring(array[i].IndexOf("=") + 1);
				if (a == "SpawnCar")
				{
					this.SpawnCarKey = text;
					this.keyValuePairs.Add(this.SpawnCarKey, text);
				}
				if (a == "IncreaseConfig")
				{
					this.IncreseConfigKey = text;
					this.keyValuePairs.Add(this.IncreseConfigKey, text);
				}
				if (a == "DecreaseConfig")
				{
					this.DecreaseConfigKey = text;
					this.keyValuePairs.Add(this.DecreaseConfigKey, text);
				}
				if (a == "RandomChangeCondition")
				{
					this.RandomChangeCondition = text;
					this.keyValuePairs.Add(this.RandomChangeCondition, text);
				}
				if (a == "RandomChangeColor")
				{
					this.RandomChangeColor = text;
					this.keyValuePairs.Add(this.RandomChangeColor, text);
				}
				if (a == "ReloadLiveries")
				{
					this.ReloadLiveries = text;
					this.keyValuePairs.Add(this.ReloadLiveries, text);
				}
				if (a == "SetMileage")
				{
					this.SetMileage = text;
					this.keyValuePairs.Add(this.SetMileage, text);
				}
				if (a == "GenerateJunkyard")
				{
					this.GenerateJunkyard = text;
					this.keyValuePairs.Add(this.GenerateJunkyard, text);
				}
				if (a == "FullyRepairCar")
				{
					this.FullyRepairCar = text;
					this.keyValuePairs.Add(this.FullyRepairCar, text);
				}
				if (a == "PhotoMode")
				{
					this.PhotoMode = text;
					this.keyValuePairs.Add(this.PhotoMode, text);
				}
				if (a == "DuplicateEngine")
				{
					this.DuplicateEngine = text;
					this.keyValuePairs.Add(this.DuplicateEngine, text);
				}
				if (a == "IncreaseSpeed")
				{
					this.IncreaseSpeed = text;
					this.keyValuePairs.Add(this.IncreaseSpeed, text);
				}
				if (a == "DecreaseSpeed")
				{
					this.DecreaseSpeed = text;
					this.keyValuePairs.Add(this.DecreaseSpeed, text);
				}
				if (a == "AddAllEngineParts")
				{
					this.AddAllEngineParts = text;
					this.keyValuePairs.Add(this.AddAllEngineParts, text);
				}
				if (a == "RepairAllItems")
				{
					this.RepairAllItems = text;
					this.keyValuePairs.Add(this.RepairAllItems, text);
				}
				if (a == "AddBarn")
				{
					this.AddBarn = text;
					this.keyValuePairs.Add(this.AddBarn, text);
				}
				if (a == "AddMoney")
				{
					this.AddMoney = text;
					this.keyValuePairs.Add(this.AddMoney, text);
				}
				if (a == "SetMoney")
				{
					this.SetMoney = text;
					this.keyValuePairs.Add(this.SetMoney, text);
				}
				if (a == "AddXP")
				{
					this.AddXP = text;
					this.keyValuePairs.Add(this.AddXP, text);
				}
				if (a == "UnlockAllUpgrades")
				{
					this.UnlockAllUpgrades = text;
					this.keyValuePairs.Add(this.UnlockAllUpgrades, text);
				}
				if (a == "OpenShop")
				{
					this.OpenShop = text;
					this.keyValuePairs.Add(this.OpenShop, text);
				}
				if (a == "AddThisPart")
				{
					this.AddThisPart = text;
					this.keyValuePairs.Add(this.AddThisPart, text);
				}
				if (a == "RotateEngineRight")
				{
					this.RotateEngineRight = text;
					this.keyValuePairs.Add(this.RotateEngineRight, text);
				}
				if (a == "RotateEngineLeft")
				{
					this.RotateEngineLeft = text;
					this.keyValuePairs.Add(this.RotateEngineLeft, text);
				}
				if (a == "CarIsExamined")
				{
					this.CarIsExamined = text;
					this.keyValuePairs.Add(this.CarIsExamined, text);
				}
				if (a == "PartIsExamined")
				{
					this.PartIsExamined = text;
					this.keyValuePairs.Add(this.PartIsExamined, text);
				}
			}
			return;
		}
		UIManager.Get().ShowPopup("System:", "swiss.ini not found in /Managed folder", PopupType.Normal);
	}

	// Token: 0x06002A90 RID: 10896 RVA: 0x0001B2BA File Offset: 0x000194BA
	public void AssignKey(string key, string value)
	{
		this.keyValuePairs = new Dictionary<string, string>();
		this.keyValuePairs.Add(new KeyValuePair<string, string>(key, value));
	}

	// Token: 0x06002A91 RID: 10897 RVA: 0x000FAA84 File Offset: 0x000F8C84
	public virtual void KeyPress()
	{
		this.getFromKeysIni();
		if (Input.GetKeyUp(KeyCode.Keypad0))
		{
			this.finder = "0";
		}
		if (Input.GetKeyUp(KeyCode.Keypad1))
		{
			this.finder = "1";
		}
		if (Input.GetKeyUp(KeyCode.Keypad2))
		{
			this.finder = "2";
		}
		if (Input.GetKeyUp(KeyCode.Keypad3))
		{
			this.finder = "3";
		}
		if (Input.GetKeyUp(KeyCode.Keypad4))
		{
			this.finder = "4";
		}
		if (Input.GetKeyUp(KeyCode.Keypad5))
		{
			this.finder = "5";
		}
		if (Input.GetKeyUp(KeyCode.Keypad6))
		{
			this.finder = "6";
		}
		if (Input.GetKeyUp(KeyCode.Keypad7))
		{
			this.finder = "7";
		}
		if (Input.GetKeyUp(KeyCode.Keypad8))
		{
			this.finder = "8";
		}
		if (Input.GetKeyUp(KeyCode.Keypad9))
		{
			this.finder = "9";
		}
		if (Input.GetKeyUp(KeyCode.KeypadPlus))
		{
			this.finder = "+";
		}
		if (Input.GetKeyUp(KeyCode.KeypadMinus))
		{
			this.finder = "-";
		}
		if (Input.GetKeyUp(KeyCode.Insert))
		{
			this.finder = "Insert";
		}
		if (Input.GetKeyUp(KeyCode.KeypadMultiply))
		{
			this.finder = "*";
		}
		if (Input.GetKeyUp(KeyCode.KeypadDivide))
		{
			this.finder = "/";
		}
		if (Input.GetKeyUp(KeyCode.F5))
		{
			this.finder = "F5";
		}
		if (Input.GetKeyUp(KeyCode.F6))
		{
			this.finder = "F6";
		}
		if (Input.GetKeyUp(KeyCode.F7))
		{
			this.finder = "F7";
		}
		if (Input.GetKeyUp(KeyCode.F8))
		{
			this.finder = "F8";
		}
		if (Input.GetKeyUp(KeyCode.F9))
		{
			this.finder = "F9";
		}
		if (Input.GetKeyUp(KeyCode.F10))
		{
			this.finder = "F10";
		}
		if (Input.GetKeyUp(KeyCode.F11))
		{
			this.finder = "F11";
		}
		if (Input.GetKeyUp(KeyCode.End))
		{
			this.finder = "End";
		}
		if (Input.GetKeyUp(KeyCode.LeftBracket))
		{
			this.finder = "[";
		}
		if (Input.GetKeyUp(KeyCode.RightBracket))
		{
			this.finder = "]";
		}
		if (Input.GetKeyUp(KeyCode.Home))
		{
			this.finder = "Home";
		}
		if (Input.GetKeyUp(KeyCode.PageUp))
		{
			this.finder = "PageUp";
		}
		if (Input.GetKeyUp(KeyCode.PageDown))
		{
			this.finder = "PageDown";
		}
	}

	// Token: 0x06002A92 RID: 10898 RVA: 0x0001B2D9 File Offset: 0x000194D9
	public bool keyListen(string key, string value)
	{
		return this.keyValuePairs.Contains(new KeyValuePair<string, string>(key, value));
	}

	// Token: 0x06002A93 RID: 10899 RVA: 0x0001B2ED File Offset: 0x000194ED
	public static TestScript Get()
	{
		return TestScript.m_instance;
	}

	// Token: 0x04002362 RID: 9058
	public CarLoader carLoader;

	// Token: 0x04002363 RID: 9059
	public int version;

	// Token: 0x04002364 RID: 9060
	public int mileage;

	// Token: 0x04002365 RID: 9061
	public int quality;

	// Token: 0x04002366 RID: 9062
	public string car;

	// Token: 0x04002367 RID: 9063
	public float condition;

	// Token: 0x04002368 RID: 9064
	public CarLoader carReLoader;

	// Token: 0x04002369 RID: 9065
	public NewGroupItem engine;

	// Token: 0x0400236A RID: 9066
	public CarLoader cEngine;

	// Token: 0x0400236B RID: 9067
	public string SpawnCarKey;

	// Token: 0x0400236C RID: 9068
	public string IncreseConfigKey;

	// Token: 0x0400236D RID: 9069
	public string DecreaseConfigKey;

	// Token: 0x0400236E RID: 9070
	public string RandomChangeCondition;

	// Token: 0x0400236F RID: 9071
	public string ReloadLiveries;

	// Token: 0x04002370 RID: 9072
	public string SetMileage;

	// Token: 0x04002371 RID: 9073
	public string DuplicateEngine;

	// Token: 0x04002372 RID: 9074
	public string IncreaseSpeed;

	// Token: 0x04002373 RID: 9075
	public string DecreaseSpeed;

	// Token: 0x04002374 RID: 9076
	public string AddAllEngineParts;

	// Token: 0x04002375 RID: 9077
	public string RepairAllItems;

	// Token: 0x04002376 RID: 9078
	public string AddBarn;

	// Token: 0x04002377 RID: 9079
	public string AddMoney;

	// Token: 0x04002378 RID: 9080
	public string AddXP;

	// Token: 0x04002379 RID: 9081
	public string UnlockAllUpgrades;

	// Token: 0x0400237A RID: 9082
	public string OpenShop;

	// Token: 0x0400237B RID: 9083
	public string AddThisPart;

	// Token: 0x0400237C RID: 9084
	public string RotateEngineRight;

	// Token: 0x0400237D RID: 9085
	public string RotateEngineLeft;

	// Token: 0x0400237E RID: 9086
	public string finder;

	// Token: 0x0400237F RID: 9087
	private IDictionary<string, string> keyValuePairs;

	// Token: 0x04002380 RID: 9088
	public string RandomChangeColor;

	// Token: 0x04002381 RID: 9089
	public string GenerateJunkyard;

	// Token: 0x04002382 RID: 9090
	public string FullyRepairCar;

	// Token: 0x04002383 RID: 9091
	public string PhotoMode;

	// Token: 0x04002384 RID: 9092
	public int addMoneyAmount;

	// Token: 0x04002385 RID: 9093
	public int addXPAmount;

	// Token: 0x04002386 RID: 9094
	public string itemID;

	// Token: 0x04002387 RID: 9095
	public string showInventory;

	// Token: 0x04002388 RID: 9096
	public string SetMoney;

	// Token: 0x04002389 RID: 9097
	public int setMoneyAmount;

	// Token: 0x0400238A RID: 9098
	public string PartIsExamined;

	// Token: 0x0400238B RID: 9099
	public string CarIsExamined;

	// Token: 0x0400238C RID: 9100
	public string showIntro;

	// Token: 0x0400238D RID: 9101
	private static TestScript m_instance;

	// Token: 0x0400238E RID: 9102
	public string spawnIsExamined;

	// Token: 0x0400238F RID: 9103
	public string licensePlate;

	// Token: 0x04002390 RID: 9104
	public string spawnLocation;
}