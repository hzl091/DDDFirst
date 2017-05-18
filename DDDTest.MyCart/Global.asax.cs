using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using DDDTest.Domain.IProvider;
using DDDTest.ServiceContract;
using DDDTest.Service;
using DDDTest.Data;

namespace DDDTest.MyCart
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            this.InitProducts();
        }

        private void InitProducts()
        { 
            IProductService productService = new ProductService(new ProductRepository());
            productService.AddProduct(new ServiceContract.Dto.AddProductRequest {
                Title = "iphone7 plus",
                Price = 7000,
                ImgPath = "http://img14.360buyimg.com/n0/s450x450_jfs/t3064/188/1693292264/115570/e891640b/57d11bfaN2e8acade.jpg"
            });

            productService.AddProduct(new ServiceContract.Dto.AddProductRequest
            {
                Title = "Orion 好丽友 薯愿 三连罐 312g/组",
                Price = 20,
                ImgPath = "http://img14.360buyimg.com/n1/g13/M02/13/0E/rBEhVFLnaTgIAAAAAALY6w_BHVsAAIQ_ABwotkAAtkD058.jpg"
            });

            productService.AddProduct(new ServiceContract.Dto.AddProductRequest
            {
                Title = "苏泊尔（SUPOR）电水壶电热水壶SWF17E20C全钢无缝",
                Price = 99,
                ImgPath = "http://img11.360buyimg.com/n1/jfs/t3199/239/977896228/50789/bdc92430/57c38dafNc435ec14.jpg"
            });

            productService.AddProduct(new ServiceContract.Dto.AddProductRequest
            {
                Title = "360手机 奇酷（QiKU）旗舰版 辰光银 移动联通4G手机 双卡双待",
                Price = 799,
                ImgPath = "http://img12.360buyimg.com/n1/s450x450_jfs/t3127/122/2720039102/254658/caee4d3a/57e4f5beN64491c46.jpg"
            });
        }
    }
}