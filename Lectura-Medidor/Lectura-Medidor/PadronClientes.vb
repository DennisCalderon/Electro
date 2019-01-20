﻿
Imports System.Data.OleDb
Public Class PadronClientes
    Private Sub PadronClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnProcesar.Enabled = False
        dgvmedidor.AllowUserToAddRows = False ' denegar la acción de registros al usuario
        cboSector.Items.Add("Tacna")
        cboSector.Items.Add("Moquegua")
        cboSector.Items.Add("Ilo")
        cboSector.Items.Add("Libres")
        cboSector.Items.Add("Todos")
        cboSector.SelectedIndex = 0
    End Sub
    Private Sub btnMostrarPadron_Click(sender As Object, e As EventArgs) Handles btnMostrarPadron.Click
        btnProcesar.Enabled = False
        dgvmedidor.DataMember = ""
        dgvmedidor.DataSource = ""

        Dim tipo_cbo As Integer
        Dim NombreSector As String = ""
        tipo_cbo = cboSector.SelectedIndex
        Select Case tipo_cbo
            Case 0 : NombreSector = "Tacna"
            Case 1 : NombreSector = "Moquegua"
            Case 2 : NombreSector = "Ilo"
            Case 3 : NombreSector = "Libres"
            Case 4 : NombreSector = "Todos"
        End Select

        MConsultasDB.MostrarPadron(NombreSector, dgvmedidor)
        dgvmedidor.AllowUserToAddRows = False ' denegar la acción de registros al usuario
    End Sub

    Private Sub btnCargarExcel_Click(sender As Object, e As EventArgs) Handles btnCargarExcel.Click
        dgvmedidor.DataMember = ""
        dgvmedidor.DataSource = ""

        btnMostrarPadron.Enabled = False
        btnProcesar.Enabled = False
        btnExportar.Enabled = False

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
                    btnProcesar.Enabled = True
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

                btnProcesar.Enabled = True

            Catch ex As Exception
                'MessageBox.Show(ex.Message)
                MsgBox("Inserte un nombre valido de la Hoja que desea importar", MsgBoxStyle.Information, "Informacion")
            End Try
        End If
        btnMostrarPadron.Enabled = True
        btnExportar.Enabled = True
        dgvmedidor.AllowUserToAddRows = False ' denegar la acción de registros al usuario
        xSheet = ""
    End Sub

    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        'MsgBox(dgvmedidor.Rows(1).Cells(4).Value.ToString())
        cboSector.Enabled = False
        btnCargarExcel.Enabled = False
        btnProcesar.Enabled = False
        btnMostrarPadron.Enabled = False
        btnExportar.Enabled = False

        Dim NumImport As Integer
        'MsgBox(dgvmedidor.Rows(2).Cells(4).Value.ToString())
        MConsultasDB.ConsultaNumImport(dgvmedidor.Rows(2).Cells(4).Value.ToString(), NumImport) ' obtener el último ID del lote de medidores en la DB

        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = dgvmedidor.Rows.Count * 1.005
        Dim item As Integer = 1
        With dgvmedidor
            If .Rows.Count > 0 Then
                btnCargarExcel.Enabled = False
                btnProcesar.Enabled = False
                dgvmedidor.Enabled = False
                'ConsultaNumImport(NumImport)
                For i As Integer = 0 To .Rows.Count - 1
                    Application.DoEvents()
                    'MsgBox(NumImport)
                    'MsgBox(dgvmedidor.Rows(i).Cells(0).Value.ToString())
                    If String.IsNullOrEmpty(.Rows(i).Cells(0).Value.ToString()) = False Then

                        MConsultasDB.GuardarPadron(NumImport, item, .Rows(i).Cells(0).Value.ToString(), .Rows(i).Cells(1).Value.ToString(), .Rows(i).Cells(2).Value.ToString(), .Rows(i).Cells(3).Value.ToString(), .Rows(i).Cells(4).Value.ToString(), .Rows(i).Cells(5).Value.ToString(), .Rows(i).Cells(6).Value.ToString(), .Rows(i).Cells(7).Value.ToString(), .Rows(i).Cells(8).Value.ToString(), .Rows(i).Cells(9).Value.ToString(), .Rows(i).Cells(10).Value.ToString(), .Rows(i).Cells(11).Value.ToString(), .Rows(i).Cells(12).Value.ToString(), .Rows(i).Cells(13).Value.ToString(), .Rows(i).Cells(14).Value.ToString())
                    End If
                    ProgressBar1.Value = i + 1
                    item = item + 1
                Next
            End If
        End With
        MsgBox("Padrón Actualizado", MsgBoxStyle.Information, "Proceso de Cargar Terminado")
        MConsultasDB.ActualizarPadronGeneral()
        ProgressBar1.Value = 0
        Me.Close()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Dim form As New PadronClientesExcel
        form.ShowDialog()
    End Sub
End Class