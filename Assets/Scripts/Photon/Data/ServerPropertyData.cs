using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;
namespace Assets.Scripts.Photon.Data
{
    [ProtoContract]
    public class ServerPropertyData
    {
        [ProtoMember(1)]
        public int ID = 0;
        [ProtoMember(2)]
        public string IP = "";
        [ProtoMember(3)]
        public string Name = "";
        [ProtoMember(4)]
        public int Count = 0;
    }
}
