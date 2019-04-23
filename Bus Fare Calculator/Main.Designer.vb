<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMain
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMain))
        Me.BtnOpen = New System.Windows.Forms.Button()
        Me.grpInput = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CbxFareCap = New System.Windows.Forms.ComboBox()
        Me.BtnHelp = New System.Windows.Forms.Button()
        Me.DgvInput = New System.Windows.Forms.DataGridView()
        Me.colInTagID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInDeviceID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInFirstName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInLastName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInCardID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInEventID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInEventName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInLatitude = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInLongitude = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInDateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TxbFareCap = New System.Windows.Forms.TextBox()
        Me.lblFare = New System.Windows.Forms.Label()
        Me.TxbRideFare = New System.Windows.Forms.TextBox()
        Me.BtnProcess = New System.Windows.Forms.Button()
        Me.grpOutput = New System.Windows.Forms.GroupBox()
        Me.BtnExport = New System.Windows.Forms.Button()
        Me.LblSearch = New System.Windows.Forms.Label()
        Me.LblFilter = New System.Windows.Forms.Label()
        Me.CbxFilter = New System.Windows.Forms.ComboBox()
        Me.TxbSearch = New System.Windows.Forms.TextBox()
        Me.DgvOutput = New System.Windows.Forms.DataGridView()
        Me.colOutDebtorID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOutStudentID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOutCardID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOutFirstName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOutLastName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOutTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOutFare = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOutRoutes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOutAM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOutPM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.BtnClear = New System.Windows.Forms.Button()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.grpInput.SuspendLayout()
        CType(Me.DgvInput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpOutput.SuspendLayout()
        CType(Me.DgvOutput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnOpen
        '
        Me.BtnOpen.Location = New System.Drawing.Point(6, 19)
        Me.BtnOpen.Name = "BtnOpen"
        Me.BtnOpen.Size = New System.Drawing.Size(75, 23)
        Me.BtnOpen.TabIndex = 1
        Me.BtnOpen.Text = "Open"
        Me.BtnOpen.UseVisualStyleBackColor = True
        '
        'grpInput
        '
        Me.grpInput.Controls.Add(Me.Label2)
        Me.grpInput.Controls.Add(Me.CbxFareCap)
        Me.grpInput.Controls.Add(Me.BtnHelp)
        Me.grpInput.Controls.Add(Me.DgvInput)
        Me.grpInput.Controls.Add(Me.BtnOpen)
        Me.grpInput.Controls.Add(Me.TxbFareCap)
        Me.grpInput.Controls.Add(Me.lblFare)
        Me.grpInput.Controls.Add(Me.TxbRideFare)
        Me.grpInput.Location = New System.Drawing.Point(12, 12)
        Me.grpInput.Name = "grpInput"
        Me.grpInput.Size = New System.Drawing.Size(581, 340)
        Me.grpInput.TabIndex = 2
        Me.grpInput.TabStop = False
        Me.grpInput.Text = "Input Data"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(190, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Fare cap:"
        '
        'CbxFareCap
        '
        Me.CbxFareCap.DisplayMember = "All"
        Me.CbxFareCap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxFareCap.FormattingEnabled = True
        Me.CbxFareCap.Items.AddRange(New Object() {"Not capped", "Capped"})
        Me.CbxFareCap.Location = New System.Drawing.Point(87, 61)
        Me.CbxFareCap.Name = "CbxFareCap"
        Me.CbxFareCap.Size = New System.Drawing.Size(100, 21)
        Me.CbxFareCap.TabIndex = 4
        '
        'BtnHelp
        '
        Me.BtnHelp.Location = New System.Drawing.Point(500, 19)
        Me.BtnHelp.Name = "BtnHelp"
        Me.BtnHelp.Size = New System.Drawing.Size(75, 23)
        Me.BtnHelp.TabIndex = 2
        Me.BtnHelp.Text = "Help"
        Me.BtnHelp.UseVisualStyleBackColor = True
        '
        'DgvInput
        '
        Me.DgvInput.AllowUserToAddRows = False
        Me.DgvInput.AllowUserToDeleteRows = False
        Me.DgvInput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvInput.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInTagID, Me.colInDeviceID, Me.colInFirstName, Me.colInLastName, Me.colInCardID, Me.colInEventID, Me.colInEventName, Me.colInLatitude, Me.colInLongitude, Me.colInDateTime})
        Me.DgvInput.Location = New System.Drawing.Point(6, 88)
        Me.DgvInput.Name = "DgvInput"
        Me.DgvInput.ReadOnly = True
        Me.DgvInput.Size = New System.Drawing.Size(569, 246)
        Me.DgvInput.TabIndex = 6
        '
        'colInTagID
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.colInTagID.DefaultCellStyle = DataGridViewCellStyle1
        Me.colInTagID.HeaderText = "Tag ID"
        Me.colInTagID.Name = "colInTagID"
        Me.colInTagID.ReadOnly = True
        Me.colInTagID.Width = 72
        '
        'colInDeviceID
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.colInDeviceID.DefaultCellStyle = DataGridViewCellStyle2
        Me.colInDeviceID.HeaderText = "Device ID"
        Me.colInDeviceID.Name = "colInDeviceID"
        Me.colInDeviceID.ReadOnly = True
        Me.colInDeviceID.Width = 80
        '
        'colInFirstName
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.colInFirstName.DefaultCellStyle = DataGridViewCellStyle3
        Me.colInFirstName.HeaderText = "First Name"
        Me.colInFirstName.Name = "colInFirstName"
        Me.colInFirstName.ReadOnly = True
        Me.colInFirstName.Width = 128
        '
        'colInLastName
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.colInLastName.DefaultCellStyle = DataGridViewCellStyle4
        Me.colInLastName.HeaderText = "Last Name"
        Me.colInLastName.Name = "colInLastName"
        Me.colInLastName.ReadOnly = True
        Me.colInLastName.Width = 128
        '
        'colInCardID
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.NullValue = Nothing
        Me.colInCardID.DefaultCellStyle = DataGridViewCellStyle5
        Me.colInCardID.HeaderText = "Card ID"
        Me.colInCardID.Name = "colInCardID"
        Me.colInCardID.ReadOnly = True
        Me.colInCardID.Width = 72
        '
        'colInEventID
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.colInEventID.DefaultCellStyle = DataGridViewCellStyle6
        Me.colInEventID.HeaderText = "Event ID"
        Me.colInEventID.Name = "colInEventID"
        Me.colInEventID.ReadOnly = True
        Me.colInEventID.Width = 72
        '
        'colInEventName
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.colInEventName.DefaultCellStyle = DataGridViewCellStyle7
        Me.colInEventName.HeaderText = "Event Name"
        Me.colInEventName.Name = "colInEventName"
        Me.colInEventName.ReadOnly = True
        Me.colInEventName.Width = 96
        '
        'colInLatitude
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.colInLatitude.DefaultCellStyle = DataGridViewCellStyle8
        Me.colInLatitude.HeaderText = "Latitude"
        Me.colInLatitude.Name = "colInLatitude"
        Me.colInLatitude.ReadOnly = True
        Me.colInLatitude.Width = 80
        '
        'colInLongitude
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.colInLongitude.DefaultCellStyle = DataGridViewCellStyle9
        Me.colInLongitude.HeaderText = "Longitude"
        Me.colInLongitude.Name = "colInLongitude"
        Me.colInLongitude.ReadOnly = True
        Me.colInLongitude.Width = 80
        '
        'colInDateTime
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "G"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.colInDateTime.DefaultCellStyle = DataGridViewCellStyle10
        Me.colInDateTime.HeaderText = "Date and Time"
        Me.colInDateTime.Name = "colInDateTime"
        Me.colInDateTime.ReadOnly = True
        Me.colInDateTime.Width = 128
        '
        'TxbFareCap
        '
        Me.TxbFareCap.Enabled = False
        Me.TxbFareCap.Location = New System.Drawing.Point(193, 62)
        Me.TxbFareCap.Name = "TxbFareCap"
        Me.TxbFareCap.Size = New System.Drawing.Size(75, 20)
        Me.TxbFareCap.TabIndex = 5
        Me.TxbFareCap.Text = "$0.00"
        Me.TxbFareCap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFare
        '
        Me.lblFare.AutoSize = True
        Me.lblFare.Location = New System.Drawing.Point(3, 45)
        Me.lblFare.Name = "lblFare"
        Me.lblFare.Size = New System.Drawing.Size(69, 13)
        Me.lblFare.TabIndex = 6
        Me.lblFare.Text = "Fare per ride:"
        '
        'TxbRideFare
        '
        Me.TxbRideFare.Location = New System.Drawing.Point(6, 62)
        Me.TxbRideFare.Name = "TxbRideFare"
        Me.TxbRideFare.Size = New System.Drawing.Size(75, 20)
        Me.TxbRideFare.TabIndex = 3
        Me.TxbRideFare.Text = "$0.00"
        Me.TxbRideFare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnProcess
        '
        Me.BtnProcess.Enabled = False
        Me.BtnProcess.Location = New System.Drawing.Point(12, 358)
        Me.BtnProcess.Name = "BtnProcess"
        Me.BtnProcess.Size = New System.Drawing.Size(75, 23)
        Me.BtnProcess.TabIndex = 7
        Me.BtnProcess.Text = "Process"
        Me.BtnProcess.UseVisualStyleBackColor = True
        '
        'grpOutput
        '
        Me.grpOutput.Controls.Add(Me.BtnExport)
        Me.grpOutput.Controls.Add(Me.LblSearch)
        Me.grpOutput.Controls.Add(Me.LblFilter)
        Me.grpOutput.Controls.Add(Me.CbxFilter)
        Me.grpOutput.Controls.Add(Me.TxbSearch)
        Me.grpOutput.Controls.Add(Me.DgvOutput)
        Me.grpOutput.Controls.Add(Me.BtnSave)
        Me.grpOutput.Location = New System.Drawing.Point(12, 387)
        Me.grpOutput.Name = "grpOutput"
        Me.grpOutput.Size = New System.Drawing.Size(581, 340)
        Me.grpOutput.TabIndex = 4
        Me.grpOutput.TabStop = False
        Me.grpOutput.Text = "Output Data"
        '
        'BtnExport
        '
        Me.BtnExport.Enabled = False
        Me.BtnExport.Location = New System.Drawing.Point(87, 19)
        Me.BtnExport.Name = "BtnExport"
        Me.BtnExport.Size = New System.Drawing.Size(75, 23)
        Me.BtnExport.TabIndex = 10
        Me.BtnExport.Text = "Export"
        Me.BtnExport.UseVisualStyleBackColor = True
        '
        'LblSearch
        '
        Me.LblSearch.AutoSize = True
        Me.LblSearch.Location = New System.Drawing.Point(109, 46)
        Me.LblSearch.Name = "LblSearch"
        Me.LblSearch.Size = New System.Drawing.Size(44, 13)
        Me.LblSearch.TabIndex = 14
        Me.LblSearch.Text = "Search:"
        '
        'LblFilter
        '
        Me.LblFilter.AutoSize = True
        Me.LblFilter.Location = New System.Drawing.Point(3, 45)
        Me.LblFilter.Name = "LblFilter"
        Me.LblFilter.Size = New System.Drawing.Size(46, 13)
        Me.LblFilter.TabIndex = 13
        Me.LblFilter.Text = "Filter by:"
        '
        'CbxFilter
        '
        Me.CbxFilter.DisplayMember = "All"
        Me.CbxFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbxFilter.Enabled = False
        Me.CbxFilter.FormattingEnabled = True
        Me.CbxFilter.Items.AddRange(New Object() {"All", "Linked Only", "Not Linked Only"})
        Me.CbxFilter.Location = New System.Drawing.Point(6, 61)
        Me.CbxFilter.Name = "CbxFilter"
        Me.CbxFilter.Size = New System.Drawing.Size(100, 21)
        Me.CbxFilter.TabIndex = 11
        '
        'TxbSearch
        '
        Me.TxbSearch.Enabled = False
        Me.TxbSearch.Location = New System.Drawing.Point(112, 62)
        Me.TxbSearch.Name = "TxbSearch"
        Me.TxbSearch.Size = New System.Drawing.Size(463, 20)
        Me.TxbSearch.TabIndex = 12
        '
        'DgvOutput
        '
        Me.DgvOutput.AllowUserToAddRows = False
        Me.DgvOutput.AllowUserToDeleteRows = False
        Me.DgvOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvOutput.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colOutDebtorID, Me.colOutStudentID, Me.colOutCardID, Me.colOutFirstName, Me.colOutLastName, Me.colOutTotal, Me.colOutFare, Me.colOutRoutes, Me.colOutAM, Me.colOutPM})
        Me.DgvOutput.Location = New System.Drawing.Point(6, 88)
        Me.DgvOutput.Name = "DgvOutput"
        Me.DgvOutput.ReadOnly = True
        Me.DgvOutput.Size = New System.Drawing.Size(569, 246)
        Me.DgvOutput.TabIndex = 13
        '
        'colOutDebtorID
        '
        Me.colOutDebtorID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colOutDebtorID.DefaultCellStyle = DataGridViewCellStyle11
        Me.colOutDebtorID.HeaderText = "Debtor ID"
        Me.colOutDebtorID.Name = "colOutDebtorID"
        Me.colOutDebtorID.ReadOnly = True
        Me.colOutDebtorID.Width = 80
        '
        'colOutStudentID
        '
        Me.colOutStudentID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.NullValue = Nothing
        Me.colOutStudentID.DefaultCellStyle = DataGridViewCellStyle12
        Me.colOutStudentID.HeaderText = "Student ID"
        Me.colOutStudentID.Name = "colOutStudentID"
        Me.colOutStudentID.ReadOnly = True
        Me.colOutStudentID.Width = 84
        '
        'colOutCardID
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.NullValue = Nothing
        Me.colOutCardID.DefaultCellStyle = DataGridViewCellStyle13
        Me.colOutCardID.HeaderText = "Card ID"
        Me.colOutCardID.Name = "colOutCardID"
        Me.colOutCardID.ReadOnly = True
        Me.colOutCardID.Width = 72
        '
        'colOutFirstName
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.colOutFirstName.DefaultCellStyle = DataGridViewCellStyle14
        Me.colOutFirstName.HeaderText = "First Name"
        Me.colOutFirstName.Name = "colOutFirstName"
        Me.colOutFirstName.ReadOnly = True
        Me.colOutFirstName.Width = 128
        '
        'colOutLastName
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.colOutLastName.DefaultCellStyle = DataGridViewCellStyle15
        Me.colOutLastName.HeaderText = "Last Name"
        Me.colOutLastName.Name = "colOutLastName"
        Me.colOutLastName.ReadOnly = True
        Me.colOutLastName.Width = 128
        '
        'colOutTotal
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.Format = "N0"
        DataGridViewCellStyle16.NullValue = Nothing
        Me.colOutTotal.DefaultCellStyle = DataGridViewCellStyle16
        Me.colOutTotal.HeaderText = "Total Rides"
        Me.colOutTotal.Name = "colOutTotal"
        Me.colOutTotal.ReadOnly = True
        Me.colOutTotal.Width = 88
        '
        'colOutFare
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle17.Format = "C2"
        DataGridViewCellStyle17.NullValue = Nothing
        Me.colOutFare.DefaultCellStyle = DataGridViewCellStyle17
        Me.colOutFare.HeaderText = "Total Fare"
        Me.colOutFare.Name = "colOutFare"
        Me.colOutFare.ReadOnly = True
        Me.colOutFare.Width = 80
        '
        'colOutRoutes
        '
        Me.colOutRoutes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.colOutRoutes.DefaultCellStyle = DataGridViewCellStyle18
        Me.colOutRoutes.HeaderText = "Routes"
        Me.colOutRoutes.Name = "colOutRoutes"
        Me.colOutRoutes.ReadOnly = True
        '
        'colOutAM
        '
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle19.Format = "N0"
        DataGridViewCellStyle19.NullValue = Nothing
        Me.colOutAM.DefaultCellStyle = DataGridViewCellStyle19
        Me.colOutAM.HeaderText = "AM Rides"
        Me.colOutAM.Name = "colOutAM"
        Me.colOutAM.ReadOnly = True
        Me.colOutAM.Width = 80
        '
        'colOutPM
        '
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle20.Format = "N0"
        DataGridViewCellStyle20.NullValue = Nothing
        Me.colOutPM.DefaultCellStyle = DataGridViewCellStyle20
        Me.colOutPM.HeaderText = "PM Rides"
        Me.colOutPM.Name = "colOutPM"
        Me.colOutPM.ReadOnly = True
        Me.colOutPM.Width = 80
        '
        'BtnSave
        '
        Me.BtnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnSave.Enabled = False
        Me.BtnSave.Location = New System.Drawing.Point(6, 19)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 9
        Me.BtnSave.Text = "Save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.Filter = "Comma Seperated Value file (*.csv)|*.csv"
        Me.OpenFileDialog.Title = "Open Input Data"
        '
        'SaveFileDialog
        '
        Me.SaveFileDialog.Filter = "Comma Seperated Value file (*.csv)|*.csv"
        Me.SaveFileDialog.Title = "Save Output Data"
        '
        'BtnClear
        '
        Me.BtnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClear.Enabled = False
        Me.BtnClear.Location = New System.Drawing.Point(518, 358)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(75, 23)
        Me.BtnClear.TabIndex = 8
        Me.BtnClear.Text = "Clear"
        Me.BtnClear.UseVisualStyleBackColor = True
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(93, 358)
        Me.ProgressBar.Maximum = 300
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(419, 23)
        Me.ProgressBar.Step = 1
        Me.ProgressBar.TabIndex = 16
        '
        'FrmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(605, 690)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.BtnClear)
        Me.Controls.Add(Me.grpOutput)
        Me.Controls.Add(Me.BtnProcess)
        Me.Controls.Add(Me.grpInput)
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(312, 408)
        Me.Name = "FrmMain"
        Me.Text = "Bus Fare Calculator"
        Me.grpInput.ResumeLayout(False)
        Me.grpInput.PerformLayout()
        CType(Me.DgvInput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpOutput.ResumeLayout(False)
        Me.grpOutput.PerformLayout()
        CType(Me.DgvOutput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnOpen As Button
	Friend WithEvents grpInput As GroupBox
	Friend WithEvents BtnProcess As Button
	Friend WithEvents grpOutput As GroupBox
	Friend WithEvents BtnSave As Button
	Friend WithEvents DgvInput As DataGridView
	Friend WithEvents DgvOutput As DataGridView
	Friend WithEvents OpenFileDialog As OpenFileDialog
	Friend WithEvents SaveFileDialog As SaveFileDialog
	Friend WithEvents colInTagID As DataGridViewTextBoxColumn
	Friend WithEvents colInDeviceID As DataGridViewTextBoxColumn
	Friend WithEvents colInFirstName As DataGridViewTextBoxColumn
	Friend WithEvents colInLastName As DataGridViewTextBoxColumn
	Friend WithEvents colInCardID As DataGridViewTextBoxColumn
	Friend WithEvents colInEventID As DataGridViewTextBoxColumn
	Friend WithEvents colInEventName As DataGridViewTextBoxColumn
	Friend WithEvents colInLatitude As DataGridViewTextBoxColumn
	Friend WithEvents colInLongitude As DataGridViewTextBoxColumn
	Friend WithEvents colInDateTime As DataGridViewTextBoxColumn
	Friend WithEvents TxbSearch As TextBox
	Friend WithEvents BtnClear As Button
	Friend WithEvents CbxFilter As ComboBox
	Friend WithEvents LblFilter As Label
	Friend WithEvents LblSearch As Label
	Friend WithEvents ProgressBar As ProgressBar
	Friend WithEvents BtnHelp As Button
	Friend WithEvents BtnExport As Button
	Friend WithEvents Label2 As Label
	Friend WithEvents CbxFareCap As ComboBox
	Friend WithEvents TxbFareCap As TextBox
	Friend WithEvents lblFare As Label
	Friend WithEvents TxbRideFare As TextBox
	Friend WithEvents colOutDebtorID As DataGridViewTextBoxColumn
	Friend WithEvents colOutStudentID As DataGridViewTextBoxColumn
	Friend WithEvents colOutCardID As DataGridViewTextBoxColumn
	Friend WithEvents colOutFirstName As DataGridViewTextBoxColumn
	Friend WithEvents colOutLastName As DataGridViewTextBoxColumn
	Friend WithEvents colOutTotal As DataGridViewTextBoxColumn
	Friend WithEvents colOutFare As DataGridViewTextBoxColumn
	Friend WithEvents colOutRoutes As DataGridViewTextBoxColumn
	Friend WithEvents colOutAM As DataGridViewTextBoxColumn
	Friend WithEvents colOutPM As DataGridViewTextBoxColumn
End Class
