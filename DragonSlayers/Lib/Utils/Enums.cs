namespace DragonSlayers.Lib
{
    public enum EGender
    {
        Male, Female
    }
    
    public enum ERecruitType
    {
        Wizard, Warrior, Archer, MenAtArms
    }

    public enum EArtifactType
    {
        MagicSword, MagicArrows, MagicStaff, MagicPotion, MagicArmour, MagicScrolls
    }

    public enum ECardAction
    {
        None, Attack, Block, Regenerate, DiscardToDraw, EnemyDrawsLess, AttackAnyHero
    }

    public enum EAttackType
    {
        None, Sword, Arrow, Spell, Mouth, Wings, Tail, Limbs
    }

    public enum EBlockType
    {
        None, Dragon, Sword, Arrow, Spell, SpellSword, SpellArrow, SwordArrow, Warrior, Archer, Wizard, ManAtArms, WarriorManAtArms, ArcherWizard
    }
}
