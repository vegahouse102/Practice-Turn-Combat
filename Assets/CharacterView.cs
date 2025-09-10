using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class CharacterView : MonoBehaviour
{

	[SerializeField]
	Animator animator;

	[SerializeField]
	Slider slider;
	[SerializeField]
	TextMeshProUGUI _mPlayerName;
	SpriteRenderer spriteRenderer;


	private void Awake()
	{
		animator = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	public void AnimateView(int animationHash)
	{
		animator.SetTrigger(animationHash);
	}
	public void FlipX(bool flag)
	{
		spriteRenderer.flipX = flag;
	}

	public void ChangeHealth(int curHealth,int maxHealth)
	{
		slider.value = curHealth/(float)maxHealth;
	}
	public void SetName(string name)
	{
		_mPlayerName.text = name;
	}
}