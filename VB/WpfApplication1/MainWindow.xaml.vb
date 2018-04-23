Imports DevExpress.Xpf.Printing
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace WpfApplication1
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()


            Dim rep As New XtraReport1()
            rep.CreateDocument(False)

            Viewer.DocumentSource = rep
            AddHandler Viewer.DocumentPreviewMouseClick, AddressOf Viewer_DocumentPreviewMouseClick
        End Sub

        Private Sub Viewer_DocumentPreviewMouseClick(ByVal d As DependencyObject, ByVal e As DocumentPreviewMouseEventArgs)

            If TypeOf e.Brick Is LabelBrick Then
                Dim brick As VisualBrick = TryCast(e.Brick, VisualBrick)
                If e.Brick.Value IsNot Nothing AndAlso e.Brick.Value.ToString() <> String.Empty Then
                    Sort(e.Brick.Value.ToString(), TryCast(Viewer.DocumentSource, XtraReport))
                Else
                    MessageBox.Show(String.Format("Cell value: {0}", brick.TextValue.ToString()))
                End If
            End If
        End Sub

        Public Sub Sort(ByVal fieldName As String, ByVal report As XtraReport)
            Dim Detail As DetailBand = TryCast(report.Bands.GetBandByType(GetType(DetailBand)), DetailBand)

            If Detail.SortFields.Any(Function(x) x.FieldName.Equals(fieldName)) Then
                ChangeSortOrder(Detail.SortFields(fieldName))
            Else
                AddNewSortField(fieldName, Detail)
            End If

            report.CreateDocument(True)
        End Sub

        Private Sub ChangeSortOrder(ByVal groupField As GroupField)
            groupField.SortOrder = If(groupField.SortOrder = XRColumnSortOrder.Ascending, XRColumnSortOrder.Descending, XRColumnSortOrder.Ascending)
        End Sub

        Private Shared Sub AddNewSortField(ByVal fieldName As String, ByVal Detail As DetailBand)
            ' Disable sorting.
            Detail.SortFields.Clear()
            ' Create a new sorting criterion.
            Dim grField As GroupField = New GroupField With {.FieldName = fieldName, .SortOrder = XRColumnSortOrder.Ascending}
            ' Enable sorting.
            Detail.SortFields.Add(grField)
        End Sub
    End Class
End Namespace
