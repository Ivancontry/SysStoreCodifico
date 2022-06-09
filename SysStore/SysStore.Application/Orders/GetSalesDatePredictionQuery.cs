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
    public class GetSalesDatePredictionQuery : IRequestHandler<GetSalesDatePredictionRequest, GetSalesDatePredictionResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetSalesDatePredictionQuery(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<GetSalesDatePredictionResponse> Handle(GetSalesDatePredictionRequest request, CancellationToken cancellationToken)
        {
            var salesDataPrediction = _unitOfWork.OrdersRepository.GetSalesDatePrediction(request.CustomerName);
            return Task.FromResult(new GetSalesDatePredictionResponse(salesDataPrediction));
        }
    }
    public class GetSalesDatePredictionRequest: IRequest<GetSalesDatePredictionResponse>
    {
        public string CustomerName { get; set; }
    }
    public class GetSalesDatePredictionResponse
    {
        public List<SaleDatePredictioDTO> SalesDatePrediction { get; set; }

        public GetSalesDatePredictionResponse(List<SaleDatePredictioDTO> salesDataPrediction)
        {
            this.SalesDatePrediction = salesDataPrediction;
        }
    }
}
