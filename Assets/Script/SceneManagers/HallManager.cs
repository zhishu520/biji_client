using System.Collections;
using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class HallManager : MonoBehaviour {

	public Transform canvas;
	public Text roomCardLabel;

	private System.UInt32 joinRoomId;

	void Start () {
		RegeditControl ();
		SocketManager.Instance.Connect ("127.0.0.1", 9000);
	}

	void Update () {

	}

	public void OnJoinRoomIdChanged(string str)
	{
		joinRoomId = UInt32.Parse (str);
	}


	private void RegeditControl()
	{
		canvas.Find("joinRoomButton").GetComponent<Button>().onClick.AddListener(OnJoinRoom);
		canvas.Find("createRoomButton").GetComponent<Button>().onClick.AddListener(OnCreateRoom);
	}


	private void OnJoinRoom()
	{
		JoinRoomReq req = new JoinRoomReq  ();
		req.roomId = joinRoomId;
		NetLogic.RequestNet(eProtocalCommand.JOIN_ROOM_CMD, req);
	}

	private void OnCreateRoom()
	{
		CreateRoomReq req = new CreateRoomReq ();
		req.account = HallNetDataManager.userInfo.account;
		req.config = new RoomConfig ();
		req.config.haveSanQing = true;
		req.config.isAA = true;
		req.config.round = 8;
		req.config.times = 1;
		req.config.haveHappyMoney = true;
		NetLogic.RequestNet(eProtocalCommand.CREATE_ROOM_CMD, req);
	}


	void OnApplicationQuit()
	{
		SocketManager.Instance.Close();
	}

	void Login_NetCall(byte[] data)
	{
		NetError err;
		LoginHallRes res;
		NetDataUtility.GetObjByNetData<LoginHallRes>(data,out err,out res);
		HallNetDataManager.userInfo = res.info;
	}

	void OnConnected(object _eventParam)
	{
		LoginHallReq req = new LoginHallReq();
		req.account = LoginData.Instance.account;
		req.token = "token";
		NetLogic.RequestNet(eProtocalCommand.LOGIN_HALL_CMD, req);
	}

	void Join_NetCall(byte[] data)
	{
		NetError err;
		JoinRoomRes res;
		NetDataUtility.GetObjByNetData<JoinRoomRes>(data,out err,out res);
	}

	void Notify_NetCall(byte[] data)
	{
		NetError err;
		RoomInfo res;
		NetDataUtility.GetObjByNetData<RoomInfo>(data,out err,out res);
		RoomNetDataManager.roomInfo = res;

		SceneManager.LoadScene (2);
	}

	void CreateRoom_NetCall(byte[] data)
	{
		NetError err;
		CreateRoomRes res;
		NetDataUtility.GetObjByNetData<CreateRoomRes>(data,out err,out res);
		Debug.Log (res);
	}

	void OnEnable()
	{
		MessageCenter.Instance.AddEventListener(eGameLogicEventType.ConnectServerSuccess, OnConnected);
		MessageCenter.Instance.addObsever(eProtocalCommand.LOGIN_HALL_CMD, Login_NetCall);
		MessageCenter.Instance.addObsever(eProtocalCommand.JOIN_ROOM_CMD, Join_NetCall);
		MessageCenter.Instance.addObsever(eProtocalCommand.CREATE_ROOM_CMD, CreateRoom_NetCall);
		MessageCenter.Instance.addObsever(eProtocalCommand.ROOM_ENTER_NOTIFY_CMD, Notify_NetCall);
	}

	void OnDisable()
	{
		MessageCenter.Instance.RemoveEventListener(eGameLogicEventType.ConnectServerSuccess, OnConnected);
		MessageCenter.Instance.removeObserver(eProtocalCommand.LOGIN_HALL_CMD, Login_NetCall);
		MessageCenter.Instance.removeObserver(eProtocalCommand.CREATE_ROOM_CMD, CreateRoom_NetCall);
		MessageCenter.Instance.removeObserver(eProtocalCommand.JOIN_ROOM_CMD, Join_NetCall);
		MessageCenter.Instance.removeObserver(eProtocalCommand.ROOM_ENTER_NOTIFY_CMD, Notify_NetCall);
	}
}
