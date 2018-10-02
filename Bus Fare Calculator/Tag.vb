' -------------------------
'	All Saints' College
'	Ewing Ave, Bull Creek
'	Bus Ticketing System
'	Aaron Musgrave
'	30/03/2018
' -------------------------
'	Tag Object Class
' -------------------------

Public Class Tag
	' Declare Feilds
	Private attIDVal As Integer
	Private firstNameVal As String
	Private lastNameVal As String
	Private cardIDVal As String
	Private routeVal As String
	Private locationVal As Location
	Private dateAndTimeVal As DateTime

	' Constructors
	Public Sub New()
		attIDVal = 0
		firstNameVal = ""
		lastNameVal = ""
		cardIDVal = ""
		locationVal = New Location
		dateAndTimeVal = New DateTime
	End Sub


	' --------------
	'	PROPERTIES
	' --------------

	Public Property AttID() As Integer
		Get
			Return attIDVal
		End Get
		Set(value As Integer)
			If value <= 0 Then
				Throw New ArgumentOutOfRangeException("AttID must be positive.")
			Else
				attIDVal = value
			End If
		End Set
	End Property


	Public Property FirstName() As String
		Get
			Return firstNameVal
		End Get
		Set(value As String)
			If value Is String.Empty Then
				Throw New ArgumentNullException("First name cannot be empty.")
			Else
				firstNameVal = value
			End If
		End Set
	End Property

	Public Property LastName() As String
		Get
			Return lastNameVal
		End Get
		Set(value As String)
			If value Is String.Empty Then
				Throw New ArgumentNullException("Last name cannot be empty.")
			Else
				lastNameVal = value
			End If
		End Set
	End Property

	Public Property CardID() As String
		Get
			Return cardIDVal
		End Get
		Set(value As String)
			If value Is String.Empty Then
				Throw New ArgumentNullException("Card ID cannot be empty.")
			Else
				cardIDVal = value
			End If
		End Set
	End Property

	Public Property Route() As String
		Get
			Return routeVal
		End Get
		Set(value As String)
			If value Is String.Empty Then
				Throw New ArgumentNullException("Route name cannot be empty.")
			Else
				routeVal = value
			End If
		End Set
	End Property

	Public Property Location() As Location
		Get
			Return locationVal
		End Get
		Set(value As Location)
			locationVal = value
		End Set
	End Property

	Public Property DateAndTime() As Date
		Get
			Return dateAndTimeVal
		End Get
		Set(value As Date)
			dateAndTimeVal = value
		End Set
	End Property


	' ---------------
	'	SUB MODULES
	' ---------------

	' NOT USED
	Private Sub FromString(parts() As String)
		AttID() = parts(0)

		' Check for Driver's card
		If parts(2).Contains("DRIVER") And parts(2).Contains("CARD") Then
			FirstName() = parts(6)
			LastName() = "Driver"
		Else
			FirstName() = parts(2)
			LastName() = parts(3)
		End If

		CardID() = parts(4)
		Route() = parts(6).TrimEnd(" Bus")
		locationVal.AddDetails(parts(7), parts(8))
		dateAndTimeVal = DateTime.Parse(parts(9))
	End Sub

	Private Sub FromRowOld(inRow As DataGridViewRow)
		' Declare Variables
		Dim cellCollection As DataGridViewCellCollection = inRow.Cells
		Dim noCells As Integer = cellCollection.Count
		Dim parts(noCells) As String
		Try
			' Convert each cell to part in array of strings
			For ii As Integer = 0 To noCells - 1
				parts(ii) = cellCollection.Item(ii).Value.ToString
			Next
		Catch ex As Exception
			MessageBox.Show(("Error creating tag list: " & ex.Message), "Processing Error")
		End Try

		' Call from string
		FromString(parts)
	End Sub

	Public Sub FromRow(inRow As DataGridViewRow)
		' Declare Variables
		Dim cells As DataGridViewCellCollection = inRow.Cells
		Try
			AttID = Integer.Parse(cells("colInTagID").Value)

			' Check for driver's card
			If cells("colInFirstName").Value.Contains("DRIVER") And cells("colInFirstName").Value.contains("CARD") Then
				FirstName = cells("colInEventName").Value
				LastName = "Driver"
			Else
				FirstName = cells("colInFirstName").Value
				LastName = cells("colInLastName").Value
			End If

			CardID = cells("colInCardID").Value

			' Check route name
			Route = cells("colInEventName").Value
			If Route.EndsWith(" Bus") Then
				Route = Route.Substring(0, Route.Length - 4)
			End If

			Location.AddDetails(cells("colInLatitude").Value, cells("colInLongitude").Value)
			DateAndTime = DateTime.Parse(cells("colInDateTime").Value)
		Catch ex As Exception
			MessageBox.Show(("Error creating tag list: " & ex.Message), "Processing Error")
		End Try
	End Sub

	' -------------
	'	FUNCTIONS
	' -------------

	Public Function IsMorning() As Boolean
		Return (DateAndTime.Hour < 12)
	End Function

	Public Function GetDayCode() As Integer
		' Returns Number of days since 01/01/2000
		Return (DateAndTime.Date - New DateTime(2000, 1, 1, 0, 0, 0)).TotalDays
	End Function
End Class
