using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Referrals.Domain.ObservationEntity
{
    /// <summary>
    /// Observation
    /// </summary>
    public class Observation
    {
        /// <summary>
        /// Date of observation
        /// </summary>
        public DateTime ObservationDate { get; set; } = DateTime.Now;
        /// <summary>
        /// Description observation
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Observation images
        /// </summary>
        public List<Attachment> Attachments { get; set; }
    }
}
