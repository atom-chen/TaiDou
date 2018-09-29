using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XLua;
using MyGameCommon;
namespace Assets.Scripts.Photon
{
    [LuaCallCSharp]
    public class LuaPhotonSend
    {
        public void SendRequest(OperationCode opCode, byte[] msgObj)
        {
            var sb = new System.Text.StringBuilder();
            for (int i = 0; i < msgObj.Length; i++)
            {
                sb.AppendFormat("{0}\t", msgObj[i]);
            }
            Logger.Log("HjTcpNetwork send bytes : " + sb.ToString());
            //PhotonEngine.Instance.SendRequest(opCode , parameters);
        }
    }
}
