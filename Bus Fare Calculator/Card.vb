' -------------------------
'	All Saints' College
'	Ewing Ave, Bull Creek
'	Bus Ticketing System
'	Aaron Musgrave
'	14/04/2018
' -------------------------
'	Card Object Class
' -------------------------

Imports Bus_Fare_Calculator

Public Class Card : Implements IComparable
    ' Declare Feilds
    Private debtorIDVal As String
    Private studentIDVal As String
    Private cardIDVal As String
    Private firstNameVal As String
    Private lastNameVal As String
    Private totalFareVal As Double
    Private foundInSynergeticVal As Boolean

    Private routesVal As List(Of String)
    Private amTags As List(Of Tag)
    Private pmTags As List(Of Tag)

    Private amRides As Dictionary(Of Integer, Ride)
    Private pmRides As Dictionary(Of Integer, Ride)

    ' Constructor
    Public Sub New()
        debtorIDVal = "-"
        studentIDVal = "-"
        cardIDVal = ""
        firstNameVal = ""
        lastNameVal = ""
        totalFareVal = 0.0
        foundInSynergeticVal = False
        routesVal = New List(Of String)
        amTags = New List(Of Tag)
        pmTags = New List(Of Tag)
        amRides = New Dictionary(Of Integer, Ride)
        pmRides = New Dictionary(Of Integer, Ride)
    End Sub


    ' --------------
    '	PROPERTIES
    ' --------------

    Public Property DebtorID() As String
        Get
            Return debtorIDVal
        End Get
        Set(value As String)
            If value = Nothing Then
                Throw New ArgumentNullException("Debtor ID cannot be null")
            Else
                debtorIDVal = value
            End If
        End Set
    End Property

    Public Property StudentID() As String
        Get
            Return studentIDVal
        End Get
        Set(value As String)
            If value = Nothing Then
                Throw New ArgumentNullException("Student ID cannot be null")
            Else
                studentIDVal = value
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

    Public Property TotalFare() As Double
        Get
            Return totalFareVal
        End Get
        Set(value As Double)
            If value < 0.0 Then
                Throw New ArgumentOutOfRangeException("Total Fare must be a positive real number.")
            Else
                totalFareVal = value
            End If
        End Set
    End Property

    Public Property FoundInSynergetic() As Boolean
        Get
            Return foundInSynergeticVal
        End Get
        Set(value As Boolean)
            If String.IsNullOrWhiteSpace(DebtorID) Or String.IsNullOrWhiteSpace(StudentID) Then
                ' Synergetic connection has not been established
                Throw New ArgumentException("Found in synergetic value cannot be set while DebtorID or StudentID is empty.")
            Else
                foundInSynergeticVal = value
            End If
        End Set
    End Property

    Public Property Routes() As List(Of String)
        Get
            Return routesVal
        End Get
        Set(value As List(Of String))
            routesVal = value
        End Set
    End Property


    ' -------------
    '	FUNCTIONS
    ' -------------

    Public Function GetTotalNoRides() As Integer
        Return amRides.Count + pmRides.Count
    End Function

    Public Function GetNoAMRides() As Integer
        Return amRides.Count
    End Function

    Public Function GetNoPMRides() As Integer
        Return pmRides.Count
    End Function

    ' Returns string of routes seperated by '&'
    Public Function GetRoutes() As String
        ' Declar Variables
        Dim routeString As String = ""

        ' Sort routes list
        Routes.Sort()

        routeString = Routes.Item(0)
        For ii = 1 To (Routes.Count - 1)
            routeString += " & " & Routes.Item(ii)
        Next

        Return routeString
    End Function

    Public Function Contains(inSearch As String) As Boolean
        ' Declare Variables
        Dim result As Boolean = False

        result =
            DebtorID.StartsWith(inSearch) Or
            StudentID.StartsWith(inSearch) Or
            CardID.StartsWith(inSearch) Or
            FirstName.ToLower.StartsWith(inSearch.ToLower) Or
            LastName.ToLower.StartsWith(inSearch.ToLower)

        Return result
    End Function

    Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        ' Declare Variables
        Dim inCard As Card = CType(obj, Card)
        Dim result As Integer

        ' Compare Last Names
        result = Me.LastName.CompareTo(inCard.LastName)

        If result = 0 Then
            ' Compare First First Names
            result = Me.FirstName.CompareTo(inCard.FirstName)

            If result = 0 Then
                ' Compare Card IDs
                result = Me.CardID.CompareTo(inCard.CardID)
            End If
        End If

        ' Return result
        Return result
    End Function


    ' ---------------
    '	SUB MODULES
    ' ---------------

    Public Sub FromTag(inTag As Tag)
        CardID = inTag.CardID
        FirstName = inTag.FirstName
        LastName = inTag.LastName
    End Sub

    Public Sub AddTag(inTag As Tag)
        If inTag.IsMorning() Then
            amTags.Add(inTag)
        Else
            pmTags.Add(inTag)
        End If
    End Sub

    Public Sub CreateRides()
        ' Declare Variables
        Dim dayCode As Integer
        Dim currRide

        Try
            ' AM Tags
            For Each currTag In amTags
                dayCode = currTag.GetDayCode()
                If amRides.ContainsKey(dayCode) Then
                    ' Ride already exists
                    currRide = amRides.Item(dayCode)
                    currRide.TagOff(currTag)
                    amRides.Item(currRide.DayCode) = currRide
                Else
                    currRide = New Ride
                    currRide.TagOn(currTag)
                    amRides.Add(currRide.DayCode, currRide)
                End If

                ' Add route to list
                If Not Routes.Contains(currTag.Route) Then
                    Routes.Add(currTag.Route)
                End If
            Next

            ' PM Tags
            For Each currTag In pmTags
                dayCode = currTag.GetDayCode()
                If pmRides.ContainsKey(dayCode) Then
                    ' Ride already exists
                    currRide = pmRides.Item(dayCode)
                    currRide.TagOff(currTag)
                    pmRides.Item(currRide.DayCode) = currRide
                Else
                    currRide = New Ride
                    currRide.TagOn(currTag)
                    pmRides.Add(currRide.DayCode, currRide)
                End If

                ' Add route to list
                If Not Routes.Contains(currTag.Route) Then
                    Routes.Add(currTag.Route)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(("Error generating ride list for card number " & CardID), "Processing Error")
        End Try
    End Sub

    Public Sub CalcFare(rideFare As Double, fareCap As Double, fareIsCapped As Boolean)
        If (rideFare < 0) Or (fareCap < 0) Then
            Throw New ArgumentOutOfRangeException("Ride fare and fare cap must both be positive integers.")
        Else
            TotalFare = GetTotalNoRides() * rideFare
            If (TotalFare > fareCap) And fareIsCapped Then
                TotalFare = fareCap
            End If
        End If
    End Sub

    Public Sub AddSynergeticData(studentRow As DataRow)
        ' Check for errors
        If Not studentRow.HasErrors Then
            DebtorID = studentRow.Item("DebtorID")
            StudentID = studentRow.Item("StudentID")
            FirstName = studentRow.Item("StudentPreferred")
            LastName = studentRow.Item("StudentSurname")
            FoundInSynergetic = True
        End If
    End Sub
End Class