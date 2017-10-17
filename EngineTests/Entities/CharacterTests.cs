using Engine.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EngineTests.Entities
{
    [TestClass]
    public class CharacterTests
    {
        [TestMethod]
        public void DefaultCharacterInitialization()
        {
            var newCharacter = Character.CreateDefaultCharacter();

            Assert.AreEqual(1000, newCharacter.Stats.CurrentHealth);
            Assert.AreEqual(1, newCharacter.Stats.Level);
        }

        [TestMethod]
        public void CharacterInitialization()
        {
            var newCharacter = new Character(500, 5, 0);

            Assert.AreEqual(500, newCharacter.Stats.CurrentHealth);
            Assert.AreEqual(5, newCharacter.Stats.Level);
        }

        [TestMethod]
        public void AttackOther()
        {
            var char1 = Character.CreateDefaultCharacter();
            char1.Stats.AttackSkill = 300;

            var char2 = Character.CreateDefaultCharacter();
            
            char1.Attack(char2);

            Assert.IsTrue(char2.IsAlive);
            Assert.AreEqual(700, char2.Stats.CurrentHealth);
        }

        [TestMethod]
        public void AttackSelf()
        {
            var char1 = Character.CreateDefaultCharacter();
            char1.Stats.AttackSkill = 300;

            char1.Attack(char1);

            Assert.IsTrue(char1.IsAlive);
            Assert.AreEqual(1000, char1.Stats.CurrentHealth);
        }

        [TestMethod]
        public void HealOther()
        {
            var char1 = Character.CreateDefaultCharacter();
            char1.Stats.HealSkill = 300;

            var char2 = Character.CreateDefaultCharacter();
            char2.ReceiveDamage(500);
            
            char1.Heal(char2);

            Assert.IsTrue(char2.IsAlive);
            Assert.AreEqual(500, char2.Stats.CurrentHealth);
        }

        [TestMethod]
        public void HealSelf()
        {
            var char1 = Character.CreateDefaultCharacter();
            char1.ReceiveDamage(500);
            char1.Stats.HealSkill = 300;

            char1.Heal(char1);

            Assert.IsTrue(char1.IsAlive);
            Assert.AreEqual(800, char1.Stats.CurrentHealth);
        }

        [TestMethod]
        public void Kill()
        {
            var newCharacter = Character.CreateDefaultCharacter();
            newCharacter.ReceiveDamage(1200);

            Assert.IsFalse(newCharacter.IsAlive);
            Assert.AreEqual(0, newCharacter.Stats.CurrentHealth);
        }

        [TestMethod]
        public void HealOverTop()
        {
            var newCharacter = Character.CreateDefaultCharacter();
            newCharacter.ReceiveDamage(300);
            newCharacter.HealDamage(600);

            Assert.AreEqual(newCharacter.Stats.MaxHealth, newCharacter.Stats.CurrentHealth);
        }

        [TestMethod]
        public void AttackHigherLevelEnemy()
        {
            var char1 = Character.CreateDefaultCharacter();
            char1.Stats.AttackSkill = 300;

            var char2 = Character.CreateDefaultCharacter();
            char2.Stats.Level = 8;

            char1.Attack(char2);

            Assert.IsTrue(char2.IsAlive);
            Assert.AreEqual(850, char2.Stats.CurrentHealth);
        }

        [TestMethod]
        public void AttackLowerLevelEnemy()
        {
            var char1 = Character.CreateDefaultCharacter();
            char1.Stats.AttackSkill = 300;
            char1.Stats.Level = 8;

            var char2 = Character.CreateDefaultCharacter();
            
            char1.Attack(char2);

            Assert.IsTrue(char2.IsAlive);
            Assert.AreEqual(550, char2.Stats.CurrentHealth);
        }

        [TestMethod]
        public void AttackRanged()
        {
            var char1 = Character.CreateDefaultRangedCharacter(0);
            char1.Stats.AttackSkill = 300;

            var char2 = Character.CreateDefaultMeleeCharacter(15);
            char2.Stats.AttackSkill = 600;

            char1.Attack(char2);
            char2.Attack(char1);

            Assert.IsTrue(char1.IsAlive);
            Assert.IsTrue(char2.IsAlive);

            Assert.AreEqual(1000, char1.Stats.CurrentHealth);
            Assert.AreEqual(700, char2.Stats.CurrentHealth);
        }

        [TestMethod]
        public void AttackMelee()
        {
            var char1 = Character.CreateDefaultRangedCharacter(0);
            char1.Stats.AttackSkill = 300;

            var char2 = Character.CreateDefaultMeleeCharacter(2);
            char2.Stats.AttackSkill = 600;

            char1.Attack(char2);
            char2.Attack(char1);

            Assert.IsTrue(char1.IsAlive);
            Assert.IsTrue(char2.IsAlive);

            Assert.AreEqual(400, char1.Stats.CurrentHealth);
            Assert.AreEqual(700, char2.Stats.CurrentHealth);
        }
    }
}
