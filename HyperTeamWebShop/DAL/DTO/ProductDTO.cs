using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HyperTeamWebShop.DAL.DTO
{
    public abstract class ProductDTO<TDto,TEntity> 
        where TDto : class
        where TEntity : class
    {
        public string Manufacturer { get; set; }
        public string Type { get; set; }
        public string ImgURL { get; set; }
        public int Price { get; set; }

        public abstract TDto EntityToDto(TEntity entity);
        public abstract TEntity DtoToEntity(TDto dto);

    }
}

