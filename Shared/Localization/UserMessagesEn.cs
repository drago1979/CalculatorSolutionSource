using Shared.Localization.Shared;

namespace Shared.Localization;

///
public class UserMessagesEn : UserMessages
{
    ///
    protected override string MessageTextChooseLanguage => """
                                                      ### Choose language ### 
                                                      Default: {0}. (just press enter)

                                                      Allowed values:
                                                      {1}
                                                      (type the value or enter a digit; First language = 0)
                                                      """;
    
    ///
    protected override string MessageTextInitMessage => """
                                                        **************************************************
                                                        -- CalculatorLib app --
                                                        Please enter required data. 
                                                        After each entered value, press ENTER to continue.
                                                        Anytime you can exit by entering: {0}"
                                                        **************************************************
                                                        """;

    ///
    protected override string MessageTextEnterFirstNumber => "### Enter a number between {0} and {1}.";

    ///
    protected override string MessageTextEnterSecondNumber => """
                                                        ### Enter a number. 
                                                        Allowed size depends on first number and math operation applied.
                                                        """;

    ///
    protected override string MessageTextEnterOperand => "### Enter an operand ({0})";

    ///
    protected override string MessageTextEnterValueAgainOrExit => "### Enter valid value or exit with {0}";

    ///
    protected override string MessageTextUserAborted => "INFO: You`ve entered {0}. Terminating application.";

    ///
    protected override string MessageTextMathOperationResultIs => "Result is: {0}";

    ///
    protected override string MessageTextShouldContinue => """
                                                           Do you want to perform another calculation?
                                                           Type: {0} to abort.
                                                           Any other key = continue.
                                                           """;

    ///
    protected override string EscapeStringsSeparator => " or ";
}