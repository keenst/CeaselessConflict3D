using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
	public List<CombatButton> buttons;
	public CombatController combatController;

	private int _selectedIndex;

	public void UpdateMenu(Menu newMenu)
	{
		for (int i = 0; i < buttons.Count; i++)
		{
			if (i >= (newMenu.Buttons).Length)
			{
				buttons[i].gameObject.SetActive(false);
				continue;
			}

			buttons[i].SetTitle(newMenu.Buttons[i]);
		}
	}

	public void OnScroll(InputAction.CallbackContext context)
	{
		if (!context.started) return;

		float direction = context.ReadValue<float>();

		_selectedIndex = Mod((_selectedIndex + (int)direction), buttons.Count - 1);
	}

	public void OnSelect(InputAction.CallbackContext context)
	{
		if (!context.started) return;

		combatController.OnPlayerAction(buttons[_selectedIndex].Title);
	}

	private static int Mod(int x, int y)
	{
		return (Math.Abs(x * y) + x) % y;
	}
}
