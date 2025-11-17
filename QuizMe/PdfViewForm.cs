using iText.Kernel.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizMe_
{
    public partial class PdfViewForm : Form
    {
        private string tempPdfPath;
        public PdfViewForm(byte[] pdfData)
        {
            InitializeComponent();
            try
            {
                
                tempPdfPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".pdf");

                File.WriteAllBytes(tempPdfPath, pdfData);

                this.FormClosed += PdfViewForm_FormClosed;

               
                InitializeWebView2();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        private async void InitializeWebView2()
        {
           
            await webView2Control.EnsureCoreWebView2Async(null);

            
            webView2Control.CoreWebView2.Navigate("file:///" + tempPdfPath.Replace("\\", "/"));
        }
        private void PdfViewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            if (!string.IsNullOrEmpty(tempPdfPath) && File.Exists(tempPdfPath))
            {
                try
                {
                    File.Delete(tempPdfPath);
                }
                catch (Exception ex)
                {
                   
                    Console.WriteLine("Error deleting temp file: " + ex.Message);
                }
            }
        }
    }
}
