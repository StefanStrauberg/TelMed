﻿using MediatR;
using Referrals.Domain;

namespace Referrals.Application.Features.Referral.Requests.Commands
{
    public class CreateReferralCommand : IRequest<string>
    {
        public Patient Patient { get; set; }
        public Guid AuthorId { get; set; }

    }
}
