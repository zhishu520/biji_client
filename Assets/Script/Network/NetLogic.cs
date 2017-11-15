using UnityEngine;

public class NetLogic {
	public static void RequestNet(eProtocalCommand cmd ,object obj)
	{
		ByteStreamBuff _tmpbuff = new ByteStreamBuff();
		if (obj != null) {
			string json = JsonUtility.ToJson (obj);
			Debug.Log (json);
			_tmpbuff.Write_String (json);
		} else {
			_tmpbuff.Write_String ("{}");
		}
			
		SocketManager.Instance.SendMsg(cmd, _tmpbuff);
	}
}
