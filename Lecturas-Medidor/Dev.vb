Public Class Dev
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("https://www.facebook.com/dennis.calderonmamani")
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Process.Start("dennis.tacna@gmail.com")
    End Sub

    Private Sub Dev_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class