
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
	private List<CharacterPresenter> _mPlayers;
	private List<CharacterPresenter> _mEnemies;
	public void Init(List<CharacterPresenter> players, List<CharacterPresenter> enemies)
	{
		_mCharacters = new();
		_mCharacters.AddRange(players);
		_mCharacters.AddRange(enemies);

		_mPlayers = players;
		_mEnemies = enemies;

		foreach(var enemy in enemies)
		{
			enemy.FlipX(true);
		}
		foreach(var character in _mCharacters)
		{
			foreach(var skill in character.SkillPresenters)
			{
				skill.OnSkillAnimationFinish += OnAttackFinished;
			}
		}

		{
			_mCombatModel = new CombatModel(
			players.Select(v => v.Model).ToList()
			, enemies.Select(v => v.Model).ToList());
			_mCombatModel.OnTurnPlayer += OnPlayerTurn;
			_mCombatModel.OnTurnEnemy += OnEnemyTurn;
			_mCombatModel.OnPlayerWin += PlayerWin;
			_mCombatModel.OnEnemyWin += PlayerDefeat;
		}

		{
			_mView.Inisialize(_mCharacters.Count,_mCharacters.Select(v=>v.Model).ToList());
			_mCombatModel.OnExecuteTurn += () => _mView.UpdatePriorityList (_mCombatModel.GetCurPriority().ToList());
		}

		_mCombatModel.Turn();
	}
	private  void OnEnemyTurn(CharacterModel enemy, CharacterModel target,SkillModel skill)
	{
		CharacterPresenter enemyPresenter = FindCharacterPresencter(enemy);
		CharacterPresenter playerPresenter = FindCharacterPresencter(target);
		SkillPresenter skillPresenter = FindSkillPresencter(enemyPresenter, skill);
		skillPresenter.Attack(enemyPresenter, playerPresenter);
	}
	private void OnPlayerTurn(CharacterModel player)
	{
		CharacterPresenter playerPresenter = FindCharacterPresencter(player);
		CharacterPresenter enemy = _mEnemies.Where(v => v.Model.Health > 0).FirstOrDefault();
		//SkillModel skill = player.Skills.Where(v => v.CanAttackSkill(player)).FirstOrDefault();
		SkillModel skill;

		//±Ã¾µ¼ö ÀÖÀ¸¸é ±Ã¾²±â
		if (player.Skills[1].CanAttackSkill(player))
		{
			skill = player.Skills[1];
		}
		else
		{
			skill = player.Skills[2];
		}
		SkillPresenter skillPresenter = FindSkillPresencter(playerPresenter, skill);
		skillPresenter.Attack(playerPresenter, enemy);
	}

	private void OnAttackFinished()
	{
		_mCombatModel.Turn();
	}
	private void PlayerWin()
	{
		Debug.Log("playerwin");
	}
	private void PlayerDefeat()
	{
		Debug.Log("playerdefeat");
	}
}

partial class CombatPresenter
{
	private CharacterPresenter FindCharacterPresencter(CharacterModel character)
	{
		return _mCharacters.Where(v => v.Model == character).FirstOrDefault();
	}
	private SkillPresenter FindSkillPresencter(CharacterPresenter character, SkillModel skill)
	{ 
		return character.SkillPresenters .Where(v => v.SkillModel == skill).First();
	}
}

