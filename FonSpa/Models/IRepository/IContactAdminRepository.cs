﻿using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.IRepository
{
    public interface IContactAdminRepository
    {
        Contact GetDetail(long id);
        List<Contact> GetListContact();
        bool? ChangeStatus(long id);
        long AddContact(Contact contact);
        bool EditContact(Contact contact);
        bool Delete(long id);
    }
}
