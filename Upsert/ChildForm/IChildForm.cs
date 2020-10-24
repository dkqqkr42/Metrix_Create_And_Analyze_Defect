using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Upsert
{
    interface IChildForm
    {
        int SelectItem();
        bool SaveItem();
        bool DeleteItem();
        string StoredProcedureName();
    }
}
