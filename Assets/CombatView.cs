using System.Collections.Generic;
using UnityEngine;

public class CombatView : MonoBehaviour
{
	[SerializeField]
	private PlayerPriroityListView listView;
	public void Inisialize(int cnt,List<CharacterModel> list)
	{
		listView.Initialize(cnt,list);
	}
	public void UpdatePriorityList(List<CharacterModel> list)
	{
		listView.SetPriroity(list);
	}
}
