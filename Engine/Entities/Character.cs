using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Interfaces;
using Engine.Sets;

namespace Engine.Entities
{
    /// <summary>
    /// Game character entity.
    /// </summary>
    public class Character : IDamageable
    {
        /// <summary>
        /// Character stat set.
        /// </summary>
        public CharacterStatSet Stats { get; set; }

        /// <summary>
        /// Gets a value indicating if the character is alive or not.
        /// </summary>
        public bool IsAlive => Stats.CurrentHealth > 0;

        /// <summary>
        /// Instantiates an instance of character class with the provided values.
        /// </summary>
        /// <param name="hp">Max health value.</param>
        /// <param name="lvl">Initial level value.</param>
        public Character(int hp, int lvl)
        {
            Stats = new CharacterStatSet();

            Stats.MaxHealth = hp;
            Stats.CurrentHealth = Stats.MaxHealth;
            Stats.Level = lvl;
        }

        /// <summary>
        /// Default instantiator for character class.
        /// </summary>
        /// <returns>A new default character with 1000 hp and level 1.</returns>
        public static Character CreateDefaultCharacter()
        {
            return new Character(1000, 1);
        }

        /// <summary>
        /// Attacks a damageable target.
        /// </summary>
        /// <param name="target">Target to attack.</param>
        public void Attack(IDamageable target)
        {
            target.ReceiveDamage(Stats.AttackSkill);
        }

        /// <summary>
        /// Heals a damageable target.
        /// </summary>
        /// <param name="target">Target to heal.</param>
        public void Heal(IDamageable target)
        {
            target.HealDamage(Stats.HealSkill);
        }

        /// <inheritdoc />
        public void ReceiveDamage(int dmg)
        {
            Stats.CurrentHealth -= dmg;

            if (Stats.CurrentHealth <= 0)
            {
                Stats.CurrentHealth = 0;
            }
        }

        /// <inheritdoc />
        public void HealDamage(int healAmount)
        {
            if (IsAlive)
            {
                Stats.CurrentHealth += healAmount;

                if (Stats.CurrentHealth > Stats.MaxHealth)
                {
                    Stats.CurrentHealth = Stats.MaxHealth;
                }
            }
        }
    }
}
