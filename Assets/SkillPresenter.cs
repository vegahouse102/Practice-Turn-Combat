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
	private void Awake()
	{
		SkillModel = new SkillModel(_mSkillStat);
	}

	private Sequence sequence;

	public event Action OnSkillAnimationFinish;
	public void Attack(CharacterPresenter attacker, CharacterPresenter target)
	{
		if (sequence != null)
		{
			sequence.Complete();
		}
		sequence = DOTween.Sequence();
		if(SkillView == null)
		{
			Debug.Log("skillview null");
		}
		if(attacker == null || target == null)
		{
			Debug.Log("presenter null");
		} 

		sequence.Append(SkillView.AnimateAttack(attacker.View, target.View))
			.AppendCallback(() => SkillModel.Attack(attacker.Model, target.Model))
			.AppendInterval(0.5f)
			.AppendCallback(() => OnSkillAnimationFinish?.Invoke());
	}
}