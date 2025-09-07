using DG.Tweening;
using System;
using UnityEngine;

public class SkillPresenter : MonoBehaviour
{
	public SkillModel SkillModel { get; private set; }

	[SerializeField]
	private SkillStatSO _mSkillStat;

	[SerializeField]
	private SkillView _mView;
	public SkillView SkillView { get { return _mView; } }



	private void Start()
	{
		SkillModel = new SkillModel(_mSkillStat);
	}
	public void Attack(CharacterPresenter attacker, CharacterPresenter target)
	{
		SkillView.AnimateAttack(attacker.View, target.View)
			.AppendCallback(() => SkillModel.Attack(attacker.Model,target.Model));
	}
}