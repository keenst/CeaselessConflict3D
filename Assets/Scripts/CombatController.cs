using UnityEngine;

public class CombatController : MonoBehaviour
{
	public MenuController menuController;
	public StatusModule playerStatus;
	public StatusModule enemyStatus;

	public bool isPlayersTurn;

	private Fighter _player;
	private Fighter _enemy;

	private int _playerInput;

	public void Start()
	{
		EndBattle();
	}

	// TODO: struct for action
	public void OnPlayerAction(string action)
	{
		isPlayersTurn = false;

		switch (action)
		{
			case "Attack":
				{
					Attack(ref _enemy, 5);
					break;
				}
			case "Run":
				{
					EndBattle();
					break;
				}
		}

		GetEnemyAction();
	}

	public void StartBattle(Fighter player, Fighter enemy)
	{
		_player = player;
		_enemy = enemy;

		menuController.gameObject.SetActive(true);
		playerStatus.gameObject.SetActive(true);
		enemyStatus.gameObject.SetActive(true);

		StartPlayerTurn();
	}

	private void EndBattle()
	{
		menuController.gameObject.SetActive(false);
		playerStatus.gameObject.SetActive(false);
		enemyStatus.gameObject.SetActive(false);
	}

	private void Attack(ref Fighter target, float damage)
	{
		target.HP -= damage;

		playerStatus.SetHP(_player.HP, _player.HPMax);
		enemyStatus.SetHP(_enemy.HP, _enemy.HPMax);

		if (_player.HP <= 0 || _enemy.HP <= 0)
		{
			EndBattle();
		}
	}

	private void StartPlayerTurn()
	{
		string[] buttons =
		{
			"Attack",
			"Run"
		};

		Menu menu = new(buttons);

		menuController.OpenMenu(menu);

		isPlayersTurn = true;
	}

	private void GetEnemyAction()
	{
		Attack(ref _player, 3);

		isPlayersTurn = true;
	}
}
