using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UIEngine;

public class StartMenuController : MonoBehaviour {

    public Button UserBtn = null;
    public Text userText = null;
    public Button ServerBtn = null;
    public Button EnterBtn = null;

    public Button LoginCloseBtn = null;
    public Button RegisterBtn = null;
    public Button LoginBtn = null;
    public Text userNameInput = null;
    public Text passwordInput = null ;

    public Button RegisterCloseBtn = null;

    public GameObject StartUI = null;
    public GameObject LoginUI = null;
    public GameObject RegisterUI = null;
    public GameObject ServerListUI = null;

    public static ServerItemController sp;
    public GameObject serverItem = null;
    public GameObject UIGrid = null;
    public static string userName = "";
    public static string password = "";

    private bool m_haveInitServerList = false;
    public GameObject serverSelectGo = null;
    void Start()
    {
        UITools.AddClick(UserBtn, UserBtnClick);
        UITools.AddClick(ServerBtn, ServerBtnClick);
        UITools.AddClick(EnterBtn, EnterBtnClick);
        UITools.AddClick(LoginCloseBtn, LoginCloseBtnClick);
        UITools.AddClick(RegisterBtn, RegisterBtnClick);
        UITools.AddClick(LoginBtn, LoginBtnClick);
        UITools.AddClick(RegisterCloseBtn, RegisterCloseBtnClick);
       
    }

    private void UserBtnClick()
    {
        StartUI.gameObject.SetActive(false);
        LoginUI.gameObject.SetActive(true);

    }
    private void ServerBtnClick()
    {
        StartUI.gameObject.SetActive(false);
        ServerListUI.gameObject.SetActive(true);
        InitServerList();

    }
    private void EnterBtnClick()
    {

    }
    private void RegisterBtnClick()
    {
        LoginUI.gameObject.SetActive(false);
        RegisterUI.gameObject.SetActive(true);

        
    }
    private void LoginBtnClick()
    {
        //得到用户名和密码
        userName = userNameInput.text.ToString();
        password = passwordInput.text.ToString();
        //返回开始界面
        StartUI.gameObject.SetActive(true);
        LoginUI.gameObject.SetActive(false);
        userText.text = userName;
    }
    private void LoginCloseBtnClick()
    {
        LoginUI.gameObject.SetActive(false);
        StartUI.gameObject.SetActive(true);
    }
    private void RegisterCloseBtnClick()
    {
        RegisterUI.gameObject.SetActive(false);
        LoginUI.gameObject.SetActive(true);
    }

    private void InitServerList()
    {
        if (m_haveInitServerList == true)
            return;
        for (int i = 0; i < 20; i++)
        {
            string ip = "127.0.0.1:9080";
            string name = (i + 1) + "杭州";
            int count = Random.Range(0, 100);
            GameObject go = null;
            go = GameObject.Instantiate(serverItem);
            if (count > 50) {           
                go.transform.SetParent(UIGrid.transform);
            }
            else {
                go.transform.SetParent(UIGrid.transform);
            }
            ServerItemController sp = go.GetComponent<ServerItemController>();
            sp.ip = ip;
            sp.name = name;
            sp.count = count;
        }

        m_haveInitServerList = true;
    }

    public void OnServerSelect(GameObject serverGo)
    {
        sp = serverGo.GetComponent<ServerItemController>();
        
    }
}
