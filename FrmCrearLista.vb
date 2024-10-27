Imports Ligas.ConexionSqlite

Public Class FrmCrearLista

    Dim DtLista As New DataTable
    Dim DtEquipos As New DataTable
    Dim numero As Integer = 0

    Private Sub FrmCrearLista_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed

        FrmUsadosPorFechas.CargarNombresListasEnCombo()

    End Sub

    Private Sub FrmCrearLista_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Definir las columnas de DtLista antes de usarlo
        DtLista.Columns.Add("idjugadores", GetType(Long))
        DtLista.Columns.Add("jugador", GetType(String))
        DtLista.Columns.Add("posicion", GetType(String))

        ' Inicializar DgvEquipos con datos
        DtEquipos = ObtenerEquiposPorLiga(LblIdLiga.Text)
        DgvEquipos.DataSource = DtEquipos
        DgvEquipos.Columns("idequipo").Visible = False
        DgvEquipos.Columns("idliga").Visible = False
    End Sub

    Private Sub DgvEquipos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvEquipos.CellClick

        Dim DtJugadores As New DataTable

        If e.RowIndex >= 0 Then

            DgvJugadores.DataSource = Nothing
            Dim idequipo As Long = Convert.ToInt64(DgvEquipos.Rows(e.RowIndex).Cells("idequipo").Value)
            DtJugadores = ObtenerJugadoresConEquipos(idequipo)
            DgvJugadores.DataSource = DtJugadores
            DgvJugadores.Columns("idjugadores").Visible = False

        End If

    End Sub


    Private Sub DgvJugadores_DoubleClick(sender As Object, e As EventArgs) Handles DgvJugadores.DoubleClick
        If DgvJugadores.CurrentRow IsNot Nothing Then
            ' Obtener datos del jugador seleccionado
            Dim idJugador As Long = Convert.ToInt64(DgvJugadores.CurrentRow.Cells("idjugadores").Value)
            Dim jugador As String = DgvJugadores.CurrentRow.Cells("jugador").Value.ToString()
            Dim posicion As String = DgvJugadores.CurrentRow.Cells("posicion").Value.ToString()

            ' Verificar si el jugador ya está en DtLista para evitar duplicados
            Dim filas() As DataRow = DtLista.Select("idjugadores = " & idJugador)
            If filas.Length = 0 Then
                ' Agregar nueva fila en DtLista
                Dim nuevaFila As DataRow = DtLista.NewRow()
                nuevaFila("idjugadores") = idJugador
                nuevaFila("jugador") = jugador
                nuevaFila("posicion") = posicion
                DtLista.Rows.Add(nuevaFila)

                ' Ordenar DtLista por la columna "posicion" según el criterio especificado
                Dim dv As New DataView(DtLista)
                dv.Sort = "posicion ASC" ' Aplicar orden de posiciones directamente

                ' Mostrar DtLista ordenado en DgvLista
                DgvLista.DataSource = dv.ToTable()
            End If

            DgvLista.Columns("idjugadores").Visible = False

        End If
    End Sub

    Private Sub BtnCrearLista_Click(sender As Object, e As EventArgs) Handles BtnCrearLista.Click



        ' Verificar que el nombre de la lista no esté vacío
        If String.IsNullOrWhiteSpace(TxtNombreLista.Text) Then


            MessageBox.Show("Por favor, ingresa un nombre para la lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Obtener el nombre de la lista
        Dim nombreLista As String = TxtNombreLista.Text

        ' Recorrer DgvLista y agregar cada jugador a la base de datos
        For Each fila As DataGridViewRow In DgvLista.Rows
            If Not fila.IsNewRow Then ' Ignorar la última fila vacía
                Dim idJugador As Integer = Convert.ToInt32(fila.Cells("idjugadores").Value)

                TxtNombreLista.Enabled = False
                BtnCrearLista.Enabled = False

                ' Llamar al método para agregar el jugador a la lista en la base de datos
                AgregarLista(nombreLista, idJugador)
            End If
        Next

        MessageBox.Show("Lista creada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub



End Class



