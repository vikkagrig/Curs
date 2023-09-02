using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Приемная_комиссия;
using System.Windows;

namespace UnitTestPС
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //добавление
            Reg reg = new Reg();
            using(var db = new PCEntities1())
            {
                User u = new User()
                {
                    Login = "log1",
                    Password = "pas1",
                    Role = "Абитуриент"
                };
                bool real = reg.AddUser(u);
                Assert.IsTrue(real);
            }
        }
        [TestMethod]
        public void TestMethod2()
        {
            //удаление
            Reg reg = new Reg();
            using (var db = new PCEntities1())
            {
                Entrant u1 = null;
                foreach(var u in db.Entrant)
                {
                    if(u.IDEntrant == 5)
                    {
                        u1 = db.Entrant.Find(u.IDEntrant);
                        break;
                    }
                }
                bool real = reg.DeleteUser(u1);
                Assert.IsTrue(real);
            }
        }
        [TestMethod]
        public void TestMethod3()
        {
            //изменение
            Reg reg = new Reg();
            using (var db = new PCEntities1())
            {
                Entrant u1 = null;
                foreach (var u in db.Entrant)
                {
                    if (u.IDEntrant == 1)
                    {
                        u1 = db.Entrant.Find(u.IDEntrant);
                        break;
                    }
                }
                bool real = reg.UpdateUser(u1);
                Assert.IsTrue(real);
            }
        }
        [TestMethod]
        public void TestMethod4()
        {
            //получение
            Reg reg = new Reg();
            Entrant real = reg.EnterUser(1);
            Assert.IsNotNull(real);
        }
    }
}
