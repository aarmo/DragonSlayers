using System.Collections.Generic;

namespace DragonSlayers.Lib.Logic
{
    public class SlayerArtifact
    {
        public EArtifactType Type { get; set; }

        public List<ERecruitType> UsableBy { get; set; }

        public int UseCount { get; set; }
        public SlayerRecruit HeldBy { get; set; }

        /* ARTIFACTS
            Magic Sword	Sword Attacks do +1 Damage
            Magic Arrows	Arrow Attacks do +1 Damage (Can be used 3 times)
            Magic Staff	Spell Attacks do +1 Damage
        */
        public int GetDamageBonus()
        {
            switch (Type)
            {
                case EArtifactType.MagicArrows:
                    if (UseCount > 0) return 1;
                    return 0;
                case EArtifactType.MagicStaff:
                    return 1;
                case EArtifactType.MagicSword:
                    return 1;
                default:
                    return 0;
            }
        }
        /* ARTIFACTS
            Magic Armor	Attacks against Warrior negated on a roll of 1-4 on 1D6 
        */
        public bool DamageReduced()
        {
            switch (Type)
            {
                case EArtifactType.MagicArmour:
                    if (Dice.Roll(1,6) <= 4) return true;
                    return false;
                default:
                    return false;
            }
        }

        public static SlayerArtifact RandomArtifact()
        {
            switch (Dice.Roll(1, 6))
            {
                case 1:
                    return MagicSword();

                case 2:
                    return MagicArrows();

                case 3:
                    return MagicStaff();

                case 4:
                    return MagicPotion();

                case 5:
                    return MagicArmour();

                default:
                    return MagicScrolls();
            }
        }

        public static SlayerArtifact MagicSword()
        {
            return new SlayerArtifact
            {
                Type = EArtifactType.MagicSword,
                UsableBy = new List<ERecruitType>(new[] { ERecruitType.Warrior, ERecruitType.MenAtArms }),
                UseCount = int.MaxValue
            };
        }

        public static SlayerArtifact MagicStaff()
        {
            return new SlayerArtifact
            {
                Type = EArtifactType.MagicStaff,
                UsableBy = new List<ERecruitType>(new[] { ERecruitType.Wizard }),
                UseCount = int.MaxValue
            };
        }

        public static SlayerArtifact MagicArrows()
        {
            return new SlayerArtifact
            {
                Type = EArtifactType.MagicArrows,
                UsableBy = new List<ERecruitType>(new[] { ERecruitType.Archer }),
                UseCount = 3
            };
        }

        public static SlayerArtifact MagicPotion()
        {
            return new SlayerArtifact
            {
                Type = EArtifactType.MagicPotion,
                UsableBy = new List<ERecruitType>(),
                UseCount = 2
            };
        }

        public static SlayerArtifact MagicArmour()
        {
            return new SlayerArtifact
            {
                Type = EArtifactType.MagicArmour,
                UsableBy = new List<ERecruitType>(new[] { ERecruitType.Warrior }),
                UseCount = int.MaxValue
            };
        }
        public static SlayerArtifact MagicScrolls()
        {
            return new SlayerArtifact
            {
                Type = EArtifactType.MagicScrolls,
                UsableBy = new List<ERecruitType>(new[] { ERecruitType.Wizard }),
                UseCount = 3
            };
        }
    }
}
