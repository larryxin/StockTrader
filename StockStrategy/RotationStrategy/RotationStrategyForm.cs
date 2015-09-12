using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Stock.Strategy.Settings
{
    public partial class RotationStrategyForm : BaseSettingForm
    {
        public RotationStrategyForm()
        {
            this.Strategy = new RotationStrategy();

            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            RotationStrategy rs = (RotationStrategy)this.Strategy;
            rs.IsValid = this.chkEnable.Checked;
            rs.BasePoint = (int)this.numBasePoint.Value;
            if(rs.IsValid)
                
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
