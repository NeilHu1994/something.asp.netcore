﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.NetCore {
    public interface IApplicationBuilder {

        IApplicationBuilder Use(Func<HttpContext, Func<Task>, Task> middleware);

        IApplicationBuilder Build();

        IApplicationBuilder Run();

    }
}
