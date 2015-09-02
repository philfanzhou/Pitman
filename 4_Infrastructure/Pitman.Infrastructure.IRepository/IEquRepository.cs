using Pitman.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitman.Infrastructure.IRepository
{
    public interface IEquRepository
    {
        bool Insert(Equ equ);

        bool DeleteAllEqus();

        List<string> GetAllTickers();

        List<Equ> GetAllEqus();
    }
}
