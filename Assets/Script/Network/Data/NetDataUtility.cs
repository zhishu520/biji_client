using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetDataUtility {

	public static void GetObjByNetData<T>(byte[] data,out NetError err, out T tData) where T : new() {
		ByteStreamBuff _tmpbuff = new ByteStreamBuff(data);
		string str = _tmpbuff.Read_String ();
		_tmpbuff.Close();
		_tmpbuff = null;

		Debug.Log (str);

		bool isError = str.IndexOf ("err") != -1;
		err = isError ? JsonUtility.FromJson<NetError> (str) : null;
		tData =  isError ? new T() : JsonUtility.FromJson<T>(str);
	}
}
