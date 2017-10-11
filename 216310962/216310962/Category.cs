using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ProblemProject
{
    class Category
    {
        public DataTable GetCategories(int num)
        {
            DataTable dt = new DataTable();
            DataAccessLayer dat = new DataAccessLayer();
            dt = dat.getCategories();
            return dt;
        }
        public int GetNumCat()
        {
            int num;
            DataAccessLayer dat = new DataAccessLayer();
            num = dat.getNumCategory();
            return num;
        }
       public DataTable GetCategories()
        {
            DataTable dt = new DataTable();
            DataAccessLayer dat = new DataAccessLayer();
            dt = dat.getCategories();
            return dt;
        }
    }
}
