﻿namespace SelectedTargetOnly{using System;using EloBuddy;using EloBuddy.SDK;using EloBuddy.SDK.Events;using EloBuddy.SDK.Menu;using EloBuddy.SDK.Menu.Values;internal class Program{public static Menu MenuIni;private static void Main(string[] args){Loading.OnLoadingComplete += Loading_OnLoadingComplete;}private static void Loading_OnLoadingComplete(EventArgs args){MenuIni = MainMenu.AddMenu("FocusSelectedTarget", "FocusSelectedTarget");MenuIni.Add("enable", new CheckBox("Attack Selected Target Only"));MenuIni.Add("mode", new ComboBox("Mode", 1, "Always", "Only In Range"));Player.OnIssueOrder += Player_OnIssueOrder;Orbwalker.OnPreAttack += Orbwalker_OnPreAttack;}private static void Orbwalker_OnPreAttack(AttackableUnit orbtarget, Orbwalker.PreAttackArgs args){var target = TargetSelector.SelectedTarget;if (!MenuIni["enable"].Cast<CheckBox>().CurrentValue || MenuIni["mode"].Cast<ComboBox>().CurrentValue != 1 || target == null || args.Target == null || args.Target.NetworkId == target.NetworkId){return;}args.Process = false;}private static void Player_OnIssueOrder(Obj_AI_Base sender, PlayerIssueOrderEventArgs args){var target = TargetSelector.SelectedTarget;if (!MenuIni["enable"].Cast<CheckBox>().CurrentValue || MenuIni["mode"].Cast<ComboBox>().CurrentValue != 0 || target == null || args.Target == null || args.Target.NetworkId == target.NetworkId || !sender.IsMe){return;}args.Process = false;Player.IssueOrder(GameObjectOrder.AttackTo, target);}}}
// Nice Code Kappa