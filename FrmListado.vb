Imports ScottPlot
Imports ScottPlot.WinForms
Imports System.Drawing ' Asegúrate de importar este espacio de nombres
Imports System.Data ' Importar para usar DataTable

Public Class FrmListado

    Public Dt As New DataTable
    Public Pos As String = ""
    Private Sub FrmListado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CrearGraficos(Dt, Pos)
    End Sub

    Private Sub CrearGraficos(dt As DataTable, PosicionActual As String)
        ' Crear instancias de FormsPlot
        Dim cantidad As Integer = dt.Rows.Count
        Dim formsPlots(cantidad - 1) As FormsPlot ' Crear un array para los plots

        ' Establecer el tamaño de los gráficos
        Dim plotWidth As Integer = 300
        Dim plotHeight As Integer = 300
        Dim spacing As Integer = 5 ' Espacio entre gráficos

        ' Datos para los gráficos de barras
        Dim posiciones() As Integer = {1, 2, 3, 4}
        Dim etiquetas() As String = {"S", "T", "Total", "Prom"}

        ' Crear y configurar cada FormsPlot
        For i As Integer = 0 To cantidad - 1
            formsPlots(i) = New FormsPlot()
            formsPlots(i).Size = New Size(plotWidth, plotHeight)

            ' Calcular la ubicación de cada gráfico
            Dim x As Integer = (i Mod 4) * (plotWidth + spacing) + 10 ' 10 es el margen izquierdo
            Dim y As Integer = (i \ 4) * (plotHeight + spacing) + 10 ' 10 es el margen superior
            formsPlots(i).Location = New Point(x, y)

            ' Añadir el gráfico al formulario
            Me.Controls.Add(formsPlots(i))

            ' Obtener los datos del jugador
            Dim valores() As Double = {
                Convert.ToDouble(dt.Rows(i)("S")),
                Convert.ToDouble(dt.Rows(i)("T")),
                Convert.ToDouble(dt.Rows(i)("Total Puntos")),
                Convert.ToDouble(dt.Rows(i)("Promedio"))
            }

            ' Crear el gráfico de barras
            CrearGraficoBarras(formsPlots(i).Plot, posiciones, valores, etiquetas, dt.Rows(i)("Jugador").ToString(), PosicionActual, dt.Rows(i)("Nombre del Equipo").ToString())
        Next

        ' Refrescar todos los gráficos para mostrarlos
        For Each plot In formsPlots
            plot.Refresh()
        Next
    End Sub

    Private Sub CrearGraficoBarras(plot As ScottPlot.Plot, posiciones() As Integer, valores() As Double, etiquetas() As String, titulo As String, etiquetaX As String, etiquetaY As String)
        ' Añadir barras al gráfico
        For i As Integer = 0 To posiciones.Length - 1
            plot.Add.Bar(position:=posiciones(i), value:=valores(i), error:=0)
            ' Añadir el valor encima de cada barra
            plot.Add.Text(valores(i).ToString(), posiciones(i), valores(i) + 45) ' Ajustar la posición del texto
        Next

        ' Establecer ticks personalizados para el eje x
        Dim ticks(posiciones.Length - 1) As ScottPlot.Tick
        For i As Integer = 0 To posiciones.Length - 1
            ticks(i) = New ScottPlot.Tick(posiciones(i), etiquetas(i))
        Next

        plot.Axes.Bottom.TickGenerator = New ScottPlot.TickGenerators.NumericManual(ticks)
        plot.Axes.Bottom.MajorTickStyle.Length = 0
        plot.HideGrid()

        plot.Axes.Margins(bottom:=0)

        ' Establecer títulos y etiquetas
        plot.Title(titulo)
        plot.YLabel(etiquetaY)
        plot.XLabel(etiquetaX)
    End Sub




End Class
