using UnityEngine;

public class CharacterView : MonoBehaviour
{

	[SerializeField]
	Animator animator;
	private void Start()
	{
		animator = GetComponent<Animator>();
	}
	public void AnimateView(int animationHash)
	{
		animator.SetTrigger(animationHash);
	}
}