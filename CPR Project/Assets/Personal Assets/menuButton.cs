using UnityEngine;
using System.Collections;

public class menuButton : MonoBehaviour {

	public enum ButtonReaction
	{
		StartSimulation,
		Quit
	};

	public Sprite hoverSprite;
	public ButtonReaction buttonReaction;

	private Sprite originalSprite;
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = this.gameObject.GetComponent<SpriteRenderer> ();
		originalSprite = spriteRenderer.sprite;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseEnter () {
		spriteRenderer.sprite = hoverSprite;
	}

	void OnMouseExit () {
		spriteRenderer.sprite = originalSprite;
	}

	void OnMouseDown () {
		int x, y;
		if (buttonReaction == ButtonReaction.StartSimulation)
			Application.LoadLevel (1);
		else if (buttonReaction == ButtonReaction.Quit)
			Application.Quit ();
	}
}
