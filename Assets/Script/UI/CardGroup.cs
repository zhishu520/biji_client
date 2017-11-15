using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGroup : MonoBehaviour {

	public static int GroupCardsNum = 9;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		int[] cards = { 1, 1, 1, 1, 1, 1, 1, 1 ,1 };
		InitByCardIds (cards);
	}

	void InitByCardIds(int[] cards)
	{
		if (cards.Length != GroupCardsNum)
			return;

		var cardPrefab = (GameObject)Resources.Load ("Prefab/card");

		for (int i = 0; i < GroupCardsNum; i++) {
			var card = (GameObject)Instantiate (cardPrefab);
			card.transform.parent = this.transform;
			card.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);

			float x = 5.93f + (4 - i)* 1.0f  ; 
			card.transform.position = new Vector3 (x,1.7f,i* 0.5f);

			card.GetComponent<Card> ().SetCard (cards[i]);
		}
	}


}
