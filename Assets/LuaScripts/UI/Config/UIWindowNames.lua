--[[
-- added by wsh @ 2017-11-30
-- UI窗口名字定义，手动添加
--]]

local UIWindowNames = {
	-- 登陆模块
	UILogin = "UILogin",
	UILoginServer = "UILoginServer",
	-- 场景加载模块
	UILoading = "UILoading",
	-- Tip窗口
	UINoticeTip = "UINoticeTip",
	-- 角色选择
	UITestMain = "UITestMain",
	-- BattleMain
	UIBattleMain = "UIBattleMain",
	--游戏主
	UIMain = "UIMain",
}

return ConstClass("UIWindowNames", UIWindowNames)