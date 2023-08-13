using GalaSoft.MvvmLight;
using System;
using System.Windows.Forms;
using Syncfusion.Windows.PdfViewer;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Interactive;
using System.Collections.Generic;
using System.Drawing;

namespace Project_Pdf_Reader.ViewModel
{
    public class MainFrameViewModel:ViewModelBase
    {


        public void PdfViewerControl_TextSelectionCompleted(object sender, Syncfusion.Windows.PdfViewer.TextSelectionCompletedEventArgs args)
        {
            List<int> keys = new List<int>(args.SelectedTextInformation.Keys);

            int page = keys[0];
            String text = args.SelectedText;
            var position    = args.SelectedTextInformation[page][text];

            String head = String.Format("X:{0},Y:{1},W:{2},H:{3}", position.X, position.Y, position.Width, position.Height);

            //MessageBox.Show(text, head);

            //https://support.syncfusion.com/kb/article/8488/how-to-highlight-text-in-a-pdf-using-c-and-vb-net


            //Create a new ink annotation
            PdfTextMarkupAnnotation textmarkup = new PdfTextMarkupAnnotation(position);

            textmarkup.TextMarkupAnnotationType = PdfTextMarkupAnnotationType.Highlight;

            textmarkup.Text = "Highlight Text";
            //Sets the highlighting color
            textmarkup.TextMarkupColor = new PdfColor(Color.LightPink);


            ((PdfViewerControl)sender).LoadedDocument.Pages[page-1].Annotations.Add(textmarkup);

        }


    }
}
