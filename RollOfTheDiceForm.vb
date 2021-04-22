Public Class RollOfTheDiceForm
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        ListBox1.Items.Clear()
        RollDice()
    End Sub

    Private Sub RollButton_Click(sender As Object, e As EventArgs) Handles RollButton.Click
        RollDice()
    End Sub

    Sub RollDice()
        Static randomNumbers(10) As Integer
        Dim numbers(0, 10) As String
        Dim rollsArray(0, 10) As String
        Dim rollNumbers(0, 10) As Integer
        Dim arrayNumbers As String
        Dim rolls As String
        ListBox1.Items.Clear()
        If RollButton.Focused = True Then
            '"roll" for random numbers between 0 and 10
            For i = 0 To 1000
                randomNumbers(GetRandomNumber(10)) += 1

            Next

            ListBox1.Items.Add("Roll of the Dice")

            'create divider between the lines
            ListBox1.Items.Add(StrDup(100, "-"))

            'list the numbers from 2 to 12 and add dividers between numbers
            For i = 2 To 12
                numbers(0, i - 2) = (Str(i).PadLeft(7) & "|")
            Next
            For i = 0 To 10
                arrayNumbers = $"{arrayNumbers}{numbers(0, i)}"
            Next
            ListBox1.Items.Add(arrayNumbers)
            'create divider between the lines
            ListBox1.Items.Add(StrDup(100, "-"))

            'will write out how many times each number was "rolled" and divides the numbers with lines
            For i = 0 To UBound(randomNumbers)
                rollsArray(0, i) = (Str(randomNumbers(i)).PadLeft(6) & "|")
            Next
            For i = 0 To 10
                rolls = $"{rolls}{rollsArray(0, i)}"
            Next
            ListBox1.Items.Add(rolls)
            'create divider between the lines
            ListBox1.Items.Add(StrDup(100, "-"))

        Else
            'this code allows for the data of previous rolls to be stored while allowing the data to be cleared.
            For i = 0 To 10
                randomNumbers(i) = 0
            Next
        End If
    End Sub

    ''' <summary>
    ''' this function will return a random number between 1 and a maximum number that is input
    ''' </summary>
    ''' <param name="maxNumber"></param>
    ''' <returns></returns>
    Function GetRandomNumber(maxNumber As Integer) As Integer
        Randomize(DateTime.Now.Millisecond)
        Return CInt(Math.Floor(Rnd() * (maxNumber + 1)))
    End Function
End Class
