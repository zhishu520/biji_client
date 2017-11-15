using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
[Serializable]
public class NetError{
	public System.UInt32 errCode;
}
*/

[Serializable]
public class RoomInfo{
	public System.UInt32 id;
	public System.UInt32 ownerAccount;
	public UserInfo[] playerList;
}


// 发牌
[Serializable]
public class DealCard{
	public int turn;
	public int[] cards;
}

[Serializable]
public class CardSolution{
	public int[] index;
}

[Serializable]
public class ScoreInfo{
	public string account;
	public int score;
}

[Serializable]
public class GameResult{
	ScoreInfo[] infos;
}

public class RoomNetDataManager{
	public static RoomInfo roomInfo;
}
