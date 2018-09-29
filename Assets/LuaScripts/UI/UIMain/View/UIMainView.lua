--[[-- added by wsh @ 2018-02-26
-- UITestMain视图层
--]]
local UIMainView = BaseClass("UIMainView", UIBaseView)
local base = UIBaseView

-- 各个组件路径 
--进入游戏


local function OnCreate(self)
	base.OnCreate(self)
	-- 初始化各个组件
end
local function OnEnable(self)
	base.OnEnable(self)
end
local function OnDestroy(self)
	base.OnDestroy(self)
end

UIMainView.OnCreate = OnCreate
UIMainView.OnEnable = OnEnable
UIMainView.OnDestroy = OnDestroy

return UIMainView 