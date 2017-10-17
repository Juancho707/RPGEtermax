using System;
using Engine.Interfaces;
using Engine.Sets;

namespace Engine.Entities
{
    /// <summary>
    /// Game character entity.
    /// </summary>
    public class Character : GameEntity, IDamageable
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
        public Character(int hp, int lvl, AttackType atkClass)
        {
            Stats = new CharacterStatSet();

            Stats.AttackType = atkClass;
            Stats.MaxHealth = hp;
            Stats.CurrentHealth = Stats.MaxHealth;
            Stats.Level = lvl;
        }

        /// <summary>
        /// Attacks a damageable target.
        /// </summary>
        /// <param name="target">Target to attack.</param>
        public void Attack(IDamageable target)
        {
            if (target != this)
            {
                var totalDamage = Stats.AttackSkill;
                var entity = target as GameEntity;

                if (entity != null && GetDistanceToEntity(entity) <= this.Stats.AttackRange)
                {
                    var enemy = target as Character;

                    if (enemy != null)
                    {
                        if (enemy.Stats.Level >= this.Stats.Level + Settings.LevelDisparityThreshold)
                        {
                            totalDamage -= (Settings.LevelDisparityDamageModifier * totalDamage) / 100;
                        }
                        else if (enemy.Stats.Level + Settings.LevelDisparityThreshold <= this.Stats.Level)
                        {
                            totalDamage += (Settings.LevelDisparityDamageModifier * totalDamage) / 100;
                        }
                    }

                    target.ReceiveDamage(totalDamage);
                }
            }
        }

        /// <summary>
        /// Heals a damageable target.
        /// </summary>
        /// <param name="target">Target to heal.</param>
        public void Heal(IDamageable target)
        {
            if (target == this)
            {
                target.HealDamage(Stats.HealSkill);
            }
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

        public int GetDistanceToEntity(GameEntity target)
        {
            return Math.Abs(this.Position - target.Position);
        }

        /// <summary>
        /// Default instantiator for character class.
        /// </summary>
        /// <returns>A new default character with 1000 hp and level 1.</returns>
        public static Character CreateDefaultCharacter()
        {
            return new Character(1000, 1, AttackType.Melee);
        }

        /// <summary>
        /// Default instantiator for a melee character.
        /// </summary>
        /// <param name="pos">Character position.</param>
        /// <returns>A new melee character.</returns>
        public static Character CreateDefaultMeleeCharacter(int pos)
        {
            var ch = new Character(1000, 1, AttackType.Melee);
            ch.Position = pos;
            return ch;
        }

        /// <summary>
        /// Default instantiator for a ranged character.
        /// </summary>
        /// <param name="pos">Character position.</param>
        /// <returns>A new ranged character.</returns>
        public static Character CreateDefaultRangedCharacter(int pos)
        {
            var ch = new Character(1000, 1, AttackType.Ranged);
            ch.Position = pos;
            return ch;
        }
    }
}
