using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;
namespace Assets.Scripts.Photon.Data
{
    [ProtoContract]
    public class ServerProperty
    {
        [ProtoMember(1)]
        public ServerPropertyData[] serverProperty = new ServerPropertyData[0];

    }
}
