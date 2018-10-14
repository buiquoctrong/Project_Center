Imports System.Drawing
Public NotInheritable Class ShowText
    Private EnglishFont As New Font("MS Reference Sans Serif", 12.0, FontStyle.Regular, 3)
    Private JapanFont As New Font("MS Gothic", 12.0, FontStyle.Regular, 3)
    Private Sub New()
    End Sub

    Private Shared ReadOnly _instance As ShowText = New ShowText()

    Public Shared Function GetSingleton() As ShowText
        Return _instance
    End Function

    Public Sub SetTextEnglish()

    End Sub

End Class