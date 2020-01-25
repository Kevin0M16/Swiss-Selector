using System;
using UnityEngine;

// Token: 0x0200047B RID: 1147
public class FPSInputController : MonoBehaviour
{
	// Token: 0x0600201E RID: 8222 RVA: 0x00015A42 File Offset: 0x00013C42
	private void Awake()
	{
		this.motor = base.GetComponent<CharacterMotor>();
		this.SetCharacterControllerPosition();
	}

	// Token: 0x0600201F RID: 8223 RVA: 0x00015A56 File Offset: 0x00013C56
	private void Start()
	{
		this.UpdateSpeed();
	}

	// Token: 0x06002020 RID: 8224 RVA: 0x000B2BF8 File Offset: 0x000B0DF8
	private void Update()
	{
		Vector3 vector = new Vector3(Singleton<InputManager>.Instance.GameplayHorizontal(), 0f, Singleton<InputManager>.Instance.GameplayVertical());
		if (!this.motor.canControl)
		{
			vector = Vector3.zero;
		}
		if (vector != Vector3.zero)
		{
			float num = vector.magnitude;
			vector /= num;
			num = Mathf.Min(this.CONST_MAX_LENGTH, num);
			num *= num;
			vector = vector * num * this.speedAdd;
		}
		if (Input.GetKeyUp(KeyCode.KeypadPlus))
		{
			this.speedAdd *= 2f;
			UIManager.Get().ShowPopup("System:", "Speed increased", PopupType.Normal);
		}
		if (Input.GetKeyUp(KeyCode.KeypadMinus))
		{
			this.speedAdd /= 2f;
			UIManager.Get().ShowPopup("System:", "Speed decreased", PopupType.Normal);
		}
		this.motor.inputMoveDirection = base.transform.rotation * vector;
	}

	// Token: 0x06002021 RID: 8225 RVA: 0x000B2CFC File Offset: 0x000B0EFC
	private void SetCharacterControllerPosition()
	{
		Vector3 direction = base.transform.TransformDirection(Vector3.down);
		RaycastHit raycastHit;
		if (Physics.Raycast(base.transform.position, direction, out raycastHit))
		{
			CharacterController component = base.GetComponent<CharacterController>();
			float num = component.height * 0.5f;
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y - raycastHit.distance + num + component.skinWidth, base.transform.position.z);
		}
		this.IsReady = true;
	}

	// Token: 0x06002022 RID: 8226 RVA: 0x00015A5E File Offset: 0x00013C5E
	public void UpdateSpeed()
	{
		this.speedAdd = Singleton<UpgradeSystem>.Instance.GetUpgradeValue("fast_movement");
	}

	// Token: 0x040019C6 RID: 6598
	private CharacterMotor motor;

	// Token: 0x040019C7 RID: 6599
	[HideInInspector]
	public bool IsReady;

	// Token: 0x040019C8 RID: 6600
	private float CONST_MAX_LENGTH = 1f;

	// Token: 0x040019C9 RID: 6601
	private float speedAdd = 1f;
}