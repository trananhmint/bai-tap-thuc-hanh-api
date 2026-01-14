using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiTapThucHanhAPI.Controllers;

[Table ("tbl_DM_Don_Vi_Tinh")]
public class DonViTinh
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(70)]
    [Column("Ten_Don_Vi_Tinh")]
    public string TenDonViTinh { get; set; } = null!;
    
    [StringLength(1000)]
    [Column("Ghi_Chu")]
    public string? GhiChu { get; set; }
}