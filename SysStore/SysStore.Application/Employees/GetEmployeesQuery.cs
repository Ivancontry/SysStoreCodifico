using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SysStore.Application.Employees
{
    public class GetEmployeesQuery : IRequestHandler<GetEmployeesRequest, GetEmployeesResponse>
    {
        public Task<GetEmployeesResponse> Handle(GetEmployeesRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new GetEmployeesResponse());
        }
    }
    public class GetEmployeesRequest : IRequest<GetEmployeesResponse>
    { 
    
    }
    public class GetEmployeesResponse
    {

    }
}
