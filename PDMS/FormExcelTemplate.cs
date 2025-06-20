using DocumentFormat.OpenXml.Bibliography;
using PDMS.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDMS
{
    public partial class FormExcelTemplate : Form
    {
        public string SelectedTemplate { get; set; } = null;
        public List<string> TemplateList { get; set; }    
        public FormFacade facade { get; set; }
        public FormExcelTemplate()
        {
            facade = new FormFacade(this);
            try
            {
                facade.CopyExcelTemplates2Local();

                TemplateList = facade.GetTemplateList();
            }
            catch
            {
                MessageBox.Show("连接服务器\\192.168.31.223失败。");
                this.Close();
            }
            InitializeComponent();
        }

        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 载入模板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSelection selectForm = new FormSelection(TemplateList);
            if (selectForm.ShowDialog() == DialogResult.OK)
            {
                SelectedTemplate = selectForm.RetrunFileName;
                LoadTemplate();
            }
            else
            {
                return;
            }

        }

        private void FormExcelTemplate_Load(object sender, EventArgs e)
        {

        }

        private void LoadTemplate()
        {
            // 打开模板  
            spreadsheet1.Open(SelectedTemplate);
        }
    }
}
