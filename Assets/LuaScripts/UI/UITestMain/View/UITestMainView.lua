--[[-- added by wsh @ 2018-02-26
-- UITestMain视图层
--]]
local UITestMainView = BaseClass("UITestMainView", UIBaseView)
local base = UIBaseView

-- 各个组件路径 
local logout_btn_path = "EnterGame/BtnRoot/LogoutBtn"
local entergame_btn_path = "EnterGame/BtnRoot/EnterGameBtn"

local entergame_tran_path = "EnterGame"
local createrole_tran_path = "CreateRole"
local back_entergame_btn_path = "CreateRole/backBtn"
local createrole_btn_path = "CreateRole/sureBtn"
local model_man_tran_path = "EnterGame/RoleInfo/roleModel/man_stand"
local model_woman_tran_path = "EnterGame/RoleInfo/roleModel/girl_stand"

local ROLE_COUNT = 4 --角色
local role_btn_path_list = {}
local role_text_path_list = {}
for i = 1, ROLE_COUNT do
	local role_btn_path = "EnterGame/ChangeRole/role" .. i
	role_btn_path_list[#role_btn_path_list + 1] = role_btn_path
	local role_text_path = "EnterGame/ChangeRole/role" .. i .. "/Text" .. i
	role_text_path_list[#role_text_path_list + 1] = role_text_path
end


local function OnCreate(self)
	base.OnCreate(self)
	-- 初始化各个组件
	self.enterGame_btn = self:AddComponent(UIButton, entergame_btn_path)
	self.logOut_btn = self:AddComponent(UIButton, logout_btn_path)
	self.backEnterGame_btn = self:AddComponent(UIButton, back_entergame_btn_path)
	self.createRole_btn = self.AddComponent(UIButton, createrole_btn_path)
	
	self.enterGame_tran = self:AddComponent(UIButton, entergame_tran_path)
	self.createRole_tran = self:AddComponent(UIButton, createrole_tran_path)
	self.manRole_tran = self:AddComponent(UIButton , model_man_tran_path)
	self.womanRole_tran = self:AddComponent(UIButton , model_woman_tran_path)

	local selectRole_btn_list = {}
	self.roleName_text_list = {}
	for i = 1, ROLE_COUNT do
		local selectRole_btn = self:AddComponent(UIButton, role_btn_path_list[i])
		selectRole_btn_list[#selectRole_btn_list + 1] = selectRole_btn
		local roleName_text = self:AddComponent(UIText, role_text_path_list[i])
		self.roleName_text_list[#self.roleName_text_list + 1] = roleName_text
	end
	
	for i = 1, ROLE_COUNT do	
		selectRole_btn_list[i]:SetOnClick(function()
			self:ChangeRole(i)
		end)	
	end
	
	self.enterGame_btn:SetOnClick(function()
		self.ctrl:StartFighting()
	end)		
	self.logOut_btn:SetOnClick(function()
		self.ctrl:Logout()
	end)
	self.backEnterGame_btn:SetOnClick(function()
		self:BackEnterGame()
	end)	
	self.createRole_btn:SetOnClick(function()
		self:CreateRole()
	end)
end
local function OnEnable(self)
	base.OnEnable(self)
	self:SetRoleListInfo()
end
local function OnDestroy(self)
	base.OnDestroy(self)
end
--设置角色列表
function UITestMainView:SetRoleListInfo()
	self.roleNameList = self.model:GetRoleNameList()
	for i = 1, #self.roleNameList do
		local roleInfo = self.roleNameList[i]
		local name = roleInfo.name
		print("#####roleName = " .. name)
		self.roleName_text_list[i]:SetText(name)
		--self.roleName_text_list.text = name
	end
end
--更改角色
function UITestMainView:ChangeRole(index)
	local roleInfo = self.roleNameList[index]		
	if not roleInfo then
		self.enterGame_tran:SetActive(false)
		self.createRole_tran:SetActive(true)
		return
	end
	local sex = roleInfo.sex
	if sex == 0 then--女
		self.manRole_tran:SetActive(false)
		self.womanRole_tran:SetActive(true)
	else
		self.manRole_tran:SetActive(true)
		self.womanRole_tran:SetActive(false)
	end
	
end
--返回进入游戏界面
function UITestMainView:BackEnterGame()
	self.enterGame_tran:SetActive(true)
	self.createRole_tran:SetActive(false)
end
--创建角色
function UITestMainView:CreateRole()
	self.enterGame_tran:SetActive(true)
	self.createRole_tran:SetActive(false)
end
UITestMainView.OnCreate = OnCreate
UITestMainView.OnEnable = OnEnable
UITestMainView.OnDestroy = OnDestroy

return UITestMainView 