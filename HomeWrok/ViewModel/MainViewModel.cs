using HomeWrok.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWrok.ViewModel
{
    public static class MainViewModel
    {
       public static ObservableCollection<SongInfo> playList = new ObservableCollection<SongInfo>();

    }
}
