﻿using MediatR;
using Referrals.Domain.AnamnesisEntity;

namespace Referrals.Application.Features.Anamnesis.Requests.Commands
{
    public class UpdateAnamnesisCommand : IRequest
    {
        public string Id { get; set; }
        public string Summary { get; set; }
        public AnamnesisCategory CategoryId { get; set; }
    }
}
