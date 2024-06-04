using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace dynamicslink1.App_Start
{
    public class MyBundleCls
    {
        public static void MyBundleJSCS(BundleCollection myobject)
        {

            myobject.Add(new StyleBundle("~/CSFILES1").Include(
                "~/Content/bootstrap.min.css"
                , "~/Content/themes/base/jquery-ui.css"
               , "~/Scripts/jtable/themes/lightcolor/green/jtable.min.css"
               , "~/Content/chosen.css"
               , "~/Content/validationEngine.jquery.css"

                ));

            myobject.Add(new StyleBundle("~/CSFILES2").Include(
            //"~/Content/themes/base/all.css"
            "~/DesignTemps/templatemo_502_short/css/animate.min.css"
          , "~/DesignTemps/templatemo_502_short/css/easy-responsive-tabs.min.css"
          , "~/DesignTemps/templatemo_502_short/css/tabs.css"
          , "~/DesignTemps/templatemo_502_short/css/templatemo-style.css"
          ));



            myobject.Add(new ScriptBundle("~/JSFILES1").Include(
             "~/scripts/modernizr-2.8.3.js"
            , "~/Scripts/jquery-3.5.1.min.js"
            , "~/Scripts/jquery.validate.min.js"
            , "~/Scripts/jquery.validate.unobtrusive.min.js"
            , "~/Scripts/jquery.unobtrusive-ajax.min.js"
            , "~/Scripts/jquery-ui-1.12.1.min.js"
            , "~/Scripts/jtable/jquery.jtable.min.js"
            , "~/Scripts/chosen.jquery.min.js"
            , "~/Scripts/jquery.validationEngine.js"
            , "~/Scripts/jquery.validationEngine-en.js"

    ));


            myobject.Add(new ScriptBundle("~/JSFILES2").Include("~/scripts/bootstrap.min.js"));

            BundleTable.EnableOptimizations = false;
        }
    }
}