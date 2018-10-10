using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XLua;
using MyGameCommon;
using ExitGames.Client.Photon;
namespace Assets.Scripts.Photon
{
    [Hotfix]
    public class CSharpPhotonSend
    {
        private static LuaEnv luaenv = null;
        public static Action<byte , string[]> ReceivePkgHandle = null;
        /// <summary>
        /// 连接服务器成功
        /// </summary>
        public static void ConnectSuccess()
        {
            
            PhotonEngine.Instance.SendRequest(OperationCode.GetServer, new Dictionary<byte, object>());
        }

        public static void SendNetMsgToLua(OperationResponse operationResponse)
        {
            Logger.Log("Receive a response . OperationCode :" + operationResponse.OperationCode);
            string[] args = { "1" , "2"};
            if (ReceivePkgHandle != null)
            {
                ReceivePkgHandle(operationResponse.OperationCode, args);
            }
        }

        [CSharpCallLua]
        public static List<Type> CSharpCallLua = new List<Type>()
        {
            typeof(Action<byte, string[]>),          
        };
    }
}
