using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ninject;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Infrastructure
{
   public class NinjectionDependencyResolver : IDependencyResolver
   {
      private IKernel kernal;

      public NinjectionDependencyResolver(IKernel kernelParam)
      {
         kernal = kernelParam;
         AddBindings();
      }
      public object GetService(Type serviceType)
      {
         return kernal.TryGet(serviceType);
      }

      public IEnumerable<object> GetServices(Type serviceType)
      {
         return kernal.GetAll(serviceType);
      }

      private void AddBindings()
      {
         Mock<IProductRepository> mock = new Mock<IProductRepository>();

         mock.Setup(m => m.Products).Returns(new List<Product>
         { new Product {Name = "Piłka nożna", Price = 25 },
            new Product { Name = "Deska surfingowa", Price = 179 },
            new Product { Name = "Buty do biegania", Price = 95 }
         });
      }
   }
}