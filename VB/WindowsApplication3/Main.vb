Imports System
Imports System.Collections.Generic
Imports System.Data
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository


Namespace DXSample
    Partial Public Class Main
        Inherits XtraForm

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub OnFormLoad(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

            Dim dt As DataTable = CreateData()

            gridControl1.DataSource = dt
            Dim edit As New RepositoryItemHypertextLabel()
            gridControl1.RepositoryItems.Add(edit)

            gridView1.Columns("Html").ColumnEdit = edit
        End Sub

        Private Shared Function CreateData() As DataTable
            Dim dt As New DataTable()
            dt.Columns.Add("Html")
            dt.Columns.Add("String")

            dt.Rows.Add("<size=14>Size = 14<br>" & "<b>Bold</b> <i>Italic</i> <u>Underline</u><br>" & "<size=11>Size = 11<br>" & "<color=255, 0, 0>Sample Text</color></size>", "String a")
            dt.Rows.Add("<size=15>Size = 15<br>" & "<b>Bold</b> <i>Italic</i> <u>Underline</u><br>" & "<size=10>Size = 10<br>" & "<color=255, 255, 0>Sample Text</color></size>", "String b")
            dt.Rows.Add("<size=18>Size = 18<br>" & "<b>Bold</b> <i>Italic</i> <u>Underline</u><br>" & "<size=8>Size = 8<br>" & "<color=255, 0, 255>Sample Text</color></size>", "String c")
            Return dt
        End Function
    End Class


End Namespace
