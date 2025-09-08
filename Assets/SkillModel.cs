public class SkillModel
{
	public SkillStatSO SkillStat { get; }

	public SkillModel(SkillStatSO mSkillStat)
	{
		SkillStat = mSkillStat;
	}

	public void Attack(CharacterModel attackerModel, CharacterModel targetModel)
	{
		if (CanAttackSkill(attackerModel))
		{
			attackerModel.SpendPartyStack(SkillStat.SpendStack);
			targetModel.GetDamaged(SkillStat.Damage);
		}
	}
	public bool CanAttackSkill(CharacterModel attackerModel)
	{
		int num;
		if (attackerModel.TryGetPartyStack(out num))
		{
			if (num < SkillStat.NeedStack)
			{
				return false;
			}
			return true;
		}
		return true;
	}
}