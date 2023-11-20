using UnityEngine;

public class CombatController : MonoBehaviour
{
	public MenuController menuController;

	private Fighter _player;
	private Fighter _enemy;

	private int _playerInput;
	private bool _isPlayersTurn;

	public void Start()
	{
		Fighter player = new(20, 20);
		Fighter enemy = new(20, 20);

		StartBattle(player, enemy);
	}

	// TODO: struct for action
	public void OnPlayerAction(string action)
	{
		_isPlayersTurn = false;

		switch (action)
		{
			case "Attack":
				{
					Debug.Log("Attack");
					break;
				}
			case "Run":
				{
					Debug.Log("Run");
					break;
				}
		}

	}

	public void StartBattle(Fighter player, Fighter enemy)
	{
		_player = player;
		_enemy = enemy;

		StartPlayerTurn();
	}

	private void StartPlayerTurn()
	{
		string[] buttons =
		{
			"Attack",
			"Run"
		};

		Menu menu = new(buttons);

		menuController.UpdateMenu(menu);

		_isPlayersTurn = true;
	}
}
