namespace MVC5Course.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(ProductMetaData))]
    public partial class Product : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Price > 1000 && Stock > 100)
            {
                yield return new ValidationResult("價格與數量不合理",
                    new string[] { "Price", "Stock"});
            }
            if(ProductName.Contains("will"))
            {
                yield return new ValidationResult("產品名稱有誤",
                    new string[] { "ProductName" });
            }
            yield break;
        }
    }

    public partial class ProductMetaData
    {
        [Required]
        public int ProductId { get; set; }
        
        [StringLength(80, ErrorMessage="欄位長度不得大於 80 個字元")]
        public string ProductName { get; set; }
        [Required]
        public Nullable<decimal> Price { get; set; }
        public Nullable<bool> Active { get; set; }
        [Required]
        public Nullable<decimal> Stock { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
