using System;
using FSParam;

namespace Erd_Tools.Models.Params.Defs
{
    /// <summary>
    /// [Erd-Tools fork] Reconstructed param-row wrapper for EquipParamWeapon.
    ///
    /// The original source for this class was not committed to the Erd-Tools submodule at the
    /// pinned commit (it existed only on the author's machine). Only the surface that ErdHook
    /// actually uses is implemented: the constructor from an FSParam row and the <see cref="wepType"/>
    /// discriminator used to categorise weapons.
    ///
    /// The <see cref="WeaponType"/> values are authoritative: they were recovered from the
    /// compiled v0.8.6.2 assembly and cross-checked against Models/Items/Weapon.cs (which carries
    /// the same numeric wepType codes). Member names follow ErdHook's usage (the refactor renamed
    /// a few DLC entries and merged the ammo codes into this enum).
    /// </summary>
    public class EquipParamWeapon
    {
        public WeaponType wepType { get; }

        public EquipParamWeapon(FSParam.Param.Row row)
        {
            wepType = (WeaponType)Convert.ToInt32(row.GetCellHandleOrThrow("wepType").Value);
        }

        public enum WeaponType
        {
            None = 0,
            Dagger = 1,
            StraightSword = 3,
            Greatsword = 5,
            ColossalSword = 7,
            CurvedSword = 9,
            CurvedGreatsword = 11,
            Katana = 13,
            Twinblade = 14,
            ThrustingSword = 15,
            HeavyThrustingSword = 16,
            Axe = 17,
            Greataxe = 19,
            Hammer = 21,
            GreatHammer = 23,
            Flail = 24,
            Spear = 25,
            SpearLarge = 26,
            GreatSpear = 28,
            Halberd = 29,
            Reaper = 31,
            Unarmed = 33,
            Fist = 35,
            Claws = 37,
            Whip = 39,
            ColossalWeapon = 41,
            LightBow = 50,
            Bow = 51,
            Greatbow = 53,
            Crossbow = 55,
            Ballista = 56,
            GlintstoneStaff = 57,
            Sorcery = 58,
            FingerSeal = 61,
            SmallShield = 65,
            MediumShield = 67,
            Greatshield = 69,
            Arrow = 81,
            GreatArrow = 83,
            Bolt = 85,
            BallistaBolt = 86,
            Torch = 87,
            HandToHand = 88,
            PerfumeBottle = 89,
            ThrustingShield = 90,
            ThrowingBlade = 91,
            ReverseHandBlade = 92,
            LightGreatsword = 93,
            GreatKatana = 94,
            BeastClaw = 95,
        }
    }
}
