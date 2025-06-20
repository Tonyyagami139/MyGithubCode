using Common.Utility;
using DocumentFormat.OpenXml.Bibliography;
using Syncfusion.Windows.Forms.Spreadsheet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDMS.Facade
{
    public partial class FormFacade
    {
        public List<string> GetTemplateList()
        { 
            string path = Path.Combine(LocalPDMSFolder, "ExcelTemplates");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                return new List<string>();
            }
            else
            {
                return Directory.GetFiles(path).ToList();
            }

        }
        public void CopyExcelTemplates2Local()
        {
            string sourceFolder = "\\\\192.168.31.223\\TestingDataRoot\\PDMS\\ExcelTemplates";
            string destFolder = Path.Combine(LocalPDMSFolder, "ExcelTemplates");
            if (Directory.Exists(LocalPDMSFolder))
            {
                var files = Directory.GetFiles(LocalPDMSFolder);
                try
                {
                    foreach (var f in files)
                    {

                            File.Delete(f);
                        
                    }
                }
                catch
                {
                    //ignore error
                }
            }
            if (!Directory.Exists(LocalPDMSFolder))
            {
                Directory.CreateDirectory(LocalPDMSFolder);
            }
            try 
            { 
                FileHelper.CopyFiles(sourceFolder, destFolder,true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:"+ex.Message);
                return;
            }
        }

        //public void LoadTemplate(string templatePath)
        //{ 
        //    Spreadsheet1.Open(templatePath);
        //}
    }
}
