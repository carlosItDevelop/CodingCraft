using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cooperchip.MedicalManagement.Web.Mappers
{
    /// <summary>
    /// 
    /// </summary>
    public class AutoMapperConfig
    {

        /// <summary>
        /// 
        /// </summary>
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }

    }
}