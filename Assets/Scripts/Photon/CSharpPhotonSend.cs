using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XLua;
using MyGameCommon;
using ExitGames.Client.Photon;
using Networks;
using LitJson;
namespace Assets.Scripts.Photon
{
    [Hotfix]
    public class CSharpPhotonSend
    {
        private static HjNetworkBase m_HjNetworkBase = null;

        /// <summary>
        /// 连接服务器成功
        /// </summary>
        public static void ConnectSuccess()
        {
            m_HjNetworkBase = new HjNetworkBase();
            PhotonEngine.Instance.SendRequest(OperationCode.GetServer, new Dictionary<byte, object>());
        }

        public static void SendNetMsgToLua(OperationResponse operationResponse)
        {               
            Dictionary<byte, object> parameters = operationResponse.Parameters;
            object jsonObject = null;
            parameters.TryGetValue((byte)ParameterCode.ServerList, out jsonObject);
            List<MyGameCommon.Model.ServerProperty> serverList =
            JsonMapper.ToObject<List<MyGameCommon.Model.ServerProperty>>(jsonObject.ToString());
            
            m_HjNetworkBase.ReciveMsg(operationResponse);
            //if (ReceivePkgHandle != null)
            //{
            //    ReceivePkgHandle(operationResponse.OperationCode, args);
            //}
        }
    }
}
