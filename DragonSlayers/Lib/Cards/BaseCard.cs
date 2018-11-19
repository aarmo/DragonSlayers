namespace DragonSlayers.Lib.Cards
{
    public class BaseCard
    {
        public string Name { get; set; }
        public string Notes { get; set; }
        public EAttackType AttackType { get; set; }
        public EBlockType BlockType { get; set; }
        public ECardAction CardAction { get; set; }
        public int Amount { get; set; }

        public BaseCard(string name, string notes)
        {
            Name = name;
            Notes = notes;
            AttackType = EAttackType.None;
            BlockType = EBlockType.None;
            CardAction = ECardAction.None;

            SetupCard(notes);
        }

        private void SetupCard(string notes)
        {
            if (notes == "Mouth Attack")
            {
                AttackType = EAttackType.Mouth;
                CardAction = ECardAction.Attack;
            }
            if (notes == "Limbs Attack")
            {
                AttackType = EAttackType.Limbs;
                CardAction = ECardAction.Attack;
            }
            if (notes == "Wings Attack")
            {
                AttackType = EAttackType.Wings;
                CardAction = ECardAction.Attack;
            }
            if (notes == "Tail Attack")
            {
                AttackType = EAttackType.Tail;
                CardAction = ECardAction.Attack;
            }
            if (notes.Contains("Regenerate") || notes.Contains("Return"))
            {
                Amount = 1;
                CardAction = ECardAction.Regenerate;
            }
            if (notes.StartsWith("Discard"))
            {
                Amount = 3;
                CardAction = ECardAction.DiscardToDraw;
            }
            if (notes.Contains("draws 2 less"))
            {
                Amount = 2;
                CardAction = ECardAction.EnemyDrawsLess;
            }
            if (notes.Contains("attack any Hero"))
            {
                CardAction = ECardAction.AttackAnyHero;
            }
            if (notes.StartsWith("Sword Attack"))
            {
                AttackType = EAttackType.Sword;
                CardAction = ECardAction.Attack;
            }
            if (notes.StartsWith("Arrow Attack"))
            {
                AttackType = EAttackType.Arrow;
                CardAction = ECardAction.Attack;
            }
            if (notes.StartsWith("Spell Attack"))
            {
                AttackType = EAttackType.Spell;
                CardAction = ECardAction.Attack;
            }
            if (notes.Contains("1 point"))
            {
                Amount = 1;
            }
            if (notes.Contains("2 points"))
            {
                Amount = 2;
            }
            if (notes.StartsWith("Negate"))
            {
                CardAction = ECardAction.Block;

                if (notes.Contains("Spell Attack"))
                {
                    BlockType = EBlockType.Spell;
                }
                if (notes.Contains("Arrow Attack"))
                {
                    BlockType = EBlockType.Arrow;
                }
                if (notes.Contains("Sword Attack"))
                {
                    BlockType = EBlockType.Sword;
                }
                if (notes.Contains("Spell or Sword Attack"))
                {
                    BlockType = EBlockType.SpellSword;
                }
                if (notes.Contains("Spell or Arrow Attack"))
                {
                    BlockType = EBlockType.SpellArrow;
                }
                if (notes.Contains("Sword or Arrow Attack"))
                {
                    BlockType = EBlockType.SwordArrow;
                }
                if (notes.Contains("Dragon"))
                {
                    BlockType = EBlockType.Dragon;
                }
                if (notes.Contains("Warrior or Man"))
                {
                    BlockType = EBlockType.WarriorManAtArms;
                }
                if (notes.Contains("Wizard or Archer"))
                {
                    BlockType = EBlockType.ArcherWizard;
                }
                if (notes.Contains("Wizard"))
                {
                    BlockType = EBlockType.Wizard;
                }
                if (notes.Contains("Archer"))
                {
                    BlockType = EBlockType.Archer;
                }
                if (notes.Contains("Warrior"))
                {
                    BlockType = EBlockType.Warrior;
                }
                if (notes.Contains("Man"))
                {
                    BlockType = EBlockType.ManAtArms;
                }
            }
        }
    }
}
