using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyContacts
{
    interface IContactsresponsitory
    {
        DataTable selectAll();
        DataTable selectrow(int contactId);
        DataTable Search(string parameter); //میره یک رشته میگیره و اون رو سرچ میکنه.
        bool Insert(string name, string familly, int age, string adress, string mobile);

        bool Update(int contactId, string name, string familly, int age, string adress, string mobile);

        bool Delete(int contactId);


    }
}
