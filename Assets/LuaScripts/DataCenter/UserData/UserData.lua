--[[
-- added by zl @ 2018-09-24
-- 角色数据
--]]

local RoleData = {
    roleID = 0,             --角色唯一id
    roleName = "",          --角色名字
    roleHeadImage = "",     --角色头像
    roleLevel = 0,          --等级
    roleFighting = 0,       --战斗力
    roleExp = 0,            --经验值
    roleDiamonds = 0,       --钻石
    roleGolds = 0,          --金币

}

local UserData = BaseClass("UserData", Singleton)
local RoleData = DataClass("RoleData", RoleData)

local function __init(self)
	self.servers = {}
end

-- 解析网络数据
local function ParseUserData(self, servers)
	self.servers = {}
	for _,v in pairs(servers) do
		local roleData = RoleData.New()
        roleData.roleID = v.roleID
        roleData.roleName = v.roleName
        roleData.roleHeadImage = v.roleHeadImage
        roleData.roleLevel = v.roleLevel
        roleData.roleFighting = v.roleFighting
        roleData.roleExp = v.roleExp
        roleData.roleDiamonds = v.roleDiamonds
        roleData.roleGolds = v.roleGolds
		self.servers[roleData.roleID] = roleData
	end
	--DataManager:GetInstance():Broadcast(DataMessageNames.ON_SERVER_LIST_CHG, self)
end

UserData.ParseUserData = ParseUserData

return UserData
