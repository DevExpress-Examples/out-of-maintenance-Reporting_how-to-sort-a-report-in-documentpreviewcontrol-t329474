Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports DevExpress.XtraReports.UI
Imports System.Windows

Namespace WpfApplication1
    Partial Public Class XtraReport1
        Inherits DevExpress.XtraReports.UI.XtraReport

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub xrTable1_PreviewClick(ByVal sender As Object, ByVal e As PreviewMouseEventArgs) Handles xrTable1.PreviewClick
            'MessageBox.Show("Row Clicked!");
        End Sub

    End Class
End Namespace
