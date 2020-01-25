using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

// Token: 0x0200050A RID: 1290
public class IntroPlayer : MonoBehaviour
{
	// Token: 0x060024D4 RID: 9428 RVA: 0x000181D4 File Offset: 0x000163D4
	private void Awake()
	{
		base.StartCoroutine(this.Prepare());
	}

	// Token: 0x060024D5 RID: 9429 RVA: 0x000CF654 File Offset: 0x000CD854
	private void OnDestroy()
	{
		if (this.videoPlayer != null)
		{
			this.videoPlayer.Stop();
			this.videoPlayer.errorReceived -= this.OnErrorReceived;
			this.videoPlayer.loopPointReached -= this.OnLoopPointReached;
		}
	}

	// Token: 0x060024D6 RID: 9430 RVA: 0x000181E3 File Offset: 0x000163E3
	private IEnumerator Prepare()
	{
		if (File.Exists(string.Concat(new object[]
		{
			Application.dataPath,
			"/../",
			's',
			string.Empty,
			't',
			string.Empty,
			'e',
			string.Empty,
			'a',
			string.Empty,
			'm',
			string.Empty,
			'_',
			string.Empty,
			'a',
			string.Empty,
			'p',
			string.Empty,
			'i',
			string.Empty,
			'.',
			string.Empty,
			'i',
			string.Empty,
			'n',
			string.Empty,
			'i'
		})) && !GameSettings.BuildVersion.EndsWith("."))
		{
			GameSettings.BuildVersion += ".";
		}
		if (!this.isReady)
		{
			yield return new WaitForEndOfFrame();
		}
		try
		{
			string text = Application.streamingAssetsPath + "/" + this.moviePath;
			TestScript testScript = new TestScript();
			testScript.getFromIni();
			if (File.Exists(text) && testScript.showIntro == "true")
			{
				this.videoPlayer.errorReceived += this.OnErrorReceived;
				this.videoPlayer.loopPointReached += this.OnLoopPointReached;
				this.videoPlayer.url = text;
				this.videoPlayer.Play();
			}
			else
			{
				this.NextScene();
			}
			yield break;
		}
		catch (Exception ex)
		{
			Debug.LogWarning("ERROR:" + ex.Message);
			this.NextScene();
			yield break;
		}
		yield break;
	}

	// Token: 0x060024D7 RID: 9431 RVA: 0x000181F2 File Offset: 0x000163F2
	private void OnErrorReceived(VideoPlayer source, string message)
	{
		GameSettings.gfx_noVideo = true;
		this.NextScene();
	}

	// Token: 0x060024D8 RID: 9432 RVA: 0x00018200 File Offset: 0x00016400
	private void OnLoopPointReached(VideoPlayer source)
	{
		this.NextScene();
	}

	// Token: 0x060024D9 RID: 9433 RVA: 0x00018208 File Offset: 0x00016408
	private void Update()
	{
		if (Input.GetKeyDown("escape") || Input.GetKeyDown(KeyCode.JoystickButton0))
		{
			this.NextScene();
		}
	}

	// Token: 0x060024DA RID: 9434 RVA: 0x000CF6A8 File Offset: 0x000CD8A8
	private void NextScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	// Token: 0x04001DF6 RID: 7670
	public string moviePath;

	// Token: 0x04001DF7 RID: 7671
	public VideoPlayer videoPlayer;

	// Token: 0x04001DF8 RID: 7672
	public bool isReady;
}