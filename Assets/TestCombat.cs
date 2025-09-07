using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public partial class TestCombat : MonoBehaviour
{
	public List<CharacterPresenter> gameObjects = new List<CharacterPresenter>();
	CombatModel model;
	List<CharacterModel> players = new List<CharacterModel>();
	List<CharacterModel> enemies = new List<CharacterModel>();
	List<CharacterModel> characters = new List<CharacterModel>();
	void Start()
	{
		players.Add(gameObjects[0].Model);
		players.Add(gameObjects[1].Model);
		enemies.Add(gameObjects[2].Model);
		enemies.Add(gameObjects[3].Model);

		characters.AddRange(players);
		characters.AddRange(enemies);

		model = new CombatModel(players,enemies);
		
		model.OnTurnEnemy += OnEnemyTurn;
		model.OnTurnPlayer += OnPlayerTurn;


		Debug.Log(GetPriority());
		model.Turn();
		Debug.Log(GetPriority());
		model.Turn();
		Debug.Log(GetPriority());
		model.Turn();
		Debug.Log(GetPriority());
		model.Turn();
		Debug.Log(GetPriority());
		model.Turn();
	}


	public void OnEnemyTurn(CharacterModel enemy,CharacterModel player,SkillModel skill)
	{
		Debug.Log($"{enemy.GetName()}");
	}

	public void OnPlayerTurn(CharacterModel player)
	{
		Debug.Log($"{player.GetName()}");
	}

	private string GetPriority()
	{
		IEnumerable<int> priorities = characters.Select(v => v.CurBehaviour);
		string result = "";
		foreach(int priority in priorities)
		{
			result += priority.ToString();
			result += ' ';
		}
		return result;
	}
}
