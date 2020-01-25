using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Token: 0x02000458 RID: 1112
public class JunkyardGenerator : MonoBehaviour
{
	// Token: 0x06002161 RID: 8545
	public IEnumerator Generate()
	{
		ScreenFader.Get().SetBlack();
		Singleton<InputManager>.Instance.ChangeInput(false, false, false);
		while (Singleton<CarBundleLoader>.Instance)
		{
			if (Singleton<CarBundleLoader>.Instance.IsReady)
			{
				IL_BE:
				while (Localization.Instance)
				{
					if (Localization.Instance.IsReady)
					{
						IL_E7:
						while (Singleton<GameInventory>.Instance && !Singleton<GameInventory>.Instance.IsReady)
						{
							yield return new WaitForEndOfFrame();
						}
						GlobalData.Load();
						base.StartCoroutine(UIManager.Get().RefreshStatsUI("Money"));
						base.StartCoroutine(UIManager.Get().RefreshStatsUI("Experience"));
						base.StartCoroutine(UIManager.Get().RefreshStatsUI("Orders"));
						base.StartCoroutine(UIManager.Get().RefreshStatsUI("Level"));
						Singleton<RichPresenceManager>.Instance.SendPresence("console_richtxt_junk");
						Singleton<TempInventory>.Instance.CleanListOfItems();
						GameManager.CanMount = false;
						GameManager.CanUnmount = false;
						base.StartCoroutine(UIManager.Get().cleanElement("CanvasInventory/Inventory/Content/ScrollRect/Content"));
						UnityEngine.Random.Range(this.CarsPercentage.x, this.CarsPercentage.y);
						float amount = 24f;
						List<Transform> carSpawnPositions = this.CarSpawnPositions.ToList<Transform>();
						Debug.Log("Spawn " + amount + " cars");
						yield return new WaitForEndOfFrame();
						int num = 0;
						while ((float)num < amount)
						{
							int index = UnityEngine.Random.Range(0, carSpawnPositions.Count);
							base.StartCoroutine(this.CreateCar(carSpawnPositions[index]));
							carSpawnPositions.RemoveAt(index);
							num++;
						}
						InteractiveObject[] ios = this.Junkyard.GetComponentsInChildren<InteractiveObject>();
						float percentItems = UnityEngine.Random.Range(this.ItemsPercentage.x, this.ItemsPercentage.y);
						List<InteractiveObject> items = ios.ToList<InteractiveObject>();
						float amountItems = Mathf.Floor(percentItems / 100f * (float)items.Count((InteractiveObject x) => x.GetSpecialType() == IOSpecialType.Junk));
						List<InteractiveObject> listOfSelectedJunks = new List<InteractiveObject>();
						Debug.Log("Enable " + amountItems);
						yield return new WaitForEndOfFrame();
						int num2 = 0;
						while ((float)num2 < amountItems)
						{
							int index2 = UnityEngine.Random.Range(0, items.Count);
							InteractiveObject interactiveObject = items[index2];
							interactiveObject.enabled = true;
							if (interactiveObject.GetSpecialType() == IOSpecialType.Junk)
							{
								interactiveObject.gameObject.AddComponent<Junk>().AddRandomItems(this.rangeJunkCondition.x, this.rangeJunkCondition.y);
								listOfSelectedJunks.Add(interactiveObject);
								items.RemoveAt(index2);
							}
							else
							{
								num2--;
							}
							num2++;
						}
						if (Singleton<DifficultyManager>.Instance.GetDifficultyLevel() != DifficultyLevel.Sandbox)
						{
							listOfSelectedJunks.ElementAt(UnityEngine.Random.Range(0, listOfSelectedJunks.Count)).GetComponent<Junk>().AddSpecialMap();
						}
						yield return new WaitForEndOfFrame();
						GameScript.Get().ReloadCarsOnScene();
						Singleton<DifficultyManager>.Instance.ActivateDifficultyLevel();
						UIManager.Get().PrepareTempInventory();
						SceneLoader.BlockProgress = false;
						GameManager.IsGameReady = true;
						yield return new WaitForEndOfFrame();
						if (this.shortPauseWhileFade)
						{
							yield return new WaitForSeconds(5f);
						}
						GameMode.Get().SetCurrentMode(gameMode.Garage);
						yield return new WaitForSeconds(1f);
						ScreenFader.Get().NormalFadeOut();
						while (ScreenFader.Get().IsRunning())
						{
							yield return new WaitForEndOfFrame();
						}
						Singleton<InputManager>.Instance.ChangeInput(true, true, false);
						yield break;
					}
					yield return new WaitForEndOfFrame();
				}
				goto IL_E7;
			}
			yield return new WaitForEndOfFrame();
		}
		goto IL_BE;
	}

	// Token: 0x06002162 RID: 8546
	private IEnumerator CreateCar(Transform t)
	{
		GameObject go2 = new GameObject();
		go2.transform.position = t.position;
		go2.transform.eulerAngles = t.eulerAngles;
		go2.name = "CarPosition";
		go2.AddComponent<CarLoader>();
		go2.GetComponent<CarLoader>().addInteractiveObject = true;
		go2.GetComponent<CarLoader>().groundPosition = go2.transform;
		go2.AddComponent<CarDebug>();
		List<CarsIdWithConfig> listOfAviableCars = Singleton<CarBundleLoader>.Instance.GetCarsSpawnsInScene(SceneType.Junkyard);
		CarsIdWithConfig randomCar = listOfAviableCars[UnityEngine.Random.Range(0, listOfAviableCars.Count)];
		CarLoader cl = go2.GetComponent<CarLoader>();
		cl.ConfigVersion = randomCar.ConfigVersion;
		base.StartCoroutine(cl.LoadCar(randomCar.CarID));
		while (!cl.IsCarLoaded())
		{
			yield return new WaitForEndOfFrame();
		}
		LicensePlate licensePlate = Singleton<GameInventory>.Instance.GetRandomLicensePlate();
		cl.ChangeLicencePlateTexture(cl.GetCarPart("license_plate_front"), licensePlate.name);
		cl.ChangeLicencePlateTexture(cl.GetCarPart("license_plate_rear"), licensePlate.name);
		CarDoorOpenBlocker doorBlocker = t.GetComponent<CarDoorOpenBlocker>();
		if (doorBlocker)
		{
			cl.LockObject("door_front_left", doorBlocker.openLeftSide);
			cl.LockObject("door_rear_left", doorBlocker.openLeftSide);
			cl.LockObject("door_front_right", doorBlocker.openRightSide);
			cl.LockObject("door_rear_right", doorBlocker.openRightSide);
		}
		cl.PlaceAtPosition();
		cl.SetRandomCarColor();
		yield return new WaitForEndOfFrame();
		cl.SetRandomMissingPanels(this.percMissingPanels);
		yield return new WaitForEndOfFrame();
		cl.SetRandomPartsConditions(this.rangePartsCondition.x, this.rangePartsCondition.y);
		yield return new WaitForEndOfFrame();
		cl.SetRustRandomParts(this.rangeBodyPartsCondition.x, this.rangeBodyPartsCondition.y);
		yield return new WaitForEndOfFrame();
		cl.SetRandomMissingParts((int)this.percRangeUnmountIO.x, (int)this.percRangeUnmountIO.y);
		yield return new WaitForEndOfFrame();
		base.StartCoroutine(cl.SetRandomColorPanels(this.percRandomPartsColor, this.rangeColorPartsCondition.x, this.rangeColorPartsCondition.y));
		yield return new WaitForEndOfFrame();
		cl.SetRandomCarLivery();
		yield return new WaitForEndOfFrame();
		cl.SetNegotiationPriceMod(UnityEngine.Random.Range(this.rangeNegotationMod.x, this.rangeNegotationMod.y));
		yield return new WaitForEndOfFrame();
		cl.RunInstantExamine();
		yield return new WaitForEndOfFrame();
		CarHelper.SetRandomFactoryColor(cl);
		cl.EnableDust(true);
		cl.EnableRustOutside(null, true);
		cl.SetRandomMileage(SceneType.Auction);
		if (go2)
		{
			go2.transform.position = t.position;
			go2.transform.eulerAngles = t.eulerAngles;
			t.gameObject.SetActive(false);
		}
		yield break;
	}

	// Token: 0x06002163 RID: 8547
	private void Awake()
	{
		SceneLoader.BlockProgress = true;
		GameManager.IsGameReady = false;
	}

	// Token: 0x06002164 RID: 8548
	private void Start()
	{
		base.StartCoroutine(this.Generate());
	}

	// Token: 0x06002165 RID: 8549
	public void Update()
	{
		if (this.GenerateNewJunkyard)
		{
			this.GenerateNewJunkyard = false;
			CarLoader[] array = UnityEngine.Object.FindObjectsOfType<CarLoader>();
			for (int i = 0; i < array.Length; i++)
			{
				array[i].DeleteCar();
			}
			base.StartCoroutine(this.Generate());
		}
	}

	// Token: 0x04001AA8 RID: 6824
	[Header("Main")]
	[SerializeField]
	private bool shortPauseWhileFade;

	// Token: 0x04001AA9 RID: 6825
	private Transform player;

	// Token: 0x04001AAA RID: 6826
	[SerializeField]
	private Transform[] CarSpawnPositions;

	// Token: 0x04001AAB RID: 6827
	[SerializeField]
	private Transform Junkyard;

	// Token: 0x04001AAC RID: 6828
	[Header("Generate Settings")]
	[SerializeField]
	public bool GenerateNewJunkyard;

	// Token: 0x04001AAD RID: 6829
	[SerializeField]
	private Vector2 CarsPercentage = new Vector2(10f, 20f);

	// Token: 0x04001AAE RID: 6830
	[SerializeField]
	private Vector2 ItemsPercentage = new Vector2(60f, 80f);

	// Token: 0x04001AAF RID: 6831
	[SerializeField]
	private int percRandomPartsColor = 65;

	// Token: 0x04001AB0 RID: 6832
	[SerializeField]
	private Vector2 percRangeUnmountIO = new Vector2(30f, 100f);

	// Token: 0x04001AB1 RID: 6833
	[SerializeField]
	private int percMissingPanels = 25;

	// Token: 0x04001AB2 RID: 6834
	[SerializeField]
	private Vector2 rangeBodyPartsCondition = new Vector2(0.2f, 0.7f);

	// Token: 0x04001AB3 RID: 6835
	[SerializeField]
	private Vector2 rangePartsCondition = new Vector2(0.2f, 0.7f);

	// Token: 0x04001AB4 RID: 6836
	[SerializeField]
	private Vector2 rangeColorPartsCondition = new Vector2(0.2f, 0.7f);

	// Token: 0x04001AB5 RID: 6837
	[SerializeField]
	private Vector2 rangeJunkCondition = new Vector2(0.35f, 0.6f);

	// Token: 0x04001AB6 RID: 6838
	[SerializeField]
	private Vector2 rangeNegotationMod = new Vector2(0.5f, 1f);
}