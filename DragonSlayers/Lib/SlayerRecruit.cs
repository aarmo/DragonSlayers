using System;
using DragonSlayers.Lib.Cards;
using DragonSlayers.Lib.Names;

namespace DragonSlayers.Lib
{
    public class SlayerRecruit
    {
        public ERecruitType Type { get; set; }
        public string Name { get; set; }

        public static SlayerRecruit Wizard()
        {
            var g = (Dice.HalfChance() ? EGender.Male : EGender.Female);
            var n = (Dice.HalfChance() ? Tiefling.Generate(g) : Human.Generate(g));

            return new SlayerRecruit
            {
                Name = n,
                Type = ERecruitType.Wizard
            };
        }

        public static SlayerRecruit Warrior()
        {
            var g = (Dice.HalfChance() ? EGender.Male : EGender.Female);
            var n = (Dice.HalfChance() ? Dwarf.Generate(g) : Human.Generate(g));

            return new SlayerRecruit
            {
                Name = n,
                Type = ERecruitType.Warrior
            };
        }

        public static SlayerRecruit Archer()
        {
            var g = (Dice.HalfChance() ? EGender.Male : EGender.Female);
            var n = (Dice.HalfChance() ? Elf.Generate(g) : Human.Generate(g));

            return new SlayerRecruit
            {
                Name = n,
                Type = ERecruitType.Warrior
            };
        }
        
        public static SlayerRecruit MenAtArms()
        {
            var g = (Dice.HalfChance() ? EGender.Male : EGender.Female);
            var n = (Dice.HalfChance() ? Gnome.Generate(g) : Halfling.Generate(g));

            return new SlayerRecruit
            {
                Name = n,
                Type = ERecruitType.MenAtArms
            };
        }

        public bool CanAttackWith(BaseCard card)
        {
            if (card.CardAction != ECardAction.Attack) return false;

            if (card.AttackType == EAttackType.Arrow && Type == ERecruitType.Archer) return true;
            if (card.AttackType == EAttackType.Spell && Type == ERecruitType.Wizard) return true;
            if (card.AttackType == EAttackType.Sword && (Type == ERecruitType.MenAtArms || Type == ERecruitType.Warrior)) return true;

            return false;
        }
    }

    public enum ERecruitType
    {
        Wizard, Warrior, Archer, MenAtArms
    }
    public enum EArtifactType
    {
        MagicSword, MagicArrows, MagicStaff, MagicPotion, MagicArmour, MagicScrolls
    }
}
