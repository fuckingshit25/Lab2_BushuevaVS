using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RegisterProject
{
    internal class Register
    {
        public static (string, string) CheckRegister(string login, string password, string password2)
        {
            /*
             * В качестве результата выводится результат первой непрошедшей проверки.
             * Порядок проверки введенных данных:
             * 1. Логин (длина)
             * 2. Логин (совпадение с зарегистрированными пользователями)
             * 3. Логин (контент / допустимые символы)
             * 4. Пароль (длина)
             * 5. Пароль (совпадение паролей между собой)
             * 6. Пароль (контент / допустимые символы)
             * 
             * */
            var result = CheckLoginLength(login);
            if (result.Item1 == "False")
                return result;

            result = CheckExistUser(login);
            if (result.Item1 == "False")
                return result;

            result = CheckLoginContent(login);
            if (result.Item1 == "False")
                return result;

            result = CheckPasswordLength(password);
            if (result.Item1 == "False")
                return result;

            result = CheckPasswordEquality(password, password2);
            if (result.Item1 != "False")
                return result;

            result = CheckPasswordContent(password);
            return result;
        }

        private static (string, string) CheckLoginLength(string login)
        {
            int length = login.Length;

            if (length <= 0)
                return ("False", "Пустая строка в качестве логина");
            else if (length <= 5)
                return ("False", "Длина логина меньше 5 символов");
            else
                return ("True", "");
        }

        private static (string, string) CheckExistUser(string login)
        {
            List<string> registeredUsers = new List<string>() { "user11", "user22", "user33" };

            if (registeredUsers.Contains(login.ToLower()))
                return ("False", "Пользователь с таким логином уже зарегистрирован");
            else
                return ("True", "");
        }

        private static (string, string) CheckLoginContent(string login)
        {
            bool reLogin = Regex.IsMatch(login, @"^[a-zA-Z0-9_]+$");
            bool reMail = Regex.IsMatch(login, @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$");
            bool rePhone = Regex.IsMatch(login, @"^\+\d{1,3}-\d{3}-\d{3}-\d{4}$"); ;

            // Correct
            if (rePhone || reMail || reLogin)
                return ("True", "");

            // Incorrect phone
            if (login.Contains('+') && !rePhone)
                return ("False", "Номер телефона не удовлетворяет заданному формату +x-xxx-xxx-xxxx");

            // Incorrect main
            if (login.Contains('@') && !reMail)
                return ("False", "Email не удовлетворяет общему формату xxx@xxx.xxx");

            // Incorrect login
            if (!reLogin)
                return ("False", "Логин содержит символы, отличные от латиницы, цифр и знака подчеркивания");
            else
                throw new Exception("Неизвестная ошибка валидации логина. Этот кейс логически невозможен.");
        }

        private static (string, string) CheckPasswordLength(string password)
        {
            int length = password.Length;

            if (length <= 0)
                return ("False", "Пустая строка в качестве пароля");
            else if (length < 7)
                return ("False", "Длина пароля меньше 7 символов");
            else
                return ("True", "");
        }

        private static (string, string) CheckPasswordEquality(string password, string password2)
        {
            if (password != password2)
            {
                return ("True", "Заданные пароли не совпадают");
            }
            else
            {
                return ("False", "OK");
            }
        }

        private static (string, string) CheckPasswordContent(string password)
        {
            var reCommonPasswd = Regex.IsMatch(password, @"^[А-Яа-яA-Za-z0-9!@#\$%\^&\*\(\)_\+`~\-=\[\]\{\}\|\\:\;"",\.<>\?\/]+$");
            var reUpLetter = Regex.IsMatch(password, @"[A-Z]+");
            var reDownLetter = Regex.IsMatch(password, @"[a-z]+");
            var reDigit = Regex.IsMatch(password, @"[0-5]");
            var reSpecialSymbol = Regex.IsMatch(password, @"[!@#\$%\^&\*\(\)_\+`~\-=\[\]\{\}\|\\:\;"",\.<>\?\/]");

            // Correct
            if (reCommonPasswd && reUpLetter && reDownLetter && reDigit && reSpecialSymbol)
                return ("True", "");

            // Incorrect symbols
            if (!reCommonPasswd)
                return ("False", "В пароле присутствуют недопустимые символы");

            // Incorrect: letter
            if (!reUpLetter)
                return ("False", "В пароле отсутствует минимум одна заглавная буква");

            // Incorrect: letter
            if (!reDownLetter)
                return ("False", "В пароле отсутствует минимум одна строчная буква");

            // Incorrect: digit
            if (!reDigit)
                return ("False", "В пароле отсутствует минимум одна цифра");

            // Incorrect: special symbols
            if (!reSpecialSymbol)
                return ("False", "В пароле отсутствует минимум один специальный символ");
            else
                throw new Exception("Неизвестная ошибка валидации пароля. Этот кейс логически невозможен.");
        }
    }
}
