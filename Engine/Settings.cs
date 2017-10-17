using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class Settings
    {
        /// <summary>
        /// The amount of level difference needed to inflict less or more damage.
        /// </summary>
        public static int LevelDisparityThreshold = 5;

        /// <summary>
        /// The percentage of damage that will be deducted or added once the level disparity threshold has been met.
        /// </summary>
        public static int LevelDisparityDamageModifier = 50;
    }
}
