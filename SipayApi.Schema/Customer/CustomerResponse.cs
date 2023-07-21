using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SipayApi.Schema;

public class CustomerResponse
{
    public int CustomerNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public bool IsActive { get; set; }

    public virtual List<AccountResponse> Accounts { get; set; }
}
