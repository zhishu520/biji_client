using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class LoginManager : MonoBehaviour {

    public String account;
	public String password;
    public Transform canvas;
	// Use this for initialization
	void Start () {
		RegeditControl ();
		SocketManager.Instance.Connect (GameConst.IP, GameConst.Port);
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void RegeditControl()
    {
		canvas.Find("registerButton").GetComponent<Button>().onClick.AddListener(OnRegister);
		canvas.Find("loginButton").GetComponent<Button>().onClick.AddListener(OnLogin);
    }

    public void OnAccountEditEnd(String account)
    {
        this.account = account;
    }

	public void OnPasswordEditEnd(String password)
	{
		this.password = password;
	}

    private void OnLogin()
    {
        LoginReq req = new LoginReq();
        req.account = account;
        req.passwd = password;
        // LoginNetLogic.Login(req);
		NetLogic.RequestNet (eProtocalCommand.LOGIN_CMD, req);
    }

    private void OnRegister()
    {
        RegisterReq req = new RegisterReq();
        req.account = account;
        req.passwd = password;
		NetLogic.RequestNet(eProtocalCommand.REGISTER_CMD, req);
    }

    void OnApplicationQuit()
    {
        SocketManager.Instance.Close();
    }

	void Login_NetCall(byte[] data)
	{
		NetError err;
		LoginRes res;
		NetDataUtility.GetObjByNetData<LoginRes>(data,out err,out res);

		LoginData.Instance.hallIp = res.ip;
		LoginData.Instance.hallPort = res.port;
		LoginData.Instance.token = res.token;
		LoginData.Instance.account = account;

		SocketManager.Instance.Close ();
		SceneManager.LoadScene (1);
	}

	void Register_NetCall(byte[] data)
	{
		NetError err;
		RegisterRes res;
		NetDataUtility.GetObjByNetData<RegisterRes>(data,out err,out res);

		LoginData.Instance.hallIp = res.ip;
		LoginData.Instance.hallPort = res.port;
		LoginData.Instance.token = res.token;
		LoginData.Instance.account = account;

		SocketManager.Instance.Close ();
		SceneManager.LoadScene (1);
	}


    void OnEnable()
    {
		MessageCenter.Instance.addObsever(eProtocalCommand.LOGIN_CMD, Login_NetCall );
		MessageCenter.Instance.addObsever(eProtocalCommand.REGISTER_CMD, Register_NetCall);
    }

    void OnDisable()
    {
        //MessageCenter.Instance.RemoveEventListener(eGameLogicEventType.NoticeInfo, CallBack_PoseEvent);
		MessageCenter.Instance.removeObserver(eProtocalCommand.LOGIN_CMD, Login_NetCall);
		MessageCenter.Instance.addObsever(eProtocalCommand.REGISTER_CMD, Register_NetCall);
    }
}
