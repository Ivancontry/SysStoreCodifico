using MediatR;
using SysStore.Domain.Contracts;
using SysStore.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SysStore.Application.Orders
{
    public class GetOrdersForCustomerIdQuery : IRequestHandler<GetOrdersForCustomerIdRequest, GetOrdersForCustomerIdResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetOrdersForCustomerIdQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<GetOrdersForCustomerIdResponse> Handle(GetOrdersForCustomerIdRequest request, CancellationToken cancellationToken)
        {
            var orders = _unitOfWork.OrdersRepository.GetOrdersForCustomerId(request.CustId);
            return Task.FromResult(new GetOrdersForCustomerIdResponse(orders));
        }
    }
    public class GetOrdersForCustomerIdRequest: IRequest<GetOrdersForCustomerIdResponse>
    {
        public int CustId { get; set; }
    }
    public class GetOrdersForCustomerIdResponse
    {
        public List<OrderForCustomerDTO> OrdersForCustomerDTO { get; set; }

        public GetOrdersForCustomerIdResponse(List<OrderForCustomerDTO> ordersForCustomerDTO)
        {
            this.OrdersForCustomerDTO = ordersForCustomerDTO;
        }
    }
}
