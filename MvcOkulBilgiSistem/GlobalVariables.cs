﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace MvcOkulBilgiSistem
{
    public class GlobalVariables
    {
        public static HttpClient webapiclient = new HttpClient();

        static GlobalVariables()
        {
            webapiclient.BaseAddress = new Uri("https://localhost:44395/api/"); 
            webapiclient.DefaultRequestHeaders.Clear();
            webapiclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}