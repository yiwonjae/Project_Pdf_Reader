using GalaSoft.MvvmLight.Command;
using Syncfusion.Windows.PdfViewer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Project_Pdf_Reader.Model
{

    public delegate void CallBack_Event_Annotation(CSelectedAnnotation a, PdfViewerControl b);

    public class CSelectedAnnotation
    {
        
        
        public String context { get; set; }

        public int page { get; set; }

        public Rectangle contextBase { get;set; }

        
        
        
        public CallBack_Event_Annotation myCallback { get; set; }


        //https://stackoverflow.com/questions/5073065/is-there-a-way-to-pass-a-parameter-or-multiple-params-to-the-callmethodaction

        public CSelectedAnnotation()
        {
            CommandMouseDown = new RelayCommand<PdfViewerControl>((x) => CommandMouseDownFunction(x));
        }

        public ICommand CommandMouseDown { get; set; }

        private void CommandMouseDownFunction(PdfViewerControl arg)
        {
            if (myCallback != null)
            {
                myCallback(this, arg);
            }
        }


    }
}
