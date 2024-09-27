Imports ScottPlot
Imports System.Drawing

Public Class FrmListado

    Private Sub FrmListado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Configurar FormsPlot1
        FormsPlot1.Location = New System.Drawing.Point(10, 10)
        FormsPlot1.Size = New System.Drawing.Size(400, 300)
        Me.Controls.Add(FormsPlot1)

        ' Crear una instancia de la trama
        Dim myPlot As Plot = FormsPlot1.Plot

        ' Añadir barras usando la nueva sintaxis
        myPlot.Add.Bar(position:=1, value:=26, error:=0)
        myPlot.Add.Bar(position:=2, value:=20, error:=0)
        myPlot.Add.Bar(position:=3, value:=23, error:=0)
        myPlot.Add.Bar(position:=4, value:=7, error:=0)


        ' Configurar los ticks del eje X
        Dim ticks() As ScottPlot.Tick = {
            New ScottPlot.Tick(1, "Categoría 1"),
            New ScottPlot.Tick(2, "Categoría 2"),
            New ScottPlot.Tick(3, "Categoría 3"),
            New ScottPlot.Tick(4, "Categoría 4")
        }

        myPlot.Axes.Bottom.TickGenerator = New ScottPlot.TickGenerators.NumericManual(ticks)
        myPlot.Axes.Bottom.MajorTickStyle.Length = 0
        myPlot.HideGrid()

        myPlot.Axes.Margins(bottom:=0)

        myPlot.Title("Gráfico de Barras")
        myPlot.YLabel("Valores")
        myPlot.XLabel("Categorías")

        FormsPlot1.Refresh()
    End Sub

End Class


