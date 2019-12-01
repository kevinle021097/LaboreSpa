﻿using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public class MenuTypeAdminRepository : IMenuTypeAdminRepository
    {
        private FonSpaDbContext _db = null;

        public FonSpaDbContext Db { get => _db; set => _db = value; }

        public MenuTypeAdminRepository()
        {
            _db = new FonSpaDbContext();
        }

        public MenuType GetDetail(long id)
        {
            var menutype = _db.MenuTypes.Find(id);
            return menutype;
        }

        public List<MenuType> GetListMenuType()
        {
            return _db.MenuTypes.ToList();
        }

        public long AddMenuType(MenuType menutype)
        {
            var AddMenuType = _db.MenuTypes.Add(menutype);
            _db.SaveChanges();
            return AddMenuType.id;
        }

        public bool EditMenuType(MenuType menutype)
        {
            var MenuTypeEdit = _db.MenuTypes.Where(x => x.id == menutype.id).SingleOrDefault();
            MenuTypeEdit.name = menutype.name;
            
            _db.SaveChanges();
            return true;
        }

        public bool Delete(long id)
        {
            var menutype = _db.MenuTypes.Find(id);
            if (menutype != null)
            {
                _db.MenuTypes.Remove(menutype);
                _db.SaveChanges();
            }
            return true;
        }

        public List<MenuType> ListSearchMenuType(string searchString)
        {
            if (searchString == null) return null;

            var listMenuType = _db.MenuTypes.Where(x => x.name.ToUpper() == searchString.ToUpper());
            return listMenuType.ToList();
        }

        public bool CheckExits(string name)
        {
            var menutype = _db.MenuTypes.Where(x => x.name == name).SingleOrDefault();
            if (menutype != null) return true;
            return false;
        }

        public List<Menu> ListMenu()
        {
            return _db.Menus.ToList();
        }
    }
}
