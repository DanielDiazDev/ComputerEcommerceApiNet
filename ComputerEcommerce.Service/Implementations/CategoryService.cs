using AutoMapper;
using ComputerEcommerce.Data.Repositories.Contracts;
using ComputerEcommerce.Model;
using ComputerEcommerce.Service.Contracts;
using ComputerEcommerce.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ComputerEcommerce.Service.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> Create(CategoryDTO entity)
        {
            try
            {
                var category = _mapper.Map<Category>(entity);
                var categoryInserted = await _unitOfWork.CategoryRepository.Insert(category);
                if (categoryInserted == true)
                {
                    return _mapper.Map<CategoryDTO>(category);
                }
                else
                {
                    throw new TaskCanceledException("No se pudo crear");
                }
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
                var categoryQuery = _unitOfWork.CategoryRepository.Consult(c => c.Id == id);
                var category = await categoryQuery.FirstOrDefaultAsync();
                if (category != null)
                {
                    var response =  _unitOfWork.CategoryRepository.Delete(category);
                    if (!response)
                    {
                        throw new TaskCanceledException("No se pudo eliminar");
                    }
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

        public async Task<bool> Edit(CategoryDTO entity)
        {
            try
            {
                var categoryQuery = _unitOfWork.CategoryRepository.Consult(c => c.Id == entity.Id);
                var category = await categoryQuery.FirstOrDefaultAsync();
                if (category != null)
                {
                    category.Name = entity.Name;
                    var response = _unitOfWork.CategoryRepository.Update(category);
                    if (!response)
                    {
                        throw new TaskCanceledException("No se pudo editar");
                    }
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

        public async Task<CategoryDTO> GetById(int id)
        {
            try
            {
                var categoryQuery = _unitOfWork.CategoryRepository.Consult(c => c.Id == id);
                var category = await categoryQuery.FirstOrDefaultAsync();
                if (category != null)
                {
                    return _mapper.Map<CategoryDTO>(category);
                }
                else
                {
                    throw new TaskCanceledException("No se econtraron coincidencias");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CategoryDTO> List(string find)
        {
            try
            {
                 var categories = _unitOfWork.CategoryRepository.Consult(c => c.Name!.ToLower().Contains(find.ToLower())).ToList();
                 List<CategoryDTO> categoriesDTO = _mapper.Map<List<CategoryDTO>>(categories);
                 return categoriesDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
