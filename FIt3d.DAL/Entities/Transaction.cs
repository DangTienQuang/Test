using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FIt3d.DAL.Enums;

namespace FIt3d.DAL.Entities
{
    public class Transaction : BaseEntity
    {
        public Guid OrderId { get; set; }

        public Guid UserId { get; set; }

        public long OrderCode { get; set; }

        [MaxLength(100)]
        public string PaymentLinkId { get; set; } = string.Empty;

        [MaxLength(500)]
        public string CheckoutUrl { get; set; } = string.Empty;

        [MaxLength(500)]
        public string QrCode { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        public TransactionStatus TransactionStatus { get; set; } = TransactionStatus.Pending;

        public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.PayOs;

        [ForeignKey(nameof(OrderId))]
        public virtual Order Order { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; } = null!;
    }

    }
