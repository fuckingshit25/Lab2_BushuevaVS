using System;
namespace RegisterProject
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitTests tests = new UnitTests();
            
            tests.CheckRegister_EmptyLogin_ReturnsFalseAndErrorMessage();
            tests.CheckRegister_ShortLogin_ReturnsFalseAndErrorMessage();
            tests.CheckRegister_InvalidPhoneLogin_ReturnsFalseAndErrorMessage();
            tests.CheckRegister_ExistingLogin_ReturnsFalseAndErrorMessage();
            tests.CheckRegister_ValidData_ReturnsTrue();
            tests.CheckRegister_NotValidPass_1();
            tests.CheckRegister_NotValidPass_2();
            tests.CheckRegister_NotValidPass_3();
            tests.CheckRegister_NotValidPass_4();
            tests.CheckRegister_NotValidPass_5();
            tests.CheckRegister_NotValidPasswordEquality();
            tests.CheckRegister_NotValidPasswordLength();
            tests.CheckRegister_InvalidEmailLogin_ReturnsFalseAndErrorMessage();
            tests.CheckRegister_InvalidSymbolInLogin();
            tests.CheckRegister_EmptyPassword_ReturnsFalseAndErrorMessage();
            tests.CheckRegister_ValidLoginAndPassword();
            tests.CheckRegister_ValidMailAndPassword();
            tests.CheckRegister_ValidPhoneAndPassword();
            tests.CheckRegister_EmptyLoginAndPassword();
            tests.CheckRegister_EmptyLogin();
        }
    }
}
