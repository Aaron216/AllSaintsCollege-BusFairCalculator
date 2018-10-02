' -------------------------
'	All Saints' College
'	Ewing Ave, Bull Creek
'	Bus Ticketing System
'	Aaron Musgrave
'	13/04/2018
' -------------------------
'	Ride Object Class
' -------------------------

Imports Bus_Fare_Calculator

Public Class Ride
	' Declare Feilds
	Private dayCodeVal As Integer
	Private noTagsVal As Integer
	Private originVal As Location
	Private destinationVal As Location
	Private startTimeVal As DateTime
	Private endTimeVal As DateTime

	' Constructor
	Public Sub New()
		dayCodeVal = 0
		noTagsVal = 0
		originVal = New Location
		destinationVal = New Location
		startTimeVal = New DateTime
		endTimeVal = New DateTime
	End Sub


	' --------------
	'	PROPERTIES
	' --------------

	Public Property DayCode() As Integer
		Get
			Return dayCodeVal
		End Get
		Set(value As Integer)
			dayCodeVal = value
		End Set
	End Property

	Public Property NoTags() As Integer
		Get
			Return noTagsVal
		End Get
		Set(value As Integer)
			noTagsVal = value
		End Set
	End Property

	Public Property Origin() As Location
		Get
			Return originVal
		End Get
		Set(value As Location)
			originVal = value
		End Set
	End Property

	Public Property Destination() As Location
		Get
			Return destinationVal
		End Get
		Set(value As Location)
			destinationVal = value
		End Set
	End Property

	Public Property StartTime() As Date
		Get
			Return startTimeVal
		End Get
		Set(value As Date)
			startTimeVal = value
		End Set
	End Property

	Public Property EndTime() As Date
		Get
			Return endTimeVal
		End Get
		Set(value As Date)
			endTimeVal = value
		End Set
	End Property


	' -------------
	'	FUNCTIONS
	' -------------

	Public Sub TagOn(inTag As Tag)
		DayCode = inTag.GetDayCode
		NoTags += 1
		Origin = inTag.Location
		StartTime = inTag.DateAndTime
	End Sub

	Public Sub TagOff(inTag As Tag)
		NoTags += 1
		Destination = inTag.Location
		EndTime = inTag.DateAndTime
	End Sub
End Class
