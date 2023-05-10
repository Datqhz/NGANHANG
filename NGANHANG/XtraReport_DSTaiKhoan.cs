using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace NGANHANG
{
    public partial class XtraReport_DSTaiKhoan : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport_DSTaiKhoan(string fromDate, string toDate)
        {
            InitializeComponent();
            Console.WriteLine(Program.connstr);
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = fromDate;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = toDate;
            this.sqlDataSource1.Fill();
        }

    }
}
