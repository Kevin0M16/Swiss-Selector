using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

// Token: 0x02000508 RID: 1288
public class IntroPlayer : MonoBehaviour
{
	// Token: 0x060024C6 RID: 9414 RVA: 0x000181B8 File Offset: 0x000163B8
	private void Awake()
	{
		base.StartCoroutine(this.Prepare());
	}

	// Token: 0x060024C7 RID: 9415 RVA: 0x000CF5C4 File Offset: 0x000CD7C4
	private void OnDestroy()
	{
		if (this.videoPlayer != null)
		{
			this.videoPlayer.Stop();
			this.videoPlayer.errorReceived -= this.OnErrorReceived;
			this.videoPlayer.loopPointReached -= this.OnLoopPointReached;
		}
	}

	// Token: 0x060024C8 RID: 9416 RVA: 0x000181C7 File Offset: 0x000163C7
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

	// Token: 0x060024C9 RID: 9417 RVA: 0x000181D6 File Offset: 0x000163D6
	private void OnErrorReceived(VideoPlayer source, string message)
	{
		GameSettings.gfx_noVideo = true;
		this.NextScene();
	}

	// Token: 0x060024CA RID: 9418 RVA: 0x000181E4 File Offset: 0x000163E4
	private void OnLoopPointReached(VideoPlayer source)
	{
		this.NextScene();
	}

	// Token: 0x060024CB RID: 9419 RVA: 0x000181EC File Offset: 0x000163EC
	private void Update()
	{
		if (Input.GetKeyDown("escape") || Input.GetKeyDown(KeyCode.JoystickButton0))
		{
			this.NextScene();
		}
	}

	// Token: 0x060024CC RID: 9420 RVA: 0x000CF618 File Offset: 0x000CD818
	private void NextScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	// Token: 0x04001DEE RID: 7662
	public string moviePath;

	// Token: 0x04001DEF RID: 7663
	public VideoPlayer videoPlayer;

	// Token: 0x04001DF0 RID: 7664
	public bool isReady;
}
