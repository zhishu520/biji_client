using UnityEngine;
using System.Collections;
using System.Text;
using System;
using UnityEngine.UI;


public class Client : MonoBehaviour {

    public Transform BtnRoot;

    void Start()
    {
        RegeditControl();
		SocketManager.Instance.Connect (GameConst.IP, GameConst.Port);
    }
    

    void OnEnable()
    {
        MessageCenter.Instance.AddEventListener(eGameLogicEventType.NoticeInfo, CallBack_PoseEvent);
		//MessageCenter.Instance.addObsever(eProtocalCommand.LOGIN_CMD, LoginNetLogic.LoginCall);
    }

    void OnDisable()
    {
        MessageCenter.Instance.RemoveEventListener(eGameLogicEventType.NoticeInfo, CallBack_PoseEvent);
		//MessageCenter.Instance.removeObserver(eProtocalCommand.REGISTER_CMD, LoginNetLogic.LoginCall);
    }

    void OnApplicationQuit()
    {
        SocketManager.Instance.Close();
    }

    private void RegeditControl()
    {
		//BtnRoot.Find("registerButton").GetComponent<Button>().onClick.AddListener(LoginNetLogic.Register);
		//BtnRoot.Find("loginButton").GetComponent<Button>().onClick.AddListener(LoginNetLogic.Login);
    }

    private void OnButton_PostEvent()
    {
        string _content = "GameLogicEvent";
        MessageCenter.Instance.PostEvent(eGameLogicEventType.NoticeInfo, _content);
    }
		
    private void CallBack_PoseEvent(object _eventParam)
    {
        string _content = (string)_eventParam;
        Debug.Log(_content);
    }
}
