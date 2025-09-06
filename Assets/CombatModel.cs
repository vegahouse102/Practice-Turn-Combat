using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.TextCore.Text;

public class CombatModel
{
	private List<CharacterModel> _mPlayers;
	private List<CharacterModel> _mEnemies;
	public event Action<CharacterModel> OnTurnPlayer;
	public event Action<CharacterModel, CharacterModel,SkillModel> OnTurnEnemy;
	public event Action OnPlayerWin;
	public event Action OnEnemyWin;

	public CombatModel(List<CharacterModel> players, List<CharacterModel> enemise)
	{
		this._mPlayers = players;
		this._mEnemies = enemise;
	}

	public void Turn()
	{
		if(_mPlayers.Where(v => v.Health>0).Count() == 0)
		{
			OnEnemyWin();
			return;
		}
		if (_mEnemies.Where(v => v.Health > 0).Count() == 0)
		{
			OnPlayerWin();
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
		List<CharacterModel> characters = _mPlayers;
		characters.AddRange(_mEnemies);
		characters.Sort((a,b)=>a.CurBehaviour.CompareTo(b.CurBehaviour));

		return characters;
	}

	private CharacterModel SelectPlayer()
	{
		return _mPlayers.Where(v => v.Health > 0).First();
	}

	private SkillModel SelectSkill(CharacterModel model)
	{
		int idx = UnityEngine.Random.Range(0, model.Skills.Count);
		return model.Skills[idx];
	}
}