﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.NetCore {

    public delegate Task RequestDelegate(HttpContext httpContext);
}
