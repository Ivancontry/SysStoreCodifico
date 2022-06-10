using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SysStore.Domain.Contracts;
using SysStore.Domain.Repositories;

namespace SysStore.Application.Customers.Orders
{
    
    public class GetDataFormQuery : IRequestHandler<GetDataFormRequest, GetDataFormResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetDataFormQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public Task<GetDataFormResponse> Handle(GetDataFormRequest request, CancellationToken cancellationToken)
        {
            var products = _unitOfWork.CategorysRepository.GetProducts();
            var shippers = _unitOfWork.ShippersRepository.GetShippers();
            var employees = _unitOfWork.EmployeesRepository.GetEmployees();
            return Task.FromResult(new GetDataFormResponse(products,shippers,employees));
        }
    }
    public class GetDataFormRequest : IRequest<GetDataFormResponse>
    {
        
    }
    public class GetDataFormResponse
    {
        public List<GetProductDTO> Products { get; set; }
        public List<GetEmployeeDTO> Employees { get; set; }
        public List<GetShipperDTO> Shippers { get; set; }
        public GetDataFormResponse(List<GetProductDTO> products)
        {
            Products = products;
        }

        public GetDataFormResponse(List<GetProductDTO> products, List<GetShipperDTO> shippers, List<GetEmployeeDTO> employees) : this(products)
        {
            Products = products;
            Employees = employees;
            Shippers = shippers;
        }
    }

    
}
