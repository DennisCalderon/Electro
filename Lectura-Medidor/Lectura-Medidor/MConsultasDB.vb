Imports System.Data.SQLite
Module MConsultasDB
    Const cadena_conexion As String = "Data Source=Electro.db;Version=3"
    Public Sub ConsultaCodSumFT(ByVal serie As String, ByRef codsuministro As String, ByRef FTEA As String)

        Dim objCon As SQLiteConnection
        Dim objCommand As SQLiteCommand
        Dim objReader As SQLiteDataReader

        Try
            objCon = New SQLiteConnection(cadena_conexion)
            objCon.Open()
            objCommand = objCon.CreateCommand()
            'objCommand.CommandText = "select CodigoSuministro, FactorTransformacionEA from Clientes where serie=" & serie & " and NumImport in (select  Max(NumImport) from Clientes)"
            objCommand.CommandText = "select CodigoSuministro, FactorTransformacionEA from Padron_General where serie=""" & serie & """ "
            objReader = objCommand.ExecuteReader()

            'MsgBox((objReader.Read()), MsgBoxStyle.Information, "leyendo")
            If objReader.Read() Then
                codsuministro = objReader.Item("CodigoSuministro").ToString
                FTEA = objReader.Item("FactorTransformacionEA").ToString
                'MsgBox(CStr(FTEA), MsgBoxStyle.Information, "leyendo")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            'If Not IsNothing(objCon) Then
            objCommand.Dispose()
            objReader.Close()
            objCon.Close()
            'End If
        End Try
    End Sub
    Public Sub MostrarPadron(ByVal NombreSector As String, ByRef dgvmedidor As DataGridView)
        Dim sql As String = ""

        If NombreSector = "Todos" Then
            sql = "SELECT * FROM Padron_Tacna where NumImport in (select  Max(NumImport) from Padron_Tacna) UNION SELECT * FROM Padron_Moquegua where NumImport in (select  Max(NumImport) from Padron_Moquegua) UNION SELECT * FROM Padron_Ilo where NumImport in (select  Max(NumImport) from Padron_Ilo) UNION SELECT * FROM Padron_Libres where NumImport in (select  Max(NumImport) from Padron_Libres) ORDER BY NombreSector"
        Else
            sql = "SELECT * FROM Padron_" & NombreSector & " where NumImport in (select  Max(NumImport) from Padron_" & NombreSector & ")"
        End If

        Using con As New SQLiteConnection(cadena_conexion)

            Dim command As New SQLiteCommand(Sql, con)
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
    End Sub
    Public Sub ConsultaNumImport(ByVal NombreSector As String, ByRef NumImport As String)

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
    Public Sub GuardarPadron(ByVal NumImport As Integer, ByVal Item As Integer, ByVal CodigoRutaSuministro As String, ByVal CodigoSuministro As String, ByVal NombreSuministro As String, ByVal DireccionPredio As String, ByVal NombreSector As String, ByVal Tension As String, ByVal Tarifa As String, ByVal SistemaElectrico As String, ByVal ActividadEconomica As String, ByVal FactorTension As String, ByVal FactorCorriente As String, ByVal FactorTransformacionEA As String, ByVal MarcaDelMedidor As String, ByVal Modelo As String, ByVal Serie As String)

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
    Public Sub ActualizarPadronGeneral()

        Dim objCon1 As SQLiteConnection
        Dim objCommand1 As SQLiteCommand
        Dim objReader1 As SQLiteDataReader
        Dim listaSector As New List(Of String)

        listaSector.Add("Tacna")
        listaSector.Add("Moquegua")
        listaSector.Add("Ilo")
        listaSector.Add("Libres")
        Try
            objCon1 = New SQLiteConnection(cadena_conexion)
            objCon1.Open()
            objCommand1 = objCon1.CreateCommand()
            objCommand1.CommandText = "delete From Padron_General"
            objReader1 = objCommand1.ExecuteReader()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            objCommand1.Dispose()
            objReader1.Close()
            objCon1.Close()
        End Try

        For int As Integer = 0 To listaSector.Count - 1
            Try
                objCon1 = New SQLiteConnection(cadena_conexion) '& "New=true;")
                objCon1.Open()
                'MsgBox("Abierta DB")
                objCommand1 = objCon1.CreateCommand()
                objCommand1.CommandText = "insert into Padron_General (CodigoRutaSuministro, CodigoSuministro, NombreSuministro, DireccionPredio, NombreSector, Tension, Tarifa, SistemaElectrico, ActividadEconomica, FactorTension, FactorCorriente, FactorTransformacionEA, MarcaDelMedidor, Modelo, Serie) Select CodigoRutaSuministro, CodigoSuministro, NombreSuministro, DireccionPredio, NombreSector, Tension, Tarifa, SistemaElectrico, ActividadEconomica, FactorTension, FactorCorriente, FactorTransformacionEA, MarcaDelMedidor, Modelo, Serie From Padron_" & listaSector.Item(int) & " Where NumImport In (Select  Max(NumImport) from Padron_" & listaSector.Item(int) & ")"
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
        Next

    End Sub
    Public Sub ExportPadron(ByVal list As List(Of String), ByRef dgvPadron As DataGridView)
        Dim sql As String = ""
        For intlist As Integer = 0 To list.Count - 1
            sql = sql & " SELECT * FROM Padron_" & list.Item(intlist) & " where NumImport in (select  Max(NumImport) from Padron_" & list.Item(intlist) & ") UNION"
            If intlist = list.Count - 1 Then
                sql = sql.Remove(sql.Length - 5)
                sql = sql & " ORDER BY NombreSector"
            End If
        Next

        Using con As New SQLiteConnection(cadena_conexion)
            Dim command As New SQLiteCommand(sql, con)
            Dim da As New SQLiteDataAdapter
            da.SelectCommand = command
            Dim dt As New DataTable
            da.Fill(dt)
            dgvPadron.DataSource = dt
        End Using
    End Sub
    Public Sub ConsultaSector(ByVal serie As String, ByRef NombreSector As String)

        Dim objCon As SQLiteConnection
        Dim objCommand As SQLiteCommand
        Dim objReader As SQLiteDataReader

        Try
            objCon = New SQLiteConnection(cadena_conexion)
            objCon.Open()
            objCommand = objCon.CreateCommand()
            'MsgBox("primero", MsgBoxStyle.Information, "leyendo")
            objCommand.CommandText = "select NombreSector from Padron_General where serie=""" & serie & """ "
            'MsgBox(objCommand.CommandText, MsgBoxStyle.Information, "leyendo")
            objReader = objCommand.ExecuteReader()

            'MsgBox((objReader.Read()), MsgBoxStyle.Information, "leyendo")
            If objReader.Read() Then
                NombreSector = objReader.Item("NombreSector").ToString
                'MsgBox(CStr(FTEA), MsgBoxStyle.Information, "leyendo")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            objCommand.Dispose()
            objReader.Close()
            objCon.Close()
        End Try
    End Sub
    Public Sub ConsultaOpcionesDB(ByRef GuardarDB As String)

        Dim objCon As SQLiteConnection
        Dim objCommand As SQLiteCommand
        Dim objReader As SQLiteDataReader

        Try
            objCon = New SQLiteConnection(cadena_conexion)
            objCon.Open()
            objCommand = objCon.CreateCommand()
            objCommand.CommandText = "select DataBaseGuardar from OpcionesDB "
            objReader = objCommand.ExecuteReader()

            If objReader.Read() Then
                GuardarDB = objReader.Item("DataBaseGuardar").ToString
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            objCommand.Dispose()
            objReader.Close()
            objCon.Close()
        End Try
    End Sub
    Public Sub ActualizarOpcionesDB(ByVal GuardarDB As String)

        Dim objCon As SQLiteConnection
        Dim objCommand As SQLiteCommand
        Dim objReader As SQLiteDataReader

        Try
            objCon = New SQLiteConnection(cadena_conexion)
            objCon.Open()
            objCommand = objCon.CreateCommand()
            objCommand.CommandText = "update OpcionesDB set DataBaseGuardar=""" & GuardarDB & """ "
            objReader = objCommand.ExecuteReader()

        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            objCommand.Dispose()
            objReader.Close()
            objCon.Close()
        End Try
    End Sub
End Module
