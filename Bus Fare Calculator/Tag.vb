' -------------------------
'	All Saints' College
'	Ewing Ave, Bull Creek
'	Bus Ticketing System
'	Aaron Musgrave
'	23/04/2019
' -------------------------
'	Tag Object Class
' -------------------------

Public Class Tag
    ' Declare Feilds
    Private attIDVal As Integer
    Private deviceIDVal As Integer
    Private firstNameVal As String
    Private lastNameVal As String
    Private cardIDVal As String
    Private eventIDVal As Integer
    Private routeVal As String
    Private locationVal As Location
    Private dateAndTimeVal As Date
    Private errorCodeVal As Integer

    ' Constructors
    Public Sub New()
        attIDVal = 0
        deviceIDVal = 0
        firstNameVal = ""
        lastNameVal = ""
        cardIDVal = ""
        eventIDVal = 0
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
                attIDVal = 0
                ErrorCode += 1
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
                firstNameVal = ""
                ErrorCode += 1
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
                lastNameVal = ""
                ErrorCode += 1
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
                cardIDVal = 0
                ErrorCode += 1
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
                routeVal = ""
                ErrorCode += 1
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

    Public Property DeviceID As Integer
        Get
            Return deviceIDVal
        End Get
        Set(value As Integer)
            deviceIDVal = value
        End Set
    End Property

    Public Property EventID As Integer
        Get
            Return eventIDVal
        End Get
        Set(value As Integer)
            eventIDVal = value
        End Set
    End Property

    Public Property ErrorCode As Integer
        Get
            Return errorCodeVal
        End Get
        Set(value As Integer)
            errorCodeVal = value
        End Set
    End Property


    ' ---------------
    '	SUB MODULES
    ' ---------------

    Public Sub FromString(inParts As String())
        ' inParts Format
        '   0: Att ID
        '   1: Device ID
        '   2: First Name
        '   3: Last Name
        '   4: Card ID
        '   5: Event ID
        '   6: Event Name
        '   7: Latitude
        '   8: Longitude
        '   9: Date and Time

        Try
            AttID = Integer.Parse(inParts(0))
            DeviceID = Integer.Parse(inParts(1))

            ' Check for driver's card
            If inParts(2).Contains("DRIVER") And inParts(3).Contains("CARD") Then
                FirstName = inParts(6)
                LastName = "Driver"
            Else
                FirstName = inParts(2)
                LastName = inParts(3)
            End If

            CardID = inParts(4)
            EventID = Integer.Parse(inParts(5))

            ' Check route name
            Route = inParts(6)
            If Route.EndsWith(" Bus") Then
                Route = Route.Substring(0, Route.Length - 4)
            End If

            Location.AddDetails(inParts(7), inParts(8))
            DateAndTime = Date.Parse(inParts(9))
        Catch ex As Exception
            Dim message As String
            Dim buttons As MessageBoxButtons
            Dim response As DialogResult

            message =
                "Error creating tag: " & ex.Message & vbNewLine &
                vbTab & "AttID: " & inParts(0) & vbNewLine &
                vbTab & "DeviceID: " & inParts(1) & vbNewLine &
                vbTab & "Name: " & inParts(2) & " " & inParts(3) & vbNewLine &
                vbTab & "Card ID: " & inParts(4) & vbNewLine &
                vbTab & "Event ID: " & inParts(5) & vbNewLine &
                vbTab & "Route: " & inParts(6) & vbNewLine &
                vbTab & "Location: " & inParts(7) & ", " & inParts(8) & vbNewLine &
                vbTab & "Time and date: " & inParts(9)
            buttons = vbOKCancel
            response = MessageBox.Show(message, "Processing Error", buttons)

            If response = vbCancel Then
                Throw New OperationCanceledException
            End If
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
