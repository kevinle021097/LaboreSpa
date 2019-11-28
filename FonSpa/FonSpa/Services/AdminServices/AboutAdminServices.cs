﻿using FonSpa.Services.IServices;
using HelperLibrary;
using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FonSpa.Services.Services
{
    public class AboutAdminServices : IAboutAdminServices
    {
        private readonly IAboutAdminRepository _aboutAdminRepository;
        public AboutAdminServices(IAboutAdminRepository aboutAdminRepository)
        {
            _aboutAdminRepository = aboutAdminRepository;
        }

        public List<About> ListAllByName(string searchString)
        {
            if (searchString == null || searchString == "")
            {
                return _aboutAdminRepository.GetListAbout();
            }
            else
            {
                searchString = Helper.RemoveSign4VietnameseString(searchString);
                var ListAbout = _aboutAdminRepository.ListSearchAbout(searchString);
                return ListAbout;
            }
        }

        public long AddAbout(About about)
        {
            if (about == null) return 0;
            var addAbout = _aboutAdminRepository.AddAbout(about);
            var idAbout = addAbout;
            return idAbout;
        }

        public About GetDetail(int id)
        {
            if (id == 0) return null;
            var about = _aboutAdminRepository.GetDetail(id);
            return about;
        }

        public bool Edit(About about)
        {
            if (about == null) return false;
            var editAbout = _aboutAdminRepository.EditAbout(about);
            return true;
        }

        public bool Delete(int id)
        {
            if (id == 0) return false;
            var deleteSuccess = _aboutAdminRepository.Delete(id);
            return true;
        }

        public bool? ChangeStatus(int id)
        {
            var status = _aboutAdminRepository.ChangeStatus(id);
            return status;
        }
    }
}