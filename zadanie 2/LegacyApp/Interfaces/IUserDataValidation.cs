using System;

namespace LegacyApp.Interfaces;

public interface IUserDataValidation
{
    bool checkIfFirstNameValid(string firstName);
    
    bool checkIfLastNameValid(string lastName);
    
    bool checkIfEmailHasDot(string email);
    
    bool checkIfEmailHasAt(string email);

    bool checkIfDecreaseAge(DateTime dateOfBirth);
}