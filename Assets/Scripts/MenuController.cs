using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
	public List<CombatButton> buttons;
	public CombatController combatController;

	private int _selectedIndex;
	private int _buttonCount;

	public void OpenMenu(Menu newMenu)
	{
		_buttonCount = 0;

		for (int i = 0; i < buttons.Count; i++)
		{
			if (i >= (newMenu.Buttons).Length)
			{
				buttons[i].gameObject.SetActive(false);
				continue;
			}

			buttons[i].gameObject.SetActive(true);
			buttons[i].SetTitle(newMenu.Buttons[i]);

			_buttonCount++;
		}

		buttons[0].SetHighlighted(true);
		_selectedIndex = 0;
	}

	public void OnScroll(InputAction.CallbackContext context)
	{
		if (!context.started) return;

		float direction = context.ReadValue<float>();

		int prevSelected = _selectedIndex;
		_selectedIndex = Mod((_selectedIndex + (int)direction), _buttonCount);

		buttons[prevSelected].SetHighlighted(false);
		buttons[_selectedIndex].SetHighlighted(true);
	}

	public void OnSelect(InputAction.CallbackContext context)
	{
		if (!context.started || !combatController.isPlayersTurn) return;

		combatController.OnPlayerAction(buttons[_selectedIndex].Title);
	}

	private static int Mod(int x, int y)
	{
		return (Math.Abs(x * y) + x) % y;
	}
}
