﻿namespace DigiMenu.Razor.Models.Product
{
    public class ProductImageModel : BaseModel
    {
        public long ProductId { get; set; }
        public string ImageName { get; set; }
        public int Order { get; set; }
    }
}
