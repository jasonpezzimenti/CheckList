using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckList
{
	public partial class CheckListItem
	{
		/// <summary>
		/// The value of this CheckListItem.
		/// </summary>
		public dynamic Value { get; set; }

		/// <summary>
		/// The Checked state of this CheckListItem.
		/// </summary>
		public bool Checked { get; set; }

		/// <summary>
		/// Checks the CheckListItem.
		/// </summary>
		public void Check()
		{
			Checked = true;
		}

		/// <summary>
		/// Unchecks the CkeckListItem.
		/// </summary>
		public void Uncheck()
		{
			Checked = false;
		}

		/// <summary>
		/// Changes this CheckListItem to another.
		/// </summary>
		/// <param name="item">The item to change this CheckListItem to.</param>
		/// <exception cref="NullReferenceException"></exception>
		public void Change(CheckListItem item)
		{
			if (item != null)
			{
				this.Value = item.Value;
				this.Checked = item.Checked;
			}
			else
			{
				throw new NullReferenceException();
			}
		}

		public CheckListItem this[string value]
		{
			get
			{
				if(this.Value == Value)
				{
					return this;
				}
				else
				{
					return null;
				}
			}
		}
	}
}