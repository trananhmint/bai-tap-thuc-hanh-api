using BaiTapThucHanhAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapThucHanhAPI.Controllers;

[ApiController]
[Route("api/don-vi-tinh")]
public class DonViTinhController : ControllerBase
{
    private readonly AppDbContext _context;

    public DonViTinhController(AppDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public IActionResult GetAllDonViTinh()
    {
        List<DonViTinh> donViTinhList = _context.DonViTinh.ToList();
        return Ok(donViTinhList);
    }

    [HttpGet("{id}")]
    public IActionResult GetDonViTinhById(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid Id!");
        }
        var entity = _context.DonViTinh.Find(id);
        if (entity == null)
        {
            return NotFound("DonViTinh not found!");
        }
        return Ok(entity);
    }
    
    [HttpPost]
    public IActionResult AddDonViTinh([FromBody] DonViTinhDTO donViTinh)
    {
        if (donViTinh ==  null)
        {
            return BadRequest("DonViTinh is null!");
        } else if (string.IsNullOrWhiteSpace(donViTinh.TenDonViTinh))
        {
            return BadRequest("TenDonViTinh is null or empty!");
        }
        bool isExist = _context.DonViTinh.Any(x => x.TenDonViTinh == donViTinh.TenDonViTinh);
        if (isExist)
        {
            return BadRequest("DonViTinh is already existed!");
        }
        _context.DonViTinh.Add(new DonViTinh()
        {
            TenDonViTinh = donViTinh.TenDonViTinh,
            GhiChu = donViTinh.GhiChu,
        });
        _context.SaveChanges();
        return Ok("Add Don Vi Tinh Successfully");
    }

    [HttpPut("{id}")]
    public IActionResult UpdateDonViTinh(int id, [FromBody] DonViTinhDTO donViTinh)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid Id!");
        }
        var entity = _context.DonViTinh.Find(id);
        if (entity == null)
        {
            return NotFound("DonViTinh not found!");
        }
        bool isTenDonViTinhExist = _context.DonViTinh.Any(x => x.TenDonViTinh == donViTinh.TenDonViTinh);
        if (isTenDonViTinhExist)
        {
            return BadRequest("TenDonViTinh is existed!");
        }
        entity.TenDonViTinh = donViTinh.TenDonViTinh;
        entity.GhiChu = donViTinh.GhiChu;
        _context.SaveChanges();
        return Ok("Update Don Vi Tinh Successfully");
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteDonViTinh(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid Id!");
        }
        var entity = _context.DonViTinh.Find(id);
        if (entity == null)
        {
            return NotFound("DonViTinh not found!");
        }

        _context.DonViTinh.Remove(entity);
        _context.SaveChanges();
        return Ok("Delete Don Vi Tinh Successfully");
    }
}