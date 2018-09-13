using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ServerItemController : MonoBehaviour {

    public Text serverName = null;
    public string ip = "127.0.0.1:9080";
    private string m_name = "1区 郑州";
    public string Name
    {
        set {
            serverName.text = value;
        }
        get {
            return m_name;
        }
       
    }
    public int count = 100;

    public void OnPress(bool isPress)
    {
        if (isPress == false) {
            //选择当前的服务器
            transform.root.SendMessage("OnServerSelect", this.gameObject);
        }
    }
}
