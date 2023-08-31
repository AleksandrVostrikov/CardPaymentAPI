using System.ComponentModel.DataAnnotations.Schema;

namespace CardPaymentAPI.Models
{
    //// <summary>
    /// Represents the credit card information of a user.
    /// </summary>
    public class UserCardDetails
    {
        /// <summary>
        /// The unique identifier for the user's card details.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the cardholder.
        /// </summary>
        [Column(TypeName ="varchar(100)")]
        public string CardHolder { get; set; } = null!;

        /// <summary>
        /// Gets or sets the card number.
        /// </summary>
        [Column(TypeName = "varchar(16)")]
        public string CardNumber { get; set; } = null!;

        /// <summary>
        /// Gets or sets the expiration date of the card.
        /// </summary>
        [Column(TypeName = "varchar(5)")]
        public string ExpirationDate { get; set; } = null!;

        /// <summary>
        /// Gets or sets the security code (CVV) of the card.
        /// </summary>
        [Column(TypeName = "varchar(3)")]
        public string SecurityCode { get; set; } = null!;
    }
}
