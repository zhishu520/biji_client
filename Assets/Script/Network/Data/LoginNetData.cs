using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class NetError{
	public System.UInt32 errCode;
}
	
[Serializable]
public class LoginReq{
	public string account;
	public string passwd;
}

[Serializable]
public class LoginRes{
	public string ip;
	public string port;
	public string token;
}

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


