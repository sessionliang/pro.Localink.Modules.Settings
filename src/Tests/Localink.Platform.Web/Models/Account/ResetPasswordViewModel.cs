using System.ComponentModel.DataAnnotations;
using Localink.Platform.Security;

namespace Localink.Platform.Web.Models.Account
{
    public class ResetPasswordViewModel
    {
        /// <summary>
        /// Encrypted tenant id.
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        /// Encrypted user id.
        /// </summary>
        [Required]
        public string UserId { get; set; }

        [Required]
        public string ResetCode { get; set; }

        public PasswordComplexitySetting PasswordComplexitySetting { get; set; }
    }
}