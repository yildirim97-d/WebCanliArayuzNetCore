using AppCore.DataAccess.EntityFramework.Bases;
using DataAccess.EntityFramework.Repositories.Base;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityFramework.Repositories
{
    public class VideoRepositories : VideoRepositoryBase 
    {
        public VideoRepositories(DbContext db) : base(db)
        {

        }
    }
}
