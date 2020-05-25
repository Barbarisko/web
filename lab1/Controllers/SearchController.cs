using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Viewmodels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace lab1.Controllers
{
    [Authorize]

    public class SearchController : Controller
    {
        //IAlbumService AlbumService;
        //public SearchController(IAlbumService albumService)
        //{
        //    AlbumService = albumService;
        //}

        //[HttpGet]
        //public IActionResult AlbumSearch()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult AlbumSearch(SearchViewModel search)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        TempData["FoundAlbums"] = JsonConvert.SerializeObject(AlbumService.AlbumSearch(search));
        //        return RedirectToAction("AlbumSearchResults", "Search");
        //    }

        //    return View(search);
        //}

        //public IActionResult AlbumSearchResults()
        //{
        //    var foundAlbums = JsonConvert.DeserializeObject<List<AlbumModel>>(TempData["FoundAlbums"].ToString());
        //    ViewBag.Fa = foundAlbums;
        //    ViewBag.FaCount = foundAlbums.Count;
        //    return View();
        //}
    }
}