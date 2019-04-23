' -------------------------
'	All Saints' College
'	Ewing Ave, Bull Creek
'	Bus Ticketing System
'	Aaron Musgrave
'	13/04/2018
' -------------------------
'	Help Form
' -------------------------

Public Class FrmHelp
    ' On Load
    Private Sub FrmHelp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tabStops(3) As Integer
        Dim helpText(11) As String

        tabStops = {20, 40, 60, 120}
        helpText(0) = vbTab & "1. " & vbTab & "Open the Unicard website at:"
        helpText(1) = vbTab & vbTab & vbTab & "https://www.idmobile.com.au/TMS.Gateway.version2/"
        helpText(2) = vbTab & "2. " & vbTab & "Log in using the following user details:"
        helpText(3) = vbTab & vbTab & vbTab & "Username: " & vbTab & "allsaints"
        helpText(4) = vbTab & vbTab & vbTab & "Password: " & vbTab & "unicard"
        helpText(5) = vbTab & "3. " & vbTab & "Select ""Events Attendance report"""
        helpText(6) = vbTab & "4. " & vbTab & "Click ""Show all Android devices"""
        helpText(7) = vbTab & "5. " & vbTab & "Input the start and end dates"
        helpText(8) = vbTab & "6. " & vbTab & "Select the bus route from the drop-down list"
        helpText(9) = vbTab & "7. " & vbTab & "Click ""Select & Report"""
        helpText(10) = vbTab & "8. " & vbTab & "Click ""Download Full Report"""
        helpText(11) = "Open the downloaded .csv file as Input Data."

        RtbHelp.SelectionTabs = tabStops
        RtbHelp.Lines = helpText
    End Sub

    ' Hyper Link Clicked
    Private Sub RtbHelp_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles RtbHelp.LinkClicked
        Process.Start("https://www.idmobile.com.au/TMS.Gateway.version2/")
    End Sub

    ' Close on Esc Key
    Private Sub RtbHelp_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles RtbHelp.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmHelp_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
End Class