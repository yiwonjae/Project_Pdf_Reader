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
using Project_Pdf_Reader.Model;

namespace Project_Pdf_Reader.ViewModel
{


    public class MainFrameViewModel:ViewModelBase
    {
        #region 변수

        private List<CSelectedAnnotation> _Annotations;

        #endregion

        #region RaisePropertyChanged


        public List<CSelectedAnnotation> Annotations
        {
            get { return this._Annotations; }
            set
            {
                if (value != this._Annotations)
                    this._Annotations = value;
                RaisePropertyChanged("Annotations");
            }
        }

        #endregion


        #region 생성자

        public MainFrameViewModel()
        {
        
        
        }

        #endregion


        #region Event


        public void Event_Annotation(CSelectedAnnotation arg, PdfViewerControl control)
        {
            // scroll 하고 page를 이동해야 정상적으로 동작함
            // page > scroll은 안됨 -- 확인함


            //https://blazor.syncfusion.com/documentation/pdfviewer/how-to/move-scrollbar

            control.ScrollTo(arg.contextBase.Location.X, arg.contextBase.Location.Y);


            //https://help.syncfusion.com/wpf/pdf-viewer/navigating-through-the-pages
            control.GotoPage(arg.page);

        }


        public void PdfViewerControl_TextSelectionCompleted(object sender, Syncfusion.Windows.PdfViewer.TextSelectionCompletedEventArgs args)
        {
            List<int> keys = new List<int>(args.SelectedTextInformation.Keys);

            int page = keys[0];
            String text = args.SelectedText;
            var position = args.SelectedTextInformation[page][text];

            String head = String.Format("X:{0},Y:{1},W:{2},H:{3}", position.X, position.Y, position.Width, position.Height);

            //MessageBox.Show(text, head);

            //https://support.syncfusion.com/kb/article/8488/how-to-highlight-text-in-a-pdf-using-c-and-vb-net


            //Create a new ink annotation
            PdfTextMarkupAnnotation textmarkup = new PdfTextMarkupAnnotation(position);

            textmarkup.TextMarkupAnnotationType = PdfTextMarkupAnnotationType.Highlight;

            textmarkup.Text = "Highlight Text";


            //Sets the highlighting color
            textmarkup.TextMarkupColor = new PdfColor(Color.LightPink);


            ((PdfViewerControl)sender).LoadedDocument.Pages[page - 1].Annotations.Add(textmarkup);

            List<CSelectedAnnotation> temp = null;

            if (Annotations != null)
            {
                temp = new List<CSelectedAnnotation>(Annotations);
                Annotations.Clear();
                Annotations = null;
            }
            else
            {
                temp = new List<CSelectedAnnotation>();
            }



            temp.Add(new CSelectedAnnotation { context = text, page = page, contextBase = position, myCallback= Event_Annotation });


            Annotations = temp;





        }


        #endregion



    }
}
