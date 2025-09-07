using System;
using UnityEngine;
[CreateAssetMenu(fileName = "CharacterStatSO", menuName = "ScriptableObject/CharacterStatSO", order = int.MaxValue)]
public class CharacterStatSO : ScriptableObject
{
	[SerializeField]
	private string _mName;
	public string Name { get { return _mName; } }

	[SerializeField]
	private int _mMaxHealth;
	public int MaxHealth { get {return _mMaxHealth; } }

	[SerializeField]

	private int _mDefence;
	public int BaseDefence { get { return _mDefence; } }

	[SerializeField]
	private int _mSpeed;
	public int BaseSpeed { get { return _mSpeed; } }


}