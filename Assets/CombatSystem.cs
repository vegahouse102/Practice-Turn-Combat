using System.Collections.Generic;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{

	public List<CharacterPresenter> combatPresenters = new List<CharacterPresenter>();
	void Start()
	{
		CombatPresenter presenter = GetComponent<CombatPresenter>();
		presenter.Init(new List<CharacterPresenter>() { combatPresenters[0], combatPresenters[1] }
		, new List<CharacterPresenter>() { combatPresenters[2], combatPresenters[3] });
	}
}
