using DG.Tweening;
using UnityEngine;

public class SkillView : MonoBehaviour
{
	private Sequence sequence;

	private int hash = Animator.StringToHash("Attack");
	public Sequence AnimateAttack(CharacterView attackerView, CharacterView tartgetView)
	{
		if (sequence != null)
			sequence.Complete();
		sequence = DOTween.Sequence();
		sequence.AppendCallback(() => attackerView.AnimateView(hash)).AppendInterval(0.5f);
		return sequence;
	}
}
