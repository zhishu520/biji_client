using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class LoginHallReq{
	public string account;
	public string token;
}

[Serializable]
public class LoginHallRes{
// "info":{"nick_name":"haha1508520989","socre":0,"account":"123"}
	public UserInfo info;
}

[Serializable]
public class UserInfo{
	public string nick_name;
	public int score;
	public string account;
}

[Serializable]
public class LoginLobbyReq{
	public string account;
}

[Serializable]
public class LoginLobbyRes{
	public int roomCard;
}


[Serializable]
public class RoomConfig{
	public int round;
	public bool haveHappyMoney;
	public bool haveSanQing;
	public int times;
	public bool isAA;
}

[Serializable]
public class CreateRoomReq{
	public string account;
	public RoomConfig config;
}

[Serializable]
public class JoinRoomReq{
	public UInt32 roomId;
}


public class CreateRoomRes{
	public int roomId;
}


[Serializable]
public class JoinRoomRes{
	public int result;
}


public class HallNetDataManager{
	public static UserInfo userInfo;
	public static int roomCard;
	public static int enterRoomId;
}





/*
[Serializable]
public class RegisterReq{
	public string account;
	public string passwd;
}

[Serializable]
public class RegisterRes{
	public string ip;
	public string port;
	public string token;
}
*/