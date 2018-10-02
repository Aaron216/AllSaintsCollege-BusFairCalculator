' -------------------------
'	All Saints' College
'	Ewing Ave, Bull Creek
'	Bus Ticketing System
'	Aaron Musgrave
' -------------------------
'	Location Object Class
' -------------------------

Public Class Location
	' Declare Constants
	Private Const MaxLatitude As Double = 90.0
	Private Const MaxLongitude As Double = 180.0

	' Declare Feilds
	Private knownVal As Boolean
	Private latitudeVal As Double
	Private longitudeVal As Double

	' Constructor
	Public Sub New()
		knownVal = False
		latitudeVal = 0.0
		longitudeVal = 0.0
	End Sub

	' Properties
	Public Property Latitude() As Double
		Get
			Return latitudeVal
		End Get
		Set(value As Double)
			If Math.Abs(value) > MaxLatitude Then
				Throw New ArgumentOutOfRangeException("Latitude must be a real number between -90 and +90 degrees.")
			Else
				latitudeVal = value
			End If
		End Set
	End Property

	Public Property Longitude() As Double
		Get
			Return longitudeVal
		End Get
		Set(value As Double)
			If Math.Abs(value) > MaxLongitude Then
				Throw New ArgumentOutOfRangeException("Latitude must be a real number between -90 and +90 degrees.")
			Else
				longitudeVal = value
			End If
		End Set
	End Property


	' ---------------
	'	SUB MODULES
	' ---------------

	' Add Details
	Public Sub AddDetails(inLatitude As String, inLongitude As String)
		' Check if values are known
		If IsNumeric(inLatitude) And IsNumeric(inLongitude) Then
			Latitude = Double.Parse(inLatitude)
			Longitude = Double.Parse(inLongitude)
			knownVal = True
		Else
			Latitude = 0.0
			Longitude = 0.0
			knownVal = False
		End If
	End Sub


	' -------------
	'	FUNCTIONS
	' -------------

	' To String
	Public Overrides Function ToString() As String
		' Declare Variables
		Dim output As String = ""
		Dim absLatitude = Math.Abs(latitudeVal)
		Dim absLongitude = Math.Abs(longitudeVal)

		' Check if known
		If knownVal Then
			' Add latitude
			output &= absLatitude
			If latitudeVal >= 0.0 Then
				output &= "N "
			Else
				output &= "S "
			End If

			' Add Longitude
			output &= absLongitude
			If longitudeVal >= 0.0 Then
				output &= "E"
			Else
				output &= "W"
			End If
		Else
			'Unknown
			output = "Unkown"
		End If

		Return output
	End Function
End Class
