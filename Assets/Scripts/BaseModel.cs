using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
	public abstract class BaseModel : MonoBehaviour
	{
		public event Action<object, string> PropertyChanged;

		protected void NotifyPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged.Invoke(this, propertyName);
			}
		}

		protected bool SetProperty<T>(ref T storage, T value, string propertyName)
		{
			if (EqualityComparer<T>.Default.Equals(storage, value))
			{
				return false;
			}

			// set new value
			storage = value;

			NotifyPropertyChanged(propertyName);
			return true;
		}
	}
}
