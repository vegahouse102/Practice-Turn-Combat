using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CombatModel
{
	private List<CharacterModel> _mPlayers;
	private List<CharacterModel> _mEnemies;
	public event Action<CharacterModel> OnTurnPlayer;
	public event Action<CharacterModel, CharacterModel,SkillModel> OnTurnEnemy;
	public event Action OnPlayerWin;
	public event Action OnEnemyWin;
	public event Action OnExecuteTurn;

	public int PartyStatck { get; private set; }
	public CombatModel(List<CharacterModel> players, List<CharacterModel> enemise)
	{
		this._mPlayers = players;
		this._mEnemies = enemise;

		foreach(var player in players)
		{
			player.StartCombat();
			player.OnRequestPartyStack += GetPartyStack;
			player.OnSpendPartyStack += SpendPartyStack;
		}
		foreach(var enemy in enemise)
		{
			enemy.StartCombat();
		}

	}

	public void Turn()
	{
		OnExecuteTurn?.Invoke();
		if(_mPlayers.Where(v => v.Health>0).Count() == 0)
		{
			OnEnemyWin?.Invoke();
			return;
		}
		if (_mEnemies.Where(v => v.Health > 0).Count() == 0)
		{
			OnPlayerWin?.Invoke();
			return;
		}
		IEnumerable<CharacterModel> priority = GetCurPriority();
		CharacterModel model = priority.First();
		model.AddBehaviour();
		if(_mPlayers.Contains(model))
		{
			OnTurnPlayer?.Invoke(model);
		}
		else
		{

			OnTurnEnemy?.Invoke(
				model
				, SelectPlayer()
				,SelectSkill(model));
		}
	}


	public IEnumerable<CharacterModel> GetCurPriority()
	{
		List<CharacterModel> characters = new List<CharacterModel>();
		characters.AddRange(_mPlayers);
		characters.AddRange(_mEnemies);
		characters.Sort((a,b)=>a.CurBehaviour.CompareTo(b.CurBehaviour));
		return characters.Where(v => v.Health>0);
	}
	private int GetPartyStack()
	{
		return PartyStatck;
	}
	private void SpendPartyStack(int num)
	{
		Debug.Log($"--------------Spend {num}");
		PartyStatck -= num;
	}
	private CharacterModel SelectPlayer()
	{
		return _mPlayers.Where(v => v.Health > 0).First();
	}

	private SkillModel SelectSkill(CharacterModel model)
	{
		List<SkillModel> skill = model.Skills.Where(v=> v.CanAttackSkill(model)).ToList();
		int length = skill.Count;
		int idx = UnityEngine.Random.Range(0, length);
		return model.Skills[idx];
	}
}