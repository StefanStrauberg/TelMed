﻿namespace Referrals.Domain.Exceptions
{
    public class ReferralNotFoundException : NotFoundException
    {
        public ReferralNotFoundException(string id) 
            : base($"The referral with the identifier {id} was not found.")
        {
        }
    }
}
