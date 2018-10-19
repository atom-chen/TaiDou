--[[
-- added by wsh @ 2017-01-09
-- 大厅网络连接器
--]]

local HallConnector = BaseClass("HallConnector", Singleton)
--local SendMsgDefine = require "Net.Config.SendMsgDefine"
--local NetUtil = require "Net.Util.NetUtil"

local ConnStatus = {
	Init = 0,
	Connecting = 1,
	WaitLogin = 2,
	Done = 3,
}

local function __init(self)
	self.hallSocket = nil
	self.globalSeq = 0
end

-- local function OnReceivePackage(self , receive_bytes)
-- 	--local receive_msg = NetUtil.DeserializeMessage(receive_bytes)
-- 	Logger.Log("------------------->>lua收到消息"  .. receive_msg.OperationCode)
-- end


function OnReceivePackage(receive_bytes )
	--local receive_msg = NetUtil.DeserializeMessage(receive_bytes)
	print("------------------->>>>>lua收到消息" .. receive_bytes.Length )
end

-- local function Connect(self, host_ip, host_port, on_connect, on_close)
-- 	if not self.hallSocket then
-- 		self.hallSocket = CS.Networks.HjTcpNetwork()
-- 		self.hallSocket.ReceivePkgHandle = Bind(self, OnReceivePackage)
-- 	end
-- 	self.hallSocket.OnConnect = on_connect
-- 	self.hallSocket.OnClosed = on_close
-- 	self.hallSocket:SetHostPort(host_ip, host_port)
-- 	self.hallSocket:Connect()
-- 	Logger.Log("Connect to "..host_ip..", port : "..host_port)
-- 	return self.hallSocket
-- end

local function Connect(self)
	if not self.hallSocket then
		self.hallSocket = CS.Networks.HjTcpNetwork()		
	end
	self.hallSocket:Connect()
	return self.hallSocket
end

local function SendMessage(self, msg_id, msg_obj, show_mask, need_resend)
	show_mask = show_mask == nil and true or show_mask
	need_resend = need_resend == nil and true or need_resend
	
	local request_seq = 0
	local send_msg = SendMsgDefine.New(msg_id, msg_obj, request_seq)
	local msg_bytes = NetUtil.SerializeMessage(send_msg, self.globalSeq)
	Logger.Log("--------------客户端发送消息" .. msg_id .. "*****" .. tostring(send_msg))
	luaPhotonSend = CS.Assets.Scripts.Photon.LuaPhotonSend()
	luaPhotonSend:SendRequest(0 , msg_bytes)
	--self.hallSocket:SendMessage(msg_bytes)
	self.globalSeq = self.globalSeq + 1
end

local function Update(self)
	if self.hallSocket then
		self.hallSocket:UpdateNetwork()
	end
end

local function Disconnect(self)
	if self.hallSocket then
		self.hallSocket:Disconnect()
	end
end

local function Dispose(self)
	if self.hallSocket then
		self.hallSocket:Dispose()
	end
	self.hallSocket = nil
end

HallConnector.__init = __init
HallConnector.Connect = Connect
HallConnector.SendMessage = SendMessage
HallConnector.Update = Update
HallConnector.Disconnect = Disconnect
HallConnector.Dispose = Dispose
HallConnector.OnReceivePackage = OnReceivePackage
return HallConnector
