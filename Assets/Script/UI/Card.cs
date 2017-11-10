using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class CardSpriteManager
{
	private Dictionary<string, Sprite> spriteDict = new Dictionary<string, Sprite>();
	static private CardSpriteManager instance;
	static public CardSpriteManager Instance{
		get {
			if (instance == null) {
				instance = new CardSpriteManager ();
				instance.init ();
			}
			return instance;
		}
	}

	private void init() {
		Sprite[] allCardSprite = Resources.LoadAll<Sprite> ("Texture/game_pai_ch1");
		foreach (Sprite sprite in allCardSprite) {
			spriteDict.Add(sprite.name, sprite);
		} 
	}

	public Sprite getCardSprite(string name){
		return spriteDict[name];
	}
}

public class Card : MonoBehaviour {

	public SpriteRenderer bgSprite;
	public SpriteRenderer numSprite;
	public SpriteRenderer suitSprite;


	// Use this for initialization
	void Start () {
		SetCard (2 * 256 + 13);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetCard(int value)
	{
		int suit = 	(value & 0xf00) >> 8;
		int num = 	value & 0x0ff;

		suitSprite.sprite = CardSpriteManager.Instance.getCardSprite("suit" + suit);
		string numSpriteName = suit % 2 == 1 ? "cardb" + num : "cardr" + num;
		numSprite.sprite = CardSpriteManager.Instance.getCardSprite(numSpriteName);
	}
}
