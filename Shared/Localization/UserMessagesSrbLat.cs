using Shared.Localization.Shared;

namespace Shared.Localization;

public class UserMessagesSrbLat: UserMessages
{
    protected override string MessageTextChooseLanguage => """
                                                      ### Izaberi jezik ### 
                                                      Default: {0}. (pritisni enter)

                                                      Dozvoljene vrednosti:
                                                      {1}
                                                      (ukucaj vrednost za zeljeni jezik ili unesi cifru; prvi jezik = 0)                                          "
                                                      """;

    
    protected override string MessageTextInitMessage => """
                                                        **************************************************
                                                        -- Kalkulator aplikacija --
                                                        Molimo unesite potrebne podatke. 
                                                        Nakon svakog unosa pritisnite ENTER za nastavak.
                                                        U bilo kom trenutku možete izaći unošenjem 'q' ili 'exit'
                                                        **************************************************
                                                        """;

    protected override string MessageTextEnterFirstNumber => "### Unesite broj između {0} i {1}.";

    protected override string MessageTextEnterSecondNumber => """
                                                              ### Unesite broj. 
                                                              Dozvoljena veličina zavisi od prvog broja i primenjene matematičke operacije.
                                                              """;

    protected override string MessageTextEnterOperand => "### Unesite operator ({0})";

    protected override string MessageTextEnterValueAgainOrExit => "### Unesite validnu vrednost ili izađite sa 'q' ili 'exit'";

    protected override string MessageTextUserAborted => "INFO: Uneli ste 'q' ili 'exit'. Prekidam aplikaciju.";

    protected override string MessageTextMathOperationResultIs => "Rezultat je: {0}";

    protected override string ErrorPrefix => "!!! GREŠKA: ";
}