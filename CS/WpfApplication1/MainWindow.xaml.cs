using DevExpress.Xpf.Printing;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            XtraReport1 rep = new XtraReport1();
            rep.CreateDocument(false);

            Viewer.DocumentSource = rep;
            Viewer.DocumentPreviewMouseClick += Viewer_DocumentPreviewMouseClick;
        }

        void Viewer_DocumentPreviewMouseClick(DependencyObject d, DocumentPreviewMouseEventArgs e)
        {

            if (e.Brick is LabelBrick)
            {
                VisualBrick brick = e.Brick as VisualBrick;
                if (e.Brick.Value != null && e.Brick.Value.ToString() != String.Empty)
                {
                    Sort(e.Brick.Value.ToString(), Viewer.DocumentSource as XtraReport);
                }
                else
                    MessageBox.Show(String.Format("Cell value: {0}", brick.TextValue.ToString()));
            }
        }

        public void Sort(string fieldName, XtraReport report)
        {
            DetailBand Detail = report.Bands.GetBandByType(typeof(DetailBand)) as DetailBand;

            if (Detail.SortFields.Any(x => x.FieldName.Equals(fieldName)))
            {
                ChangeSortOrder(Detail.SortFields[fieldName]);
            }
            else
                AddNewSortField(fieldName, Detail);

            report.CreateDocument(true);
        }

        private void ChangeSortOrder(GroupField groupField)
        {
            groupField.SortOrder = groupField.SortOrder == XRColumnSortOrder.Ascending ? XRColumnSortOrder.Descending : XRColumnSortOrder.Ascending;
        }

        private static void AddNewSortField(string fieldName, DetailBand Detail)
        {
            // Disable sorting.
            Detail.SortFields.Clear();
            // Create a new sorting criterion.
            GroupField grField = new GroupField { FieldName = fieldName, SortOrder = XRColumnSortOrder.Ascending };
            // Enable sorting.
            Detail.SortFields.Add(grField);
        }
    }
}
