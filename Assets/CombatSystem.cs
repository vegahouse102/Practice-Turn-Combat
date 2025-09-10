using System.Collections.Generic;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{

	public List<CharacterPresenter> combatPresenters = new List<CharacterPresenter>();

	[SerializeField]
	private List<CharacterPresenter> players = new();
	[SerializeField]
	private List<CharacterPresenter> enemies = new();
	void Start()
	{
		CombatPresenter presenter = GetComponent<CombatPresenter>();
		presenter.Init(players,enemies);
	}
}
