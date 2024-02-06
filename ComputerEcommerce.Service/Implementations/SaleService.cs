using AutoMapper;
using ComputerEcommerce.Data.Repositories.Contracts;
using ComputerEcommerce.Model;
using ComputerEcommerce.Service.Contracts;
using ComputerEcommerce.Shared.DTOs;

namespace ComputerEcommerce.Service.Implementations
{
    public class SaleService : ISaleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SaleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<SaleDTO> Register(SaleDTO entity)
        {
            try
            {
                var sale = _mapper.Map<Sale>(entity);
                var saleGenerated = await _unitOfWork.SaleRepository.Register(sale);
                if(saleGenerated.Id == 0)
                {
                    throw new TaskCanceledException("No se pudo registrar");
                }
                return _mapper.Map<SaleDTO>(saleGenerated);
            }
            catch(Exception ex) 
            {
                throw ex;                
            }
        }
    }
}
