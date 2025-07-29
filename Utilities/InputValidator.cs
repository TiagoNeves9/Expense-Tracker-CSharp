/*
*  This file helps to validate user input for the expense tracker application.
*  It ensures that the data entered by the user meets the required criteria
*/
using Models;
using System;

namespace Utilities
{
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

        public static bool IsValidCategory(Category category)
        {
            return Enum.IsDefined(typeof(Category), category);
        }

        public static string[] HandleInput(string input)
        {   // Validate and process the input
            // The input is expected to be a semicolon-separated string
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input cannot be null or empty.");
            }
            // Expecting input format: "description;amount;category"
            if (!input.Contains(';'))
            {
                throw new ArgumentException("Input must be in the format: 'description;amount;category'.");
            }
            
            string[] parsedInput = input.Split(';');

            if (parsedInput.Length != 3)
            {
                throw new ArgumentException("Input must be in the format: 'description;amount;category'.");
            }
            if (!IsValidExpenseDescription(parsedInput[0]))
            {
                throw new ArgumentException("Description must be a non-empty string with a maximum length of 100 characters.");
            }
            if (!decimal.TryParse(parsedInput[1], out decimal amount))
            {
                throw new ArgumentException("Amount must be a valid decimal number.");
            }
            if (!Enum.TryParse(parsedInput[2], out Category category))
            {
                throw new ArgumentException("Invalid category.");
            }

            return parsedInput;
        }
    }
}