using System;
using LegacyApp.Implementations;
using LegacyApp.Interfaces;

namespace LegacyApp
{
    public class UserService
    {
        IUserDataValidation _userDataValidation;

        public UserService()
        {
            _userDataValidation = new UserDataValidation();
        }
        public UserService(IUserDataValidation userDataValidation)
        {
            _userDataValidation = new UserDataValidation();
        }
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!_userDataValidation.checkIfFirstNameValid(firstName) || !_userDataValidation.checkIfLastNameValid(lastName))
            {
                return false;
            }

            if (!_userDataValidation.checkIfEmailHasAt(email) && !_userDataValidation.checkIfEmailHasDot(email))
            {
                return false;
            }

            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (_userDataValidation.checkIfDecreaseAge(dateOfBirth)) age--;

            if (age < 21)
            {
                return false;
            }

            var clientRepository = new ClientRepository();
            var client = clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };
        
            if (client.Type == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
            }
            else if (client.Type == "ImportantClient")
            {
                using (var userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    creditLimit = creditLimit * 2;
                    user.CreditLimit = creditLimit;
                }
            }
            else
            {
                user.HasCreditLimit = true;
                using (var userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    user.CreditLimit = creditLimit;
                }
            }

            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }
    }
}
