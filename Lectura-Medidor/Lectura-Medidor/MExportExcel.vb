Imports System.IO
Module MExportExcel
    Public Sub ExportPadron(ByVal lista As List(Of String), ByVal dgvpadron As DataGridView)
        Dim FilePadron As String = "Exportados\" & "Padron" & "--" & Now.Year & "-" & Now.Month & "-" & Now.Day & "--" & Now.Hour & "-" & Now.Minute & "-" & Now.Second & ".xls"
        If File.Exists(FilePadron) Then File.Delete(FilePadron)

        MConsultasDB.ExportPadron(lista, dgvpadron)

        Dim fw As New StreamWriter(FilePadron, False)
        With fw
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

            If dgvpadron.Name = "Hoja" Then
                .WriteLine("    <Worksheet ss:Name=""Hoja1"">") 'SET NAMA SHEET
                .WriteLine("        <Table>")
                .WriteLine("            <Column ss:Width=""100""/>") '"Número de Padrón Actual"
                .WriteLine("            <Column ss:Width=""100""/>") '"Item"
                .WriteLine("            <Column ss:Width=""100""/>") '"Codigo Ruta de Suministro"
                .WriteLine("            <Column ss:Width=""100""/>") '"Codigo de Suministro"
                .WriteLine("            <Column ss:Width=""100""/>") '"Nombre de Suministro"
                .WriteLine("            <Column ss:Width=""100""/>") '"Direccion del Predio"
                .WriteLine("            <Column ss:Width=""100""/>") '"Nombre del Sector"
                .WriteLine("            <Column ss:Width=""100""/>") '"Tension"
                .WriteLine("            <Column ss:Width=""100""/>") '"Tarifa"
                .WriteLine("            <Column ss:Width=""100""/>") '"Sistema Electrico"
                .WriteLine("            <Column ss:Width=""100""/>") '"Actividad Economica"
                .WriteLine("            <Column ss:Width=""100""/>") '"Factor de Tension"
                .WriteLine("            <Column ss:Width=""100""/>") '"Factor de Corriente"
                .WriteLine("            <Column ss:Width=""100""/>") '"Factor de Transformacion EA"
                .WriteLine("            <Column ss:Width=""100""/>") '"Marca del Medidor"
                .WriteLine("            <Column ss:Width=""100""/>") '"Modelo"
                .WriteLine("            <Column ss:Width=""100""/>") '"Serie"
                .WriteLine("            <Column ss:Width=""100""/>") '"Uno"
                .WriteLine("            <Column ss:Width=""100""/>") '"Dos"
                .WriteLine("            <Column ss:Width=""100""/>") '"Tres"
                .WriteLine("            <Column ss:Width=""100""/>") '"Fecha"
                .WriteLine("            <Column ss:Width=""100""/>") '"Cinco"
                .WriteLine("            <Column ss:Width=""100""/>") '"Seis"
                .WriteLine("            <Column ss:Width=""100""/>") '"Siete"
                .WriteLine("            <Column ss:Width=""100""/>") '"Dies"
            End If
            'AUTO SET HEADER
            .WriteLine("            <Row ss:StyleID=""ksg"">")

            For i As Integer = 0 To dgvpadron.Columns.Count - 1 'SET HEADER
                Application.DoEvents()
                .WriteLine("            <Cell ss:StyleID=""hdr"">")
                .WriteLine("                <Data ss:Type=""String"">{0}</Data>", dgvpadron.Columns.Item(i).HeaderText)
                .WriteLine("            </Cell>")
            Next
            .WriteLine("            </Row>")

            For intRow As Integer = 0 To dgvpadron.RowCount - 2
                Application.DoEvents()
                .WriteLine("        <Row ss:StyleID=""ksg"" ss:utoFitHeight =""0"">")
                For intCol As Integer = 0 To dgvpadron.Columns.Count - 1
                    Application.DoEvents()
                    .WriteLine("        <Cell ss:StyleID=""isi"">")
                    .WriteLine("            <Data ss:Type=""String"">{0}</Data>", dgvpadron.Item(intCol, intRow).Value.ToString)
                    .WriteLine("        </Cell>")
                Next
                .WriteLine("        </Row>")
            Next
            .WriteLine("        </Table>")
            .WriteLine("    </Worksheet>")
            .WriteLine("</Workbook>")
            .Close()
        End With
        Process.Start(FilePadron)
    End Sub
    Public Sub ExportToExcel(ByVal DGV As DataGridView, ByVal FlNm As String, ByVal exportar As Integer)
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

            If exportar = 1 Then
                If DGV.Name = "Hoja" Then
                    .WriteLine("    <Worksheet ss:Name=""Hoja1"">") 'SET NAMA SHEET
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
            End If
            .Close()
        End With
    End Sub
    Public Sub AddExcelHeader(ByVal DGV As DataGridView, ByVal NameSector As String, ByVal FlNm As String)
        Dim fs As New StreamWriter(FlNm, True)
        With fs
            If DGV.Name = "Hoja" Then
                .WriteLine("    <Worksheet ss:Name=""" & NameSector & """>") 'SET NAMA SHEET
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
        End With
        fs.Close()
    End Sub
    Public Sub AddExcelBody(ByVal DGV As DataGridView, ByVal FlNm As String)
        Dim fs As New StreamWriter(FlNm, True)
        With fs
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
            .Close()
        End With
    End Sub
    Public Sub IntegridadLecturas(ByVal id_medidorserie As String, ByVal dgv As DataGridView, ByVal NombreSector As String, ByVal Report As String)
        Dim id_serie As Integer
        Dim anio As String
        Dim mes As String
        Dim cant_dias As Integer
        Dim cant_lecturas As Integer
        id_serie = CInt(Val(id_medidorserie))

        Dim ListaParaComparar As New List(Of String)
        Dim ListaCompleta As New List(Of String)

        anio = dgv.Item(4, 1).Value.ToString().Substring(0, 4) 'obtenemo el formato 201807010015 -- 2018-07-01-00-15
        mes = dgv.Item(4, 1).Value.ToString().Substring(4, 2)

        cant_dias = System.DateTime.DaysInMonth(anio, mes) 'Obtiene la cantidad de días indicandole el Año y el Mes
        cant_lecturas = (cant_dias * 4) 'cantidad de lecturas por mes

        For intdias As Integer = 1 To cant_dias
            For inthoras As Integer = 0 To 23
                ListaCompleta.Add(anio & mes & IIf(intdias < 10, "0" & intdias, intdias) & IIf(inthoras < 10, "0" & inthoras, inthoras) & "00")
                ListaCompleta.Add(anio & mes & IIf(intdias < 10, "0" & intdias, intdias) & IIf(inthoras < 10, "0" & inthoras, inthoras) & "15")
                ListaCompleta.Add(anio & mes & IIf(intdias < 10, "0" & intdias, intdias) & IIf(inthoras < 10, "0" & inthoras, inthoras) & "30")
                ListaCompleta.Add(anio & mes & IIf(intdias < 10, "0" & intdias, intdias) & IIf(inthoras < 10, "0" & inthoras, inthoras) & "45")
            Next
        Next
        ListaCompleta.Add(anio & IIf((Val(mes) + 1) < 10, "0" & Val(mes) + 1, Val(mes) + 1) & "010000")
        If ListaCompleta.Item(0).Contains("0000") Then
            ListaCompleta.RemoveAt(0)
        End If

        For intRow As Integer = 0 To dgv.RowCount - 1
            ListaParaComparar.Add(dgv.Item(4, intRow).Value.ToString())
        Next

        Dim ListadeDiferencias As List(Of String) = ListaCompleta.Except(ListaParaComparar).ToList()

        If NombreSector = "" Then
            MConsultasDB.ConsultaSector(id_serie, NombreSector)
            If NombreSector = "" Then NombreSector = "No Tiene"
        End If

        If ListadeDiferencias.Count > 0 Then
            Dim texto As New StreamWriter(Report, True)
            With texto
                .WriteLine("Nombre del Archivo : {0}", id_medidorserie)
                .WriteLine("Nombre del Sector : {0}", NombreSector)
                .WriteLine("Lecturas Faltantes:")
                For ii = 0 To ListadeDiferencias.Count - 1
                    Dim fechaReg As String
                    Dim horaReg As String
                    Dim imprimerReg As String
                    fechaReg = ListadeDiferencias.Item(ii).Substring(0, 4) & "-" & ListadeDiferencias.Item(ii).Substring(4, 2) & "-" & ListadeDiferencias.Item(ii).Substring(6, 2)
                    horaReg = ListadeDiferencias.Item(ii).Substring(8, 2) & ":" & ListadeDiferencias.Item(ii).Substring(10, 2)
                    imprimerReg = "Fecha :" & fechaReg & " y Hora: " & horaReg
                    .WriteLine("                   {0}", imprimerReg)
                Next ii
                .WriteLine("")
                .WriteLine("")
                .Close()
            End With
        End If


        'Module1.integridadLecturas = ListadeDiferencias
        '
        'Dim formDB As New IntegridadLecturas
        'formDB.ShowDialog()

        ListaParaComparar.Clear()
        ListaCompleta.Clear()
    End Sub
    'se encargara de guardar los querys en un archivo de texto para unirlos en insert de 30 unidades
    Sub GenerarQuerysHistoricos(ByVal DGV As DataGridView, ByVal NumImport As String)
        'dividir el contenido en bloques y agregar el sobrante
        Dim dividirEnBloques As Integer
        Dim inquery As Integer = 1
        dividirEnBloques = 30 ' modificar el numero de archivos que se tomaran por hoja

        Dim FlNm As String = "exportDB.txt"
        If File.Exists(FlNm) Then File.Delete(FlNm)
        Dim fs As New StreamWriter(FlNm, False)

        Dim dividirBloque As Integer = 50 'dividir los datos en querys
        With fs
            .Write("insert into Historico (NumImport, Sector, Mes, CodigoEmpresa, CodigoSuministro, CodigoBarraCompra, FechaHora, EA) ")
            For intRow As Integer = 0 To DGV.RowCount - 1

                Application.DoEvents()
                .Write(" SELECT ")
                .Write("""{0}"",", NumImport)
                .Write("""{0}"",", MVariables.NombreSector)

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
End Module
