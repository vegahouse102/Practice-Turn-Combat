using System.Collections.Generic;
using System;
using UnityEngine;

public partial class CharacterModel
{
	private CharacterStatSO statSO;

	public int Health { get; private set; }
	public int Defence { get; private set; }

	public int BaseBehaviour { get; private set; }

	public List<SkillModel> Skills { get; private set; }

	public event Action OnDied;
	public CharacterModel(CharacterStatSO statSO,List<SkillModel> skills)
	{
		Health = statSO.MaxHealth;
		Defence = statSO.BaseDefence;
		BaseBehaviour = 10000/statSO.BaseSpeed;
		Skills = skills;
	}


	public void GetDamaged(int damage)
	{
		damage = UnityEngine.Mathf.Clamp(damage - Defence, 0, damage);
		Health = UnityEngine.Mathf.Clamp(Health - damage, 0, Health);
		if (Health == 0)
		{
			OnDied?.Invoke();
		}
	}

	
}

partial class CharacterModel
{

	public int CurBehaviour { get; private set; }
	public void StartCombat()
	{
		CurBehaviour = BaseBehaviour;
	}
	public void AddBehaviour()
	{
		CurBehaviour += BaseBehaviour;
	}
}