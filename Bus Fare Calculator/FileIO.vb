' -------------------------
'	All Saints' College
'	Ewing Ave, Bull Creek
'	Bus Ticketing System
'	Aaron Musgrave
'	23/04/2019
' -------------------------
'	File Open and Save
' -------------------------

Imports System.IO
Imports System.Text

Public Class FileIO
    ' Open CSV File and Load contents into data grid
    Shared Sub OpenCSV(fileName As String, dataGrid As DataGridView)
        Try
            If fileName IsNot String.Empty Then
                ' Clear Contents
                dataGrid.Rows.Clear()
                ' Create Reader
                Dim reader As New StreamReader(fileName, Encoding.Default)
                ' Skip first line
                reader.ReadLine()
                ' Get next line
                Dim currLine As String = reader.ReadLine()

                Do While currLine IsNot Nothing
                    ' Remove extra comma from end
                    currLine = currLine.TrimEnd(",")
                    ' Check to see if blank line
                    If Not currLine.All(AddressOf Char.IsPunctuation) Then
                        ' Split line into array
                        Dim linePart() As String = currLine.Split(",")
                        ' Create new row
                        dataGrid.Rows.Add("")
                        For ii As Integer = 0 To linePart.Length - 1
                            dataGrid.Rows(dataGrid.Rows.Count - 1).Cells(ii).Value = linePart(ii)
                        Next
                    End If
                    ' Get next line
                    currLine = reader.ReadLine
                Loop
                reader.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error opening input data")
            dataGrid.Rows.Clear()
        End Try
    End Sub

    Shared Function OpenCSV(fileName As String) As List(Of String())
        ' Check fileName
        If fileName Is String.Empty Then
            Throw New ArgumentNullException("Filename cannot be empty.")
        End If

        ' Declare Variables
        Dim inputRows As New List(Of String())
        Dim currLine As String
        Dim reader As StreamReader

        Try
            ' Initialise File reader
            reader = New StreamReader(fileName, Encoding.Default)
            ' Skip first line
            reader.ReadLine()
            ' Get next line
            currLine = reader.ReadLine()

            Do While currLine IsNot Nothing
                ' Remove extra comma from end
                currLine = currLine.TrimEnd(",")
                ' Check to see if blank line
                If Not currLine.All(AddressOf Char.IsPunctuation) Then
                    ' Split line into array and add to list
                    inputRows.Add(currLine.Split(","))
                End If
                ' Get next line
                currLine = reader.ReadLine
            Loop
            reader.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error opening input data")
        End Try

        Return inputRows
    End Function

    ' Save data grid content into CSV file
    Shared Sub SaveCSV(fileName As String, dataGrid As DataGridView)
        ' Declare Variables
        Dim utf8WithoutBom As New System.Text.UTF8Encoding(False)
        Dim currLine As String = ""

        Try
            If fileName IsNot String.Empty Then
                ' Get column headers
                For Each currColumn As DataGridViewColumn In dataGrid.Columns
                    currLine &= currColumn.HeaderText & ","
                Next
                ' Remove extra comma from end
                currLine = currLine.TrimEnd(",")

                ' Write headers to file
                Using headerWriter As New StreamWriter(fileName, False, utf8WithoutBom)
                    headerWriter.WriteLine(currLine)
                End Using

                ' Creat writer
                Dim writer As New StreamWriter(fileName, True, utf8WithoutBom)

                ' For each row in data grid
                For Each currRow As DataGridViewRow In dataGrid.Rows
                    ' Reset current line string
                    currLine = ""
                    ' For each cell in row
                    For Each currCell As DataGridViewCell In currRow.Cells
                        currLine &= currCell.FormattedValue & ","
                    Next
                    ' Remove extra comma from end
                    currLine = currLine.TrimEnd(",")
                    ' Append to file
                    writer.WriteLine(currLine)
                Next

                ' Close writer
                writer.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error saving output data")
        End Try
    End Sub

    ' Create CSV file in correct format for import into synergetic
    Shared Sub ExportCSV(fileName As String, cardMap As Dictionary(Of String, Card))
        ' Declare Constants
        Const FeeCode As String = "BUS"
        Const GLCode As String = "4657591-01"
        Const TaxCode As String = "10"

        ' Declare Variables
        Dim TransactionDate As String = Date.Today.ToString("dd/MM/yyyy")
        Dim utf8WithoutBom As New System.Text.UTF8Encoding(False)
        Dim currLine As String

        Try
            If fileName IsNot String.Empty Then
                ' Add Headers
                currLine = "StudentID,"
                currLine &= "StudentName,"
                currLine &= "DebtorID,"
                currLine &= "FeeCode,"
                currLine &= "TransactionDate,"
                currLine &= "TransactionAmount,"
                currLine &= "TransactionDescription,"
                currLine &= "OrideGLCode,"
                currLine &= "OrideTaxCode"

                ' Write headers to file
                Using headerWriter As New StreamWriter(fileName, False, utf8WithoutBom)
                    headerWriter.WriteLine(currLine)
                End Using

                ' Creat writer
                Dim writer As New StreamWriter(fileName, True, utf8WithoutBom)

                For Each currCard As Card In cardMap.Values
                    ' Get values
                    currLine = currCard.StudentID & ","
                    currLine &= currCard.FirstName & " " & currCard.LastName & ","
                    currLine &= currCard.DebtorID & ","
                    currLine &= FeeCode & ","
                    currLine &= TransactionDate & ","
                    currLine &= currCard.TotalFare.ToString("F2") & ","
                    currLine &= currCard.GetRoutes & ","
                    currLine &= GLCode & ","
                    currLine &= TaxCode

                    ' Write to file
                    writer.WriteLine(currLine)
                Next

                ' Close writer
                writer.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error saving export data")
        End Try
    End Sub
End Class