using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public partial class CombatPresenter : MonoBehaviour
{
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	private CombatModel _mCombatModel;
	[SerializeField]
	private CombatView _mView;
	private List<CharacterPresenter> _mCharacters;
	public void Init(List<CharacterPresenter> players, List<CharacterPresenter> enemies)
	{
		_mCharacters = new();
		_mCharacters.AddRange(players);
		_mCharacters.AddRange(enemies);
			

		foreach(var enemy in enemies)
		{
			enemy.FlipX(true);
		}

		_mCombatModel = new CombatModel(
			players.Select(v => v.Model).ToList()
			, enemies.Select(v => v.Model).ToList());
		_mCombatModel.OnTurnPlayer += OnPlayerTurn;
		_mCombatModel.OnTurnEnemy += OnEnemyTurn;
		_mCombatModel.Turn();
	}
	private  void OnEnemyTurn(CharacterModel enemy, CharacterModel target,SkillModel skill)
	{
		CharacterPresenter enemyPresenter = FindCharacterPresencter(enemy);
		CharacterPresenter playerPresenter = FindCharacterPresencter(target);
		SkillPresenter skillPresenter = FindSkillPresencter(enemyPresenter, skill);
		skillPresenter.Attack(enemyPresenter, playerPresenter);
		skillPresenter.OnSkillAnimationFinish += ()=>_mCombatModel.Turn();

		Debug.Log("enemy");
	}
	private void OnPlayerTurn(CharacterModel player)
	{
		CharacterPresenter playerPresenter = FindCharacterPresencter(player);
		Debug.Log("Player");
		_mCombatModel.Turn();
	}
}

partial class CombatPresenter
{
	private CharacterPresenter FindCharacterPresencter(CharacterModel character)
	{
		return _mCharacters.Where(v => v.Model == character).First();
	}
	private SkillPresenter FindSkillPresencter(CharacterPresenter character, SkillModel skill)
	{ 
		return character.SkillPresenters .Where(v => v.SkillModel == skill).First();
	}
}

