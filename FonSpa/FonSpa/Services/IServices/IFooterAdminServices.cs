﻿using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FonSpa.Services.IServices
{
    public interface IFooterAdminServices
    {
        List<FooterCategory> GetFooterCategory();
        long AddFooter(Footer footer);
        bool Delete(int id);
        Footer GetDetail(int id);
        bool Edit(Footer footer);
        bool? ChangeStatus(int id);
        List<Footer> GetListFooter();
    }
}