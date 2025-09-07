using System.Collections.Generic;
using System;
using UnityEngine;

public partial class CharacterModel
{
	private CharacterStatSO _mStatSO;

	public int Health { get; private set; }
	public int Defence { get; private set; }

	public List<SkillModel> Skills { get; private set; }
	public event Func<int> OnRequestPartyStack;
	public event Action<int> OnSpendPartyStack;
	public event Action<int> OnDemaged;
	public event Action OnDied;
	public CharacterModel(CharacterStatSO statSO,List<SkillModel> skills)
	{
		_mStatSO = statSO;
		Health = statSO.MaxHealth;
		Defence = statSO.BaseDefence;
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
		OnDemaged?.Invoke(damage);
	}

	public void Attack(CharacterModel target,SkillModel model)
	{
		if (OnRequestPartyStack!=null)
		{
			int partyStack = OnRequestPartyStack();
			if(partyStack < model.SkillStat.NeedStack)
			{
				return;
			}
		}
		OnSpendPartyStack?.Invoke(model.SkillStat.SpendStack);
		target.GetDamaged(model.SkillStat.Damage);
	}
	public bool TryGetPartyStack(out int num)
	{
		num = 0;
		if (OnRequestPartyStack == null)
			return false;
		num = OnRequestPartyStack.Invoke();
		return true;
	}
	public void SpendPartyStack(int num)
	{
		OnSpendPartyStack?.Invoke(-num);
	}
}

partial class CharacterModel
{

	public int CurBehaviour { get; private set; }
	public void StartCombat()
	{
		CurBehaviour = GetBaseBehaviour();
	}
	public void AddBehaviour()
	{
		CurBehaviour += GetBaseBehaviour();
	}
	public string GetName()
	{
		return _mStatSO.Name;
	}
	private int GetBaseBehaviour()
	{
		if (_mStatSO.BaseSpeed == 0)
			return 0;
		return 10000 / _mStatSO.BaseSpeed;
	}


}