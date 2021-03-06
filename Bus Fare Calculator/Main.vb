﻿' -------------------------
'	All Saints' College
'	Ewing Ave, Bull Creek
'	Bus Ticketing System
'	Aaron Musgrave
'	23/04/2019
' -------------------------
'	Main Form
' -------------------------

Public Class FrmMain
    ' Declare Global Variables
    Dim calculator As Calculator

    ' --------------------
    '	USER INTERACTION
    ' --------------------

    ' Open Tag List CSV File
    Private Sub BtnOpen_Click(sender As Object, e As EventArgs) Handles BtnOpen.Click
        ' Declare Variables
        Dim numErrors As Integer
        Dim fileName As String
        Dim inputRows As List(Of String())

        Dim errorTags As New List(Of Tag)
        Dim errorMessage As String

        ' Browse to input file
        If OpenFileDialog.ShowDialog() = DialogResult.OK Then
            fileName = OpenFileDialog.FileName

            ' Set Wait Cursor
            Cursor = Cursors.WaitCursor
            ' Load Input File
            inputRows = FileIO.OpenCSV(fileName)
            ' Process Into Tags
            calculator.CreateTags(inputRows)
            ' Populate Data View Grid
            PopulateInput(calculator.TagList)

            ' Count errors
            numErrors = 0
            For Each currTag As Tag In calculator.TagList
                If currTag.ErrorCode > 0 Then
                    numErrors += 1
                    errorTags.Add(currTag)
                End If
            Next

            If numErrors > 0 Then
                ' Display error message
                errorMessage =
                    numErrors & " records were found to contain errors." & vbNewLine &
                    "Would you like to delete erroneous tags?"

                ' Delete rows
                If MessageBox.Show(errorMessage, "Errors in input data", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = vbYes Then
                    For Each currTag As Tag In errorTags
                        calculator.TagList.Remove(currTag)
                    Next

                    ' Populate Data View Grid
                    PopulateInput(calculator.TagList)
                End If
            End If

            ' Enable Buttons
            BtnProcess.Enabled = True
            BtnClear.Enabled = True
            ' Reset Cursor
            Cursor = Cursors.Default
        End If
    End Sub

    ' Save Outptut CSV File
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        ' Declare Variables
        Dim fileName As String
        ' Browse to file save location
        ResetSaveDialog()
        SaveFileDialog.ShowDialog()
        fileName = SaveFileDialog.FileName
        ' Set Wait cursor
        Cursor = Cursors.WaitCursor
        ' Save ouptut file
        FileIO.SaveCSV(fileName, DgvOutput)
        ' Reset cursor
        Cursor = Cursors.Default
    End Sub

    ' Save Export CSV File
    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click
        ' Declare Variables
        Dim fileName As String
        ' Browse to file save location
        ResetSaveDialog()
        SaveFileDialog.ShowDialog()
        fileName = SaveFileDialog.FileName
        ' Set Wait Curtsor
        Cursor = Cursors.WaitCursor
        ' Save export File
        FileIO.ExportCSV(fileName, calculator.CardMap)
        ' Reset Cursor
        Cursor = Cursors.Default
    End Sub

    ' Process input
    Private Sub BtnProcess_Click(sender As Object, e As EventArgs) Handles BtnProcess.Click
        ' Check input loaded
        If DgvInput.Rows.Count > 0 Then
            ' Set wait cursor
            Cursor = Cursors.WaitCursor
            Try
                ' Process Data
                calculator.Process(CbxFareCap.SelectedItem = CbxFareCap.Items(1))
                ' Populate Output
                PopulateOutput(calculator.CardMap)
                SetProgress(ProgressBar.Maximum)
                ' Enable Buttons
                BtnSave.Enabled = True
                BtnExport.Enabled = True
                TxbSearch.Enabled = True
                CbxFilter.Enabled = True
            Catch ex As OperationCanceledException
                ' Reset progress
                SetProgress(0)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error Processing Input")
            Finally
                ' Reset cursor
                Cursor = Cursors.Default
            End Try
        End If
    End Sub

    ' Clear Output
    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        ' Clear Objects
        calculator.Clear()
        DgvInput.Rows.Clear()
        DgvOutput.Rows.Clear()
        ' Reset Form
        TxbSearch.Text = ""
        CbxFilter.SelectedItem = CbxFilter.Items(0)
        SetProgress(ProgressBar.Minimum)
        ' Disable Buttons
        BtnProcess.Enabled = False
        BtnClear.Enabled = False
        BtnSave.Enabled = False
        BtnExport.Enabled = False
        TxbSearch.Enabled = False
        CbxFilter.Enabled = False
    End Sub

    ' Help Button
    Private Sub BtnHelp_Click(sender As Object, e As EventArgs) Handles BtnHelp.Click
        FrmHelp.Show()
    End Sub

    ' Search Output Table
    Private Sub TxbSearch_TextChanged(sender As Object, e As EventArgs) Handles TxbSearch.TextChanged
        ' Create Variables
        Dim cardSearch As Dictionary(Of String, Card)

        If calculator.CardMap.Count > 0 Then
            ' Change Mouse cursor
            Cursor = Cursors.WaitCursor

            Try
                ' Get search result
                cardSearch = calculator.FilterAndSearch(CbxFilter.SelectedItem, TxbSearch.Text)

                ' Populate Output Table
                PopulateOutput(cardSearch)
            Catch ex As Exception
                MessageBox.Show(("Error searching data: " & ex.Message), "Search Error")
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub

    ' Filter Output Table
    Private Sub CbxFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxFilter.SelectedIndexChanged
        ' Create Variables
        Dim cardFilter As Dictionary(Of String, Card)

        If calculator.CardMap.Count > 0 Then
            ' Change Mouse Cursor
            Cursor = Cursors.WaitCursor

            Try
                ' Get Filter Result
                cardFilter = calculator.FilterAndSearch(CbxFilter.SelectedItem, TxbSearch.Text)
                ' Populate Output Table
                PopulateOutput(cardFilter)
            Catch ex As Exception
                MessageBox.Show(("Error filtering output: " & ex.Message), "Filter Error")
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub

    ' Update Ride Fare Text Box
    Private Sub TbxRideFare_LostFocus(sender As Object, e As EventArgs) Handles TxbRideFare.LostFocus
        calculator.UpdateRideFare(TxbRideFare.Text)
        TxbRideFare.Text = FormatCurrency(calculator.RideFare)
    End Sub

    ' Update Fare Cap Text Box
    Private Sub TbxFareCap_LostFocus(sender As Object, e As EventArgs) Handles TxbFareCap.LostFocus
        calculator.UpdateFareCap(TxbFareCap.Text)
        TxbFareCap.Text = FormatCurrency(calculator.FareCap)
    End Sub

    ' Update Fare Cap Drop-down list
    Private Sub CbxFareCap_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxFareCap.SelectedIndexChanged
        TxbFareCap.Enabled = (CbxFareCap.SelectedItem = CbxFareCap.Items(1))
    End Sub

    ' Handles Resize of Main Window
    Private Sub FrmMain_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        ResizeWindow()
    End Sub

    ' Handles First Load of Main Window
    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialise Calculator Object
        calculator = New Calculator

        ' Set Drop Down Options
        CbxFareCap.SelectedItem = CbxFareCap.Items(0)
        CbxFilter.SelectedItem = CbxFilter.Items(0)

        ' Set Tool Tips
        Dim toolTipSave As New ToolTip()
        Dim toolTipExport As New ToolTip()
        toolTipSave.SetToolTip(Me.BtnSave, "Save the data currently shown in the output table.")
        toolTipExport.SetToolTip(Me.BtnExport, "Export the output data for import into Synergetic.")

        ' Resize Window
        Me.Width = 621
        Me.Height = 778
        ResizeWindow()
    End Sub


    ' ---------------
    '	SUB MODULES
    ' ---------------

    ' Populate Input Table
    Private Sub PopulateInput(tagList As List(Of Tag))
        Try
            ' Clear Input Table
            DgvInput.Rows.Clear()

            For Each currTag As Tag In tagList
                DgvInput.Rows.Add("")
                With DgvInput.Rows(DgvInput.Rows.Count - 1)
                    .Cells("colInTagID").Value = currTag.AttID
                    .Cells("colInDeviceID").Value = currTag.DeviceID
                    .Cells("colInFirstName").Value = currTag.FirstName
                    .Cells("colInLastName").Value = currTag.LastName
                    .Cells("colInCardID").Value = currTag.CardID
                    .Cells("colInEventID").Value = currTag.EventID
                    .Cells("colInEventName").Value = currTag.Route
                    .Cells("colInLatitude").Value = currTag.Location.Latitude
                    .Cells("colInLongitude").Value = currTag.Location.Longitude
                    .Cells("colInDateTime").Value = currTag.DateAndTime

                    If currTag.ErrorCode > 0 Then
                        .DefaultCellStyle.ForeColor = Style.Colours.ErrorText
                        .DefaultCellStyle.BackColor = Style.Colours.ErrorBackground
                    Else
                        .DefaultCellStyle.ForeColor = Color.Black
                        .DefaultCellStyle.BackColor = Color.White
                    End If
                End With
            Next
        Catch ex As Exception

        End Try
    End Sub

    ' Populate Output Table
    Private Sub PopulateOutput(outputCards As Dictionary(Of String, Card))
        Try
            ' Clear Output Table
            DgvOutput.Rows.Clear()

            ' Check for null input
            For Each currCard As Card In outputCards.Values
                ' Create new row
                DgvOutput.Rows.Add("")
                With DgvOutput.Rows(DgvOutput.Rows.Count - 1)
                    .Cells("colOutDebtorID").Value = currCard.DebtorID
                    .Cells("colOutStudentID").Value = currCard.StudentID
                    .Cells("colOutCardID").Value = currCard.CardID
                    .Cells("colOutFirstName").Value = currCard.FirstName
                    .Cells("colOutLastName").Value = currCard.LastName
                    .Cells("colOutTotal").Value = currCard.GetTotalNoRides
                    .Cells("colOutFare").Value = currCard.TotalFare
                    .Cells("colOutRoutes").Value = currCard.GetRoutes
                    .Cells("colOutAM").Value = currCard.GetNoAMRides
                    .Cells("colOutPM").Value = currCard.GetNoPMRides
                End With
            Next

            ' Sort Table
            DgvOutput.Sort(DgvOutput.Columns.Item("colOutLastName"), System.ComponentModel.ListSortDirection.Ascending)
            DgvOutput.CurrentCell = DgvOutput.Rows(0).Cells(0)
        Catch ex As Exception
            MessageBox.Show(("Error populating output table: " & ex.Message), "Processing Error")
        End Try
    End Sub

    ' Resize Elements to fit Main Window
    Private Sub ResizeWindow()
        ' Input Group Boxes
        grpInput.Width = Me.Width - 40
        grpInput.Height = (Me.Height / 2) - 49

        ' Ouput Group Box
        grpOutput.Width = grpInput.Width
        grpOutput.Height = grpInput.Height
        grpOutput.Top = grpInput.Height + 47

        ' Data Grids
        DgvInput.Width = grpInput.Width - 12
        DgvInput.Height = grpInput.Height - 94
        DgvOutput.Width = DgvInput.Width
        DgvOutput.Height = DgvInput.Height

        ' Process Button
        BtnProcess.Top = grpInput.Height + 18

        ' Progresss Bar
        ProgressBar.Top = BtnProcess.Top

        If Me.Width < 700 Then
            ' Progress Bar
            ProgressBar.Width = Me.Width - 202
            ' Search Text Box
            TxbSearch.Width = grpOutput.Width - 118
            ' Help Button
            BtnHelp.Left = grpInput.Width - 81
        Else
            ProgressBar.Width = 498
            TxbSearch.Width = 542
            BtnHelp.Left = 579
        End If

        ' Clear Button
        BtnClear.Top = BtnProcess.Top
        BtnClear.Left = ProgressBar.Width + 99
    End Sub

    Private Sub ResetSaveDialog()
        Me.SaveFileDialog.Reset()
        Me.SaveFileDialog.Filter = "Comma Seperated Value file (*.csv)|*.csv"
        Me.SaveFileDialog.Title = "Save Output Data"
    End Sub


    ' ----------------------
    '	SHARED SUB MODULES
    ' ----------------------

    Shared Sub SetProgress(value As Integer)
        If value <= FrmMain.ProgressBar.Maximum Then
            FrmMain.ProgressBar.Value = value
        End If
    End Sub
End Class