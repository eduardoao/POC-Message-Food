using System;
using POC.Modules.Domain.Enums;

namespace POC.Modules.Domain.Entities
{
    public class Delivery : IEntity
    {
        public Delivery(DateTime estimatedDeliveryDate)
        {
            this.Id = Guid.NewGuid();
            CreateDate = DateTime.UtcNow;
            EstimatedDeliveryDate = estimatedDeliveryDate;
            Status = EDeliveryStatus.Waiting;
        }

        public Delivery()
        {
        }
        
        public DateTime CreateDate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }

        public EDeliveryStatus Status { get; private set; }
        public Guid Id { get;  set; }

        public void Send()
        {
            Status = EDeliveryStatus.Sent;
        }

        public void Cancel()
        {
            Status = EDeliveryStatus.Canceled;
        }
    }
}
