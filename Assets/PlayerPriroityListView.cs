using System.Collections.Generic;
using System.Linq;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class PlayerPriroityListView : MonoBehaviour
{
	[SerializeField]
	private PlayerPrioritySlotView slotViewPrefab;
	private List<PlayerPrioritySlotView> slotList = new List<PlayerPrioritySlotView>();
	public void Initialize(int characterLength, List<CharacterModel> characters)
	{
		for(int i = 0; i < characterLength; i++)
		{
			GameObject slot = Instantiate(slotViewPrefab.gameObject, transform);
			slot.GetComponent<RectTransform>().localPosition = Vector3.zero+Vector3.up*65*i;
			slotList.Add(slot.GetComponent<PlayerPrioritySlotView>());
		}
		SetPriroity(characters);
	}

	public void SetPriroity(List<CharacterModel> characters)
	{
		List<CharacterModel> priorty = characters.Where(v => v.Health > 0).ToList();
		while (slotList.Count > priorty.Count)
		{
			PlayerPrioritySlotView removed = slotList[slotList.Count - 1];
			slotList.Remove(removed);
			Destroy(removed.gameObject);
		}
		for(int i  =0; i <  priorty.Count; i++)
		{
			slotList[i].SetPlayerName(characters[i].GetName());
		}
	}
}
