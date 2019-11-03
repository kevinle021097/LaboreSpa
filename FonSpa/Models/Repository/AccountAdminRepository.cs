﻿using Models.Entity;
using Models.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Repository
{
    public class AccountAdminRepository : IAccountAdminRepository
    {
        private FonSpaDbContext _db = null;

        public FonSpaDbContext Db { get => _db; set => _db = value; }

        public AccountAdminRepository()
        {
            var abc = "str";
            _db = new FonSpaDbContext();
        }

        public AccountAdmin GetDetail(long id)
        {
            var account = _db.AccountAdmins.Find(id);
            return account;
        }

        public List<AccountAdmin> GetListAccount()
        {
            return _db.AccountAdmins.ToList();
        }

        public long AddAccount(AccountAdmin accountAdmin)
        {
            var account = _db.AccountAdmins.Add(accountAdmin);
            _db.SaveChanges();
            return account.id;
        }

        public bool EditAccount(AccountAdmin accountAdmin)
        {
            var account = _db.AccountAdmins.Where(x => x.userName == accountAdmin.userName).SingleOrDefault();
            account.passWord = accountAdmin.passWord;
            account.type = accountAdmin.type;
            _db.SaveChanges();
            return true;
        }

        public bool Delete(long id)
        {
            var accountAdmin = _db.AccountAdmins.Find(id);
            if(accountAdmin != null)
            {
                _db.AccountAdmins.Remove(accountAdmin);
                _db.SaveChanges();
            }
            return true;
        }

        public bool? ChangeStatus(long id)
        {
            if (id > 0)
            {
                var accountNeedChange = _db.AccountAdmins.Find(id);
                accountNeedChange.STATUS = !accountNeedChange.STATUS;
                _db.SaveChanges();
                return accountNeedChange.STATUS;
            }
            return false;
        }


      
        public bool CheckUserName(string userName)
        {     
            var account = _db.AccountAdmins.Where(x => x.userName == userName).SingleOrDefault();
            if (account != null) return true;
            return false;
        }

        public bool CheckPassword(string userName, string password)
        {
            var account = _db.AccountAdmins.Where(x => x.userName == userName && x.passWord ==password).SingleOrDefault();
            bool passwordExits = false;
            if (account != null) passwordExits = true;
            if (passwordExits) return true;
            return false;
        }

        public bool CheckStatusAccount(string userName, string password)
        {
            var account = _db.AccountAdmins.Where(x => x.userName == userName && x.passWord == password).SingleOrDefault();
            if (account.STATUS != true ) return false;
            return true;   
        }


    }
}
