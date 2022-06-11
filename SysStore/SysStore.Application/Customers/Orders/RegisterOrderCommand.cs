using FluentValidation;
using MediatR;
using SysStore.Domain.Contracts;
using SysStore.Domain.Entities.Sales.Orders;
using SysStore.Application.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SysStore.Application.Customers.Orders
{
    public class RegisterOrderCommand : IRequestHandler<RegisterOrderRequest, RegisterOrderResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public RegisterOrderCommand(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public Task<RegisterOrderResponse> Handle(RegisterOrderRequest request, CancellationToken cancellationToken)
        {
            var order = new Order(  request.Custid,
                                    request.Empid,
                                    request.Shipperid,
                                    request.ShipName,
                                    request.ShipAddress,
                                    request.ShipCity,
                                    request.ShipCountry,
                                    request.OrderDate,
                                    request.RequiredDate,
                                    request.ShippedDate,
                                    request.Freight
                                 );
            order.AddDetail(request.Detail.Productid,request.Detail.Qty,request.Detail.Unitprice,request.Detail.Discount);
            var orderIdReponse = _unitOfWork.OrdersRepository.AddOrderAndDetail(order);
            return Task.FromResult(new RegisterOrderResponse(orderIdReponse));
        }
    }
    public class RegisterOrderRequest : IRequest<RegisterOrderResponse>
    {
        public int Empid { get; set; }
        public int Shipperid { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public decimal Freight { get; set; }
        public OrderDetailRequest Detail { get; set; }
        public int Custid { get; set; }
    }
    public class RegisterOrderResponse
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public RegisterOrderResponse(int id)
        {
            Id = id;
            Message = "¡Successful Operation!";
        }
    }

    public class RegisterOrderValidator :AbstractValidator<RegisterOrderRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderDetailValidator OrderDetailValidator { get; set; }
        public RegisterOrderValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            OrderDetailValidator = new OrderDetailValidator(_unitOfWork);
            RuleFor(x => x.ShipName).NotEmpty().WithMessage("ShipName can't be empty");
            RuleFor(x => x.ShipName).Length(4, 40).WithMessage("ShipName invalid");
            RuleFor(x => x.ShipAddress).NotEmpty().WithMessage("ShipAddress can't be empty");
            RuleFor(x => x.ShipAddress).Length(4, 60).WithMessage("ShipAddress invalid");
            RuleFor(x => x.ShipCity).NotEmpty().WithMessage("ShipCity can't be empty");
            RuleFor(x => x.ShipCity).Length(2, 15).WithMessage("ShipCity invalid");
            RuleFor(x => x.ShipCountry).NotEmpty().WithMessage("ShipCountry can't be empty");
            RuleFor(x => x.ShipCountry).Length(2, 15).WithMessage("ShipAddress invalid");
            RuleFor(x => x.OrderDate).NotEmpty().WithMessage("OrderDate can't be empty");
            RuleFor(x => x.RequiredDate).NotEmpty().WithMessage("RequiredDate can't be empty");
            RuleFor(x => x.Freight).NotEmpty().WithMessage("Freight can't be empty");
            RuleFor(x => x.Empid).Must(ExistEmployee).WithMessage("Employee does not exist");
            RuleFor(x => x.Shipperid).Must(ExistShipper).WithMessage("Shipper does not exist");
            RuleFor(x => x.Detail).NotNull().WithMessage("Detail can't be empty");
            RuleFor(x => x.Detail).SetValidator(OrderDetailValidator).When(x => x.Detail is not null);
        }
        private bool ExistEmployee(int employeId)
        {
            var employee = _unitOfWork.EmployeesRepository.FindFirstOrDefault(t => t.EmpId == employeId);
            return employee is not null;
        }
        private bool ExistShipper(int shipperId)
        {
            var shipper = _unitOfWork.ShippersRepository.FindFirstOrDefault(t => t.ShipperId == shipperId);
            return shipper is not null;
        }
    }
    public class OrderDetailValidator : AbstractValidator<OrderDetailRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderDetailValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            RuleFor(x => x.Unitprice).GreaterThan(0).WithMessage("Unitprice can't be empty");
            RuleFor(x => x.Qty).GreaterThan(0).WithMessage("Qty can't be empty");
            RuleFor(x => x.Productid).Must(ExistProduct).WithMessage("Product does not exist");
            RuleFor(x => x.Discount).Must(IsValidRound).WithMessage("The Format to Discount is incorrect example format => [1.000 or 0.150]");
        }
        public bool IsValidRound(decimal value)
        {            
            return value.IsNumberValid();
            
        }
        private bool ExistProduct(int productId)
        {
            var product = _unitOfWork.CategorysRepository.GetProduct(productId);
            return product is not null;
        }

    }

    public class OrderDetailRequest {
        public int Productid { get; set; }
        public decimal Unitprice { get; set; }
        public int Qty { get; set; }
        public decimal Discount { get; set; }
    }

}
