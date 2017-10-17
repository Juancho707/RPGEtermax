namespace Engine.Sets
{
    /// <summary>
    /// Stat set for game characters.
    /// </summary>
    public class CharacterStatSet : BasicStatSet
    {
        /// <summary>
        /// Character level.
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Character attack skill.
        /// </summary>
        public int AttackSkill { get; set; }

        /// <summary>
        /// Character heal skill.
        /// </summary>
        public int HealSkill { get; set; }

        /// <summary>
        /// Character fighting type.
        /// </summary>
        public AttackType AttackType { get; set; }

        /// <summary>
        /// Gets the character attack range based on its class.
        /// </summary>
        public int AttackRange
        {
            get
            {
                switch (AttackType)
                {
                    case AttackType.Melee:
                        return 2;
                    case AttackType.Ranged:
                        return 20;

                }
                return 2;
            }
        }
    }
}
