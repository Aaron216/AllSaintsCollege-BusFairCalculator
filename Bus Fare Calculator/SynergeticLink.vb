' -------------------------
'	All Saints' College
'	Ewing Ave, Bull Creek
'	Bus Ticketing System
'	Aaron Musgrave
'	30/03/2018
' ----------------------------------
'	Synergetic Database Link Class
' ----------------------------------

Imports System.Data.SqlClient

Public Class SynergeticLink
    ' Declare Constants
    Private Const connectionString As String = "Data Source=SYNDB;Initial Catalog=SynergyOne;Integrated Security=True"

    ' Declare Feilds
    Private connection As SqlConnection
    Private connectedVal As Boolean

    ' Constructor
    Public Sub New()
        connection = New SqlConnection(connectionString)
        connectedVal = False
    End Sub


    ' --------------
    '	PROPERTIES
    ' --------------

    Public ReadOnly Property Connected As Boolean
        Get
            Return connectedVal
        End Get
    End Property


    ' ---------------
    '	SUB MODULES
    ' ---------------
    Public Sub Open()
        Try
            connection.Open()
            connectedVal = True
        Catch ex As Exception
            connectedVal = False
            Throw New Exception("Failed to open synergetic connection: " & ex.Message)
        End Try
    End Sub

    Public Sub Close()
        Try
            connection.Close()
            connectedVal = False
        Catch ex As Exception
            Throw New Exception("Failed to close synergetic connection: " & ex.Message)
        End Try
    End Sub

    ' -------------
    '	FUNCTIONS
    ' -------------
    Public Function GetStudentCard(cardID As String) As DataRow
        ' Declare Variables
        Dim queryString As String
        Dim studentTable As DataTable
        Dim studentRow As DataRow

        ' Get table
        queryString = "select * from uCustomBulkExportMifare where pager='" & cardID & "'"
        studentTable = MakeQuery(queryString)

        ' Check for no result
        If studentTable.Rows.Count = 1 Then
            studentRow = studentTable.Rows(0)
        Else
            studentRow = studentTable.NewRow
            studentRow.SetColumnError(0, "Card not found")
        End If

        Return studentRow
    End Function

    Public Function GetStudentDebtor(studentID As String) As String
        ' Declare Variables
        Dim queryString As String
        Dim resultsTable As DataTable
        Dim debtorID As String = ""

        ' Get table
        queryString = "select StudentID, DebtorID from vStudents where StudentID='" & studentID & "'"
        resultsTable = MakeQuery(queryString)

        ' Check for no result
        If resultsTable.Rows.Count > 0 Then
            debtorID = resultsTable.Rows(0).Item("DebtorID")
        End If

        Return debtorID
    End Function

    Public Function GetStudentRow(cardID As String) As DataRow
        ' Declare Variables
        Dim queryString As String
        Dim studentTable As DataTable
        Dim studentRow As DataRow

        ' Get Table
        queryString =
            "SELECT DebtorID, StudentID, StudentBarcode, StudentPreferred, StudentSurname, FileYear, FileSemester " &
            "FROM vStudents " &
            "WHERE StudentBarcode='" & cardID & "' " &
            "ORDER BY FileYear DESC, FileSemester DESC"
        studentTable = MakeQuery(queryString)

        ' Check for no result
        If studentTable.Rows.Count > 0 Then
            ' Get most recent record
            studentRow = studentTable.Rows(0)
        Else
            studentRow = studentTable.NewRow
            studentRow.SetColumnError(0, "Card not found")
        End If

        Return studentRow
    End Function

    ' ---------------------
    '	PRIVATE FUNCTIONS
    ' ---------------------
    Private Function MakeQuery(queryString As String) As DataTable
        ' Declare Variables
        Dim resultsTable As DataTable = New DataTable()
        Dim adaptor As SqlDataAdapter = New SqlDataAdapter(queryString, connection)

        ' Get Table
        adaptor.Fill(resultsTable)

        Return resultsTable
    End Function
End Class
