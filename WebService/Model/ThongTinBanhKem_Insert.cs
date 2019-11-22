using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Model
{
    public class ThongTinBanhKem_Insert
    {
        public int maBanhKem;

        public string tenBanhKem;

        public ThongTinBanhKem_Insert()
        {

        }

        public int MaBanhKem { get; set; }
        public int TenBanhKem { get; set; }
    }
}