Imports System.IO 'esta libreria nos va a servir para poder activar el commandialog
Imports Microsoft.Office.Interop
Imports System.Data
Imports System.Data.OleDb
Imports System
Imports Microsoft.VisualBasic

Imports System.Data.SQLite

Public Class datos

    Const cadena_conexion As String = "Data Source=Electro.db;Version=3"
    Private Sub datos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button2.Enabled = False
        dgvmedidor.AllowUserToAddRows = False ' denegar la acción de registros al usuario
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim myFileDialog As New OpenFileDialog()
        Dim xSheet As String = ""

        With myFileDialog
            .Filter = "Excel Files |*.xlsx"
            .Title = "Open File"
            .ShowDialog()
        End With
        If myFileDialog.FileName.ToString <> "" Then
            Dim ExcelFile As String = myFileDialog.FileName.ToString

            Dim ds As New DataSet
            Dim da As OleDbDataAdapter
            Dim dt As DataTable
            Dim conn As OleDbConnection

            xSheet = InputBox("Digite el nombre de la Hoja que desea importar", "Complete")
            conn = New OleDbConnection(
                              "Provider=Microsoft.ACE.OLEDB.12.0;" &
                              "data source=" & ExcelFile & "; " &
                             "Extended Properties='Excel 12.0 Xml;HDR=Yes'")
            Try
                'limpiar el DGV en cada posible carga verdadera
                'MsgBox("buena")
                dgvmedidor.DataMember = ""
                dgvmedidor.DataSource = ""

                Button2.Enabled = True

                da = New OleDbDataAdapter("SELECT * FROM  [" & xSheet & "$]", conn)
                conn.Open()
                da.Fill(ds, "MyData")
                dt = ds.Tables("MyData")
                dgvmedidor.DataSource = ds
                dgvmedidor.DataMember = "MyData"
            Catch ex As Exception
                MsgBox("Inserte un nombre valido de la Hoja que desea importar", MsgBoxStyle.Information, "Informacion")
            Finally
                conn.Close()
            End Try
        End If
        xSheet = ""
        '        MsgBox("Se ha cargado la importacion correctamente", MsgBoxStyle.Information, "Importado con exito")
    End Sub
    Sub ConsultaNumImport(ByRef NumImport As String)

        Dim objCon As SQLiteConnection
        Dim objCommand As SQLiteCommand
        Dim objReader As SQLiteDataReader

        Try
            objCon = New SQLiteConnection(cadena_conexion)
            objCon.Open()
            objCommand = objCon.CreateCommand()
            objCommand.CommandText = "select  Max(NumImport) from clientes"
            objReader = objCommand.ExecuteReader()

            If objReader.Read() Then
                NumImport = objReader.Item("Max(NumImport)").ToString
                NumImport = Val(NumImport) + 1
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            objCommand.Dispose()
            objReader.Close()
            objCon.Close()
        End Try

    End Sub
    Sub ConsultaCargar(ByVal NumImport As Integer, ByVal Item As Integer, ByVal CodigoRutaSuministro As String, ByVal CodigoSuministro As String,
                       ByVal NombreSuministro As String, ByVal DireccionPredio As String, ByVal FactorTransformacionEA As String,
                       ByVal Marca_medidor As String, ByVal Modelo As String, ByVal Serie As String)

        Dim objCon1 As SQLiteConnection
        Dim objCommand1 As SQLiteCommand

        Try
            objCon1 = New SQLiteConnection(cadena_conexion) '& "New=true;")
            objCon1.Open()
            'MsgBox("Abierta DB")
            objCommand1 = objCon1.CreateCommand()
            objCommand1.CommandText = "insert into clientes (NumImport, Item, CodigoRutaSuministro, CodigoSuministro, NombreSuministro, DireccionPredio, FactorTransformacionEA, Marca_medidor, Modelo, Serie) values (""" & NumImport & """,""" & Item & """,""" & CodigoRutaSuministro & """,""" & CodigoSuministro & """,""" & NombreSuministro & """,""" & DireccionPredio & """,""" & FactorTransformacionEA & """,""" & Marca_medidor & """,""" & Modelo & """,""" & Serie & """);"
            'MsgBox(objCommand1.CommandText, MsgBoxStyle.Information, "leyendo")
            'objCommand1.CommandText = "insert into clientes (NumImport, Item) values (""" & NumImport & """,""" & Item & """);"

            txtprueba.Text = objCommand1.CommandText
            'MsgBox(objCommand1.CommandText)
            'System.Threading.Thread.CurrentThread.Sleep(10000)
            objCommand1.ExecuteNonQuery()
            'MsgBox("ex DB")
            'Catch ex As Exception
            'MsgBox(ex.ToString)
        Finally
            If Not IsNothing(objCon1) Then
                objCon1.Close()
            End If
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim NumImport As Integer
        'ConsultaNumImport(NumImport) ' obtener el último ID del lote de medidores en la DB
        ConsultaNumImport(NumImport)
        MsgBox(NumImport)
        'nombre = dgvmedidor.Columns.Item(1).Name
        'MsgBox(nombre)

        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = dgvmedidor.Rows.Count * 1.005

        With dgvmedidor
            If .Rows.Count > 0 Then
                'ConsultaNumImport(NumImport)
                For i As Integer = 0 To .Rows.Count - 1

                    Application.DoEvents()
                    If i > 0 Then
                        'MsgBox(NumImport)
                        'MsgBox(dgvmedidor.Rows(i).Cells(0).Value.ToString())
                        'MsgBox(dgvmedidor.Rows(i).Cells(1).Value.ToString())
                        'MsgBox(dgvmedidor.Rows(i).Cells(2).Value.ToString())
                        'MsgBox(dgvmedidor.Rows(i).Cells(3).Value.ToString())
                        'MsgBox(dgvmedidor.Rows(i).Cells(4).Value.ToString())
                        'MsgBox(dgvmedidor.Rows(i).Cells(23).Value.ToString())
                        'MsgBox(dgvmedidor.Rows(i).Cells(24).Value.ToString())
                        'MsgBox(dgvmedidor.Rows(i).Cells(25).Value.ToString())
                        'MsgBox(dgvmedidor.Rows(i).Cells(26).Value.ToString())
                        If String.IsNullOrEmpty(.Rows(i).Cells(0).Value.ToString()) = False Then

                            ConsultaCargar(NumImport, .Rows(i).Cells(0).Value.ToString(), .Rows(i).Cells(1).Value.ToString(),
                                           .Rows(i).Cells(2).Value.ToString(), .Rows(i).Cells(3).Value.ToString(),
                                           .Rows(i).Cells(4).Value.ToString(), .Rows(i).Cells(23).Value.ToString(),
                                           .Rows(i).Cells(24).Value.ToString(), .Rows(i).Cells(25).Value.ToString(),
                                           .Rows(i).Cells(26).Value.ToString())
                        End If

                    End If
                    ProgressBar1.Value = i + 1
                Next
            End If
        End With
        ProgressBar1.Value = 0
        MsgBox("ex DB")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        dgvmedidor.DataMember = ""
        dgvmedidor.DataSource = ""
    End Sub
End Class