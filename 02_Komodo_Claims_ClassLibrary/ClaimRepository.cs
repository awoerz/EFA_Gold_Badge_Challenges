using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Komodo_Claims_ClassLibrary
{
    public class ClaimRepository
    {
        public List<Claim> Repository { get; set; }

        public ClaimRepository()
        {
            Repository = new List<Claim>();
        }
        public ClaimRepository(List<Claim> claimList)
        {
            Repository = claimList;
        }
    }
}
