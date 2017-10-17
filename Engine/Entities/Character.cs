using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Interfaces;

namespace Engine.Entities
{
    /// <summary>
    /// Game character entity.
    /// </summary>
    public class Character : IDamageable
    {
        /// <inheritdoc />
        public int MaxHealth { get; set; }

        /// <inheritdoc />
        public int CurrentHealth { get; set; }

        /// <summary>
        /// Character level.
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if the character is alive or not.
        /// </summary>
        public bool IsAlive { get; set; }

        /// <summary>
        /// Character attack skill.
        /// </summary>
        public int AttackSkill { get; set; }

        /// <summary>
        /// Character heal skill.
        /// </summary>
        public int HealSkill { get; set; }

        /// <summary>
        /// Instantiates an instance of character class with the provided values.
        /// </summary>
        /// <param name="hp">Max health value.</param>
        /// <param name="lvl">Initial level value.</param>
        public Character(int hp, int lvl)
        {
            MaxHealth = hp;
            CurrentHealth = MaxHealth;
            Level = lvl;
            IsAlive = hp > 0;
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
            target.ReceiveDamage(AttackSkill);
        }

        /// <summary>
        /// Heals a damageable target.
        /// </summary>
        /// <param name="target">Target to heal.</param>
        public void Heal(IDamageable target)
        {
            target.HealDamage(HealSkill);
        }

        /// <inheritdoc />
        public void ReceiveDamage(int dmg)
        {
            CurrentHealth -= dmg;

            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                IsAlive = false;
            }
        }

        /// <inheritdoc />
        public void HealDamage(int healAmount)
        {
            if (IsAlive)
            {
                CurrentHealth += healAmount;

                if (CurrentHealth > MaxHealth)
                {
                    CurrentHealth = MaxHealth;
                }
            }
        }
    }
}
