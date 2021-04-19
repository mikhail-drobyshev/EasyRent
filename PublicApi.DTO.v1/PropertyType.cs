using System;
using System.ComponentModel.DataAnnotations;

namespace PublicApi.DTO.v1
{
    public class PropertyType
    {
        public Guid Id { get; set; }
        [MaxLength(32)] public string PropertyTypeValue { get; set; } = default!;
        public int PropertyCount { get; set; } = default!;
    }
}