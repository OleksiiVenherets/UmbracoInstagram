﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace UmbracoInstagram.Abstract
{
    public interface IHttpContextWrapper
    {
        HttpContextBase Context { get; }
    }
}
