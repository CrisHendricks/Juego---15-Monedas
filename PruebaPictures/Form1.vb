Public Class Form1

    Dim numMonedas As Integer = 15
    Dim turno As Integer = 1
    Dim arrayImagenes() As PictureBox

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MsgBox(" Reglas del Juego " & vbCrLf & " -----------------------------------------------------------------------------" & vbCrLf & "Cada jugador puede durante su turno coger una, dos o tres monedas pero no más. Pierde el jugador que se ve obligado a recoger la última moneda sobre la mesa. También puedes jugar contra el ordenador en dos niveles de dificultad.", , "Quince Monedas")
        dibujar()

    End Sub

    Public Sub dibujar()
        lbl1.ForeColor = Color.Blue

        turno = 1
        lbl1.ForeColor = Color.Blue
        lbl2.ForeColor = Color.Black

        numMonedas = 15

        arrayImagenes = {pct1, pct2, pct3, pct4, pct5, pct6, pct7, pct8, pct9, pct10, pct11, pct12, pct13, pct14, pct15}
      
        For i As Integer = 0 To arrayImagenes.Length - 1

            arrayImagenes(i).Image = PruebaPictures.My.Resources.euro1
            arrayImagenes(i).SizeMode = PictureBoxSizeMode.Zoom
        Next

        btn1.Enabled = True
        btn2.Enabled = True
        btn3.Enabled = True
    End Sub


    Public Sub jugar()
        btn1.Enabled() = True
        btn2.Enabled() = True
        btn3.Enabled() = True
    End Sub


    Private Sub btn3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn3.Click

        Dim monedasARestar As Integer = 3

        For i As Integer = 0 To monedasARestar - 1
            arrayImagenes(numMonedas - 1 - i).Image = PruebaPictures.My.Resources.euro2
        Next

        numMonedas -= monedasARestar

        compRestantes()
        ComprobarGanador()

    End Sub
    Private Sub btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn2.Click

        Dim monedasARestar As Integer = 2

        For i As Integer = 0 To monedasARestar - 1
            arrayImagenes(numMonedas - 1 - i).Image = PruebaPictures.My.Resources.euro2
        Next
        numMonedas -= monedasARestar

        compRestantes()
        ComprobarGanador()

    End Sub
    Private Sub btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1.Click


        arrayImagenes(numMonedas - 1).Image = PruebaPictures.My.Resources.euro2
        numMonedas -= 1

        compRestantes()
        ComprobarGanador()
        

        

    End Sub

    Public Sub ComprobarGanador()
        If compGanar() Then

            MsgBox("Gana el jugador " & turno)

            dibujar()
        Else
            cambiarTurno()
        End If
    End Sub

    Public Function compGanar()
        If numMonedas = 1 Then
            Return True
        Else
            Return False

        End If

    End Function

    Public Sub compRestantes()
        If numMonedas = 3 Then

            btn3.Enabled = False


        ElseIf numMonedas = 2 Then

            btn2.Enabled = False
            btn3.Enabled = False

        End If
    End Sub
    Public Sub cambiarTurno()
        If turno = 1 Then
            turno = 2
            lbl2.ForeColor = Color.Blue
            lbl1.ForeColor = Color.Black
            If cb1.Checked = True Then
                If cbIa2.Checked Then
                    iaDificil()
                Else
                    ia()
                End If

            End If
        Else
            turno = 1
            lbl1.ForeColor = Color.Blue
            lbl2.ForeColor = Color.Black
        End If
    End Sub


    Public Sub ia()
        Randomize()
        Dim aleatorio As Integer = Math.Truncate((Rnd() * 3) + 1)

        Select Case aleatorio
            Case 1

                If Not btn1.Enabled Then
                    ia()
                Else
                    btn1_Click(Nothing, Nothing)
                End If
            Case 2

                If Not btn2.Enabled Then
                    ia()
                Else
                    btn2_Click(Nothing, Nothing)
                End If
            Case 3
                If Not btn3.Enabled Then
                    ia()
                Else
                    btn3_Click(Nothing, Nothing)
                End If
        End Select

    End Sub

    Public Sub iaDificil()
        If numMonedas = 6 Then

        End If
        Select Case numMonedas
            Case 2
                btn1_Click(Nothing, Nothing)
            Case 3
                btn2_Click(Nothing, Nothing)
            Case 4
                btn3_Click(Nothing, Nothing)
            Case 5
                btn1_Click(Nothing, Nothing)
            Case 6
                btn1_Click(Nothing, Nothing)
            Case 7
                btn2_Click(Nothing, Nothing)
            Case 8
                btn3_Click(Nothing, Nothing)
            Case Else
                ia()

        End Select
    End Sub

End Class
