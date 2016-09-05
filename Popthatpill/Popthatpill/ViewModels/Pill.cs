using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using System.ComponentModel;
using SQLite.Net.Attributes;

namespace Popthatpill.ViewModel
{
    [Table("Pills")]
    public class Pill : INotifyPropertyChanged
    {
        private int _id;
        [PrimaryKey, AutoIncrement]
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                this._id = value;
                OnPropertyChanged(nameof(ID));
            }
        }
        private string _Day;

        public string Day

        {
            get
            {
                return _Day;
            }
            set
            {
                this._Day = value;
                OnPropertyChanged(nameof(Day));
            }
        }

        private string _NewPillName;
        public string NewPillName
        {
            get
            {
                return _NewPillName;
            }
            set
            {
                this._NewPillName = value;
                OnPropertyChanged(nameof(NewPillName));
            }
        }

        private string _NewPillImage;
        public string NewPillImage
        {
            get
            {
                return _NewPillImage;
            }
            set
            {
                this._NewPillImage = value;
                OnPropertyChanged(nameof(NewPillImage));
            }
        }

        private int _NewPillCount;
        public int NewPillCount
        {
            get
            {
                return _NewPillCount;
            }
            set
            {
                this._NewPillCount = value;
                OnPropertyChanged(nameof(NewPillCount));
            }
        }
        private TimeSpan _NewTime;
        public TimeSpan NewTime
        {
            get
            {
                return _NewTime;
            }
            set
            {
                _NewTime = value;
                OnPropertyChanged(nameof(NewTime));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this,
              new PropertyChangedEventArgs(propertyName));
        }
    }
}
