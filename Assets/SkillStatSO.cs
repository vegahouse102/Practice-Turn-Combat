using UnityEngine;

[CreateAssetMenu(fileName = "SkillStat",menuName = "ScriptableObject/SkillStat")]
public class SkillStatSO : ScriptableObject
{
	[SerializeField]
	private string _mName;
	public string Name { get { return _mName; } }

	[SerializeField]
	private int _mDamage;
	public int Damage { get { return _mDamage; } }

	[SerializeField]
	private int _mNeedStack;
	public int NeedStack {  get { return _mNeedStack; } }

	[SerializeField]
	private int _mSpendStack;
	public int SpendStack {  get { return _mSpendStack; }}

}