﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Captcha.App_Start
{
    public class BunddleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery-unobtrusive").Include("~/Scripts/jquery.unobtrusive-ajax.js"));
        }
    }
}