using System;
using LegacyApp.Interfaces;

namespace LegacyApp.Implementations;

public class UserDataValidation : IUserDataValidation
{
    public bool checkIfFirstNameValid(string firstName)
    {
        if (firstName != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool checkIfLastNameValid(string lastName)
    {
        if (lastName != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool checkIfEmailHasDot(string email)
    {
        if (email.Contains("."))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool checkIfEmailHasAt(string email)
    {
        if (email.Contains("@"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool checkIfDecreaseAge(DateTime dateOfBirth)
    {
        if (DateTime.Now.Month < dateOfBirth.Month || (DateTime.Now.Month == dateOfBirth.Month && DateTime.Now.Day < dateOfBirth.Day))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}