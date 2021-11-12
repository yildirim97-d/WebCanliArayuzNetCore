using AppCore.Business.Models.Results;
using Business.Models;
using Business.Services.Bases;
using DataAccess.EntityFramework.Repositories.Base;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Services
{
    public class VideoService : IVideoService
    {
        private readonly VideoRepositoryBase _videoRepository;
        public VideoService(VideoRepositoryBase videoRepository)
        {
            _videoRepository = videoRepository;
        }
        public Result Add(VideoModel model)
        {
            try
            {
                if (_videoRepository.GetEntityQuery().Any(d => d.yayinLink.Trim() == model.yayinLink.Trim()))
                {
                    return new ErrorResult("Bu Link Zaten Eklenmiş!");
                }
                
              
                var entity = new Video()
                { 
                 
                
                yayinAdi = model.yayinAdi,
                    yayinLink = model.yayinLink,
                    
                    

            };
                
                _videoRepository.Add(entity);

                return new SuccesResult();
            }
            catch (Exception e)
            {

                return new ExceptionResult(e);
            }
        }

        public Result Delete(int id)
        {
            try
            {
                var video = _videoRepository.GetEntityQuery(d => d.Id == id).SingleOrDefault();
                _videoRepository.Delete(video);
                return new SuccesResult();
            }
            catch (Exception e)
            {

                return new ExceptionResult(e);
            }
        }

        public void Dispose()
        {
            _videoRepository.Dispose();
        }

        public IQueryable<VideoModel> GetQuery()
        {
            var query = _videoRepository.GetEntityQuery().OrderBy(d => d.yayinAdi).Select(d => new VideoModel()
            {
                Id = d.Id,
               yayinAdi = d.yayinAdi,
                yayinLink = d.yayinLink


            });
            return query;
        }

        public Result Update(VideoModel model)
        {
            try
            {
            
                var entity = _videoRepository.GetEntityQuery(d => d.Id == model.Id).SingleOrDefault();
                entity.yayinLink = model.yayinLink.Trim();
                entity.yayinAdi = model.yayinAdi.Trim();
               
                _videoRepository.Update(entity);
                return new SuccesResult();
            }
            catch (Exception e)
            {

                return new ExceptionResult(e);
            }
        }
    }
}
