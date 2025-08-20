using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace ST
{
    public partial class reporttushaal : DevExpress.XtraReports.UI.XtraReport
    {
        public reporttushaal()
        {
            InitializeComponent();
        }

        private void reporttushaal_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //Utga.Rtf = DevExpress.XtraPrinting.TextAlignment.TopJustify;
        }

    }
}
