using System.Collections.Generic;

namespace DragonSlayers.Lib
{
    public class SlayerArtifact
    {
        public EArtifactType Type { get; set; }

        public List<ERecruitType> UsableBy { get; set; }

        public int UseCount { get; set; }

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
