Imports System.IO
Public Class Principal
    Dim ruta_general As String 'almacena la ruta de la carpeta donde se encuentran los archivos de lecturas
    Dim exportar As Integer = 1 'determina si la exportación en de forma Unitaria o Masiva
    Dim conteoTotal As Integer = 1 'determina el incremente en la Barra de Progreso
    Dim registrosTotales As Integer
    Sub leerTiposMedidores(ByRef tipos_archivo As String)
        If chkS1440.Checked = True Then tipos_archivo = "S-1440|*.LP"
        If chkA1800.Checked = True Then tipos_archivo = "A-1800|*.prn"
        If chkMHTAB.Checked = True Then tipos_archivo = "MH-TAB|*.tab"
        If chkS1440.Checked = True And chkA1800.Checked = True Then tipos_archivo = "S-1440 y A-1800|*.LP;*.prn" '"S-1440|*.LP" & "|A-1800|*.prn"
        If chkS1440.Checked = True And chkMHTAB.Checked = True Then tipos_archivo = "S-1440 y MH-TAB|*.LP;*.tab" '"S-1440|*.LP" & "|MH-TAB|*.tab"
        If chkA1800.Checked = True And chkMHTAB.Checked = True Then tipos_archivo = "A-1800 y MH-TAB|*.prn;*.tab" ' "A-1800|*.prn" & "|MH-TAB|*.tab"
        If chkS1440.Checked = True And chkA1800.Checked = True And chkMHTAB.Checked = True Then tipos_archivo = "S-1440 y A-1800 y MH-TAB|*.LP;*.prn;*.tab" '"S-1440|*.LP" & "|A-1800|*.prn" & "|MH-TAB|*.tab"
    End Sub
    Sub checkedMedidor(ByVal X As Boolean)
        chkS1440.Enabled = X
        chkA1800.Enabled = X
        chkMHTAB.Enabled = X
    End Sub
    Sub checkedPadron(ByVal X As Boolean)
        chkTacna.Enabled = X
        chkMoquegua.Enabled = X
        chkIlo.Enabled = X
        chkLibres.Enabled = X
    End Sub
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        'buscar la ruta de los archivos
        Dim tipos_archivo As String = "Ejecutables|*.exe" ' por si el usuario no elije ningún checked se le colocara esto por defecto

        leerTiposMedidores(tipos_archivo)
        'MsgBox(tipos_archivo)

        OpenFileDialog1.Title = "Buscando la ubicación de los Archivos"
        OpenFileDialog1.FileName = "Archivos"

        OpenFileDialog1.Filter = tipos_archivo
        'OpenFileDialog1.Filter = "S-1440|*.LP" + "|A-1800|*.prn" + "|MH-TAB|*.tab"

        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim ruta As String '= "C:\Users\sing_\source\repos\Electrosur\Recursos"
            ruta = OpenFileDialog1.FileName
            txtruta.Text = OpenFileDialog1.FileName

            lbArchivos.Items.Clear()
            'MsgBox(tipos_archivo.Remove(0, 7))
            ruta = ruta.Substring(0, (ruta.LastIndexOf("\") + 1))
            ruta_general = ruta ' colocando la RUTA en la variable Global "RUTA"
            Dim folder As New DirectoryInfo(ruta)
            Dim cant_archivos As Integer = 0

            'llenar el ListBox con las lecturas
            If tipos_archivo.Contains("*.LP") = True Then
                'MsgBox(tipos_archivo)
                For Each file As FileInfo In folder.GetFiles("*.LP")
                    lbArchivos.Items.Add(file.Name)
                    cant_archivos = cant_archivos + 1
                Next
            End If
            If tipos_archivo.Contains("*.prn") = True Then
                For Each file As FileInfo In folder.GetFiles("*.prn")
                    lbArchivos.Items.Add(file.Name)
                    cant_archivos = cant_archivos + 1
                Next
            End If
            If tipos_archivo.Contains("*.tab") = True Then
                For Each file As FileInfo In folder.GetFiles("*.tab")
                    lbArchivos.Items.Add(file.Name)
                    cant_archivos = cant_archivos + 1
                Next
            End If

            lblarchivos.Text = cant_archivos

            btnBuscar.Enabled = False
            btnExportMasivo.Enabled = True
            lbArchivos.Enabled = True
            btnNuevo.Enabled = True
            checkedMedidor(False)
            checkedPadron(True)
            btnNuevo.Select()
        Else
            MsgBox("No seleccionaste nada", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnNuevo.Enabled = False
        btnExportUnit.Enabled = False
        btnExportMasivo.Enabled = False
        lbArchivos.Enabled = False
        dgvcontenido.Enabled = False
        checkedPadron(False)

        btnBuscar.Select()
        dgvcontenido.AllowUserToAddRows = False ' denegar la acción de registros al usuario
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        btnBuscar.Enabled = True
        checkedMedidor(True)
        lblregistros.Text = "0"
        lblarchivos.Text = "0"
        btnNuevo.Enabled = False
        btnExportUnit.Enabled = False
        btnExportMasivo.Enabled = False
        checkedPadron(False)

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
        Dim conteo As Integer
        Dim filasT As Integer ' este solo se usara para el conteo total de registros
        obtenertotal(ruta, conteo, filasT)

        'diferenciar entre la exportación unitaria y la masiva
        If (exportar = 1) Then
            dgvcontenido.Rows.Clear()
        End If

        Dim tipo_medidor As String
        tipo_medidor = ruta.Substring(ruta.LastIndexOf(".") + 1, 2)
        'MsgBox(tipo_medidor)
        Select Case tipo_medidor
            Case "LP" : lecturaArchivo(dgvcontenido, ruta, " ", 2, 0)
            Case "pr" : lecturaArchivo(dgvcontenido, ruta, ",", 1, 0)
            Case "ta" : lecturaArchivo(dgvcontenido, ruta, vbTab, 1, 0)
        End Select
        eliminarPrimeralineaDGV(dgvcontenido)
        btnNuevo.Enabled = True
        btnExportUnit.Enabled = True
        btnExportMasivo.Enabled = True
    End Sub
    Sub obtenertotal(ByVal ruta As String, ByRef conteo As String, ByRef filasT As Integer)
        Dim objReader As New StreamReader(ruta)
        Dim sLine As String = ""
        Dim fila As Integer = 0

        Dim id_medidor As String = "" ''Número de identificación=06677067
        Do
            sLine = objReader.ReadLine()
            If Not sLine Is Nothing Then
                fila += 1
            End If
        Loop Until sLine Is Nothing

        filasT = fila

        Dim tipo_medidor As String
        tipo_medidor = ruta.Substring(ruta.LastIndexOf(".") + 1, 2)
        'MsgBox(tipo_medidor)

        Select Case tipo_medidor
            Case "LP" : conteo = fila - 3
            Case "pr" : conteo = fila - 1
            Case "ta" : conteo = fila - 2
        End Select

        If exportar = 1 Then
            lblregistros.Text = conteo
            ProgressBar1.Minimum = 0
            ProgressBar1.Maximum = fila
        End If

        objReader.Close()
    End Sub
    Sub lecturaArchivo(ByVal tabla As DataGridView, ByVal ruta As String, ByVal caracter As String, ByVal numfila As Integer, ByRef medidor As String)
        Dim objReader As New StreamReader(ruta)
        Dim sLine As String = ""
        Dim fila As Integer = 0
        Dim fila2 As Integer = 0
        Dim primero As Integer = 1 'verificar la primera línea de lecturas en el archivo de texto
        Dim codsuministro As String = ""
        Dim FTEA As String = ""

        tabla.AllowUserToAddRows = False

        Dim id_medidor As String = "" ''Número de identificación=06677067	Factor U=1	Factor I=1
        Do
            sLine = objReader.ReadLine()

            If Not sLine Is Nothing Then

                If fila = 0 Then
                    If exportar = 2 Then
                        id_medidor = medidor
                    Else
                        id_medidor = CInt(Val(lbArchivos.SelectedItem))
                    End If
                    'consulta a la DB
                    MConsultasDB.ConsultaCodSumFT(CStr(id_medidor), codsuministro, FTEA)
                    fila += 1
                Else
                    If fila2 >= numfila Then
                        'MsgBox(sLine, MsgBoxStyle.Information, "leyendo")imero = primero + 1
                        agregarFilaCaso(tabla, sLine, caracter, id_medidor, codsuministro, FTEA, ruta)
                    End If
                    txtruta.Text = sLine
                    'MsgBox(sLine, MsgBoxStyle.Information, "leyendo")
                    fila2 += 1
                End If
            End If
            If exportar = 1 Then
                ProgressBar1.Value = fila2
            End If
            If exportar = 2 Then
                conteoTotal = conteoTotal + 1
                ProgressBar1.Value = conteoTotal
            End If
        Loop Until sLine Is Nothing

        'MsgBox(fila2, MsgBoxStyle.Information, "leyendo")
        objReader.Close()
        If exportar = 1 Then
            ProgressBar1.Value = 0
        End If
    End Sub
    Sub agregarFilaCaso(ByVal tabla As DataGridView, ByVal linea As String, ByVal caracter As String, ByVal id_medidor As Integer, ByVal codsuministro As String, ByVal FTEA As String, ByVal ruta As String)
        Dim arreglo() As String = linea.Split(caracter)
        Dim cod_empresa As String = "ELS"
        Dim cod_barra As String = "B0229"
        Dim fech_hora As String = ""
        Dim hora As Integer = 0
        Dim fech As Date
        Dim mes As String = ""
        Dim Potencia As String = ""

        'Dim codsuministro As String = ""
        'Dim FTEA As String = ""
        Dim EA As Double

        Dim tipo_medidor As String
        tipo_medidor = ruta.Substring(ruta.LastIndexOf(".") + 1, 2)
        'MsgBox(tipo_medidor)
        Select Case tipo_medidor
            Case "pr"
                fech = CStr(arreglo(1).Substring(1, 8))
                fech_hora = CStr(fech.Year) & (If(fech.Month < 10, 0 & fech.Month, fech.Month)) & CStr(If(fech.Day < 10, 0 & fech.Day, fech.Day)) &
                            (Replace(arreglo(2).Substring(1, 5), ":", ""))
                mes = fech.Month
                Potencia = arreglo(4)
                EA = ((Val(Potencia) * (Val(Replace(FTEA, ",", ".")) / 4)))
                'MsgBox(CStr(EA), MsgBoxStyle.Information, "leyendo")
            Case "LP"
                'MsgBox(arreglo(1)) ' hora    / 12:00:00
                'MsgBox(arreglo(2)) 'am - fm  / a.m.;
                'MsgBox(arreglo(3))
                If arreglo(1) = "12:00:00" And arreglo(2) = "a.m.;" Then arreglo(1) = "00:00:00"
                If arreglo(1) = "12:15:00" And arreglo(2) = "a.m.;" Then arreglo(1) = "00:15:00"
                If arreglo(1) = "12:30:00" And arreglo(2) = "a.m.;" Then arreglo(1) = "00:30:00"
                If arreglo(1) = "12:45:00" And arreglo(2) = "a.m.;" Then arreglo(1) = "00:45:00"

                If arreglo(2) = "p.m.;" Then
                    'MsgBox(arreglo(1).Substring(0, 1))
                    If Val(arreglo(1).Substring(0, 2)) >= 1 And Val(arreglo(1).Substring(0, 2)) <= 11 Then
                        hora = arreglo(1).Substring(0, 2)
                        hora = hora + 12
                        arreglo(1) = hora & arreglo(1).Remove(0, 2)
                        'MsgBox(arreglo(1))
                    End If
                End If

                fech = CStr(arreglo(0))
                fech_hora = CStr(fech.Year) & (If(fech.Month < 10, 0 & fech.Month, fech.Month)) & CStr(If(fech.Day < 10, 0 & fech.Day, fech.Day)) & (Replace(arreglo(1).Substring(0, 5), ":", ""))
                mes = fech.Month
                Potencia = arreglo(4)
                EA = ((Val(Potencia) * (Val(Replace(FTEA, ",", ".")) / 4)))
            Case "ta"
                'MsgBox(arreglo(1)) ' hora y am - fm / 04:45 a.m.
                'MsgBox(arreglo(2))
                If arreglo(1) = "12:00 a.m." Then arreglo(1) = "00:00 a.m."
                If arreglo(1) = "12:15 a.m." Then arreglo(1) = "00:15 a.m."
                If arreglo(1) = "12:30 a.m." Then arreglo(1) = "00:30 a.m."
                If arreglo(1) = "12:45 a.m." Then arreglo(1) = "00:45 a.m."

                If arreglo(1).Contains("p.m.") Then
                    'MsgBox(arreglo(1).Substring(0, 1))
                    If Val(arreglo(1).Substring(0, 2)) >= 1 And Val(arreglo(1).Substring(0, 2)) <= 11 Then
                        hora = arreglo(1).Substring(0, 2)
                        hora = hora + 12
                        arreglo(1) = hora & arreglo(1).Remove(0, 2)
                        'MsgBox(arreglo(1))
                    End If
                End If

                fech = CStr(arreglo(0))
                fech_hora = CStr(fech.Year) & (If(fech.Month < 10, 0 & fech.Month, fech.Month)) & CStr(If(fech.Day < 10, 0 & fech.Day, fech.Day)) &
                    (Replace(arreglo(1).Substring(0, 5), ":", ""))
                mes = fech.Month
                Potencia = arreglo(3)
                'consulta(CStr(id_medidor), codsuministro, FTEA)
                EA = ((Val(Potencia) * (Val(Replace(FTEA, ",", ".")) / 4)))
                'MsgBox(CStr(EA), MsgBoxStyle.Information, "leyendo")
        End Select
        EA = Math.Round(EA, 5)
        tabla.Rows.Add(mes, cod_empresa, IIf(codsuministro = "", "No Existe", codsuministro), cod_barra, fech_hora, CStr(EA))
    End Sub
    Sub eliminarPrimeralineaDGV(ByVal DGV As DataGridView)
        If (DGV.Item(4, 0).Value.ToString().Substring(8, 4) = "0000") Then
            DGV.Rows.RemoveAt(0)
        End If
    End Sub

    Private Sub ActualizarMedidoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizarMedidoresToolStripMenuItem.Click
        Dim formDB As New PadronClientes
        formDB.ShowDialog()
    End Sub
    'Exportar a Excel
    Dim FlNm As String
    Dim FlNm2 As String
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
        With dgvcontenido
            If .Rows.Count > 0 Then
                For i As Integer = 0 To .Rows.Count - 1
                    Application.DoEvents()
                    DGV.Rows.Add(.Rows(i).Cells("Column1").Value, .Rows(i).Cells("Column2").Value, .Rows(i).Cells("Column3").Value, .Rows(i).Cells("Column4").Value, .Rows(i).Cells("Column5").Value, .Rows(i).Cells("Column6").Value)
                Next
            End If
        End With
        FlNm2 = Val(lbArchivos.SelectedItem)
        'MsgBox(FlNm2, MsgBoxStyle.Information, "leyendo")
        FlNm = "Exportados\" & FlNm2 & "--" & Now.Year & "-" & Now.Month & "-" & Now.Day & "--" & Now.Hour & "-" & Now.Minute & "-" & Now.Second & ".xls"
        If File.Exists(FlNm) Then File.Delete(FlNm)
        'MsgBox("stop", MsgBoxStyle.Information, "leyendo")
        MExportExcel.ExportToExcel(DGV, FlNm, 1)

        'generando el archivo de texto que contendra las lecturas faltantes
        Report = "Exportados\Reporte" & FlNm2 & "--" & Now.Year & "-" & Now.Month & "-" & Now.Day & "--" & Now.Hour & "-" & Now.Minute & "-" & Now.Second & ".txt"
        If File.Exists(Report) Then File.Delete(Report)
        Dim fsR As New StreamWriter(Report, False)
        With fsR
            .WriteLine("Reporte de Lecturas Incompletas")
            .WriteLine("===============================")
            .Close()
        End With
        MExportExcel.IntegridadLecturas(lbArchivos.SelectedItem, DGV, "", Report)

        DGV.Dispose()
        DGV = Nothing

        Process.Start(FlNm)
        btnNuevo.Enabled = True
        btnExportUnit.Enabled = True
        btnExportMasivo.Enabled = True
        lblarchivos.Enabled = True
        dgvcontenido.Enabled = True
    End Sub

    Private Sub btnExportMasivo_Click(sender As Object, e As EventArgs) Handles btnExportMasivo.Click
        dgvcontenido.Rows.Clear()

        lbArchivos.Enabled = False
        btnNuevo.Enabled = False
        btnExportMasivo.Enabled = False
        dgvcontenido.Enabled = False

        exportar = 2

        'Mostramos el mensaje de forma centrada
        Dim name As String
        Dim XPos, YPos
        XPos = Me.Width / 2
        YPos = Me.Height / 2
        name = InputBox("Ingrese un nombre del Archivo, este campo es obligatorio", "Nombra el Archivo a Exportar", "Electrosur", XPos * 1.6, YPos)

        'recorrer el listbox que contiene el nombre de los archivos de lectura
        'comprobar que el Medidor exista
        Dim idserie As String 'comprobar que exista la serie del medidor
        Dim codsuministro As String = "", mandarCadena As String = ""
        For i = 0 To lbArchivos.Items.Count - 1
            idserie = CInt(Val(lbArchivos.Items.Item(i)))
            'MsgBox(idserie, MsgBoxStyle.Information, "leyendo")
            MConsultasDB.ConsultaCodSumFT(idserie, codsuministro, "")
            'MsgBox(codsuministro, MsgBoxStyle.Information, "leyendo")
            If codsuministro = "" Then
                mandarCadena = mandarCadena & lbArchivos.Items.Item(i) & ";"
            End If
            'MsgBox(verificar.Length(), MsgBoxStyle.Information, "leyendo")
            codsuministro = ""
        Next i
        'Mostrar en un nuevo form la lista con los Archivos que no tienen una Serie Valida
        MVariables.cadena = mandarCadena
        MVariables.verificarProceso = 1
        Dim proceso As Integer
        proceso = 2
        If mandarCadena IsNot "" Then
            Dim form As New RegistrosVacios
            form.ShowDialog()
            proceso = MVariables.verificarProceso
        End If

        'Array donde se almacenaran las TXT dependiendo de donde son: Tacna, Moquegua o Ilo
        Dim archivo As String = ""
        Dim conteo As Integer, conteoT As Integer, filasT As Integer, filasTotales As Integer
        If proceso = 2 Then
            Dim Tacna As String = "", Moquegua As String = "", Ilo As String = "", Libres As String = ""
            'Dim otros As String = ""

            For ii = 0 To lbArchivos.Items.Count - 1
                archivo = lbArchivos.Items(ii)
                Dim ruta As String = ruta_general.Substring(0, (ruta_general.LastIndexOf("\") + 1))
                ruta = ruta & archivo
                Dim NombreSector As String = ""
                MConsultasDB.ConsultaSector(CInt(Val(lbArchivos.Items.Item(ii))), NombreSector)
                'MsgBox(NombreSector)
                If NombreSector IsNot "" Then
                    NombreSector = NombreSector
                Else
                    NombreSector = ""
                End If
                Select Case NombreSector
                    Case "Tacna" : Tacna = Tacna & lbArchivos.Items(ii) & ";"
                    Case "Moquegua" : Moquegua = Moquegua & lbArchivos.Items(ii) & ";"
                    Case "Ilo" : Ilo = Ilo & lbArchivos.Items(ii) & ";"
                    Case "Libres" : Libres = Libres & lbArchivos.Items(ii) & ";"
                End Select
                obtenertotal(ruta, conteo, filasT)
                conteoT = conteo + conteoT
                filasTotales = filasT + filasTotales
            Next ii
            'MsgBox(Tacna, MsgBoxStyle.Information, "Tacna")
            'MsgBox(Moquegua, MsgBoxStyle.Information, "Moquegua")
            'MsgBox(Ilo, MsgBoxStyle.Information, "Ilo")
            'MsgBox(otros, MsgBoxStyle.Information, "otros")
            registrosTotales = filasTotales
            ProgressBar1.Minimum = 0
            ProgressBar1.Maximum = filasTotales * 1.007

            Dim DGVTotal As New DataGridView 'preparamos el DGV para la exportación masiva
            With DGVTotal
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

            'Creamos el archivo excel donde de escribiran los datos de la exportación Masiva
            FlNm2 = name
            FlNm = "Exportados\" & FlNm2 & "--" & Now.Year & "-" & Now.Month & "-" & Now.Day & "--" & Now.Hour & "-" & Now.Minute & "-" & Now.Second & ".xls"
            If File.Exists(FlNm) Then File.Delete(FlNm)
            MExportExcel.ExportToExcel(DGVTotal, FlNm, exportar)

            'generando el archivo de texto que contendra las lecturas faltantes
            Report = "Exportados\Reporte" & FlNm2 & "--" & Now.Year & "-" & Now.Month & "-" & Now.Day & "--" & Now.Hour & "-" & Now.Minute & "-" & Now.Second & ".txt"
            If File.Exists(Report) Then File.Delete(Report)
            Dim fsR As New StreamWriter(Report, False)
            With fsR
                .WriteLine("Reporte de Lecturas Incompletas")
                .WriteLine("===============================")
                .Close()
            End With

            'Aqui comienza el procesamiento de los datos
            Dim contadorReg As Integer = 1
            Dim newHojaExcel As Integer = 340 'division de hojas en la exportacion al archivo de excel
            Dim divReg As Integer = 1
            Dim id_medidor As String

            'procesamiento de los datos del Sector de Tacna
            If (Tacna IsNot "" And chkTacna.Checked = True) Then
                Tacna = Tacna.Remove(Tacna.Length - 1)
                'MsgBox(Tacna,, "tacna")
                Dim arregloTacna() As String = Tacna.Split(";")

                MExportExcel.AddExcelHeader(DGVTotal, "Tacna", FlNm)

                For intRow As Integer = 0 To arregloTacna.Length - 1
                    id_medidor = CInt(Val(arregloTacna(intRow)))
                    Dim ruta As String = ruta_general.Substring(0, (ruta_general.LastIndexOf("\") + 1))
                    ruta = ruta & arregloTacna(intRow)
                    'MsgBox(ruta,, "Tacna")

                    Dim tipo_medidor As String
                    tipo_medidor = ruta.Substring(ruta.LastIndexOf(".") + 1, 2)
                    'MsgBox(tipo_medidor)
                    Select Case tipo_medidor
                        Case "LP" : lecturaArchivo(DGVTotal, ruta, " ", 2, id_medidor)
                        Case "pr" : lecturaArchivo(DGVTotal, ruta, ",", 1, id_medidor)
                        Case "ta" : lecturaArchivo(DGVTotal, ruta, vbTab, 1, id_medidor)
                    End Select
                    eliminarPrimeralineaDGV(DGVTotal)
                    'comprobar la integridad
                    MExportExcel.IntegridadLecturas(arregloTacna(intRow), DGVTotal, "Tacna", Report)

                    MExportExcel.AddExcelBody(DGVTotal, FlNm) 'agregar el contenido al cuerpo del excel

                    'guardar los registros en la base de datos
                    MVariables.RegDB = DGVTotal
                    MVariables.NombreSector = "Tacna"
                    Dim formDB As New GuardarDGVDB
                    formDB.ShowDialog()

                    DGVTotal.Rows.Clear()

                    contadorReg = contadorReg + 1
                    If contadorReg = newHojaExcel Then
                        Dim fsTa As New StreamWriter(FlNm, True)
                        With fsTa
                            .WriteLine("        </Table>")
                            .WriteLine("    </Worksheet>")
                            .Close()
                        End With
                        divReg = divReg + 1
                        MExportExcel.AddExcelHeader(DGVTotal, "Tacna" & divReg, FlNm)
                        contadorReg = 0
                    End If
                Next
                Dim fsT As New StreamWriter(FlNm, True)
                With fsT
                    .WriteLine("        </Table>")
                    .WriteLine("    </Worksheet>")
                    .Close()
                End With
            End If

            If (Moquegua IsNot "" And chkMoquegua.Checked = True) Then
                Moquegua = Moquegua.Remove(Moquegua.Length - 1)
                Dim arregloMoquegua() As String = Moquegua.Split(";")

                MExportExcel.AddExcelHeader(DGVTotal, "Moquegua", FlNm)

                For intRow As Integer = 0 To arregloMoquegua.Length - 1

                    id_medidor = CInt(Val(arregloMoquegua(intRow)))

                    Dim ruta As String = ruta_general.Substring(0, (ruta_general.LastIndexOf("\") + 1))
                    ruta = ruta & arregloMoquegua(intRow)
                    'MsgBox(ruta,, "moquegua")

                    Dim tipo_medidor As String
                    tipo_medidor = ruta.Substring(ruta.LastIndexOf(".") + 1, 2)
                    'MsgBox(tipo_medidor)
                    Select Case tipo_medidor
                        Case "LP" : lecturaArchivo(DGVTotal, ruta, " ", 2, id_medidor)
                        Case "pr" : lecturaArchivo(DGVTotal, ruta, ",", 1, id_medidor)
                        Case "ta" : lecturaArchivo(DGVTotal, ruta, vbTab, 1, id_medidor)
                    End Select

                    eliminarPrimeralineaDGV(DGVTotal)
                    'comprobar la integridad
                    MExportExcel.IntegridadLecturas(arregloMoquegua(intRow), DGVTotal, "Moquegua", Report)

                    MExportExcel.AddExcelBody(DGVTotal, FlNm) 'agregar el contenido al cuerpo del excel

                    'guardar los registros en la base de datos
                    MVariables.RegDB = DGVTotal
                    MVariables.NombreSector = "Moquegua"
                    Dim formDB As New GuardarDGVDB
                    formDB.ShowDialog()

                    DGVTotal.Rows.Clear()

                    contadorReg = contadorReg + 1
                    If contadorReg = newHojaExcel Then
                        Dim fsTa As New StreamWriter(FlNm, True)
                        With fsTa
                            .WriteLine("        </Table>")
                            .WriteLine("    </Worksheet>")
                            .Close()
                        End With
                        divReg = divReg + 1
                        MExportExcel.AddExcelHeader(DGVTotal, "Moquegua" & divReg, FlNm)
                        contadorReg = 0
                    End If
                Next
                Dim fsM As New StreamWriter(FlNm, True)
                With fsM
                    .WriteLine("        </Table>")
                    .WriteLine("    </Worksheet>")
                    .Close()
                End With
            End If

            If (Ilo IsNot "" And chkIlo.Checked = True) Then
                Ilo = Ilo.Remove(Ilo.Length - 1)
                'MsgBox(Ilo,, "ilo")
                Dim arregloIlo() As String = Ilo.Split(";")
                'MsgBox(Ilo,, "ilo")
                MExportExcel.AddExcelHeader(DGVTotal, "Ilo", FlNm)

                For intRow As Integer = 0 To arregloIlo.Length - 1

                    id_medidor = CInt(Val(arregloIlo(intRow)))

                    Dim ruta As String = ruta_general.Substring(0, (ruta_general.LastIndexOf("\") + 1))
                    ruta = ruta & arregloIlo(intRow)
                    'MsgBox(ruta,, "ilo")

                    Dim tipo_medidor As String
                    tipo_medidor = ruta.Substring(ruta.LastIndexOf(".") + 1, 2)
                    'MsgBox(tipo_medidor)
                    Select Case tipo_medidor
                        Case "LP" : lecturaArchivo(DGVTotal, ruta, " ", 2, id_medidor)
                        Case "pr" : lecturaArchivo(DGVTotal, ruta, ",", 1, id_medidor)
                        Case "ta" : lecturaArchivo(DGVTotal, ruta, vbTab, 1, id_medidor)
                    End Select

                    eliminarPrimeralineaDGV(DGVTotal)
                    'comprobar la integridad
                    MExportExcel.IntegridadLecturas(arregloIlo(intRow), DGVTotal, "Ilo", Report)

                    MExportExcel.AddExcelBody(DGVTotal, FlNm) 'agregar el contenido al cuerpo del excel

                    ''guardar los registros en la base de datos
                    MVariables.RegDB = DGVTotal
                    MVariables.NombreSector = "Ilo"
                    Dim formDB As New GuardarDGVDB
                    formDB.ShowDialog()

                    DGVTotal.Rows.Clear()

                    contadorReg = contadorReg + 1
                    If contadorReg = newHojaExcel Then
                        Dim fsTa As New StreamWriter(FlNm, True)
                        With fsTa
                            .WriteLine("        </Table>")
                            .WriteLine("    </Worksheet>")
                            .Close()
                        End With
                        divReg = divReg + 1
                        MExportExcel.AddExcelHeader(DGVTotal, "Ilo" & divReg, FlNm)
                        contadorReg = 0
                    End If
                Next
                Dim fsI As New StreamWriter(FlNm, True)
                With fsI
                    .WriteLine("        </Table>")
                    .WriteLine("    </Worksheet>")
                    .Close()
                End With
            End If

            If (Libres IsNot "" And chkLibres.Checked = True) Then
                Tacna = Tacna.Remove(Tacna.Length - 1)
                'MsgBox(Tacna,, "tacna")
                Dim arregloLibres() As String = Tacna.Split(";")

                MExportExcel.AddExcelHeader(DGVTotal, "Libres", FlNm)

                For intRow As Integer = 0 To arregloLibres.Length - 1
                    id_medidor = CInt(Val(arregloLibres(intRow)))
                    Dim ruta As String = ruta_general.Substring(0, (ruta_general.LastIndexOf("\") + 1))
                    ruta = ruta & arregloLibres(intRow)
                    'MsgBox(ruta,, "Tacna")

                    Dim tipo_medidor As String
                    tipo_medidor = ruta.Substring(ruta.LastIndexOf(".") + 1, 2)
                    'MsgBox(tipo_medidor)
                    Select Case tipo_medidor
                        Case "LP" : lecturaArchivo(DGVTotal, ruta, " ", 2, id_medidor)
                        Case "pr" : lecturaArchivo(DGVTotal, ruta, ",", 1, id_medidor)
                        Case "ta" : lecturaArchivo(DGVTotal, ruta, vbTab, 1, id_medidor)
                    End Select
                    eliminarPrimeralineaDGV(DGVTotal)
                    'comprobar la integridad
                    MExportExcel.IntegridadLecturas(arregloLibres(intRow), DGVTotal, "Libres", Report)

                    MExportExcel.AddExcelBody(DGVTotal, FlNm) 'agregar el contenido al cuerpo del excel

                    'guardar los registros en la base de datos
                    MVariables.RegDB = DGVTotal
                    MVariables.NombreSector = "Libres"
                    Dim formDB As New GuardarDGVDB
                    formDB.ShowDialog()

                    DGVTotal.Rows.Clear()

                    contadorReg = contadorReg + 1
                    If contadorReg = newHojaExcel Then
                        Dim fsTa As New StreamWriter(FlNm, True)
                        With fsTa
                            .WriteLine("        </Table>")
                            .WriteLine("    </Worksheet>")
                            .Close()
                        End With
                        divReg = divReg + 1
                        MExportExcel.AddExcelHeader(DGVTotal, "Libres" & divReg, FlNm)
                        contadorReg = 0
                    End If
                Next
                Dim fsT As New StreamWriter(FlNm, True)
                With fsT
                    .WriteLine("        </Table>")
                    .WriteLine("    </Worksheet>")
                    .Close()
                End With
            End If

            Dim fs2 As New StreamWriter(FlNm, True)
            With fs2
                .WriteLine("</Workbook>")
                .Close()
            End With
            ProgressBar1.Value = ProgressBar1.Maximum
            MsgBox("Exportación Terminada, tenga presente que el archivo generado posee un formato Universal de datos, para editarlo correctamente guardelo en la versión de EXCEL de su preferencia.", MsgBoxStyle.Information, "Atención!!!")
            Process.Start(FlNm)
        End If
        lbArchivos.Enabled = True
        btnNuevo.Enabled = True
        btnExportMasivo.Enabled = True
        dgvcontenido.Enabled = True
        exportar = 1
        ProgressBar1.Value = 0
        conteoTotal = 0

        If proceso = 3 Then
            lbArchivos.Items.Clear()
            btnExportMasivo.Enabled = False
            btnNuevo.Select()
        End If
    End Sub
    'reporte de lecturas incompletas
    Dim Report As String
    Dim ContNombres As New List(Of String)
End Class
