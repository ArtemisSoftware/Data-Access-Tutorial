using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace DataAccess.Sql
{
    public class Recipe : INotifyPropertyChanged
    {
        private string _name;


        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { 
            get { return _name; }
            set {

                if(_name == value)
                {
                    return;
                }
                else
                {
                    _name = value;
                    OnPropertyChanged();
                }
            } 
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
