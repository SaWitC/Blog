using Blog.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Blog.Components
{
    public static class WWWrootFile
    {
        
        public static string NormaliseFileName(string text)
        {
            Regex r = new Regex(@"\W");
            string doneText = r.Replace(text, "");
            if (doneText.Length > 50) doneText.Substring(49,doneText.Length);
            return doneText;
        }
   
        //public async static Task<string> SaveImage(ImageModel imageModel, string Path)
        //{
            //string ImageName;
            //bool DoneSave;
            //try
            //{
            //    //Save Image
            //    ImageName = fileName + DateTime.Now.ToString("ssmmhhdd") + extenshion;

            //    using (var filestrem = new FileStream(Path, FileMode.Create))
            //    {
            //        await ImageFile.CopyToAsync(filestrem);
            //    }
            //    OperationStatus = true;
            //}
            //catch
            //{
            //    OperationStatus = false;
            //}
            //return DoneSave;
        //}
    }
}
