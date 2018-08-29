using System;
using System.Collections.Generic;
using System.Text;
using VideoMenu.Core.DomainService;
using VideoMenu.Core.Entity;

namespace VideoMenu.Infrastructure.Static.Data.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        static int id = 1;
        private static List<Video> _videos = new List<Video>();

        public Video Create(Video video)
        {
            video.Id = id++;
            _videos.Add(video);
            return video;
        }

        public Video Delete(int id)
        {
            Video videoRemove = FindVideoById(id);
            if (videoRemove != null) {
                _videos.Remove(videoRemove);
                return videoRemove;
            }
            return null;
        }

        public List<Video> ReadAll()
        {
            return _videos;
        }

        public Video ReadById(int id)
        {
            return FindVideoById(id);
        }

        public Video Update(Video videoUpdate)
        {
            Video videoFromDB = FindVideoById(videoUpdate.Id);
            if (videoFromDB != null) {
                videoFromDB.Title = videoUpdate.Title;
                videoFromDB.Length = videoUpdate.Length;
                return videoUpdate;
            }
            return null;
        }

        private Video FindVideoById(int id)
        {
            foreach (var item in _videos) {
                if (item.Id == id) {
                    return item;
                }
            }
            return null;
        }

    }
}
