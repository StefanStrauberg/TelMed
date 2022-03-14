﻿using Specializations.Domain.Common;

namespace Specializations.Domain
{
    public class Specialization : BaseDomainEntity
    {
        private string _name;
        /// <summary>
        /// Division name
        /// </summary>
        public string Name { get { return _name; } set { _name = value.Trim(); }  }
        public bool IsActive { get; set; } = true;
        public bool DenyConsult { get; set; }
    }
}
