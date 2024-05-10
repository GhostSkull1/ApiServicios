using ApiServicios.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiServicios.Data.Repositories
{
    public interface InveRepositories
    {
        Task<IEnumerable<Inve>> GetAllInv();
        Task<Inve> GetDetails(int id);
        Task<bool> InsetInve(Inve inve);
        Task<bool> UpdateInve(Inve inve);
        Task<bool> DeleteInve(Inve  inve);
    }
}
