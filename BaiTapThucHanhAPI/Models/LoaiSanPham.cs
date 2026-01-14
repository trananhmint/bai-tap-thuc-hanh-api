using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiTapThucHanhAPI.Models;

[Table("tbl_DM_Loai_San_Pham")]
public class LoaiSanPham
{
    [Key]
    [Required]
    [Column("Ma_LSP")]
    public string MaLSP { get; set; } = null!;
    
    [Required]
    [Column("Ten_LSP")]
    public string TenLSP { get; set; } = null!;
    
    [Column("Ghi_Chu")]
    public string? GhiChu { get; set; }
}