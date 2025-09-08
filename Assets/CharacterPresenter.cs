using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterPresenter : MonoBehaviour
{
	[SerializeField]
	private CharacterView _mView;

	[SerializeField]
	private CharacterModel _mModel;
	public CharacterModel Model { get { return _mModel; } }

	[SerializeField]
	private CharacterStatSO _mStat;



	[SerializeField]
	private List<SkillPresenter> _mSkillPresenter = new List<SkillPresenter>();

	public List<SkillPresenter> SkillPresenters { get { return _mSkillPresenter; } }

	public CharacterView View { get { return _mView; } }

	private void Awake()
	{
		_mModel = new CharacterModel(_mStat, SkillPresenters.Select(v=>v.SkillModel).ToList());
		_mModel.OnDemaged += (num,max) => _mView.AnimateView(Animator.StringToHash("Hit"));
		_mModel.OnDemaged += (num, max) => _mView.ChangeHealth(num, max);
		_mModel.OnDied += () => _mView.AnimateView(Animator.StringToHash("Die"));
	}


	public void FlipX(bool flag)
	{
		View.FlipX(flag);
	}
}