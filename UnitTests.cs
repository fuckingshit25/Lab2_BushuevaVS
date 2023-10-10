using NUnit.Framework;
namespace RegisterProject
{
    [TestFixture]
    public class UnitTests
    {
        Register Register = new Register();
        [Test]
        public void CheckRegister_EmptyLogin_ReturnsFalseAndErrorMessage()
        {
            string login = "";
            string password = "Test123!";
            string password2 = "Test123!";
            var result = Register.CheckRegister(login, password, password2);
            Assert.AreEqual(("False", "Пустая строка в качестве логина"), result);
        }//1

        [Test]
        public void CheckRegister_ShortLogin_ReturnsFalseAndErrorMessage()
        {
            string login = "user";
            string password = "Test123!";
            string password2 = "Test123!";
            var result = Register.CheckRegister(login, password, password2);
            Assert.AreEqual(("False", "Длина логина меньше 5 символов"), result);
        }//2

        [Test]
        public void CheckRegister_ExistingLogin_ReturnsFalseAndErrorMessage()
        {
            string login = "user11";
            string password = "Test123!";
            string password2 = "Test123!";
            var result = Register.CheckRegister(login, password, password2);
            Assert.AreEqual(("False", "Пользователь с таким логином уже зарегистрирован"), result);
        }//3

        [Test]
        public void CheckRegister_InvalidPhoneLogin_ReturnsFalseAndErrorMessage()
        {
            string login = "+1234567890";
            string password = "Test123!";
            string password2 = "Test123!";
            var result = Register.CheckRegister(login, password, password2);
            Assert.AreEqual(("False", "Номер телефона не удовлетворяет заданному формату +x-xxx-xxx-xxxx"), result);
        }//4
        public void CheckRegister_ValidData_ReturnsTrue()
        {
            string login = "user123";
            string password = "Password123!";
            string password2 = "Password123!";
            var result = Register.CheckRegister(login, password, password2);
            Assert.AreEqual("True", result.Item1);
            Assert.AreEqual("", result.Item2);
        }//5
        public void CheckRegister_NotValidPass_1()
        {
            string login = "user123";
            string password = "Password123";
            string password2 = "Password123";
            var result = Register.CheckRegister(login, password, password2);
            Assert.AreEqual("False", result.Item1);
            Assert.AreEqual("В пароле отсутствует минимум один специальный символ", result.Item2);
        }//6
        public void CheckRegister_NotValidPass_2()
        {
            string login = "user123";
            string password = "Password";
            string password2 = "Password";
            var result = Register.CheckRegister(login, password, password2);
            Assert.AreEqual("False", result.Item1);
            Assert.AreEqual("В пароле отсутствует минимум одна цифра", result.Item2);
        }//7
        public void CheckRegister_NotValidPass_3()
        {
            string login = "user123";
            string password = "password";
            string password2 = "password";
            var result = Register.CheckRegister(login, password, password2);
            Assert.AreEqual("False", result.Item1);
            Assert.AreEqual("В пароле отсутствует минимум одна заглавная буква", result.Item2);
        }//8
        public void CheckRegister_NotValidPass_4()
        {
            string login = "user123";
            string password = "PPPPPPP";
            string password2 = "PPPPPPP";
            var result = Register.CheckRegister(login, password, password2);
            Assert.AreEqual("False", result.Item1);
            Assert.AreEqual("В пароле отсутствует минимум одна строчная буква", result.Item2);
        }//9
        public void CheckRegister_NotValidPass_5()
        {
            string login = "user123";
            string password = "Password猫";
            string password2 = "Password猫";
            var result = Register.CheckRegister(login, password, password2);
            Assert.AreEqual("False", result.Item1);
            Assert.AreEqual("В пароле присутствуют недопустимые символы", result.Item2);
        }//10
        public void CheckRegister_NotValidPasswordEquality()
        {
            string login = "user123";
            string password = "Password123!";
            string password2 = "Password1234!";
            var result = Register.CheckRegister(login, password, password2);
            Assert.AreEqual("True", result.Item1);
            Assert.AreEqual("Заданные пароли не совпадают", result.Item2);
        }//11
        public void CheckRegister_NotValidPasswordLength()
        {
            string login = "user123";
            string password = "Pass1!";
            string password2 = "Pass1!";
            var result = Register.CheckRegister(login, password, password2);
            Assert.AreEqual("False", result.Item1);
            Assert.AreEqual("Длина пароля меньше 7 символов", result.Item2);
        }//12
        [Test]
        public void CheckRegister_InvalidEmailLogin_ReturnsFalseAndErrorMessage()
        {
            string login = "user@example";
            string password = "Test123!";
            string password2 = "Test123!";
            var result = Register.CheckRegister(login, password, password2);
            Assert.AreEqual("False", result.Item1);
            Assert.AreEqual("Email не удовлетворяет общему формату xxx@xxx.xxx", result.Item2);
        }//13

        [Test]
        public void CheckRegister_InvalidSymbolInLogin()
        {
            string login = "user猫test123";
            string password = "Test123!";
            string password2 = "Test123!";
            var result = Register.CheckRegister(login, password, password2);
            Assert.AreEqual(("False", "Логин содержит символы, отличные от латиницы, цифр и знака подчеркивания"), result);
        }//14

        [Test]
        public void CheckRegister_EmptyPassword_ReturnsFalseAndErrorMessage()
        {
            string login = "testuser";
            string password = "";
            string password2 = "";
            var result = Register.CheckRegister(login, password, password2);
            Assert.AreEqual(("False", "Пустая строка в качестве пароля"), result);
        }//15
        [Test]
        public void CheckRegister_ValidLoginAndPassword()
        {
            string login = "testuser";
            string password = "Test123!";
            string password2 = "Test123!";
            var result = Register.CheckRegister(login, password, password2);
            Assert.AreEqual(("True", ""), result);
        }//16
        [Test]
        public void CheckRegister_ValidMailAndPassword()
        {
            string login = "testuser@mail.ru";
            string password = "Test123!";
            string password2 = "Test123!";
            var result = Register.CheckRegister(login, password, password2);
            Assert.AreEqual(("True", ""), result);
        }//17
        [Test]
        public void CheckRegister_ValidPhoneAndPassword()
        {
            string login = "+7-963-843-5647";
            string password = "Test123!";
            string password2 = "Test123!";
            var result = Register.CheckRegister(login, password, password2);
            Assert.AreEqual(("True", ""), result);
        }//18
        [Test]
        public void CheckRegister_EmptyLoginAndPassword()
        {
            string login = "";
            string password = "";
            string password2 = "";
            var result = Register.CheckRegister(login, password, password2);
            Assert.AreEqual(("False", "Пустая строка в качестве логина"), result);
        }//19
        [Test]
        public void CheckRegister_EmptyLogin()
        {
            string login = "猫猫猫猫猫猫猫";
            string password = "";
            string password2 = "";
            var result = Register.CheckRegister(login, password, password2);
            Assert.AreEqual(("False", "Логин содержит символы, отличные от латиницы, цифр и знака подчеркивания"), result);
        }//20
    }
}