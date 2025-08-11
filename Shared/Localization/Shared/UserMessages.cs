using CalculatorLib;
using CalculatorLib.InputTypes;
using Shared.Constants;

namespace Shared.Localization.Shared;

/// <summary>
/// Provides abstract definitions for user-facing message strings and methods to retrieve localized messages.
/// </summary>
public abstract class UserMessages
{
    ///
    protected abstract string MessageTextChooseLanguage { get; }
    ///
    protected abstract string MessageTextInitMessage { get; }
    ///
    protected abstract string MessageTextEnterFirstNumber { get; }
    ///
    protected abstract string MessageTextEnterSecondNumber { get; }
    ///
    protected abstract string MessageTextEnterOperand { get; }
    ///
    protected abstract string MessageTextEnterValueAgainOrExit { get; }
    ///
    protected abstract string MessageTextUserAborted { get; }
    ///
    protected abstract string MessageTextMathOperationResultIs { get; }
    ///
    protected abstract string MessageTextShouldContinue { get; }
    ///
    protected abstract string EscapeStringsSeparator { get; }
    
    
    ///
    public string GetMessageTextChooseLanguage() => MessageTextChooseLanguage;
    
    ///
    public string GetMessageTextInitMessage() => string.Format(MessageTextInitMessage, GetEscapeCharactersString());

    ///
    private string GetEscapeCharactersString() => string.Join(EscapeStringsSeparator, ConstantsList.EscapeStrings);

    ///
    public string GetMessageTextReadFirstNumber() =>
        string.Format(
            MessageTextEnterFirstNumber,
            InputTypeDecimal.GetMinValue(),
            InputTypeDecimal.GetMaxValue(),
            Calculator.GetOperandValues()
        );

    ///
    public string GetMessageTextReadOperand() => string.Format(MessageTextEnterOperand, Calculator.GetOperandValues());

    ///
    public string GetMessageTextReadSecondNumber() => MessageTextEnterSecondNumber;

    ///
    public string GetMessageTextEnterValueAgainOrExit() =>
        string.Format(MessageTextEnterValueAgainOrExit, GetEscapeCharactersString());

    ///
    public string GetMessageUserAbortedExecution() =>
        string.Format(MessageTextUserAborted, GetEscapeCharactersString());

    ///
    public string GetMessageMathOperationResult(decimal value) =>
        string.Format(MessageTextMathOperationResultIs, value);

    ///
    public string GetMessageShouldContinue() => string.Format(MessageTextShouldContinue, GetEscapeCharactersString());
}