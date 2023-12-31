﻿
using AutoMapper;
using HrManagement.Application.Contracts.Persistence;
using HrManagement.Application.DTOs.LeaveType.DTO;
using HrManagement.Application.Features.LeaveTypes.Requests.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HrManagement.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetLeaveTypeDetailRequestHandler : IRequestHandler<GetLeaveTypeDetailRequest, LeaveTypeDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeDetailRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<LeaveTypeDto> Handle(GetLeaveTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.GetById(request.Id);
            return _mapper.Map<LeaveTypeDto>(leaveType);
        }
    }
}
