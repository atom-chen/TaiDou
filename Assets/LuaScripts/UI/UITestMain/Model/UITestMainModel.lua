--[[
-- added by wsh @ 2017-12-01
-- UITestMainModel模型层
--]]

local UITestMainModel = BaseClass("UITestMainModel", UIBaseModel)
local base = UIBaseModel

-- 创建
local function OnCreate(self)
	base.OnCreate(self)
	-- 窗口生命周期内保持的成员变量放这
end

-- 打开
local function OnEnable(self)
	base.OnEnable(self)
	
	self:OnRefresh()
end

local function OnRefresh(self)
	
end
-- 关闭
local function OnDisable(self)
	base.OnDisable(self)
	-- 清理成员变量
	
end
-- 销毁
local function OnDistroy(self)
	base.OnDistroy(self)
	-- 清理成员变量
end
--从服务器获取角色信息
function UITestMainModel:GetRoleNameList( ... )
    local roleInfoList = {}
    for i=1,3 do
        local name = "文清" .. i
        local roleId = i
        local level = i + 10
        local sex = 0
        if i%2 == 0 then
            sex = 1
        end
        local roleInfo = 
        {
            name = name,
            roleId = roleId,
            level = level,
            sex = sex
        }
        roleInfoList[#roleInfoList + 1] = roleInfo
    end
    return roleInfoList
end

UITestMainModel.OnCreate = OnCreate
UITestMainModel.OnEnable = OnEnable
UITestMainModel.OnRefresh = OnRefresh
UITestMainModel.OnDisable = OnDisable
UITestMainModel.OnDistroy = OnDistroy

return UITestMainModel