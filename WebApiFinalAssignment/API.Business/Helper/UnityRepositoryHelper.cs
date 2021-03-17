using API.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using Unity.Extension;

namespace API.BAL.Helper
{
    public class UnityRepositoryHelper : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IHotelRepository, HotelRepository>();
        }
    }
}
