using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Project_Pdf_Reader
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        //https://m.blog.naver.com/PostView.nhn?isHttpsRedirect=true&blogId=vps32&logNo=222042078922


        public App()
        {
            String key = String.Empty;
            
            
            using(StreamReader sr = new StreamReader(@"S:\공부\C#\Syncfusion_License.txt"))
            {
                key = sr.ReadToEnd();

                sr.Close();
                sr.Dispose();
            }
            
            
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(key);


        }
    }
}
