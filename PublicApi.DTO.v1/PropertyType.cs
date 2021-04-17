using System.ComponentModel.DataAnnotations;

namespace PublicApi.DTO.v1
{
    public class PropertyType
    {
        [MaxLength(32)] public string PropertyTypeValue { get; set; } = default!;
        public int? PropertyCount { get; set; }
    }
}