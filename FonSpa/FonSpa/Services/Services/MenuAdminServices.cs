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
    public class MenuAdminServices : IMenuAdminServices
    {
        private readonly IMenuAdminRepository _menuAdminRepository;
        public MenuAdminServices(IMenuAdminRepository menuAdminRepository)
        {
            _menuAdminRepository = menuAdminRepository;
        }

        public List<Menu> ListMenuByText(string searchString)
        {
            if (searchString != null)
            {
                return _menuAdminRepository.GetMenusByText(searchString);
            }
            return _menuAdminRepository.GetListMenu();
        }

        public List<MenuType> GetMenuTypes()
        {
            return _menuAdminRepository.GetMenuType();
        }

        public long AddMenu(Menu menu)
        {
            if (menu == null) return 0;
            var addMenu = _menuAdminRepository.AddMenu(menu);
            var idMenu = addMenu;
            return idMenu;
        }

        public Menu GetDetail(int id)
        {
            if (id == 0) return null;
            var menu = _menuAdminRepository.GetDetail(id);
            return menu;
        }

        public bool Edit(Menu menu)
        {
            if (menu == null) return false;
            var editMenu = _menuAdminRepository.EditMenu(menu);
            return true;
        }

        public bool Delete(int id)
        {
            if (id == 0) return false;
            var deleteSuccess = _menuAdminRepository.Delete(id);
            return true;
        }

        public bool? ChangeStatus(int id)
        {
            var status = _menuAdminRepository.ChangeStatus(id);
            return status;
        }
    }
}