' -------------------------
'	All Saints' College
'	Ewing Ave, Bull Creek
'	Bus Ticketing System
'	Aaron Musgrave
'	14/04/2018
' -------------------------
'	Calculator Class
' -------------------------

Public Class Calculator
	' Declare Feilds
	Private rideFareVal As Double
	Private fareCapVal As Double
	Private cardMapVal As Dictionary(Of String, Card)

	' Constructor
	Public Sub New()
		rideFareVal = 0.0
		fareCapVal = 0.0
		cardMapVal = New Dictionary(Of String, Card)
	End Sub


	' --------------
	'	PROPERTIES
	' --------------

	Public Property RideFare As Double
		Get
			Return rideFareVal
		End Get
		Set(value As Double)
			If value >= 0.0 Then
				rideFareVal = value
			Else
				Throw New ArgumentException("Ride fare must be a positive number")
			End If
		End Set
	End Property

	Public Property FareCap As Double
		Get
			Return fareCapVal
		End Get
		Set(value As Double)
			If value >= 0.0 Then
				fareCapVal = value
			Else
				Throw New ArgumentException("Fare cap must be a positive number")
			End If
		End Set
	End Property

	Public Property CardMap As Dictionary(Of String, Card)
		Get
			Return cardMapVal
		End Get
		Set(value As Dictionary(Of String, Card))
			cardMapVal = value
		End Set
	End Property


	' ---------------
	'	SUB MODULES
	' ---------------

	Public Sub Process(inputTable As DataGridView, fareIsCapped As Boolean)
		' Create Variables
		Dim tagList As New List(Of Tag)

		Try
			' Check data has been loaded
			If inputTable.Rows.Count > 0 Then
				FrmMain.SetProgress(100)

				' Create Tags
				tagList = CreateTags(inputTable)
				FrmMain.SetProgress(200)

				' Create Cards
				CreateCards(tagList)
				FrmMain.SetProgress(300)

				' Create Rides and Calculate Fare
				CalcRides(fareIsCapped)
				FrmMain.SetProgress(400)
			End If
		Catch ex As Exception
			MessageBox.Show(("Error processing data: " & ex.Message), "Error Processing Error")
		End Try
	End Sub

	Public Sub Clear()
		CardMap.Clear()
	End Sub

	Public Sub UpdateRideFare(inRideFare As String)
		RideFare = ConvertToNumber(inRideFare, "Ride fare")
	End Sub

	Public Sub UpdateFareCap(inFareCap As String)
		FareCap = ConvertToNumber(inFareCap, "Fare cap")
	End Sub


	' -------------
	'	FUNCTIONS
	' -------------

	' Filter and Search
	Public Function FilterAndSearch(filterObj As Object, search As String) As Dictionary(Of String, Card)
		Dim result As New Dictionary(Of String, Card)

		' Filter
		result = FilterCards(filterObj)

		' Search
		If Not String.IsNullOrWhiteSpace(search) Then
			result = SearchCards(search, result)
		End If

		Return result
	End Function


	' ----------------
	'	PRIVATE SUBS
	' ----------------

	' Create Card Objects from Tag List
	Private Sub CreateCards(tagList As List(Of Tag))
		' Declare Variables
		Dim progressIncrement As Integer = 100 / tagList.Count
		Dim synergetic As SynergeticLink = New SynergeticLink
		Dim studentRow As DataRow
		Dim connectedToSynergetic As Boolean = False

		Try
			' Connect to synergetic
			synergetic.Open()
			connectedToSynergetic = True
		Catch ex As Exception
			' Failed to connect to synergetic
			MessageBox.Show("Failed to connect to Synergetic.", "Warning")
		End Try

		Try
			For Each currTag As Tag In tagList
				Dim currCard As New Card
				If CardMap.ContainsKey(currTag.CardID) Then
					' Card already exists
					currCard = CardMap.Item(currTag.CardID)
					' Add tag to card
					currCard.AddTag(currTag)
					' Update card in map
					CardMap.Item(currCard.CardID) = currCard
				Else
					' Create new card
					currCard.FromTag(currTag)
					' Get synergetic data
					If synergetic.Connected Then
						studentRow = synergetic.GetStudentRow(currCard.CardID)
						currCard.AddSynergeticData(studentRow)
					End If
					' Add tag to card
					currCard.AddTag(currTag)
					' Add card to map
					CardMap.Add(currCard.CardID, currCard)
				End If

				FrmMain.IncreaseProgress(progressIncrement)
			Next
		Catch ex As Exception
			MessageBox.Show(("Error creating card objects: " & ex.Message), "Processing Error")
		Finally
			'Close synergetic connection
			synergetic.Close()
		End Try
	End Sub

	' Calculate Rides and Fares from Tag List
	Private Sub CalcRides(fareIsCapped As Boolean)
		' Declare Variables
		Dim progressIncrement As Integer = 100 / CardMap.Count
		Dim cardIDArray() As String = CardMap.Keys.ToArray
		Dim currCard As New Card

		Try
			For ii As Integer = 0 To cardIDArray.Length - 1
				currCard = CardMap.Item(cardIDArray(ii))
				currCard.CreateRides()
				currCard.CalcFare(RideFare, FareCap, fareIsCapped)
				CardMap.Item(currCard.CardID) = currCard
				FrmMain.IncreaseProgress(progressIncrement)
			Next
		Catch ex As Exception
			MessageBox.Show(("Error calculating ride fares: " & ex.Message), "Processing Error")
		End Try
	End Sub


	' ---------------------
	'	PRIVATE FUNCTIONS
	' ---------------------

	' Create Tag List from Input Table
	Private Function CreateTags(inputTable As DataGridView) As List(Of Tag)
		' Declare Variables
		Dim progressIncrement As Integer = 100 / inputTable.Rows.Count
		Dim tagList As New List(Of Tag)

		For Each currRow As DataGridViewRow In inputTable.Rows
			Dim currTag As New Tag
			currTag.FromRow(currRow)
			tagList.Add(currTag)
			FrmMain.IncreaseProgress(progressIncrement)
		Next

		Return tagList
	End Function

	Private Function ConvertToNumber(inString As String, name As String) As Double
		' Declare Variables
		Dim number As Double = 0.0

		' Remove dollar sign
		inString = inString.TrimStart("$")

		' Check if numeric
		If Not String.IsNullOrWhiteSpace(inString) And IsNumeric(inString) Then
			number = Double.Parse(inString)
		Else
			MessageBox.Show((name & " must be a number. Please try again."), "Input Error")
			number = 0.0
		End If

		' Check if negative
		If number < 0.0 Then
			' Negative Number
			MessageBox.Show((name & " must be a positive number. Please try again."), "Input Error")
			number = 0.0
		End If

		Return number
	End Function

	' Search Card Map
	Private Function SearchCards(search As String, inCards As Dictionary(Of String, Card)) As Dictionary(Of String, Card)
		' Declare Variables
		Dim result As New Dictionary(Of String, Card)

		' Check that cardmap is not empty
		If inCards.Count > 0 Then
			' Search card map
			For Each currCard As Card In inCards.Values
				If currCard.Contains(search) Then
					' Add to search results
					result.Add(currCard.CardID, currCard)
				End If
			Next
		End If

		Return result
	End Function

	' Filter Card Map
	Private Function FilterCards(filterObject As Object) As Dictionary(Of String, Card)
		Dim filter As String = filterObject.ToString
		Dim result As New Dictionary(Of String, Card)

		' Check that cardmap is not empty
		If CardMap.Count > 0 Then
			Select Case filter
				Case "All"
					result = CardMap
				Case "Linked Only"
					For Each currCard As Card In CardMap.Values
						If currCard.FoundInSynergetic Then
							result.Add(currCard.CardID, currCard)
						End If
					Next
				Case "Not Linked Only"
					For Each currCard As Card In CardMap.Values
						If Not currCard.FoundInSynergetic Then
							result.Add(currCard.CardID, currCard)
						End If
					Next
				Case Else
					result = CardMap
			End Select
		End If

		Return result
	End Function
End Class