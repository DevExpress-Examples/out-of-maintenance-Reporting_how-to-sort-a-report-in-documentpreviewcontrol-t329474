using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Windows;

namespace WpfApplication1
{
    public partial class XtraReport1 : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport1()
        {
            InitializeComponent();
        }

        private void xrTable1_PreviewClick(object sender, PreviewMouseEventArgs e)
        {
            //MessageBox.Show("Row Clicked!");
        }

    }
}
