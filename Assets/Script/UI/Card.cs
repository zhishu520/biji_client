using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class CardSpriteManager
{
	private Dictionary<string, Sprite> spriteDict = new Dictionary<string, Sprite> ();
	static private CardSpriteManager instance;

	static public CardSpriteManager Instance {
		get {
			if (instance == null) {
				instance = new CardSpriteManager ();
				instance.init ();
			}
			return instance;
		}
	}

	private void init ()
	{
		Sprite[] allCardSprite = Resources.LoadAll<Sprite> ("Texture/game_pai_ch1");
		foreach (Sprite sprite in allCardSprite) {
			spriteDict.Add (sprite.name, sprite);
		} 
	}

	public Sprite getCardSprite (string name)
	{
		Debug.Log (name);
		return spriteDict [name];
	}
}

public class Card : MonoBehaviour
{

	public SpriteRenderer bgSprite;
	public SpriteRenderer numSprite;
	public SpriteRenderer suitSprite;

	void Start ()
	{
		orgPosition = this.transform.position;
	}
	
	void Update ()
	{
		
	}

	bool isUpState = false;
	Vector3 orgPosition;
	bool isTouch = false;

	public void setTouchState(bool isTouch)
	{
		this.isTouch = isTouch;
		bool isUp = isTouch ? !isUpState : isUpState;
		this.transform.position = isUp ? orgPosition + new Vector3(0.0f, 0.2f, 0.0f) : orgPosition;
	}

	public void onTouchEnd()
	{
		if (isTouch)
			isUpState = !isUpState;
	}

	public void changeUpDownState ()
	{
		
	}

	public bool IsContainTouchPosition (Vector2 position)
	{
		Bounds bounds = bgSprite.bounds;
		bounds.center = this.transform.position;

		Vector3 convert = new Vector3 (position.x, position.y, bgSprite.transform.position.z);
		return bounds.Contains (convert);
	}

	public void SetCard (int value)
	{
		int suit = (value & 0xf00) >> 8;
		int num = value & 0x0ff;

		suitSprite.sprite = CardSpriteManager.Instance.getCardSprite ("suit" + suit);
		string numSpriteName = suit % 2 == 1 ? "cardb" + num : "cardr" + num;
		numSprite.sprite = CardSpriteManager.Instance.getCardSprite (numSpriteName);
	}
}
