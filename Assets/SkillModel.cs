public class SkillModel
{
	public SkillStatSO SkillStat { get; }

	public SkillModel(SkillStatSO mSkillStat)
	{
		SkillStat = mSkillStat;
	}

	public void Attack(CharacterModel attackerModel, CharacterModel targetModel)
	{
		int num;
		if (attackerModel.TryGetPartyStack(out num))
		{
			if(num < SkillStat.NeedStack)
			{
				return;
			}
		}
		targetModel.GetDamaged(SkillStat.Damage);
	}
}