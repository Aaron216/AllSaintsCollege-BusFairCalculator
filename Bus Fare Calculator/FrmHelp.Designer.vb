<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHelp
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> _
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
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Me.RtbHelp = New System.Windows.Forms.RichTextBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.SuspendLayout()
		'
		'RtbHelp
		'
		Me.RtbHelp.BackColor = System.Drawing.SystemColors.ControlLightLight
		Me.RtbHelp.Location = New System.Drawing.Point(12, 25)
		Me.RtbHelp.Name = "RtbHelp"
		Me.RtbHelp.ReadOnly = True
		Me.RtbHelp.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
		Me.RtbHelp.Size = New System.Drawing.Size(350, 167)
		Me.RtbHelp.TabIndex = 1
		Me.RtbHelp.Text = ""
		Me.RtbHelp.WordWrap = False
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(12, 9)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(217, 13)
		Me.Label1.TabIndex = 2
		Me.Label1.Text = "To get import data please follow these steps:"
		'
		'FrmHelp
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(376, 202)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.RtbHelp)
		Me.MaximumSize = New System.Drawing.Size(392, 241)
		Me.MinimumSize = New System.Drawing.Size(392, 241)
		Me.Name = "FrmHelp"
		Me.Text = "Bus Fare Calculator Help"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents RtbHelp As RichTextBox
	Friend WithEvents Label1 As Label
End Class
