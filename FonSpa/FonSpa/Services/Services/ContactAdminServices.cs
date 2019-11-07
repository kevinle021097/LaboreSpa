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
    public class ContactAdminServices : IContactAdminServices
    {
        private readonly IContactAdminRepository _contactAdminRepository;
        public ContactAdminServices(IContactAdminRepository contactAdminRepository)
        {
            _contactAdminRepository = contactAdminRepository;
        }

        public long AddContact(Contact contact)
        {
            if (contact == null) return 0;
            var addContact = _contactAdminRepository.AddContact(contact);
            var idContact = addContact;
            return idContact;
        }

        public Contact GetDetail(int id)
        {
            if (id == 0) return null;
            var contact = _contactAdminRepository.GetDetail(id);
            return contact;
        }

        public bool Edit(Contact contact)
        {
            if (contact == null) return false;
            var editProduct = _contactAdminRepository.EditContact(contact);
            return true;
        }

        public bool Delete(int id)
        {
            if (id == 0) return false;
            var deleteSuccess = _contactAdminRepository.Delete(id);
            return true;
        }
    }
}