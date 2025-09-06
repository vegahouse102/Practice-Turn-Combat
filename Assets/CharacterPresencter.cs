using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterPresencter : MonoBehaviour
{
	[SerializeField]
	private CharacterView _mView;

	[SerializeField]
	private CharacterModel _mModel;


	[SerializeField]
	private CharacterStatSO _mStat;


	[SerializeField]
	private List<SkillPresenter> _mSkillPresenters;
	public CharacterModel Model { get { return _mModel; } }

	public List<SkillPresenter> SkillPresenters { get { return _mSkillPresenters; } }



	private void Start()
	{
		_mModel = new CharacterModel(_mStat,_mSkillPresenters.Select(v=>v.SkillModel).ToList());
	}
	public void Attack(CharacterPresencter target,SkillPresenter skill)
	{
		skill.Attack(this, target);
	}
}