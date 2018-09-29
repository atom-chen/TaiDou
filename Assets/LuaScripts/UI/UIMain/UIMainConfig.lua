--[[
-- added by wsh @ 2018-02-26
-- UITestMain模块窗口配置，要使用还需要导出到UI.Config.UIConfig.lua
--]]

-- 窗口配置
local UIMain = {
	Name = UIWindowNames.UIMain,
	Layer = UILayers.BackgroudLayer,
	Model = require "UI.UIMain.Model.UIMainModel",
	Ctrl = require "UI.UIMain.Controller.UIMainCtrl",
	View = require "UI.UIMain.View.UIMainView",
	PrefabPath = "UI/Prefabs/View/UIMain.prefab",
}

return {
	-- 配置
	UIMain = UIMain,
}