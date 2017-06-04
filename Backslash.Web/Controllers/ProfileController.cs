﻿using Backslash.Data.Entities;
using Backslash.Data.Repositories;
using Backslash.Web.Models.ViewModels;
using System.Web.Mvc;

namespace Backslash.Web.Controllers
{
    [Authorize]
    public class ProfileController : BaseController
    {
        private FileRepository _fileRepository;

        public ProfileController()
        {
            _fileRepository = new FileRepository();
        }

        public ActionResult Uploader()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }

        [Route("edit/{id:int}")]
        public ActionResult Edit(int id)
        {
            ProfileEditViewModel model = new ProfileEditViewModel();

            model.file = _fileRepository.GetFileByFileIdAndUserId(id, GetUserID());

            //var fileTags = model.file.FileTags;

            //model.tags = new int[fileTags.Count];            

            //if (fileTags.Count > 0)
            //{
            //    for (var i = 0; i < fileTags.Count; i++)
            //    {
            //        model.tags[i] = fileTags[i].TagId;
            //    }
            //}

            return View(model);
        }

        [HttpPost]
        [Route("edit/{id:int}")]
        public ActionResult Edit(ProfileEditViewModel model)
        {
            return View(model);
        }

    }
}
