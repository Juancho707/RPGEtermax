namespace Engine.Interfaces
{
    /// <summary>
    /// Damageable entity
    /// Handles eveything related to health, damage and recovery.
    /// </summary>
    public interface IDamageable
    {
        /// <summary>
        /// Implementation for receiving damage.
        /// </summary>
        /// <param name="dmg">Amount of damage received.</param>
        void ReceiveDamage(int dmg);

        /// <summary>
        /// Implementation for healing damage.
        /// </summary>
        /// <param name="healAmount">Amount of damage healed.</param>
        void HealDamage(int healAmount);
    }
}
