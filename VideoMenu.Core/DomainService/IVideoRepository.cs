using System;
using System.Collections.Generic;
using System.Text;
using VideoMenu.Core.Entity;

namespace VideoMenu.Core.DomainService
{
    public interface IVideoRepository
    {
        Video Create(Video video);

        Video ReadById(int id);

        List<Video> ReadAll();

        Video Update(Video videoUpdate);

        Video Delete(int id);
    }
}
