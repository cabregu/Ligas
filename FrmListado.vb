Imports ScottPlot
Imports ScottPlot.WinForms
Imports System.Drawing ' Asegúrate de importar este espacio de nombres
Imports System.Data ' Importar para usar DataTable

Public Class FrmListado

    Public Dt As New DataTable
    Public Pos As String = ""


    Private Sub FrmListado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel.BackColor = ColorTranslator.FromHtml("#0b3049")

        Dim dv As New DataView(Dt)
        dv.Sort = "Total Puntos DESC"
        Dim sortedDt As DataTable = dv.ToTable()

        CrearGraficos(sortedDt, Pos)
    End Sub


    Private Sub CrearGraficos(dt As DataTable, PosicionActual As String)

        Dim cantidad As Integer = dt.Rows.Count
        Dim formsPlots(cantidad - 1) As FormsPlot

        Dim plotWidth As Integer = 300
        Dim plotHeight As Integer = 300
        Dim spacing As Integer = 5

        Dim posiciones() As Integer = {1, 2, 3, 4}
        Dim etiquetas() As String = {"S", "T", "Total", "Prom"}

        For i As Integer = 0 To cantidad - 1
            formsPlots(i) = New FormsPlot()
            formsPlots(i).Size = New Size(plotWidth, plotHeight)

            ' Calculate the x and y positions based on grouping of 6
            Dim x As Integer = (i Mod 6) * (plotWidth + spacing) + 10
            Dim y As Integer = (i \ 6) * (plotHeight + spacing) + 10
            formsPlots(i).Location = New Point(x, y)

            Me.Panel.Controls.Add(formsPlots(i))

            Dim valores() As Double = {
            Convert.ToDouble(dt.Rows(i)("S")),
            Convert.ToDouble(dt.Rows(i)("T")),
            Convert.ToDouble(dt.Rows(i)("Total Puntos")),
            Convert.ToDouble(dt.Rows(i)("Promedio"))
        }

            CrearGraficoBarras(formsPlots(i).Plot, posiciones, valores, etiquetas, "", dt.Rows(i)("Jugador").ToString(), "")


        Next

        For Each plot In formsPlots
            plot.Refresh()
        Next
    End Sub


    Private Sub CrearGraficoBarras(plot As ScottPlot.Plot, posiciones() As Integer, valores() As Double, etiquetas() As String, titulo As String, etiquetaX As String, etiquetaY As String)



        Dim palette As New ScottPlot.Palettes.Frost()

        For i As Integer = 0 To posiciones.Length - 1
            Dim bar As New ScottPlot.Bar() With {
            .Position = posiciones(i),
            .Value = valores(i),
            .Error = 0,
            .FillColor = palette.GetColor(i Mod palette.Colors.Count)
        }
            plot.Add.Bars(New ScottPlot.Bar() {bar})

            plot.Add.Text(valores(i).ToString(), posiciones(i), valores(i) + 45).Color = ScottPlot.Color.FromHex("#ffffff")

        Next


        Dim ticks(posiciones.Length - 1) As ScottPlot.Tick
        For i As Integer = 0 To posiciones.Length - 1
            ticks(i) = New ScottPlot.Tick(posiciones(i), etiquetas(i))
        Next




        plot.FigureBackground.Color = ScottPlot.Color.FromHex("#0b3049")
        plot.DataBackground.Color = ScottPlot.Color.FromHex("#0b3049")
        plot.Axes.Color(ScottPlot.Color.FromHex("#ffffff"))

        plot.Grid.MajorLineColor = ScottPlot.Color.FromHex("#FFFFFF")

        plot.Axes.Bottom.TickGenerator = New ScottPlot.TickGenerators.NumericManual(ticks)
        plot.Axes.Bottom.MajorTickStyle.Length = 0

        plot.HideGrid()
        plot.Axes.Margins(bottom:=0)

        plot.Title(titulo)
        plot.YLabel(etiquetaY)
        plot.XLabel(etiquetaX)


    End Sub



    Private Sub Panel_DoubleClick(sender As Object, e As EventArgs)

        Dim bmp As New Bitmap(Width, Height)
        Panel.DrawToBitmap(bmp, New Rectangle(0, 0, Width, Panel.Height))

        Dim saveFileDialog As New SaveFileDialog
        saveFileDialog.Filter = "JPEG Image|*.jpg"
        saveFileDialog.Title = "Guardar imagen como"

        If saveFileDialog.ShowDialog = DialogResult.OK Then
            bmp.Save(saveFileDialog.FileName, Imaging.ImageFormat.Jpeg)
        End If
    End Sub

End Class
