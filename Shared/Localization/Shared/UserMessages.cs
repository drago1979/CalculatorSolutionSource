using CalculatorLib;

namespace Shared.Localization.Shared;

public abstract class UserMessages
{
    protected abstract string MessageTextChooseLanguage { get; }
    protected abstract string MessageTextInitMessage { get; }
    protected abstract string MessageTextEnterFirstNumber { get; }
    protected abstract string MessageTextEnterSecondNumber { get; }
    protected abstract string MessageTextEnterOperand { get; }
    protected abstract string MessageTextEnterValueAgainOrExit { get; }
    protected abstract string MessageTextUserAborted { get; }
    protected abstract string MessageTextMathOperationResultIs { get; }
    protected abstract string ErrorPrefix { get; }
    
    public string GetMessageTextChooseLanguage() => MessageTextChooseLanguage;
    
    public string GetMessageTextInitMessage() => MessageTextInitMessage;

    public string GetMessageTextReadFirstNumber() => 
        string.Format(
            MessageTextEnterFirstNumber,
            Calculator.GetMaxDecimalValue(),
            Calculator.GetMinDecimalValue(),
            Calculator.GetOperandValues()
        );
    
    public string GetMessageTextReadOperand()
    {
        return string.Format(MessageTextEnterOperand, Calculator.GetOperandValues());
    }

    public string GetMessageTextReadSecondNumber() => MessageTextEnterSecondNumber;

    public string GetMessageTextEnterValueAgainOrExit() => MessageTextEnterValueAgainOrExit;

    public string GetMessageUserAbortedExecution() => MessageTextUserAborted;

    public string GetMessageMathOperationResult(decimal value) => string.Format(MessageTextMathOperationResultIs, value);

    public string GetErrorPrefix() => ErrorPrefix;
}