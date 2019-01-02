Imports System.IO
Imports System.Data.SQLite
Public Class GuardarDGVDB
    Private Sub GuardarDGVDB_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Show()

        Dim DGVReg As New DataGridView
        With DGVReg
            .AllowUserToAddRows = False
            .Name = "Hoja"
            .Visible = False
            .Columns.Clear()
            .Columns.Add("Column1", "Mes")
            .Columns.Add("Column2", "Código de Empresa")
            .Columns.Add("Column3", "Código de Suministro")
            .Columns.Add("Column4", "Código de Barra de Compra")
            .Columns.Add("Column5", "Fecha / Hora")
            .Columns.Add("Column6", "EA")
        End With

        DGVReg = MVariables.RegDB

        Dim NumImport As Integer
        MConsultasDB.ConsultaNumImport(MVariables.NombreSector, NumImport) ' obtener el último ID del lote de medidores en la DB
        MExportExcel.GenerarQuerysHistoricos(DGVReg, NumImport)

        Dim filasT As Integer
        obtenertotal(filasT)
        pbDB.Minimum = 0
        pbDB.Maximum = filasT * 1.007
        pbDB.Value = 0

        GuardarRegistros()
        pbDB.Value = 0
        'MsgBox("stop")
        File.Delete("exportDB.txt")
        Me.Close()
    End Sub
    Sub obtenertotal(ByRef filasT As Integer)
        Dim objReader As New StreamReader("exportDB.txt")
        Dim sLine As String = ""
        Dim fila As Integer = 0

        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                fila += 1
            End If
        Loop Until sLine Is Nothing
        objReader.Close()

        filasT = fila
    End Sub

    Sub GuardarRegistros()
        Dim objReader As New StreamReader("exportDB.txt")
        Dim rLine As String = ""
        Dim objCon1 As SQLiteConnection
        Dim objCommand1 As SQLiteCommand
        Do
            rLine = objReader.ReadLine()
            If Not rLine Is Nothing Then
                Try
                    objCon1 = New SQLiteConnection("Data Source=Electro.db;Version=3") '& "New=true;")
                    objCon1.Open()
                    'MsgBox("Abierta DB")
                    objCommand1 = objCon1.CreateCommand()
                    'objCommand1.CommandText = "insert into Historico (NumImport, Mes, CodigoEmpresa, CodigoSuministro, CodigoBarraCompra, FechaHora, EA) values (""" & rLine & """);"
                    'MsgBox(rLine)
                    objCommand1.CommandText = rLine

                    objCommand1.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox(rLine)
                    MsgBox(ex.ToString)
                Finally
                    'If Not IsNothing(objCon1) Then
                    objCommand1.Dispose()
                    objCon1.Close()
                    'End If
                End Try
                pbDB.Value = pbDB.Value + 1
            End If
        Loop Until rLine Is Nothing
        objReader.Close()
    End Sub
End Class