using AutoMapper;
using ComputerEcommerce.Data.Repositories.Contracts;
using ComputerEcommerce.Data.Repositories.Implementation;
using ComputerEcommerce.Model;
using ComputerEcommerce.Service.Contracts;
using ComputerEcommerce.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ComputerEcommerce.Service.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<ProductDTO> Catalog(string category, string find)
        {
            var products = _unitOfWork.ProductRepository.Consult(p =>
                p.Name.ToLower().Contains(find.ToLower()) &&
                p.Category.Name.ToLower().Contains(category.ToLower())).ToList();
            return _mapper.Map<List<ProductDTO>>(products);
        }

        public async Task<ProductDTO> Create(ProductDTO entity)
        {
            try
            {
                var product = _mapper.Map<Product>(entity);
                var productInserted = await _unitOfWork.ProductRepository.Insert(product);

                if (productInserted == true)
                    return _mapper.Map<ProductDTO>(product);
                else
                    throw new TaskCanceledException("No se pudo crear");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var productQuery = _unitOfWork.ProductRepository.Consult(p => p.Id == id);
                var product = await productQuery.FirstOrDefaultAsync();
                if (product != null)
                {
                    var response = _unitOfWork.ProductRepository.Delete(product);
                    if (!response)
                    {
                        throw new TaskCanceledException("No se pudo eliminar");
                    }
                    return response;
                }
                else
                    throw new TaskCanceledException("No se econtraron resultados");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Edit(ProductDTO entity)
        {
            try
            {
                var productQuery = _unitOfWork.ProductRepository.Consult(p => p.Id == entity.Id);
                var product = await productQuery.FirstOrDefaultAsync();
                if (product != null)
                {
                    product.Name = entity.Name;
                    product.Description = entity.Description;
                    product.CategoryId = entity.CategoryId;
                    product.Price = entity.Price;
                    product.PriceOffer = entity.PriceOffer;
                    product.Quantity = entity.Quantity;
                    product.Image = entity.Image;
                    var response = _unitOfWork.ProductRepository.Update(product);
                    if (!response)
                        throw new TaskCanceledException("No se pudo editar");
                    return response;
                }
                else
                {
                    throw new TaskCanceledException("No se econtraron resultados");
                }

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ProductDTO> GetById(int id)
        {
            try
            {
                var productQuery = _unitOfWork.ProductRepository.Consult(p => p.Id == id).Include(p => p.Category);
                var product = await productQuery.FirstOrDefaultAsync();
                
                if (product != null)
                    return _mapper.Map<ProductDTO>(product);
                else
                    throw new TaskCanceledException("No se econtraron coincidencias");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ProductDTO>> List(string find)
        {
            try
            {
                var products = _unitOfWork.ProductRepository.Consult(p =>
                p.Name.ToLower().Contains(find.ToLower())
                ).Include(c=>c.Category);
                return _mapper.Map<List<ProductDTO>>(await products.ToListAsync());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
    
