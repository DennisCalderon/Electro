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

            xSheet = InputBox("Digite el nombre de la Hoja que desea importar", "Complete")
            ''''''''''''''''''
            Try

                Dim cadenaConexion As String =
                "Provider=Microsoft.ACE.OLEDB.12.0;" &
                "Extended Properties='Excel 12.0 Xml;HDR=Yes;'" &
                ";Data Source=" & ExcelFile

                Using cnn As New OleDbConnection(cadenaConexion)

                    Dim sql As String = "SELECT * FROM [" & xSheet & "$]"

                    Dim das As New OleDbDataAdapter(sql, cnn)

                    Dim dts As New DataTable()

                    das.Fill(dts)

                    dgvmedidor.DataSource = dts
                    Button2.Enabled = True

                End Using

            Catch ex As Exception
                MessageBox.Show(ex.Message)
                MsgBox("Inserte un nombre valido de la Hoja que desea importar", MsgBoxStyle.Information, "Informacion")
            End Try
        End If
        xSheet = ""
    End Sub
    Sub ConsultaNumImport(ByRef NumImport As String)

        Dim objCon As SQLiteConnection
        Dim objCommand As SQLiteCommand
        Dim objReader As SQLiteDataReader

        Try
            objCon = New SQLiteConnection(cadena_conexion)
            objCon.Open()
            objCommand = objCon.CreateCommand()
            objCommand.CommandText = "select  Max(NumImport) from Clientes"
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
    Sub ConsultaCargar(ByVal NumImport As Integer, ByVal Item As Integer, ByVal CodigoRutaSuministro As String, ByVal CodigoSuministro As String, ByVal NombreSuministro As String, ByVal DireccionPredio As String, ByVal PotenciaContratadaHFP As String, ByVal FechaInicio As String, ByVal DireccionElectrica As String, ByVal NumeroDNI As String, ByVal NumeroRUC As String, ByVal Telefono As String, ByVal NombreSector As String, ByVal TipoAlimentacion As String, ByVal PuntoConexion As String, ByVal SimboloImpresionRecibo As String, ByVal TipoRedElectrica As String, ByVal TipoSistema As String, ByVal Tension As String, ByVal Tarifa As String, ByVal SistemaElectrico As String, ByVal ActividadEconomica As String, ByVal FactorTension As String, ByVal FactorCorriente As String, ByVal FactorTransformacionEA As String, ByVal MarcaDelMedidor As String, ByVal Modelo As String, ByVal Serie As String, ByVal AnoFabricacion As String, ByVal Hilos As String, ByVal Fases As String, ByVal ConstanteRotacion As String, ByVal IP As String, ByVal Blanco1 As String, ByVal Blanco2 As String, ByVal Blanco3 As String, ByVal uno As String, ByVal dos As String, ByVal tres As String, ByVal cuatro As String, ByVal cinco As String, ByVal seis As String, ByVal siete As String, ByVal dies As String)

        Dim objCon1 As SQLiteConnection
        Dim objCommand1 As SQLiteCommand

        Try
            objCon1 = New SQLiteConnection(cadena_conexion) '& "New=true;")
            objCon1.Open()
            'MsgBox("Abierta DB")
            objCommand1 = objCon1.CreateCommand()
            objCommand1.CommandText = "insert into Clientes values (""" & NumImport & """,""" & Item & """,""" & CodigoRutaSuministro & """,""" & CodigoSuministro & """,""" & NombreSuministro & """,""" & DireccionPredio & """,""" & PotenciaContratadaHFP & """,""" & FechaInicio & """,""" & DireccionElectrica & """,""" & NumeroDNI & """,""" & NumeroRUC & """,""" & Telefono & """,""" & NombreSector & """,""" & TipoAlimentacion & """,""" & PuntoConexion & """,""" & SimboloImpresionRecibo & """,""" & TipoRedElectrica & """,""" & TipoSistema & """,""" & Tension & """,""" & Tarifa & """,""" & SistemaElectrico & """,""" & ActividadEconomica & """,""" & FactorTension & """,""" & FactorCorriente & """,""" & FactorTransformacionEA & """,""" & MarcaDelMedidor & """,""" & Modelo & """,""" & Serie & """,""" & AnoFabricacion & """,""" & Hilos & """,""" & Fases & """,""" & ConstanteRotacion & """,""" & IP & """,""" & Blanco1 & """,""" & Blanco2 & """,""" & Blanco3 & """,""" & uno & """,""" & dos & """,""" & tres & """,""" & cuatro & """,""" & cinco & """,""" & seis & """,""" & siete & """,""" & dies & """);"
            'MsgBox(objCommand1.CommandText, MsgBoxStyle.Information, "leyendo")
            'objCommand1.CommandText = "insert into clientes (NumImport, Item) values (""" & NumImport & """,""" & Item & """);"

            txtprueba.Text = objCommand1.CommandText
            'MsgBox(objCommand1.CommandText)
            objCommand1.ExecuteNonQuery()
            'MsgBox("ex DB")
            'Catch ex As Exception
            'MsgBox(ex.ToString)
        Finally
            If Not IsNothing(objCon1) Then
                objCommand1.Dispose()
                objCon1.Close()
            End If
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim NumImport As Integer
        ConsultaNumImport(NumImport) ' obtener el último ID del lote de medidores en la DB

        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = dgvmedidor.Rows.Count * 1.005

        With dgvmedidor
            If .Rows.Count > 0 Then
                Button1.Enabled = False
                Button2.Enabled = False
                dgvmedidor.Enabled = False
                'ConsultaNumImport(NumImport)
                For i As Integer = 0 To .Rows.Count - 1

                    Application.DoEvents()
                    If i > 0 Then
                        'MsgBox(NumImport)
                        'MsgBox(dgvmedidor.Rows(i).Cells(0).Value.ToString())
                        'MsgBox(dgvmedidor.Rows(i).Cells(1).Value.ToString())
                        If String.IsNullOrEmpty(.Rows(i).Cells(0).Value.ToString()) = False Then

                            ConsultaCargar(NumImport, .Rows(i).Cells(0).Value.ToString(), .Rows(i).Cells(1).Value.ToString(), .Rows(i).Cells(2).Value.ToString(), .Rows(i).Cells(3).Value.ToString(), .Rows(i).Cells(4).Value.ToString(), .Rows(i).Cells(5).Value.ToString(), .Rows(i).Cells(6).Value.ToString(), .Rows(i).Cells(7).Value.ToString(), .Rows(i).Cells(8).Value.ToString(), .Rows(i).Cells(9).Value.ToString(), .Rows(i).Cells(10).Value.ToString(), .Rows(i).Cells(11).Value.ToString(), .Rows(i).Cells(12).Value.ToString(), .Rows(i).Cells(13).Value.ToString(), .Rows(i).Cells(14).Value.ToString(), .Rows(i).Cells(15).Value.ToString(), .Rows(i).Cells(16).Value.ToString(), .Rows(i).Cells(17).Value.ToString(), .Rows(i).Cells(18).Value.ToString(), .Rows(i).Cells(19).Value.ToString(), .Rows(i).Cells(20).Value.ToString(), .Rows(i).Cells(21).Value.ToString(), .Rows(i).Cells(22).Value.ToString(), .Rows(i).Cells(23).Value.ToString(), .Rows(i).Cells(24).Value.ToString(), .Rows(i).Cells(25).Value.ToString(), .Rows(i).Cells(26).Value.ToString(), .Rows(i).Cells(27).Value.ToString(), .Rows(i).Cells(28).Value.ToString(), .Rows(i).Cells(29).Value.ToString(), .Rows(i).Cells(30).Value.ToString(), .Rows(i).Cells(31).Value.ToString(), .Rows(i).Cells(32).Value.ToString(), .Rows(i).Cells(33).Value.ToString(), .Rows(i).Cells(34).Value.ToString(), .Rows(i).Cells(35).Value.ToString(), .Rows(i).Cells(36).Value.ToString(), .Rows(i).Cells(37).Value.ToString(), .Rows(i).Cells(38).Value.ToString(), .Rows(i).Cells(39).Value.ToString(), .Rows(i).Cells(40).Value.ToString(), .Rows(i).Cells(41).Value.ToString(), .Rows(i).Cells(42).Value.ToString())
                        End If

                    End If
                    ProgressBar1.Value = i + 1
                Next
            End If
        End With
        MsgBox("Padrón Actualizado", MsgBoxStyle.Information, "Proceso de Cargar Terminado")
        ProgressBar1.Value = 0
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        dgvmedidor.DataMember = ""
        dgvmedidor.DataSource = ""
    End Sub
End Class