using TMPro;
using UnityEngine;

public class PlayerPrioritySlotView : MonoBehaviour
{
	[SerializeField]
	private  TextMeshProUGUI text;

	public void SetPlayerName(string str)
	{
		text.text = str;
	}
}
