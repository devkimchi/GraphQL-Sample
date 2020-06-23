using System;

namespace Orders.Models
{
    [Flags]
    public enum OrderStatuses
    {
        Created = 1,
        Processing = 2,
        Completed = 4,
        Cancelled = 8,
        Closed = 16,
    }
}