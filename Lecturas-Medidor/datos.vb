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
        cboSector.Items.Add("Tacna")
        cboSector.Items.Add("Moquegua")
        cboSector.Items.Add("Ilo")
        cboSector.SelectedIndex = 0
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        dgvmedidor.DataMember = ""
        dgvmedidor.DataSource = ""

        Button3.Enabled = False
        Button2.Enabled = False

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
                "Extended Properties='Excel 12.0 Xml;HDR=No;'" & ' se cambio el valor del HDR de "Yes" a "No" para que reconociera el valor de las columnas en el formato de "F1, F2, F3 ... Fnº"
                ";Data Source=" & ExcelFile

                Using cnn As New OleDbConnection(cadenaConexion)

                    Dim sql As String = "SELECT F86, F2, F81, F128, F97, F110, F111, F112, F113, F137, F138, F139, F118, F119, F140 FROM [" & xSheet & "$]"
                    Dim das As New OleDbDataAdapter(sql, cnn)
                    Dim dts As New DataTable()

                    das.Fill(dts)

                    dgvmedidor.DataSource = dts
                    Button2.Enabled = True
                End Using

                With dgvmedidor
                    dgvmedidor.Rows.RemoveAt(0) 'remover la PRIMERA fila del gatagridview
                    dgvmedidor.Rows.RemoveAt(0) 'remover la SEGUNDA fila del gatagridview
                    '.Columns(0).HeaderText = "Item"                                  '1
                    .Columns(0).HeaderText = "Codigo Ruta de Suministro"             '2
                    .Columns(1).HeaderText = "Codigo de Suministro"                  '3
                    .Columns(2).HeaderText = "Nombre de Suministro"                  '4
                    .Columns(3).HeaderText = "Direccion del Predio"                  '5
                    .Columns(4).HeaderText = "Nombre del Sector"                    '6
                    .Columns(5).HeaderText = "Tension"                              '7
                    .Columns(6).HeaderText = "Tarifa"                               '8
                    .Columns(7).HeaderText = "Sistema Electrico"                    '9
                    .Columns(8).HeaderText = "Actividad Economica"                  '10
                    .Columns(9).HeaderText = "Factor de Tension"                    '11
                    .Columns(10).HeaderText = "Factor de Corriente"                  '12
                    .Columns(11).HeaderText = "Factor de Transformacion EA"          '13
                    .Columns(12).HeaderText = "Marca del Medidor"                    '14
                    .Columns(13).HeaderText = "Modelo"                               '15
                    .Columns(14).HeaderText = "Serie"                                '16
                End With

            Catch ex As Exception
                'MessageBox.Show(ex.Message)
                MsgBox("Inserte un nombre valido de la Hoja que desea importar", MsgBoxStyle.Information, "Informacion")
            End Try
        End If
        Button3.Enabled = True
        Button2.Enabled = True
        dgvmedidor.AllowUserToAddRows = False ' denegar la acción de registros al usuario
        xSheet = ""
    End Sub
    Sub ConsultaNumImport(ByVal NombreSector As String, ByRef NumImport As String)

        Dim objCon As SQLiteConnection
        Dim objCommand As SQLiteCommand
        Dim objReader As SQLiteDataReader

        Try
            objCon = New SQLiteConnection(cadena_conexion)
            objCon.Open()
            objCommand = objCon.CreateCommand()
            objCommand.CommandText = "select  Max(NumImport) from Padron_" & NombreSector
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
    Sub ConsultaCargar(ByVal NumImport As Integer, ByVal Item As Integer, ByVal CodigoRutaSuministro As String, ByVal CodigoSuministro As String, ByVal NombreSuministro As String, ByVal DireccionPredio As String, ByVal NombreSector As String, ByVal Tension As String, ByVal Tarifa As String, ByVal SistemaElectrico As String, ByVal ActividadEconomica As String, ByVal FactorTension As String, ByVal FactorCorriente As String, ByVal FactorTransformacionEA As String, ByVal MarcaDelMedidor As String, ByVal Modelo As String, ByVal Serie As String)

        Dim objCon1 As SQLiteConnection
        Dim objCommand1 As SQLiteCommand

        Try
            objCon1 = New SQLiteConnection(cadena_conexion) '& "New=true;")
            objCon1.Open()
            'MsgBox("Abierta DB")
            objCommand1 = objCon1.CreateCommand()
            objCommand1.CommandText = "insert into Padron_" & NombreSector & " ('NumImport', 'Item', 'CodigoRutaSuministro', 'CodigoSuministro', 'NombreSuministro', 'DireccionPredio', 'NombreSector', 'Tension', 'Tarifa', 'SistemaElectrico', 'ActividadEconomica', 'FactorTension', 'FactorCorriente', 'FactorTransformacionEA', 'MarcaDelMedidor', 'Modelo', 'Serie') values (""" & NumImport & """,""" & Item & """,""" & CodigoRutaSuministro & """,""" & CodigoSuministro & """,""" & NombreSuministro.Replace(Chr(34), "") & """,""" & DireccionPredio.Replace(Chr(34), "") & """,""" & NombreSector & """,""" & Tension & """,""" & Tarifa & """,""" & SistemaElectrico & """,""" & ActividadEconomica & """,""" & FactorTension & """,""" & FactorCorriente & """,""" & FactorTransformacionEA & """,""" & MarcaDelMedidor & """,""" & Modelo & """,""" & Serie & """);"
            'MsgBox(objCommand1.CommandText)
            objCommand1.ExecuteNonQuery()
            'MsgBox("ex DB")
        Catch ex As Exception
            MsgBox(ex.ToString)
            MsgBox(objCommand1.CommandText)
        Finally
            objCommand1.Dispose()
            objCon1.Close()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'MsgBox(dgvmedidor.Rows(1).Cells(4).Value.ToString())
        cboSector.Enabled = False
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False

        Dim NumImport As Integer
        'MsgBox(dgvmedidor.Rows(2).Cells(4).Value.ToString())
        ConsultaNumImport(dgvmedidor.Rows(2).Cells(4).Value.ToString(), NumImport) ' obtener el último ID del lote de medidores en la DB

        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = dgvmedidor.Rows.Count * 1.005
        Dim item As Integer = 1
        With dgvmedidor
            If .Rows.Count > 0 Then
                Button1.Enabled = False
                Button2.Enabled = False
                dgvmedidor.Enabled = False
                'ConsultaNumImport(NumImport)
                For i As Integer = 0 To .Rows.Count - 1
                    Application.DoEvents()
                    'MsgBox(NumImport)
                    'MsgBox(dgvmedidor.Rows(i).Cells(0).Value.ToString())
                    If String.IsNullOrEmpty(.Rows(i).Cells(0).Value.ToString()) = False Then

                        ConsultaCargar(NumImport, item, .Rows(i).Cells(0).Value.ToString(), .Rows(i).Cells(1).Value.ToString(), .Rows(i).Cells(2).Value.ToString(), .Rows(i).Cells(3).Value.ToString(), .Rows(i).Cells(4).Value.ToString(), .Rows(i).Cells(5).Value.ToString(), .Rows(i).Cells(6).Value.ToString(), .Rows(i).Cells(7).Value.ToString(), .Rows(i).Cells(8).Value.ToString(), .Rows(i).Cells(9).Value.ToString(), .Rows(i).Cells(10).Value.ToString(), .Rows(i).Cells(11).Value.ToString(), .Rows(i).Cells(12).Value.ToString(), .Rows(i).Cells(13).Value.ToString(), .Rows(i).Cells(14).Value.ToString())
                    End If
                    ProgressBar1.Value = i + 1
                    item = item + 1

                Next
            End If
        End With
        MsgBox("Padrón Actualizado", MsgBoxStyle.Information, "Proceso de Cargar Terminado")
        ActualizarPadronGeneral()
        ProgressBar1.Value = 0
        Me.Close()
        cboSector.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Button2.Enabled = False
        dgvmedidor.DataMember = ""
        dgvmedidor.DataSource = ""
        Dim cs As String = "Data Source=Electro.db;Version=3"

        Dim tipo_cbo As Integer
        Dim NombreSector As String = ""
        tipo_cbo = cboSector.SelectedIndex
        Select Case tipo_cbo
            Case 0 : NombreSector = "Tacna"
            Case 1 : NombreSector = "Moquegua"
            Case 2 : NombreSector = "Ilo"
        End Select

        Dim sql As String = "SELECT * FROM Padron_" & NombreSector & " where NumImport in (select  Max(NumImport) from Padron_" & NombreSector & ")"

        Using con As New SQLiteConnection(cs)

            Dim command As New SQLiteCommand(sql, con)
            Dim da As New SQLiteDataAdapter
            da.SelectCommand = command
            Dim dt As New DataTable
            da.Fill(dt)
            dgvmedidor.DataSource = dt

            With dgvmedidor
                .Columns(0).HeaderText = "Número de Padrón Actual"
                .Columns(1).HeaderText = "Item"
                .Columns(2).HeaderText = "Codigo Ruta de Suministro"
                .Columns(3).HeaderText = "Codigo de Suministro"
                .Columns(4).HeaderText = "Nombre de Suministro"
                .Columns(5).HeaderText = "Direccion del Predio"
                .Columns(6).HeaderText = "Nombre del Sector"
                .Columns(7).HeaderText = "Tension"
                .Columns(8).HeaderText = "Tarifa"
                .Columns(9).HeaderText = "Sistema Electrico"
                .Columns(10).HeaderText = "Actividad Economica"
                .Columns(11).HeaderText = "Factor de Tension"
                .Columns(12).HeaderText = "Factor de Corriente"
                .Columns(13).HeaderText = "Factor de Transformacion EA"
                .Columns(14).HeaderText = "Marca del Medidor"
                .Columns(15).HeaderText = "Modelo"
                .Columns(16).HeaderText = "Serie"
                .Columns(17).HeaderText = "Uno"
                .Columns(18).HeaderText = "Dos"
                .Columns(19).HeaderText = "Tres"
                .Columns(20).HeaderText = "Fecha"
                .Columns(21).HeaderText = "Cinco"
                .Columns(22).HeaderText = "Seis"
                .Columns(23).HeaderText = "Siete"
                .Columns(24).HeaderText = "Dies"
            End With
        End Using
        dgvmedidor.AllowUserToAddRows = False ' denegar la acción de registros al usuario
    End Sub
    Sub ActualizarPadronGeneral()

        Dim objCon1 As SQLiteConnection
        Dim objCommand1 As SQLiteCommand
        Dim objReader1 As SQLiteDataReader
        Try
            objCon1 = New SQLiteConnection(cadena_conexion)
            objCon1.Open()
            objCommand1 = objCon1.CreateCommand()
            objCommand1.CommandText = "delete From Padron_General Where NombreSector = """ & dgvmedidor.Rows(1).Cells(4).Value.ToString() & """ "
            objReader1 = objCommand1.ExecuteReader()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            'If Not IsNothing(objCon) Then
            objCommand1.Dispose()
            objReader1.Close()
            objCon1.Close()
            'End If
        End Try

        Try
            objCon1 = New SQLiteConnection(cadena_conexion) '& "New=true;")
            objCon1.Open()
            'MsgBox("Abierta DB")
            objCommand1 = objCon1.CreateCommand()
            objCommand1.CommandText = "insert into Padron_General (CodigoRutaSuministro, CodigoSuministro, NombreSuministro, DireccionPredio, NombreSector, Tension, Tarifa, SistemaElectrico, ActividadEconomica, FactorTension, FactorCorriente, FactorTransformacionEA, MarcaDelMedidor, Modelo, Serie) Select CodigoRutaSuministro, CodigoSuministro, NombreSuministro, DireccionPredio, NombreSector, Tension, Tarifa, SistemaElectrico, ActividadEconomica, FactorTension, FactorCorriente, FactorTransformacionEA, MarcaDelMedidor, Modelo, Serie From Padron_" & dgvmedidor.Rows(1).Cells(4).Value.ToString() & " Where NumImport In (Select  Max(NumImport) from Padron_" & dgvmedidor.Rows(1).Cells(4).Value.ToString() & ")"
            'MsgBox(objCommand1.CommandText)
            objCommand1.ExecuteNonQuery()
            'MsgBox("ex DB")
        Catch ex As Exception
            MsgBox(ex.ToString)
            MsgBox(objCommand1.CommandText)
        Finally
            objCommand1.Dispose()
            objCon1.Close()
        End Try
    End Sub
End Class