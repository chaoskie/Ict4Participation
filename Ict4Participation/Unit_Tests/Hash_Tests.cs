using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Class_Layer;

namespace Unit_Tests
{
    [TestClass]
    public class Hash_Tests
    {
        [TestMethod]
        public void Test_Hashing()
        {
            string SendThis = "WachtwoordHash";
            string Hashed = PasswordHashing.CreateHash(SendThis);
            Assert.AreNotEqual(SendThis, Hashed, string.Format("Raw wachtwoord ({0}) is gelijk aan Hashedwachtwoord ({1})", SendThis, Hashed));

            SendThis = string.Empty;
            Hashed = PasswordHashing.CreateHash(SendThis);
            Assert.AreNotEqual(SendThis, Hashed, string.Format("Raw wachtwoord ({0}) is gelijk aan Hashedwachtwoord ({1})", SendThis, Hashed));
        }

        [TestMethod]
        public void Hashing_Uniek()
        {
            string SendThis = "WachtwoordHash";
            string Hashed_A = PasswordHashing.CreateHash(SendThis);
            string Hashed_B = PasswordHashing.CreateHash(SendThis);

            Assert.AreNotEqual(Hashed_A, Hashed_B, string.Format("Gehashed wachtenwoorden met identieke start ({0}) zijn gelijk.", SendThis));
        }

        [TestMethod]
        public void Login_Hash()
        {
            string SendThis = "WachtwoordHash";
            string RegisterPass = PasswordHashing.CreateHash(SendThis);
            Assert.IsTrue(PasswordHashing.ValidatePassword(SendThis, RegisterPass), "Login simulatie was niet succesvol.");
        }
    }
}
