using CalculatorLib;
using CalculatorLib.InputTypes;
using CalculatorLib.Interfaces;
using Shared.Base;
using Shared.Helpers;
using Shared.Interfaces;
using Shared.Localization.Enum;
using Shared.Localization.Factory;
using Shared.Localization.Shared;

namespace Shared.AppLogic;

public class CalculatorApp(
    UserInterface userInterface,
    IApplicationTerminator applicationTerminator,
    IUserMessagesFactory messagesFactory
)
{
    private const Language DefaultLanguage = Language.En;
    private const string InvalidInputMessage = "Invalid input: ";

    private static readonly string[] EscapeStrings = ["q", "exit"];

    private UserMessages _userMessages = messagesFactory.Create(DefaultLanguage);

    private readonly IParser<decimal> _decimalParser = Calculator.GetDecimalParser();
    private readonly IParser<Operand> _operandParser = Calculator.GetOperandParser();

    public void Run()
    {
        _userMessages = ReadUserLanguageChoice();

        GreetTheUser();

        var num1 = ReadInput(_userMessages.GetMessageTextReadFirstNumber(), _decimalParser);
        var operand = ReadInput(_userMessages.GetMessageTextReadOperand(), _operandParser);
        var num2 = ReadInput(_userMessages.GetMessageTextReadSecondNumber(), _decimalParser);

        try
        {
            var result = Calculator.Calculate(num1, num2, operand);

            Respond(_userMessages.GetMessageMathOperationResult(result));
        }
        catch (OverflowException e)
        {
            Respond(e);
        }
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
    private T ReadInput<T>(string message, IParser<T> parser)
    {
        while (true)
        {
            ReadUserInputOrExit(out var input, message);

            try
            {
                return parser.Parse(input);
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
        EscapeStrings.Any(escapeString => input.Equals(escapeString, StringComparison.InvariantCultureIgnoreCase));

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