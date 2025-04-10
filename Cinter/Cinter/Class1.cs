using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace Cinter
{
    public interface I1
    {
        void insert(string s11);
        DataTable select(string s1);
    }
}
