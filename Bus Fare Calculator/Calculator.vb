' -------------------------
'	All Saints' College
'	Ewing Ave, Bull Creek
'	Bus Ticketing System
'	Aaron Musgrave
'	23/04/2019
' -------------------------
'	Calculator Class
' -------------------------

Public Class Calculator
    ' Declare Feilds
    Private rideFareVal As Double
    Private fareCapVal As Double
    Private tagListVal As List(Of Tag)
    Private cardMapVal As Dictionary(Of String, Card)


    ' Constructor
    Public Sub New()
        rideFareVal = 0.0
        fareCapVal = 0.0
        tagListVal = New List(Of Tag)
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

    Public Property TagList As List(Of Tag)
        Get
            Return tagListVal
        End Get
        Set(value As List(Of Tag))
            tagListVal = value
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

    ' Create Tags from Input Strings
    Public Sub CreateTags(inputRows As List(Of String()))
        For Each currRow As String() In inputRows
            Dim currTag As New Tag
            currTag.FromString(currRow)
            TagList.Add(currTag)
        Next
    End Sub

    Public Sub Process(fareIsCapped As Boolean)
        Try
            ' Check data has been loaded
            If TagList.Count > 0 Then
                ' Create Cards
                CreateCards()
                FrmMain.SetProgress(100)

                ' Create Rides and Calculate Fare
                CalcRides(fareIsCapped)
                FrmMain.SetProgress(200)
            End If
        Catch ex As OperationCanceledException
            ' Stop work and pass exception upwards
            Throw ex
        Catch ex As Exception
            MessageBox.Show(("Error processing data: " & ex.Message), "Error Processing Error")
        End Try
    End Sub

    Public Sub Clear()
        TagList.Clear()
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
        Dim result As Dictionary(Of String, Card)

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
    Private Sub CreateCards()
        ' Declare Variables
        Dim progress As Double = 0.0
        Dim progressIncrement As Double = 100.0 / TagList.Count
        Dim synergetic As SynergeticLink = New SynergeticLink
        Dim studentRow As DataRow

        Try
            ' Connect to synergetic
            synergetic.Open()
        Catch ex As Exception
            ' Failed to connect to synergetic
            MessageBox.Show("Failed to connect to Synergetic.", "Warning")
        End Try

        Try
            For Each currTag As Tag In TagList
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

                progress += progressIncrement
                FrmMain.SetProgress(progress)
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
        Dim progress As Double = 100.0
        Dim progressIncrement As Double = 100.0 / CardMap.Count
        Dim cardIDArray() As String = CardMap.Keys.ToArray
        Dim currCard As Card

        Try
            For ii As Integer = 0 To cardIDArray.Length - 1
                currCard = CardMap.Item(cardIDArray(ii))
                currCard.CreateRides()
                currCard.CalcFare(RideFare, FareCap, fareIsCapped)
                CardMap.Item(currCard.CardID) = currCard

                progress += progressIncrement
                FrmMain.SetProgress(progress)
            Next
        Catch ex As Exception
            MessageBox.Show(("Error calculating ride fares: " & ex.Message), "Processing Error")
        End Try
    End Sub


    ' ---------------------
    '	PRIVATE FUNCTIONS
    ' ---------------------

    Private Function ConvertToNumber(inString As String, name As String) As Double
        ' Declare Variables
        Dim number As Double

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