using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExcelAddInExpBDTP.PRES {
    public class DepartementViewModel : INotifyPropertyChanged {

        private String _headerListBoxDepartement = "";
        public String HeaderListBoxDepartement {
            get { return _headerListBoxDepartement; }
            set {
                _headerListBoxDepartement = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] String propertyName = "") {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }




    }
}
