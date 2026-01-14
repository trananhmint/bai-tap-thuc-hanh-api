using BaiTapThucHanhAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapThucHanhAPI.Controllers;

[ApiController]
[Route("api/loai-san-pham")]
public class LoaiSanPhamController : ControllerBase
{
    private readonly AppDbContext _context;

    public LoaiSanPhamController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAllLoaiSanPham()
    {
        return Ok(_context.LoaiSanPham.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetLoaiSanPhamById(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid Id!");
        }

        var entity = _context.LoaiSanPham.Find(id);
        if (entity == null)
        {
            return NotFound("Loai san pham not found!");
        }

        return Ok(entity);
    }

    [HttpPost]
    public IActionResult AddLoaiSanPham([FromBody] LoaiSanPhamDTO loaiSanPham)
    {
        if (loaiSanPham == null)
        {
            return BadRequest("Loai san pham null!");
        }
        else if (string.IsNullOrWhiteSpace(loaiSanPham.TenLSP) || string.IsNullOrWhiteSpace(loaiSanPham.MaLSP))
        {
            return BadRequest("Loai san pham information null or empty!");
        }

        bool isExist = _context.LoaiSanPham.Any(x => x.MaLSP == loaiSanPham.MaLSP || x.TenLSP == loaiSanPham.TenLSP);
        if (isExist)
        {
            return BadRequest("Loai san pham is already existed!");
        }

        _context.LoaiSanPham.Add(new LoaiSanPham()
        {
            TenLSP = loaiSanPham.TenLSP,
            MaLSP = loaiSanPham.MaLSP,
            GhiChu = loaiSanPham.GhiChu
        });
        _context.SaveChanges();
        return Ok("Loai san pham Added Successfully!");
    }

    [HttpPut("{id}")]
    public IActionResult UpdateLoaiSanPham(int id, [FromBody] LoaiSanPhamDTO loaiSanPham)
    {
        if (loaiSanPham == null)
        {
            return BadRequest("Loai san pham null!");
        }
        else if (string.IsNullOrWhiteSpace(loaiSanPham.TenLSP) || string.IsNullOrWhiteSpace(loaiSanPham.MaLSP))
        {
            return BadRequest("Loai san pham information null or empty!");
        }
        var entity =  _context.LoaiSanPham.Find(id);
        if (entity == null)
        {
            return NotFound("Loai san pham not found!");
        }
        bool isExistedInfo = _context.LoaiSanPham.Any(x => x.MaLSP == loaiSanPham.MaLSP || x.TenLSP == loaiSanPham.TenLSP);
        if (isExistedInfo)
        {
            return BadRequest("Loai san pham is already existed!");
        }
        entity.MaLSP = loaiSanPham.MaLSP;
        entity.TenLSP = loaiSanPham.TenLSP;
        entity.GhiChu = loaiSanPham.GhiChu;
        _context.LoaiSanPham.Update(entity);
        _context.SaveChanges();
        return Ok("Loai san pham Updated Successfully!");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteLoaiSanPham(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid Id!");
        }

        var entity = _context.LoaiSanPham.Find(id);
        if (entity == null)
        {
            return NotFound("Loai san pham not found!");
        }

        _context.LoaiSanPham.Remove(entity);
        _context.SaveChanges();
        return Ok("Delete Don Vi Tinh Successfully");
    }
}