using ComputerEcommerce.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerEcommerce.Service.Contracts
{
    public interface IProductService
    {
        Task<List<ProductDTO>> List(string find);
        List<ProductDTO> Catalog(string category, string find);
        Task<ProductDTO> GetById(int id);
        Task<ProductDTO> Create(ProductDTO entity);
        Task<bool> Edit(ProductDTO entity);
        Task<bool>  Delete(int id);
    }
}
