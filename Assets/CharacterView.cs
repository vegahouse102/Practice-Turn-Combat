using UnityEngine;

public class CharacterView : MonoBehaviour
{

	[SerializeField]
	Animator animator;
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
}