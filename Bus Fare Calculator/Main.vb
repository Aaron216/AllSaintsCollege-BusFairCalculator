' -------------------------
'	All Saints' College
'	Ewing Ave, Bull Creek
'	Bus Ticketing System
'	Aaron Musgrave
'	14/04/2018
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
		Dim fileName As String
		' Browse to input file
		OpenFileDialog.ShowDialog()
		fileName = OpenFileDialog.FileName
		' Set Wait Cursor and reset progress bar
		Cursor = Cursors.WaitCursor
		' Load Input File
		FileIO.OpenCSV(fileName, DgvInput)
		' Enable Buttons
		BtnProcess.Enabled = True
		BtnClear.Enabled = True
		' Reset Cursor
		Cursor = Cursors.Default
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
			' Process Data
			calculator.Process(DgvInput, (CbxFareCap.SelectedItem = CbxFareCap.Items(1)))
			' Populate Output
			PopulateOutput(calculator.CardMap)
			SetProgress(ProgressBar.Maximum)
			' Enable Buttons
			BtnSave.Enabled = True
			BtnExport.Enabled = True
			TxbSearch.Enabled = True
			CbxFilter.Enabled = True
			' Reset cursor
			Cursor = Cursors.Default
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

	' Populate Output Table
	Private Sub PopulateOutput(outputCards As Dictionary(Of String, Card))
		' Declare Variables
		Dim progressIncrement As Integer = 0

		Try
			' Clear Output Table
			DgvOutput.Rows.Clear()

			' Check for null input
			If outputCards.Count > 0 Then
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
			End If
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

	Shared Sub IncreaseProgress(value As Integer)
		If (FrmMain.ProgressBar.Value + value) < FrmMain.ProgressBar.Maximum Then
			FrmMain.ProgressBar.Value += value
		End If
	End Sub
End Class