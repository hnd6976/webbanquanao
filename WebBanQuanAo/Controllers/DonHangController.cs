﻿//using AspNetCoreHero.ToastNotification.Abstractions;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using WebBanQuanAo.Models;
//using WebBanQuanAo.ModelViews;

//namespace WebBanQuanAo.Controllers
//{
//    public class DonHangController : Controller
//    {
//        private readonly db_ClothingContext _context;
//        public INotyfService _notyfService { get; }
//        public DonHangController(db_ClothingContext context, INotyfService notyfService)
//        {
//            _context = context;
//            _notyfService = notyfService;
//        }

//        [HttpPost]
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }
//            try
//            {
//                var taikhoanID = HttpContext.Session.GetString("CustomerId");
//                if (string.IsNullOrEmpty(taikhoanID)) return RedirectToAction("Login", "Accounts");
//                var khachhang = _context.Accounts.AsNoTracking().SingleOrDefault(x => x.AccountId == Convert.ToInt32(taikhoanID));
//                if (khachhang == null) return NotFound();
//                var donhang = await _context.Orders
//                    .Include(x => x.TransactStatus)
//                    .FirstOrDefaultAsync(m => m.OrderId == id && Convert.ToInt32(taikhoanID) == m.AccountId);
//                if (donhang == null) return NotFound();

//                ViewBag.DonHang = donhang;


//                var chitietdonhang = _context.OrderDetails
//                    .Include(x => x.Product)
//                    .AsNoTracking()
//                    .Where(x => x.OrderId == id)
//                    .OrderBy(x => x.OrderDetailId)
//                    .ToList();
//                XemDonHang donHang = new XemDonHang();
//                donHang.DonHang = donhang;
//                donHang.ChiTietDonHang = chitietdonhang;
//                return PartialView("Details", donHang);

//            }
//            catch
//            {
//                return NotFound();
//            }
//        }
//    }
//}
