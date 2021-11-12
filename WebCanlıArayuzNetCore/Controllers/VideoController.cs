using AppCore.Business.Models.Results;
using Business.Models;
using Business.Services.Bases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebCanlıArayuzNetCore.Controllers
{
    public class VideoController : Controller
    {
        private readonly IVideoService _videoService;
        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }
        public ActionResult Index()
        {
            var query = _videoService.GetQuery();

            var model = query.ToList();
            return View(model);
        }
        public ActionResult ListVideo()
        {
            var query = _videoService.GetQuery();

            var model = query.ToList();
            return View(model);
        }

      

        // GET: VideoController/Create
        public ActionResult Create()
        {
            var VideoModel = new VideoModel();
            return View(VideoModel);
        }

        // POST: VideoController/Create
        [HttpPost]
        public ActionResult Create(VideoModel video)
        {
            if (ModelState.IsValid)
            {
                // Youtube yerleştir özelliğinden değilde sadece route linki eklendiğinde replace ederek geçerli linke ulaşıyor.
                var comment = video.yayinLink.Replace("watch?v=", "embed/").Replace("embed/", "embed/");
                video.yayinLink = comment;

                var result = _videoService.Add(video);
                if (result.Status == ResultStatus.Succes)
                    return RedirectToAction(nameof(Index));
                if (result.Status == ResultStatus.Error)
                {
                    TempData["Error"] = "Link Daha Önce Eklenmiş"; 
                }
                TempData["Error"] = "Link Daha Önce Eklenmiş";
            }
            return View(video);
        }

        // GET: VideoController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var query = _videoService.GetQuery();

            var video = query.SingleOrDefault(p => p.Id == id.Value);
            if (video == null)
                return View("NotFound");




            return View(video);
        }

        // POST: VideoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VideoModel video)
        {
            if (ModelState.IsValid)
            {
                var result = _videoService.Update(video);
                if (result.Status == ResultStatus.Succes)
                    return RedirectToAction(nameof(Index));
                if (result.Status == ResultStatus.Error)
                {
                    ModelState.AddModelError("", result.message);
                    return View(video);
                }
                throw new Exception(result.message);

            }
            return View(video);
        }

       
        // POST: VideoController/Delete/5
       
        public ActionResult Delete(int id)
        {
            var deleteResult = _videoService.Delete(id);
            if (deleteResult.Status == ResultStatus.Succes)
                return RedirectToAction(nameof(ListVideo));

            if (deleteResult.Status == ResultStatus.Error)
            {
                ModelState.AddModelError("", deleteResult.message);
            }

            throw new Exception(deleteResult.message);
        }
    }
}
