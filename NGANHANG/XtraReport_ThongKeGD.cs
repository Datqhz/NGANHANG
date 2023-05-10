using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace NGANHANG
{
    public partial class XtraReport_ThongKeGD : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport_ThongKeGD()
        {
            InitializeComponent();
        }

        public XtraReport_ThongKeGD(string stk, string fromDate, string toDate)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = stk;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = fromDate;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = toDate;
            this.sqlDataSource1.Fill();
            //lblSDC.Text = this.table2.Rows.LastRow.Cells.;
        }
    }
}
