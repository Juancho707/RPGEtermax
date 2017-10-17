using Engine.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EngineTests.Entities
{
    [TestClass]
    public class DamageableTests
    {
        [TestMethod]
        public void TestDamage()
        {
            var newCharacter = Character.CreateDefaultCharacter();
            newCharacter.ReceiveDamage(300);

            Assert.AreEqual(700, newCharacter.CurrentHealth);
        }

        [TestMethod]
        public void TestHeal()
        {
            var newCharacter = Character.CreateDefaultCharacter();
            newCharacter.ReceiveDamage(300);
            newCharacter.HealDamage(100);

            Assert.AreEqual(800, newCharacter.CurrentHealth);
        }
    }
}
