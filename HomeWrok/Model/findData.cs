using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWrok.Model
{
    public class findData:ViewModel.BaseViewModel
    {
        private string data;
        public  string Data
        {
            get
            {
                return data;
            }

            set
            {
                data = value;
                 OnPropertyChanged("Data");
            }
        }
    }
}
