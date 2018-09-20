--[[
-- added by wsh @ 2018-02-26
-- UITestMain控制层
--]]

local UITestMainCtrl = BaseClass("UITestMainCtrl", UIBaseCtrl)
--进入游戏
local function StartFighting(self)
	SceneManager:GetInstance():SwitchScene(SceneConfig.BattleScene)
end
--返回登录
local function Logout(self)
	SceneManager:GetInstance():SwitchScene(SceneConfig.LoginScene)
end

UITestMainCtrl.StartFighting = StartFighting
UITestMainCtrl.Logout = Logout

return UITestMainCtrl