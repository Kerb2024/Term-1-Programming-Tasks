Imports System



Module Program

    Dim UserChoice As Integer = 0
    Dim letter As Char = ""
    Dim shift As Integer = 0
    Dim encrypt As Char
    Dim word As String
    Dim ConvertedNum As Integer
    Dim Finished As Boolean
    Dim arrayStringSplit() As String
    Dim exponent As Integer
    Dim BinNum As String = ""
    Dim negOrPosi As Boolean = False
    Dim expoStr As String



    Sub Main()
        Console.WriteLine("Test")
        Console.WriteLine("19.75 in FPB is " & turntoFPBin(19.75, 2, 4) & ". The exponent is " & ExpoTo2s(exponent))
        'next part to do is convert exponent into 2's complement 
        Console.ReadKey()
    End Sub

    Function ExpoTo2s(expoInt As Integer)
        Dim expoStr As String

        expoStr = DenaryToBinary(expoInt)

        'expoStr = "0" & expoStr 'this code would convert the exponent, e.g. 5, into -5
        'expoStr = Invert(expoStr)
        'expoStr = InvertedToBinStr(expoStr)
        Return (expoStr)
    End Function

    Function turntoFPBin(number As Decimal, bitsforMan As Integer, bitsforEx As Integer) As String
        'Convert to fixed point binary
        Dim DecNum As Decimal = -19.75


        Dim BinNum As String

        If DecNum < 0 Then 'checks if DecNum is positive or not, by seeing if it is less than zero
            negOrPosi = True 'if DecNUm is less than zero, it sets negOrPosi to true
            DecNum = DecNum * (0 - 1) 'then it multiplies the number by -1 to make it positive.
        End If 'if DecNum is positive, negOrPosi's inital value is already set to false, so the program does not have to do anything.
        arrayStringSplit = Str(DecNum).Split(".") 'DecNum is split into 2 parts at the decimal point, e.g. 9.5 is split into 9 and 5

        arrayStringSplit(0) = DenaryToBinary(arrayStringSplit(0))

        arrayStringSplit(1) = arrayStringSplit(1) / 10 ^ Len(arrayStringSplit(1))

        'Console.WriteLine(PosiToNeg(arrayStringSplit(0)))
        BinNum = DecimalPToBin(CDec(arrayStringSplit(1)), bitsforMan)
        'BinNum = BinNum + "1"
        If (arrayStringSplit(0))(0) = "0" Then 'removes any unneccessary zeros from the start of the binary number
            arrayStringSplit(0) = Right(arrayStringSplit(0), (Len(arrayStringSplit(0)) - 1))
        End If
        BinNum = arrayStringSplit(0) & BinNum
        'If negOrPosi = True Then
        '    BinNum = PosiToNeg(BinNum)
        'End If

        'convert to negative if neccessary
        If negOrPosi = True Then 'check if the inital inputted number was negative or not
            BinNum = PosiToNeg(BinNum) 'if the initial number was negative, it uses the PosiToNeg function to convert BinNum into negative.
        Else
            BinNum = "0." & BinNum 'if the inital number was positive, it normalises BinNum
        End If
        exponent = Len(arrayStringSplit(0))

        Return (BinNum)
    End Function

    Function DecimalPToBin(Deci As Decimal, Mantissa As Integer)
        Do 'This Do Loop *should* convert the decimal part into binary
            Deci = Deci * 2
            If Deci >= 1 Then ' checks if decnum divided by 1 is greater than 1 (i.e 1.2 or 1.4).
                BinNum = BinNum & "1" ' adds a 1 to the binary number
                Deci = Deci - 1
                'subtracts 1 from decnum so that instead of being 1.2 or 1.4, it is 0.2 or 0.4
            Else
                BinNum = BinNum & "0" 'adds a 0 to the binary number 

            End If
        Loop Until Mantissa = Len(BinNum)
        Return BinNum
    End Function
    Function Invert(posNum As String)
        Dim negiNum As String = ""
        For i = 0 To Len(posNum) - 1
            If posNum(i) = "0" Then
                negiNum = negiNum & "1"
            ElseIf posNum(i) = "1" Then
                negiNum = negiNum & "0"
            Else
                negiNum = negiNum & ""
            End If
        Next
        Return (negiNum)
    End Function

    Function InvertedToBinStr(InvertedStr)
        Dim negiNumConvert As Integer
        Dim negNumLen As Integer
        negNumLen = Len(InvertedStr)
        'convert back into denary
        negiNumConvert = BinaryToDenary(InvertedStr)
        'add 1
        negiNumConvert = negiNumConvert + 1
        'convert back into binary
        InvertedStr = DenaryToBinary(negiNumConvert)
        If Len(InvertedStr) < negNumLen Then
            InvertedStr = "0" & InvertedStr
        End If
        Return (InvertedStr)
    End Function
    Function PosiToNeg(posiNum As String)
        Dim negiNum As String = ""
        negiNum = Invert(posiNum)
        negiNum = InvertedToBinStr(negiNum)
        'posiNum = "0" & posiNum
        'add decimal point where it should be
        negiNum = "1." & negiNum ' remove first 1 from negiNum, then add "1." to normalise it
        Return (negiNum)
    End Function
    'Sub Quiz()
    '    Dim questions(4) As QuestionsAnswers
    '    questions(0).Question = "What type of number is pi?"
    '    questions(0).Option1 = "1 = Natural"
    '    questions(0).Option2 = "2 = Integer"
    '    questions(0).Option3 = "3 = Rational"
    '    questions(0).Option4 = "4 = Irrational"
    '    questions(0).Answer = 4

    '    questions(1).Question = "What is the symbol for Real numbers?"
    '    questions(1).Option1 = "1 = N"
    '    questions(1).Option2 = "2 = Q"
    '    questions(1).Option3 = "3 = R"
    '    questions(1).Option4 = "4 = Z"
    '    questions(1).Answer = 3

    '    questions(2).Question = "What does the symbol Z mean"
    '    questions(2).Option1 = "1 = Natural Numbers"
    '    questions(2).Option2 = "2 = Integer Numbers"
    '    questions(2).Option3 = "3 = Rational Numbers"
    '    questions(2).Option4 = "4 = Irrational Numbers"
    '    questions(2).Answer = 2

    '    questions(3).Question = "Is 2 a:"
    '    questions(3).Option1 = "1 = Rational number"
    '    questions(3).Option2 = "2 = Integer"
    '    questions(3).Option3 = "3 = Irrational number"
    '    questions(3).Option4 = "4 = Natural number"
    '    questions(3).Answer = 4

    '    questions(4).Question = "Do rational numbers:"
    '    questions(4).Option1 = "1 = Contain non-integers that cannot be written as a decimal"
    '    questions(4).Option2 = "2 = Contain integers, as well as numbers that are not integers, but can be written as fractions or decimals"
    '    questions(4).Option3 = "3 = Contain all numbers"
    '    questions(4).Option4 = "4 = Contain only integers"
    '    questions(4).Answer = 2

    '    Console.WriteLine("To select your answer, input the number associated with the answer you would like to select")

    '    For i = 0 To questions.Length - 1
    '        DisplayQuestion(questions(i))
    '    Next

    'End Sub
    'Sub finishedyn()
    '    Dim choice As Integer
    '    Console.WriteLine("If you would like to finish the program, please enter 0. If you would like to test other code, please input 1")
    '    If choice = 0 Then
    '        Finished = True
    '    End If
    'End Sub
    Function wasIRight(question As QuestionsAnswers, answer As Integer) As Boolean
        If question.Answer = answer Then
            Return True
        Else
            Return False
        End If

    End Function

    Sub DisplayQuestion(q As QuestionsAnswers)
        Dim userinput As String
        Console.WriteLine()
        Console.WriteLine(q.Question)
        Console.WriteLine(q.Option1)
        Console.WriteLine(q.Option2)
        Console.WriteLine(q.Option3)
        Console.WriteLine(q.Option4)
        userinput = Console.ReadLine
        If wasIRight(q, userinput) = True Then
            Console.WriteLine("You are right")
        Else
            Console.WriteLine("You are wrong")
        End If
    End Sub
    Structure QuestionsAnswers
        Dim Question As String
        Dim Option1 As String
        Dim Option2 As String
        Dim Option3 As String
        Dim Option4 As String
        Dim Answer As Integer
    End Structure

    Function BinaryToDenary(BinNum As String) As Integer
        Dim BinLen As Integer
        Dim DenNum As Integer
        DenNum = 0
        BinLen = Len(BinNum)
        BinNum = StrReverse(BinNum)
        For i = 0 To BinLen - 1
            If BinNum(i) = "1" Then
                DenNum = DenNum + 2 ^ i
            End If
        Next
        Return (DenNum)
    End Function

    Function DenaryToBinary(DenNum As Integer) As String
        Dim DivAns As Integer
        Dim BinNum As String
        BinNum = ""
        Do Until DenNum = 0
            If DenNum Mod 2 = 1 Then
                BinNum = BinNum & "1"
            Else
                BinNum = BinNum & "0"
            End If

            DenNum = DenNum \ 2
        Loop
        DivAns = StrReverse(BinNum)

        Return (DivAns)
    End Function





    Function CaesarLetterEncrypt(Letter As String, Shift As Integer) As String
        Dim LetterASCII As Integer
        LetterASCII = Asc(Letter)
        If Char.IsUpper(Letter) Then
            If LetterASCII + Shift > 90 Then
                Shift = 26 - Shift
                LetterASCII = LetterASCII - Shift
            Else
                LetterASCII = LetterASCII + Shift
            End If
        Else
            If LetterASCII + Shift > 122 Then
                Shift = 26 - Shift
                LetterASCII = LetterASCII - Shift
            Else
                LetterASCII = LetterASCII + Shift
            End If
        End If
        Letter = Chr(LetterASCII)
        Return (Letter)
    End Function

    Function CaesarLetterDecrypt(Letter As String, Shift As Integer) As String
        Dim LetterASCII As Integer
        LetterASCII = Asc(Letter)
        If Char.IsUpper(Letter) Then
            If LetterASCII - Shift < 65 Then
                Shift = 26 - Shift
                LetterASCII = LetterASCII + Shift
            Else
                LetterASCII = LetterASCII - Shift
            End If
        Else
            If LetterASCII + Shift < 97 Then
                LetterASCII = LetterASCII + Shift
            Else
                LetterASCII = LetterASCII - Shift
            End If
        End If
        Letter = Chr(LetterASCII)
        Return (Letter)
    End Function

    Function WordEnDecrypt(Word As String, Shift As Integer) As String
        Dim encryptedWord As String
        Dim encryptedChar As String
        encryptedWord = ""

        For i = 0 To Len(Word) - 1
            If encrypt = "Y" Then
                encryptedChar = CaesarLetterEncrypt(Word(i), Shift)
                encryptedWord = encryptedWord & encryptedChar
            Else
                encryptedChar = CaesarLetterDecrypt(Word(i), Shift)
                encryptedWord = encryptedWord & encryptedChar
            End If
        Next
        Return (encryptedWord)
    End Function

End Module

