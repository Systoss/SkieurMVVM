using SkieurMVVML.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkieurMVVML.Services
{
    public interface ISkieurService
    {
        Task<IEnumerable<Skieur>> Refresh();
    }
}
