using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XLua;
using MyGameCommon;
namespace Assets.Scripts.Photon
{
    [CSharpCallLua]
    public class CSharpPhotonSend
    {
        /// <summary>
        /// 连接服务器成功
        /// </summary>
        public static void ConnectSuccess()
        {
            PhotonEngine.Instance.SendRequest(OperationCode.GetServer, new Dictionary<byte, object>());
        }

        public static void SendNetMsgToLua()
        {

        }

    }
}
