using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public partial class TestCombat : MonoBehaviour
{
	public List<CharacterPresenter> gameObjects = new List<CharacterPresenter>();
	CombatModel model;
	List<CharacterModel> players = new List<CharacterModel>();
	List<CharacterModel> enemies = new List<CharacterModel>();
	void Start()
	{
		players.Add(gameObjects[0].Model);
		players.Add(gameObjects[1].Model);
		enemies.Add(gameObjects[2].Model);
		enemies.Add(gameObjects[3].Model);
		model = new CombatModel(players,enemies);
		
		model.OnTurnEnemy += OnEnemyTurn;
		model.OnTurnPlayer += OnPlayerTurn;

		model.Turn();
		model.Turn();
		model.Turn();
		model.Turn();
		model.Turn();
	}


	public void OnEnemyTurn(CharacterModel enemy,CharacterModel player,SkillModel skill)
	{
		Debug.Log($"{enemy.GetName()} {player.GetName()} {skill} \n {model.GetCurPriority().Select(v=>v.CurBehaviour).ToString()}");
	}

	public void OnPlayerTurn(CharacterModel player)
	{
		Debug.Log($"{player.GetName()} \n {model.GetCurPriority().Select(v=>v.CurBehaviour).ToString()}");
	}

}
