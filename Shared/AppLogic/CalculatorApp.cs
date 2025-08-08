using CalculatorLib;
using CalculatorLib.InputTypes;
using Shared.Base;
using Shared.Helpers;
using Shared.Interfaces;
using Shared.Localization.Enum;
using Shared.Localization.Factory;
using Shared.Localization.Shared;
using Shared.Constants;

namespace Shared.AppLogic;

public class CalculatorApp(
    UserInterface userInterface,
    IApplicationTerminator applicationTerminator,
    IUserMessagesFactory messagesFactory
)
{
    private const Language DefaultLanguage = Language.En;
    private const string InvalidInputMessage = "Invalid input: ";

    private UserMessages _userMessages = messagesFactory.Create(DefaultLanguage);

    public void Run()
    {
        _userMessages = ReadUserLanguageChoice();

        GreetTheUser();

        var continueRunning = true;
        
        while (continueRunning)
        {
            continueRunning = GetUserInputsAndCalculate();
        }
    }

    private bool GetUserInputsAndCalculate()
    {
        var num1 = ReadInput<InputTypeDecimal>(_userMessages.GetMessageTextReadFirstNumber());
        var operand = ReadInput<InputTypeOperand>(_userMessages.GetMessageTextReadOperand());
        var num2 = ReadInput<InputTypeDecimal>(_userMessages.GetMessageTextReadSecondNumber());

        try
        {
            var result = Calculator.Calculate(num1, num2, operand);

            Respond(_userMessages.GetMessageMathOperationResult(result));
        }
        catch (Exception e) when (e is OverflowException or DivideByZeroException)
        {
            Respond(e);
        }

        return AskUserToContinue();
    }
    
    private bool AskUserToContinue()
    {
        Respond(_userMessages.GetMessageShouldContinue());

        var input = userInterface.GetInput();

        return !ShouldExit(input);
    }

    // --> Languages
    private UserMessages ReadUserLanguageChoice()
    {
        while (true)
        {
            Respond(GenerateChooseLanguageMessage());

            var userInput = userInterface.GetInput();

            if (UseDefaultLanguage(userInput)) return _userMessages;

            if (Helper.TryGetValidEnum<Language>(userInput, out var lang)) return messagesFactory.Create(lang);

            ReadUserReinputOrExit(new ArgumentException(InvalidInputMessage + userInput));
        }
    }

    private static bool UseDefaultLanguage(string s) => string.IsNullOrEmpty(s) ||
                                                        string.IsNullOrWhiteSpace(s) ||
                                                        (Enum.TryParse(s, false, out Language lang) &&
                                                         lang == DefaultLanguage);

    private string GenerateChooseLanguageMessage()
    {
        return string.Format(_userMessages.GetMessageTextChooseLanguage(),
            DefaultLanguage.GetUserPreview(),
            GetAllowedLanguages());
    }

    private static string GetAllowedLanguages()
    {
        return DefaultLanguage.GetAllLanguages();
    }
    // <--Languages
    
    private void GreetTheUser()
    {
        Respond(_userMessages.GetMessageTextInitMessage());
    }

    // --> Read input
    private T ReadInput<T>(string message) where T : IParsableInput<T>
    {
        while (true)
        {
            ReadUserInputOrExit(out var input, message);

            try
            {
                return T.Parse(input);
            }
            catch (Exception e) when (e is FormatException or OverflowException)
            {
                ReadUserReinputOrExit(e);
            }
        }
    }

    private void ReadUserInputOrExit(out string input, string message)
    {
        Respond(message);

        input = userInterface.GetInput();

        if (ShouldExit(input)) applicationTerminator.Terminate(userInterface, _userMessages);
    }
    
    private void ReadUserReinputOrExit(Exception exception)
    {
        Respond(exception);
        Respond(_userMessages.GetMessageTextEnterValueAgainOrExit());
    }

    private static bool ShouldExit(string input) =>
      ConstantsList.EscapeStrings.Any(escapeString => input.Equals(escapeString, StringComparison.InvariantCultureIgnoreCase));
    // <-- Read input

    // --> Responses
    private void Respond(string message)
    {
        userInterface.Respond(message);
    }

    private void Respond(Exception e)
    {
        userInterface.Respond(e);
    }
    // <-- Responses
}