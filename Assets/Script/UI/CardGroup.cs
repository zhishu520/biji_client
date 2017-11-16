using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGroup : MonoBehaviour {

	public static int GroupCardsNum = 9;

	private Card[] cardViews = new Card[GroupCardsNum];

	Vector3 touchStartPosition;


	void Start () {
		int[] cards = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
		InitByCardIds (cards);
	}


	void SelectCard() {

	}


	bool isLastMouseDown = false;
	int touchStartIndex = 0;

	public Camera mainCamera;
	int getCardIndexByTouchPosition(Vector3 pos) {
		var wpos = mainCamera.ScreenToWorldPoint (pos);
		for (int i = GroupCardsNum-1; i >=0 ; i-- ){
			if (cardViews[i].IsContainTouchPosition(wpos)) {
				return i;
			}
		}
		return -1;
	}

	void CheckTouchCard() {
		var touch = Input.GetTouch (0);
		if (touch.phase == TouchPhase.Began) {
			touchStartPosition = touch.position;
			touchStartIndex = getCardIndexByTouchPosition (touchStartPosition);
		}

		int index = getCardIndexByTouchPosition(touch.position);
		if (index == -1)
			return;

		int a = Mathf.Min (touchStartIndex, index);
		int b = Mathf.Max (touchStartIndex, index);

		for (int i = 0; i < GroupCardsNum; i++)
			cardViews [i].setTouchState (i>=a && i<=b);

		isLastMouseDown = true;
	}

	void CheckMouseCard()
	{
		if (!isLastMouseDown) {
			touchStartPosition = Input.mousePosition;
			touchStartIndex = getCardIndexByTouchPosition (touchStartPosition);
		}

		int index = getCardIndexByTouchPosition(Input.mousePosition);
		if (index == -1)
			return;

		int a = Mathf.Min (touchStartIndex, index);
		int b = Mathf.Max (touchStartIndex, index);

		for (int i = 0; i < GroupCardsNum; i++)
			cardViews [i].setTouchState (i>=a && i<=b);

		isLastMouseDown = true;
	}


	void Update () {
		if (Input.touchCount > 0) {
			CheckTouchCard ();
		}

		if(Input.GetMouseButton(0))
			CheckMouseCard ();

		if (Input.GetMouseButtonUp (0)) {
			isLastMouseDown = false;
			for (int i = 0; i < GroupCardsNum; i++)
				cardViews [i].onTouchEnd ();
		}
	}

	public void InitByCardIds(int[] cards)
	{
		if (cards.Length != GroupCardsNum)
			return;

		var cardPrefab = (GameObject)Resources.Load ("Prefab/card");

		for (int i = 0; i < GroupCardsNum; i++) {
			var obj = (GameObject)Instantiate (cardPrefab);
			obj.transform.parent = this.transform;
			obj.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);

			float x = 5.675f + (i-4)* 0.5f  ; 
			obj.transform.position = new Vector3 (x,1.35f,-i* 0.5f);

			var card = obj.GetComponent<Card> ();
			card.SetCard (cards[i]);
			cardViews[i] = card;
		}
	}


}
