Imports System.Data.SQLite
Imports System.IO

Public Class GuardarDGVDB

    Const cadena_conexion As String = "Data Source=Electro.db;Version=3"

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

        DGVReg = Module1.RegDB

        Dim NumImport As Integer
        ConsultaNumImport(Module1.NombreSector, NumImport) ' obtener el último ID del lote de medidores en la DB
        CargarRegistros(DGVReg, NumImport)

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
    Sub ConsultaNumImport(ByVal NombreSector As String, ByRef NumImport As String)

        Dim objCon As SQLiteConnection
        Dim objCommand As SQLiteCommand
        Dim objReader As SQLiteDataReader

        Try
            objCon = New SQLiteConnection(cadena_conexion)
            objCon.Open()
            objCommand = objCon.CreateCommand()
            'objCommand.CommandText = "select  Max(NumImport) from Clientes"
            objCommand.CommandText = "select  Max(NumImport) from Padron_" & NombreSector
            objReader = objCommand.ExecuteReader()

            If objReader.Read() Then
                NumImport = objReader.Item("Max(NumImport)").ToString
                NumImport = Val(NumImport)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            objCommand.Dispose()
            objReader.Close()
            objCon.Close()
        End Try

    End Sub

    Dim FlNm As String
    'se encargara de guardar los querys en un archivo de texto para unirlos en insert de 30 unidades
    Sub CargarRegistros(ByVal DGV As DataGridView, ByVal NumImport As String)
        'dividir el contenido en bloques y agregar el sobrante
        Dim dividirEnBloques As Integer
        Dim inquery As Integer = 1
        dividirEnBloques = 30 ' modificar el numero de archivos que se tomaran por hoja

        FlNm = "exportDB.txt"
        If File.Exists(FlNm) Then File.Delete(FlNm)
        Dim fs As New StreamWriter(FlNm, False)

        Dim dividirBloque As Integer = 50 'dividir los datos en querys
        With fs
            .Write("insert into Historico (NumImport, Sector, Mes, CodigoEmpresa, CodigoSuministro, CodigoBarraCompra, FechaHora, EA) ")
            For intRow As Integer = 0 To DGV.RowCount - 1

                Application.DoEvents()
                .Write(" SELECT ")
                .Write("""{0}"",", NumImport)
                .Write("""{0}"",", Module1.NombreSector)

                For intCol As Integer = 0 To DGV.Columns.Count - 1
                    Application.DoEvents()
                    .Write("""{0}""", DGV.Item(intCol, intRow).Value.ToString)
                    If intCol < DGV.Columns.Count - 1 Then
                        .Write(",")
                    End If
                Next
                If inquery < dividirBloque - 1 Then
                    If intRow = DGV.RowCount - 1 Then
                    Else
                        .Write(" UNION ")
                    End If
                End If
                inquery += 1

                If inquery = dividirBloque Then
                    .WriteLine("")
                    .Write("insert into Historico (NumImport, Sector, Mes, CodigoEmpresa, CodigoSuministro, CodigoBarraCompra, FechaHora, EA) ")
                    inquery = 0
                End If
            Next
        End With
        fs.Close()
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
                    objCon1 = New SQLiteConnection(cadena_conexion) '& "New=true;")
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
End Class