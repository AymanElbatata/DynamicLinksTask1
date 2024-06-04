using com.sun.xml.@internal.ws.wsdl.writer.document;
using dynamicslink1.Models;
using eBdb.EpubReader;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;

namespace dynamicslink1.Controllers
{
    public class HomeController : Controller
    {
 
        // GET: Home
        [HttpGet]
            public ActionResult Index( )
        {

            return View();
        }

        [HttpGet]
        public ActionResult Epub()
        {
            return View();
        }
    

        [HttpGet]
        public ActionResult JqueryPage()
        {
            var result = getmylist();
            ViewBag.GetMyList = new SelectList(result, "Value", "DisplayText");
            return View();
        }

        [HttpGet]
        public ActionResult Action(int countermore = 0, int counterless =0)
        {
            var mylist = new List<MyModel>();
            ViewBag.counter = 1;
            if (countermore > 0)
            {
                ViewBag.counter = mycounterplus(ref countermore);
            }
            else if (counterless > 0)
            {
                ViewBag.counter = mycounterminus(ref counterless);
            }


            for (int i = 1; i <= ViewBag.counter; i++)
            {
                MyModel myobject = new MyModel();
                mylist.Add(myobject);
            }
            //int i = 1;
            //do
            //{
            //    MyModel myobject = new MyModel();
            //    mylist.Add(myobject);
            //    i++;

            //} while (i <= ViewBag.counter);

            var result = getmylist();
            ViewBag.GetMyList = new SelectList(result, "Value", "DisplayText");
            ViewBag.Item = new SelectList(result, "Value", "DisplayText");
            ViewBag.Unit = new SelectList(result, "Value", "DisplayText");
            return View(mylist);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Action(List<MyModel> mymodel = null, int countermore = 0, int counterless = 0, int counterall =0)
        {
            var result = getmylist();
            ViewBag.GetMyList = new SelectList(result, "Value", "DisplayText");
            ViewBag.Item = new SelectList(result, "Value", "DisplayText");
            ViewBag.Unit = new SelectList(result, "Value", "DisplayText");

            //for (int i = 0; i <= counterall; i++)
            //{
            //    // save my data
            //}
            return RedirectToAction("Action", new { countermore = countermore, counterless = counterless });
        }


        [HttpPost]
        public JsonResult SaveMYData(int invoicenumber = 0,DateTime? date= null, int store = 0, List<int> MyItem = null, List<int> MyUnit = null, List<int> MyFirst = null, List<int> MySecond = null, List<int> MyThird = null, List<int> MyFourth = null, List<int> MyFifth = null)
        {
            var mymodel = new List<MyModel>();
            if (MyItem.Count() > 0)
            {
                for (int i = 0; i < MyItem.Count; i++)
                {
                    var myobject = new MyModel();
                    myobject.Item = MyItem[i];
                    myobject.Unit = MyUnit[i];
                    myobject.Price = MyFirst[i];
                    myobject.Qty = MySecond[i];
                    myobject.Total = MyThird[i];
                    myobject.Discount = MyFourth[i];
                    myobject.Net = MyFifth[i];
                    mymodel.Add(myobject);
                }
            }
            return Json(mymodel, JsonRequestBehavior.AllowGet);
            //RedirectToAction("JqueryPage", "Home");
            //return Json(null);
            //return Json(new
            //{
            //    redirectUrl = Url.Action("JqueryPage", "Home"),
            //    isRedirect = true
            //});
            //return Json(new
            //{
            //    redirectUrl = Url.Action("JqueryPage", "Home", new { area = "" }),
            //    isRedirect = true
            //});
        }

        //
        private List<CustomOption> getmylist()
        {
            var result = new List<CustomOption>();
            for (int i = 1; i <= 10; i++)
            {
                CustomOption myrow = new CustomOption();
                myrow.Value = i;
                myrow.DisplayText = i.ToString();
                result.Add(myrow);

            }
            CustomOption empty = new CustomOption();
            empty.Value = null;
            empty.DisplayText = "-";
            result.Insert(0, empty);

            return result;
        }
        //

        private int mycounterplus(ref int counters)
        {
            counters ++;
            return counters;
        }

        private int mycounterminus(ref int counters)
        {
            counters--;
            return counters;
        }


        [HttpGet]
        public ActionResult UploadIMAGE()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadIMAGE(HttpPostedFileBase Image1 = null)
        {
            if (Image1 != null && Image1.ContentLength > 0 && (Image1.ContentType == "image/jpg" || Image1.ContentType == "image/jpeg"
                || Image1.ContentType == "image/png" || Image1.ContentType == "image/bmp"))
            {

                //get input Strean from file object and call the function as given below
                Image resizeImage = Image.FromStream(Image1.InputStream, true, true);
                resizeImage = ResizeImage(resizeImage, 300, 200);
                //HttpPostedFileBase newimage = HttpPostedFileBaseModelBinder(resizeImage);
                //300,300 is width and  height

                //string fullPath = Request.MapPath("~/Images/Employee/" + model.PassportORIDIMGURL);
                //if (System.IO.File.Exists(fullPath))
                //{
                //    System.IO.File.Delete(fullPath);
                //}

                if (!Directory.Exists("~/Images/Employee"))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Images/Employee"));
                }
                string _FileName = "EMPIMG" + Guid.NewGuid() + Path.GetExtension(Image1.FileName);
                string _path = Path.Combine(Server.MapPath("~/Images/Employee/"), _FileName);
                //Image1.SaveAs(_path);
                resizeImage.Save(_path, System.Drawing.Imaging.ImageFormat.Gif);
            }
            return View();
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var resultImage = new Bitmap(width, height);
            resultImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            using (var graphics = Graphics.FromImage(resultImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return resultImage;
        }


        [HttpGet]
        public ActionResult PopUP()
        {
            return View();
        }

    }
}