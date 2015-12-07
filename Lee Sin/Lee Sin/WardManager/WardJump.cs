﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;

namespace Lee_Sin.WardManager
{
    class WardJump : LeeSin
    {
        public static void WardJumped(Vector3 position, bool objectuse, bool use = true)
        {
            var objectss =
                ObjectManager.Get<Obj_AI_Base>()
                    .FirstOrDefault(
                        x =>
                            x.IsValid && x.Distance(position) < 200 && x.IsAlly && !x.IsDead &&
                            x.Name.ToLower().Contains("ward"));

            var ward = Items.GetWardSlot();
            if (W.IsReady() && ward != null && Environment.TickCount - _lastwcasted > 1000 && W1() && !use)
            {
                Player.Spellbook.CastSpell(ward.SpellSlot, position);
            }

            if (W.IsReady() && ward != null && W1() && use && Environment.TickCount - wardlastcasted > 400)
            {
                Player.Spellbook.CastSpell(ward.SpellSlot, position);
            }

            var objects =
                ObjectManager.Get<Obj_AI_Base>()
                    .FirstOrDefault(
                        x =>
                            x.IsValid && x.Distance(position) < 200 && x.IsAlly && !x.IsDead &&
                            !x.Name.ToLower().Contains("turret"));
            if (!objectuse) return;
            foreach (
                var wards in
                    ObjectManager.Get<Obj_AI_Base>()
                        .Where(wards => W.IsReady() && Environment.TickCount - wardlastcasted > 400 && W1() && !W2() && (objects != null)))
            {
                W.Cast(objects);
            }
        }
    }
}