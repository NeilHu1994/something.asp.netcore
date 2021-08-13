using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.NetCore {

    public delegate Task RequestDelegate(HttpContext httpContext);

    class DefaultApplicationBuilder : IApplicationBuilder {

        public static List<Func<RequestDelegate, RequestDelegate>> _components = new ();

        public static RequestDelegate requestDelegate = null;

        public IApplicationBuilder Use(Func<HttpContext,Func<Task>,Task> middleware) {

            Func<RequestDelegate, RequestDelegate> component = next => {
                return context => {
                    Func<Task> task = () => next(context);
                    return middleware(context,task);
                };
            };

            _components.Add(component);

            return this;
        }

        public IApplicationBuilder Build() {

            RequestDelegate app = context => Task.CompletedTask;

            _components.Reverse();

            foreach (var component in _components) {

                app = component(app);
            }

            requestDelegate = app;

            return this;
        }

        public IApplicationBuilder Run() {

            var context = new HttpContext();

            requestDelegate(context);

            return this;
        }

    }
}
