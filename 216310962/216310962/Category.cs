using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using _216310962;

namespace ProblemProject
{
    class Category
    {
        public DataTable GetCategories(int num) //Gets table of current category data in the category table.
        {
            DataTable dt = new DataTable();
            DataAccessLayer dat = new DataAccessLayer();
            dt = dat.getCategories();
            return dt;
        }

        public void InsertCategory(string catCode, string catDesc) //Inserts category data into the category table.
        {
            DataAccessLayer dat = new DataAccessLayer();
            dat.insertCategory(catCode, catDesc);
        }

        public int CategoryExists(string catCode) //Checks if the entered category code already exists.
        {
            DataAccessLayer dat = new DataAccessLayer();
            int exists;
            exists = dat.categoryExists(catCode);
            return exists;
        }

        public int GetNumCat() //Returns number of categories in the Category table.
        {
            int num;
            DataAccessLayer dat = new DataAccessLayer();
            num = dat.getNumCategory();
            return num;
        }
        public DataTable GetCategories() //Gets table of current category data in the category table.
        {
            DataTable dt = new DataTable();
            DataAccessLayer dat = new DataAccessLayer();
            dt = dat.getCategories();
            return dt;
        }

        public void RemoveCategory(string CategoryID) //Removes selected category record from the category table.
        {
            DataAccessLayer dat = new DataAccessLayer();
            dat.removeCategory(CategoryID);
        }
    }
}
