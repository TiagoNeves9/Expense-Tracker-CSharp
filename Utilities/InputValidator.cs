/*
*  This file helps to validate user input for the expense tracker application.
*  It ensures that the data entered by the user meets the required criteria
*/

namespace Utilities
{
using Models;
using System;
    public static class InputValidator
    {
        public static bool IsValidExpenseDescription(string description)
        {
            return !string.IsNullOrWhiteSpace(description) && description.Length <= 100;
        }

        public static bool IsValidExpenseAmount(decimal amount)
        {
            return amount > 0;
        }

        public static bool IsValidExpenseDate(DateTime date)
        {
            return date <= DateTime.Now;
        }

        public static bool IsValidCategory(Category category)
        {
            return Enum.IsDefined(typeof(Category), category);
        }
    }
}