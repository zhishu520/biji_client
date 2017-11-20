using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour {

	public CardGroup cardGroup;
	public Text roomIdLabel;
	public Transform preparePanel;
	// Use this for initialization
	void Start () {
		// if(HallNetDataManager.userInfo.account == 
		if (RoomNetDataManager.roomInfo != null) {
			roomIdLabel.text = RoomNetDataManager.roomInfo.id.ToString ();
			UpdateMember ();
		}

		preparePanel.Find("startButton").GetComponent<Button>().onClick.AddListener(OnDealCard);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Notify_NetCall(byte[] data)
	{
		NetError err;
		RoomInfo res;
		NetDataUtility.GetObjByNetData<RoomInfo>(data,out err,out res);
		RoomNetDataManager.roomInfo = res;

		UpdateMember();
	}


	void OnDealCard()
	{
		NetLogic.RequestNet(eProtocalCommand.GAME_DEAL_CARD, null);
	}

	void DealCardNetCall(byte[] data)
	{
		NetError err;
		DealCard res;
		NetDataUtility.GetObjByNetData<DealCard>(data,out err,out res);

		cardGroup.gameObject.SetActive(true);
		preparePanel.gameObject.SetActive (false);
		cardGroup.InitByCardIds (res.cards);
	}


	void UpdateMember()
	{
		var myStatuObj = preparePanel.Find ("myStatu").gameObject;
		myStatuObj.SetActive (false);

		GameObject[] otherStatuObjs = {
			preparePanel.Find ("statu1").gameObject,
			preparePanel.Find ("statu2").gameObject,
			preparePanel.Find ("statu3").gameObject,
			preparePanel.Find ("statu4").gameObject,
		};

		foreach (var i in otherStatuObjs)
			i.SetActive (false);


		int cnt = 0;
		foreach (var i in RoomNetDataManager.roomInfo.playerList) {
			if (i.account == HallNetDataManager.userInfo.account) {
				myStatuObj.SetActive (true);
			} else {
				otherStatuObjs [cnt].SetActive (true);
				cnt++;
			}
		}
	}

	void UpdateStateText()
	{

	}
		

	void OnEnable()
	{
		MessageCenter.Instance.addObsever(eProtocalCommand.ROOM_ENTER_NOTIFY_CMD, Notify_NetCall);
		MessageCenter.Instance.addObsever(eProtocalCommand.GAME_DEAL_CARD, DealCardNetCall);
	}

	void OnDisable()
	{
		MessageCenter.Instance.removeObserver(eProtocalCommand.ROOM_ENTER_NOTIFY_CMD, Notify_NetCall);
		MessageCenter.Instance.removeObserver(eProtocalCommand.GAME_DEAL_CARD, DealCardNetCall);
	}
}
