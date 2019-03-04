using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Data;

namespace Tracker.Repository.Repository
{
    public class BaseRepository
    {
        protected TrackerEntities DbContext = new TrackerEntities();
    }
}
