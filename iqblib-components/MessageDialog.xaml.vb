﻿Public Class MessageDialog
    Public Enum DialogMode
        Message
        WarningMessage
        ErrorMessage
        YesNoCancel
    End Enum

    Public TitleStr As String
    Public MessageStr As String
    Public HelpTopic As Integer
    Public DlgMode As DialogMode

    Private Sub Me_Loaded() Handles Me.Loaded
        Me.Title = TitleStr
        Me.TBMessage.Text = MessageStr
        If HelpTopic > 0 Then
            Me.SetValue(HelpProvider.HelpTopicIdProperty, HelpTopic.ToString)
        Else
            BtnHelp.Visibility = Windows.Visibility.Collapsed
        End If

        Select Case DlgMode
            Case DialogMode.Message
                ImgError.Visibility = Windows.Visibility.Collapsed
                ImgWarning.Visibility = Windows.Visibility.Collapsed
                BtnNo.Visibility = Windows.Visibility.Collapsed
                BtnCancel.Visibility = Windows.Visibility.Collapsed

            Case DialogMode.ErrorMessage
                ImgWarning.Visibility = Windows.Visibility.Collapsed
                BtnNo.Visibility = Windows.Visibility.Collapsed
                BtnCancel.Visibility = Windows.Visibility.Collapsed

            Case DialogMode.WarningMessage
                ImgError.Visibility = Windows.Visibility.Collapsed
                BtnNo.Visibility = Windows.Visibility.Collapsed
                BtnCancel.Visibility = Windows.Visibility.Collapsed

            Case DialogMode.YesNoCancel
                ImgError.Visibility = Windows.Visibility.Collapsed
                ImgWarning.Visibility = Windows.Visibility.Collapsed
                BtnOK.Content = "Ja"

            Case Else
                Throw New ArgumentNullException("MessageDialog: SmallDialogMode")
        End Select
    End Sub

    Private Sub BtnOK_Clicked(sender As Object, e As RoutedEventArgs) Handles BtnOK.Click
        Me.DialogResult = True
    End Sub

    Private Sub BtnNo_Clicked(sender As Object, e As RoutedEventArgs) Handles BtnNo.Click
        Me.DialogResult = False
    End Sub

End Class
