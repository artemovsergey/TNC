using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TNC.WPF.ViewModels;

namespace TNC.WPF.Models
{
    internal class User : ViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public int RoleId { get; set; }


        //public virtual Role Role { get; set; }

        #region Свойство Role
        //private Role _role;
        //public virtual Role Role
        //{
        //    get { return _role; }

        //    set
        //    {
        //        Set(ref _role, value);
        //    }

        //}
        #endregion

    }
}
