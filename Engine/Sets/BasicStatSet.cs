using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Sets
{
    /// <summary>
    /// Basic stat set for entities.
    /// </summary>
    public class BasicStatSet
    {
        /// <summary>
        /// Maximum health value.
        /// </summary>
        public int MaxHealth { get; set; }

        /// <summary>
        /// Current health value.
        /// </summary>
        public int CurrentHealth { get; set; }
    }
}
