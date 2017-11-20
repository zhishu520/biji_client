using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dun : MonoBehaviour {

	const int DunCardNum = 3;

	public Card card1;
	public Card card2;
	public Card card3;

  public SpriteRenderer bg;
  private int [] _cards;

  bool isTouchedCard(Vector3 worldPos)
  {
    return bg.bounds.Contains(worldPos);
  }

	void SetSlotCard(int[] cards)
	{
		if (this._cards.Length != 0 || cards.Length != DunCardNum)
			return;

        this._cards = cards;

		card1.SetCard (cards[0]);
		card2.SetCard (cards[1]);
		card3.SetCard (cards[2]);

		card1.gameObject.SetActive(true);
		card2.gameObject.SetActive(true);
		card3.gameObject.SetActive(true);
	}

	void DeleteSlotCard()
	{
		card1.gameObject.SetActive(false);
		card2.gameObject.SetActive(false);
		card3.gameObject.SetActive(false);
	}

	void Update()
	{
		Vector3 startPoint;
		if (Input.GetMouseButtonDown (0))
			startPoint = Input.mousePosition;
		if (Input.touchCount > 0)
			startPoint = Input.GetTouch (0).position;
	}
}
