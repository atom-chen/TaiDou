--[[
-- added by wsh @ 2017-12-01
-- UITestMainModel模型层
--]]

local UIMainModel = BaseClass("UIMainModel", UIBaseModel)
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


UIMainModel.OnCreate = OnCreate
UIMainModel.OnEnable = OnEnable
UIMainModel.OnRefresh = OnRefresh
UIMainModel.OnDisable = OnDisable
UIMainModel.OnDistroy = OnDistroy

return UIMainModel