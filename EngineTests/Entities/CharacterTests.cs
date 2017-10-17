using Engine.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EngineTests.Entities
{
    [TestClass]
    public class CharacterTests
    {
        [TestMethod]
        public void TestDefaultCharacterInitialization()
        {
            var newCharacter = Character.CreateDefaultCharacter();

            Assert.AreEqual(1000, newCharacter.CurrentHealth);
            Assert.AreEqual(1, newCharacter.Level);
        }

        [TestMethod]
        public void TestCharacterInitialization()
        {
            var newCharacter = new Character(500, 5);

            Assert.AreEqual(500, newCharacter.CurrentHealth);
            Assert.AreEqual(5, newCharacter.Level);
        }

        [TestMethod]
        public void TestAttack()
        {
            var char1 = Character.CreateDefaultCharacter();
            var char2 = Character.CreateDefaultCharacter();
            char1.AttackSkill = 300;

            char1.Attack(char2);

            Assert.IsTrue(char2.IsAlive);
            Assert.AreEqual(700, char2.CurrentHealth);
        }

        [TestMethod]
        public void TestHeal()
        {
            var char1 = Character.CreateDefaultCharacter();
            var char2 = Character.CreateDefaultCharacter();
            char2.ReceiveDamage(500);
            char1.HealSkill = 300;

            char1.Heal(char2);

            Assert.IsTrue(char2.IsAlive);
            Assert.AreEqual(800, char2.CurrentHealth);
        }

        [TestMethod]
        public void TestKill()
        {
            var newCharacter = Character.CreateDefaultCharacter();
            newCharacter.ReceiveDamage(1200);

            Assert.IsFalse(newCharacter.IsAlive);
            Assert.AreEqual(0, newCharacter.CurrentHealth);
        }

        [TestMethod]
        public void TestHealOverTop()
        {
            var newCharacter = Character.CreateDefaultCharacter();
            newCharacter.ReceiveDamage(300);
            newCharacter.HealDamage(600);

            Assert.AreEqual(newCharacter.MaxHealth, newCharacter.CurrentHealth);
        }
    }
}
