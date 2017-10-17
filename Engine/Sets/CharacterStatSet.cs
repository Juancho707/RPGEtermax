using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
