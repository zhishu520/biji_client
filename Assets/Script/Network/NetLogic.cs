using UnityEngine;

public class NetLogic {
	public static void RequestNet(eProtocalCommand cmd ,object obj)
	{
		ByteStreamBuff _tmpbuff = new ByteStreamBuff();
        string json = JsonUtility.ToJson(obj);
        Debug.Log(json);
		_tmpbuff.Write_String(json);
		SocketManager.Instance.SendMsg(cmd, _tmpbuff);
	}
}
