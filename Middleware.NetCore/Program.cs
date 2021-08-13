using System;
using System.Threading.Tasks;

namespace Middleware.NetCore {


    /// <summary>
    /// 如何优雅的制作中间件
    /// </summary>
    class Program {
        static void Main(string[] args) {

            IApplicationBuilder applicationBuilder = new DefaultApplicationBuilder();

            applicationBuilder.Use(async (context, next) => {
                Console.WriteLine(1);
                await next.Invoke();
                Console.WriteLine(2);

            });

            applicationBuilder.Use(async (context, next) => {
                Console.WriteLine(3);
                await next.Invoke();
                Console.WriteLine(4);
            });

            applicationBuilder.Use(async (context, next) => {
                Console.WriteLine(5);
                await next.Invoke();
                Console.WriteLine(6);
            });

            applicationBuilder
                .Build()
                .Run();

            Console.WriteLine("Hello World!");
        }
    }
}
