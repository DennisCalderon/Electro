Imports System.IO
Imports System.Data.SQLite
Public Class Form1
    Const cadena_conexion As String = "Data Source=Electro.db;Version=3"
    Dim exportar As Integer = 1
    Dim ruta_general As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbotipomedidor.Items.Add("S-1440")
        cbotipomedidor.Items.Add("A-1800")
        cbotipomedidor.Items.Add("MH-TAB")
        cbotipomedidor.SelectedIndex = 0 ' colocar el focus en el item 0
        dgvcontenido.AllowUserToAddRows = False ' denegar la acción de registros al usuario

        'btnBuscar.Enabled = False
        btnNuevo.Enabled = False
        btnExportUnit.Enabled = False
        btnExportMasivo.Enabled = False

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        'buscar la ruta de los archivos
        Dim tipo_archivo As Integer
        Dim tipos_archivo As String = String.Empty

        tipo_archivo = cbotipomedidor.SelectedIndex
        Select Case tipo_archivo
            Case 0 : tipos_archivo = "S-1440|*.LP"
            Case 1 : tipos_archivo = "A-1800|*.prn"
            Case 2 : tipos_archivo = "MH-TAB|*.tab"
        End Select

        OpenFileDialog1.Title = "Buscando la ubicación de los Archivos"
        OpenFileDialog1.FileName = "Archivos"

        OpenFileDialog1.Filter = tipos_archivo

        'OpenFileDialog1.Filter = "S-1440|*.LP" +
        '                        "|A-1800|*.prn" +
        '                       "|MH-TAB|*.tab"
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtruta.Text = OpenFileDialog1.FileName

            lbArchivos.Items.Clear()
            'MsgBox(tipos_archivo.Remove(0, 7))
            Dim ruta As String '= "C:\Users\sing_\source\repos\Electrosur\Recursos"
            ruta = txtruta.Text.Substring(0, (txtruta.Text.LastIndexOf("\") + 1))
            ruta_general = ruta
            Dim folder As New DirectoryInfo(ruta)
            Dim cant_archivos As Integer = 0

            For Each file As FileInfo In folder.GetFiles(tipos_archivo.Remove(0, 7))
                lbArchivos.Items.Add(file.Name)
                cant_archivos = cant_archivos + 1
            Next
            lblarchivos.Text = cant_archivos

            btnBuscar.Enabled = False
            cbotipomedidor.Enabled = False
            btnNuevo.Enabled = True
            btnNuevo.Select()
            btnExportMasivo.Enabled = True
        Else
            MsgBox("No seleccionaste nada", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        btnBuscar.Enabled = True
        cbotipomedidor.Enabled = True
        lblregistros.Text = "0"
        lblarchivos.Text = "0"
        btnNuevo.Enabled = False
        btnExportUnit.Enabled = False
        btnExportMasivo.Enabled = False
        'btnExportUnit.Enabled = False
        'btnExportMasivo.Enabled = False
        lbArchivos.Items.Clear()
        dgvcontenido.Rows.Clear()
        btnBuscar.Select()
    End Sub

    Private Sub lbArchivos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbArchivos.SelectedIndexChanged
        btnNuevo.Enabled = False
        btnExportUnit.Enabled = False
        btnExportMasivo.Enabled = False

        dgvcontenido.Rows.Clear()

        Dim ruta As String = ruta_general.Substring(0, (ruta_general.LastIndexOf("\") + 1))
        ruta = ruta & lbArchivos.SelectedItem
        txtruta.Text = ruta
        'MsgBox(ruta, MsgBoxStyle.Information, "leyendo")
        obtenertotal(dgvcontenido, ruta)

        'diferenciar entre la exportación unitaria y la masiva
        If (exportar = 1) Then
            dgvcontenido.Rows.Clear()
        End If


        Dim tipo_archivo As Integer
        tipo_archivo = cbotipomedidor.SelectedIndex
        Select Case tipo_archivo
            Case 0 : lecturaArchivo(dgvcontenido, ruta, " ", 2)
            Case 1 : lecturaArchivo(dgvcontenido, ruta, ",", 0)
            Case 2 : lecturaArchivo(dgvcontenido, ruta, vbTab, 1)
        End Select

        'MsgBox(lbArchivos.SelectedItem, MsgBoxStyle.Information, "leyendo")
        'MsgBox(ruta, MsgBoxStyle.Information, "leyendo")

        btnNuevo.Enabled = True
        btnExportUnit.Enabled = True
        btnExportMasivo.Enabled = True
    End Sub
    Sub obtenertotal(ByVal tabla As DataGridView, ByVal ruta As String)
        Dim objReader As New StreamReader(ruta)
        Dim sLine As String = ""
        Dim fila As Integer = 0
        'tabla.Rows.Clear()

        Dim id_medidor As String = "" ''Número de identificación=06677067	Factor U=1	Factor I=1
        Do
            sLine = objReader.ReadLine()

            If Not sLine Is Nothing Then
                fila += 1
            End If

        Loop Until sLine Is Nothing

        Dim tipo_archivo As Integer
        tipo_archivo = cbotipomedidor.SelectedIndex
        Select Case tipo_archivo
            Case 0 : lblregistros.Text = fila - 4
            Case 1 : lblregistros.Text = fila - 2
            Case 2 : lblregistros.Text = fila - 3
        End Select

        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = fila
        objReader.Close()
    End Sub
    Sub lecturaArchivo(ByVal tabla As DataGridView, ByVal ruta As String, ByVal caracter As String, ByVal numfila As Integer)
        Dim objReader As New StreamReader(ruta)
        Dim sLine As String = ""
        Dim fila As Integer = 0
        Dim fila2 As Integer = 0
        'tabla.Rows.Clear()
        tabla.AllowUserToAddRows = False

        Dim id_medidor As String = "" ''Número de identificación=06677067	Factor U=1	Factor I=1
        Do
            sLine = objReader.ReadLine()

            If Not sLine Is Nothing Then

                If fila = 0 Then
                    id_medidor = CInt(Val(lbArchivos.SelectedItem))
                    'id_medidor = CInt(id_medidor)
                    'MsgBox(id_medidor, MsgBoxStyle.Information, "leyendo")
                    fila += 1

                Else
                    If fila2 > numfila Then
                        'MsgBox(sLine, MsgBoxStyle.Information, "leyendo")

                        agregarFilaCaso(tabla, sLine, caracter, id_medidor)
                    End If
                    txtruta.Text = sLine
                    'MsgBox(sLine, MsgBoxStyle.Information, "leyendo")
                    fila2 += 1
                End If
                'MsgBox(id_medidor, MsgBoxStyle.Information, "leyendo")

            End If
            ProgressBar1.Value = fila2

        Loop Until sLine Is Nothing

        'MsgBox(fila2, MsgBoxStyle.Information, "leyendo")
        objReader.Close()
        ProgressBar1.Value = 0
    End Sub
    Sub agregarFilaCaso(ByVal tabla As DataGridView, ByVal linea As String, ByVal caracter As String, ByVal id_medidor As Integer)
        Dim arreglo() As String = linea.Split(caracter)
        Dim cod_empresa As String = "ELS"
        Dim cod_barra As String = "B0229"
        Dim fech_hora As String
        Dim fech As Date
        Dim mes As String
        Dim Potencia As String

        Dim IdMedidor As String
        Dim FTEA As String
        Dim EA As Double

        'MsgBox(arreglo(0), MsgBoxStyle.Information, "leyendo")
        'MsgBox(arreglo(1), MsgBoxStyle.Information, "leyendo")
        'MsgBox(arreglo(2), MsgBoxStyle.Information, "leyendo")
        'MsgBox(arreglo(3), MsgBoxStyle.Information, "leyendo")
        'MsgBox(arreglo(4), MsgBoxStyle.Information, "leyendo")
        'MsgBox(arreglo(5), MsgBoxStyle.Information, "leyendo")

        Dim tipo_archivo As Integer
        tipo_archivo = cbotipomedidor.SelectedIndex
        Select Case tipo_archivo
            Case 0
                fech = CStr(arreglo(0))
                fech_hora = CStr(fech.Year) & (If(fech.Month < 10, 0 & fech.Month, fech.Month)) & CStr(If(fech.Day < 10, 0 & fech.Day, fech.Day)) &
                    (Replace(arreglo(1).Substring(0, 5), ":", ""))
                'MsgBox(fech_hora, MsgBoxStyle.Information, "leyendo")
                'MsgBox(arreglo(4), MsgBoxStyle.Information, "leyendo")
                mes = fech.Month
                'MsgBox(mes, MsgBoxStyle.Information, "leyendo")
                Potencia = arreglo(4)
                consulta(CStr(id_medidor), IdMedidor, FTEA)
                'MsgBox(Val(Potencia), MsgBoxStyle.Information, "leyendo")
                'MsgBox(Val(Replace(FTEA, ",", ".")), MsgBoxStyle.Information, "leyendo")
                'MsgBox((Val(Potencia) * Val(Replace(FTEA, ",", "."))), MsgBoxStyle.Information, "leyendo")
                'MsgBox(arreglo(3), MsgBoxStyle.Information, "leyendo")
                EA = ((Val(Potencia) * (Val(Replace(FTEA, ",", ".")) / 4)))
                'MsgBox(CStr(EA), MsgBoxStyle.Information, "leyendo")

            Case 1
                fech = CStr(arreglo(1).Substring(1, 8))

                fech_hora = CStr(fech.Year) & (If(fech.Month < 10, 0 & fech.Month, fech.Month)) & CStr(If(fech.Day < 10, 0 & fech.Day, fech.Day)) &
                            (Replace(arreglo(2).Substring(1, 5), ":", ""))

                'MsgBox(fech_hora, MsgBoxStyle.Information, "leyendo")

                mes = fech.Month
                'MsgBox(mes, MsgBoxStyle.Information, "leyendo")

                Potencia = arreglo(4)

                consulta(CStr(id_medidor), IdMedidor, FTEA)

                'MsgBox(Val(Potencia), MsgBoxStyle.Information, "leyendo")
                'MsgBox(Val(Replace(FTEA, ",", ".")), MsgBoxStyle.Information, "leyendo")
                'MsgBox((Val(Potencia) * Val(Replace(FTEA, ",", "."))), MsgBoxStyle.Information, "leyendo")
                'MsgBox(arreglo(3), MsgBoxStyle.Information, "leyendo")
                EA = ((Val(Potencia) * (Val(Replace(FTEA, ",", ".")) / 4)))
                'MsgBox(CStr(EA), MsgBoxStyle.Information, "leyendo")

            Case 2
                fech = CStr(arreglo(0))

                fech_hora = CStr(fech.Year) & (If(fech.Month < 10, 0 & fech.Month, fech.Month)) & CStr(If(fech.Day < 10, 0 & fech.Day, fech.Day)) &
                    (Replace(arreglo(1).Substring(0, 5), ":", ""))

                'MsgBox(fech_hora, MsgBoxStyle.Information, "leyendo")

                mes = fech.Month
                'MsgBox(mes, MsgBoxStyle.Information, "leyendo")

                Potencia = arreglo(3)

                consulta(CStr(id_medidor), IdMedidor, FTEA)

                'MsgBox(Val(Potencia), MsgBoxStyle.Information, "leyendo")
                'MsgBox(Val(Replace(FTEA, ",", ".")), MsgBoxStyle.Information, "leyendo")
                'MsgBox((Val(Potencia) * Val(Replace(FTEA, ",", "."))), MsgBoxStyle.Information, "leyendo")
                'MsgBox(arreglo(3), MsgBoxStyle.Information, "leyendo")
                EA = ((Val(Potencia) * (Val(Replace(FTEA, ",", ".")) / 4)))
                'MsgBox(CStr(EA), MsgBoxStyle.Information, "leyendo")
        End Select


        EA = Math.Round(EA, 5)
        tabla.Rows.Add(mes, cod_empresa, IdMedidor, cod_barra, fech_hora, CStr(EA))

    End Sub
    Sub consulta(ByVal serie As String, ByRef IdMedidor As String, ByRef FTEA As String)

        Dim objCon As SQLiteConnection
        Dim objCommand As SQLiteCommand
        Dim objReader As SQLiteDataReader

        Try
            objCon = New SQLiteConnection(cadena_conexion)
            objCon.Open()
            objCommand = objCon.CreateCommand()
            'MsgBox("primero", MsgBoxStyle.Information, "leyendo")
            'objCommand.CommandText = "select FactortransformacionEA from clientes where serie='" & serie & "'"
            objCommand.CommandText = "select CodigoSuministro, FactorTransformacionEA from clientes where serie=" & serie & ""
            'MsgBox(objCommand.CommandText, MsgBoxStyle.Information, "leyendo")
            objReader = objCommand.ExecuteReader()

            'MsgBox((objReader.Read()), MsgBoxStyle.Information, "leyendo")
            If objReader.Read() Then
                IdMedidor = objReader.Item("CodigoSuministro").ToString
                FTEA = objReader.Item("FactorTransformacionEA").ToString
                'MsgBox(CStr(FTEA), MsgBoxStyle.Information, "leyendo")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            If Not IsNothing(objCon) Then
                objCon.Close()
            End If
        End Try

    End Sub

    Private Sub btnExportUnit_Click(sender As Object, e As EventArgs) Handles btnExportUnit.Click
        btnNuevo.Enabled = False
        btnExportUnit.Enabled = False
        btnExportMasivo.Enabled = False
        lblarchivos.Enabled = False
        dgvcontenido.Enabled = False

        If dgvcontenido.RowCount = 0 Then Return

        Application.DoEvents()

        Dim DGV As New DataGridView

        With DGV
            .AllowUserToAddRows = False
            .Name = "Procesos"
            .Visible = False
            .Columns.Clear()
            .Columns.Add("Column1", "Mes")
            .Columns.Add("Column2", "Código de Empresa")
            .Columns.Add("Column3", "Código de Suministro")
            .Columns.Add("Column4", "Código de Barra de Compra")
            .Columns.Add("Column5", "Fecha / Hora")
            .Columns.Add("Column6", "EA")

        End With
        With dgvcontenido
            If .Rows.Count > 0 Then
                For i As Integer = 0 To .Rows.Count - 1

                    Application.DoEvents()
                    DGV.Rows.Add(.Rows(i).Cells("Column1").Value, .Rows(i).Cells("Column2").Value,
                                 .Rows(i).Cells("Column3").Value, .Rows(i).Cells("Column4").Value,
                                 .Rows(i).Cells("Column5").Value, .Rows(i).Cells("Column6").Value)
                Next
            End If
        End With
        FlNm2 = Val(lbArchivos.SelectedItem)
        'MsgBox(FlNm2, MsgBoxStyle.Information, "leyendo")
        FlNm = "Exportados\" & FlNm2 & "--" & Now.Year & "-" & Now.Month & "-" & Now.Day & "--" & Now.Hour & "-" & Now.Minute & "-" & Now.Second & ".xls"
        'FlNm = "Exportados\" & FlNm2 & ".xls"
        'FlNm = Application.StartupPath & "\Student " _
        '        & Now.Day & "-" & Now.Month & "-" & Now.Year & ".xls"
        If File.Exists(FlNm) Then File.Delete(FlNm)
        ExportToExcel(DGV)

        DGV.Dispose()
        DGV = Nothing

        'Process.Start("Exportados\" & Now.Day & "-" & Now.Month & "-" & Now.Year & ".xls")
        Process.Start(FlNm)
        'Process.Start("Exportados\" & FlNm2 & ".xls")
        btnNuevo.Enabled = True
        btnExportUnit.Enabled = True
        btnExportMasivo.Enabled = True
        lblarchivos.Enabled = True
        dgvcontenido.Enabled = True
    End Sub
    'EXPORTAR a EXCEL
    Dim FlNm As String
    Dim FlNm2 As String
    Private Sub ExportToExcel(ByVal DGV As DataGridView)
        Dim fs As New StreamWriter(FlNm, False)
        With fs
            .WriteLine("<?xml version=""1.0""?>")
            .WriteLine("<?mso-application progid=""Excel.Sheet""?>")
            .WriteLine("<Workbook xmlns=""urn:schemas-microsoft-com:office:spreadsheet"">")
            .WriteLine("    <Styles>")
            .WriteLine("        <Style ss:ID=""hdr"">")
            .WriteLine("            <Alignment ss:Horizontal=""Center""/>")
            .WriteLine("            <Borders>")
            .WriteLine("                <Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
            .WriteLine("                <Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
            .WriteLine("                <Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
            .WriteLine("            </Borders>")
            .WriteLine("            <Font ss:FontName=""Calibri"" ss:Size=""11"" ss:Bold=""1""/>") 'SET FONT
            .WriteLine("        </Style>")
            .WriteLine("        <Style ss:ID=""ksg"">")
            .WriteLine("            <Alignment ss:Vertical=""Bottom""/>")
            .WriteLine("            <Borders/>")
            .WriteLine("            <Font ss:FontName=""Calibri""/>") 'SET FONT
            .WriteLine("        </Style>")
            .WriteLine("        <Style ss:ID=""isi"">")
            .WriteLine("            <Borders>")
            .WriteLine("                <Border ss:Position=""Bottom"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
            .WriteLine("                <Border ss:Position=""Left"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
            .WriteLine("                <Border ss:Position=""Right"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
            .WriteLine("                <Border ss:Position=""Top"" ss:LineStyle=""Continuous"" ss:Weight=""1""/>")
            .WriteLine("            </Borders>")
            .WriteLine("            <Font ss:FontName=""Calibri"" ss:Size=""10""/>") 'SET FONT
            .WriteLine("        </Style>")
            .WriteLine("    </Styles>")
            If DGV.Name = "Procesos" Then
                .WriteLine("    <Worksheet ss:Name=""Procesos"">") 'SET NAMA SHEET
                .WriteLine("        <Table>")
                .WriteLine("            <Column ss:Width=""40""/>") '   "Mes"
                .WriteLine("            <Column ss:Width=""93""/>") '   "Código de Empresa"
                .WriteLine("            <Column ss:Width=""84""/>") '   "Código de Suministro"
                .WriteLine("            <Column ss:Width=""100""/>") '  "Código de Barra de Compra"
                .WriteLine("            <Column ss:Width=""84""/>") '   "Fecha / Hora"
                .WriteLine("            <Column ss:Width=""90""/>") '   "EA"
            End If
            'AUTO SET HEADER
            .WriteLine("            <Row ss:StyleID=""ksg"">")
            For i As Integer = 0 To DGV.Columns.Count - 1 'SET HEADER
                Application.DoEvents()
                .WriteLine("            <Cell ss:StyleID=""hdr"">")
                .WriteLine("                <Data ss:Type=""String"">{0}</Data>", DGV.Columns.Item(i).HeaderText)
                .WriteLine("            </Cell>")
            Next
            .WriteLine("            </Row>")
            For intRow As Integer = 0 To DGV.RowCount - 1
                Application.DoEvents()
                .WriteLine("        <Row ss:StyleID=""ksg"" ss:utoFitHeight =""0"">")
                For intCol As Integer = 0 To DGV.Columns.Count - 1
                    Application.DoEvents()
                    .WriteLine("        <Cell ss:StyleID=""isi"">")
                    .WriteLine("            <Data ss:Type=""String"">{0}</Data>", DGV.Item(intCol, intRow).Value.ToString)
                    .WriteLine("        </Cell>")
                Next
                .WriteLine("        </Row>")
            Next
            .WriteLine("        </Table>")
            .WriteLine("    </Worksheet>")
            .WriteLine("</Workbook>")
            .Close()
        End With
    End Sub
End Class
