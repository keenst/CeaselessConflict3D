using UnityEngine;
using UnityEngine.InputSystem;

public class Flashlight : MonoBehaviour
{
	public GameObject flashlight;

	public void OnToggle(InputAction.CallbackContext context)
	{
		if (!context.started) return;

		flashlight.SetActive(!flashlight.activeSelf);
	}
}
