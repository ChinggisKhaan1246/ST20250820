using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ST; // ⚡ dataSetFillnew-г дуудахын тулд namespace нэмэв

public class projectnameFilter
{
    private dataSetFillnew dsn;

    public projectnameFilter()
    {
        dsn = new dataSetFillnew();
    }

    public void LoadActiveProjects(LookUpEdit lookUpEditControl)
    {
        try
        {
            var parameters = new Dictionary<string, string> { { "status", "filter" } };
            var projectData = dsn.getData("getproject", parameters);

            if (projectData == null || projectData.Rows.Count == 0)
            {
                MessageBox.Show("Идэвхтэй төсөл олдсонгүй.", "Анхааруулга", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            lookUpEditControl.Properties.DataSource = projectData;
            lookUpEditControl.Properties.ValueMember = "projectID";
            lookUpEditControl.Properties.DisplayMember = "projectName";
            lookUpEditControl.Properties.Columns.Clear();
            lookUpEditControl.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("projectName", "Төслийн нэр"));
        }
        catch (Exception ex)
        {
            MessageBox.Show("Алдаа гарлаа: " + ex.Message, "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
