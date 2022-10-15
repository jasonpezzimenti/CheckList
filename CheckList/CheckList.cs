// Parts adapted from https://dotnetcodr.com/2020/10/13/roll-your-own-custom-list-with-c-net/.

using System.Collections;

namespace CheckList
{
	public partial class CheckList<CheckListItem> : IEnumerable<CheckList.CheckListItem>
	{
		private CheckList.CheckListItem[] Data;

		/// <summary>
		/// The number of elements in the list.
		/// </summary>
		public int Count { get { return Data.Length; } }

		public CheckList(int capacity = 0)
		{
			Data = new CheckList.CheckListItem[capacity];
		}

		private void Resize()
		{
			CheckList.CheckListItem[] array = new CheckList.CheckListItem[Count + 1];

			for (int index = 0; index < Data.Length; index++)
			{
				array[index] = Data[index];
			}

			Data = array;
		}

		/// <summary>
		/// Adds an item to the end of the list.
		/// </summary>
		/// <param name="item"></param>
		public void Add(CheckList.CheckListItem item)
		{
			Resize();

			Data[Count - 1] = item;
		}

		/// <summary>
		/// Removed the item from the list.
		/// </summary>
		/// <param name="item"></param>
		public void Remove(CheckList.CheckListItem item)
		{
			int index = Array.IndexOf(Data, item);
			Data = Data.Where<CheckList.CheckListItem>((value, i) => i != index).ToArray();
		}

		public IEnumerator<CheckList.CheckListItem> GetEnumerator()
		{
			for (int index = 0; index < Count; index++)
			{
				yield return Data[index];
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return Data.GetEnumerator();
		}

		/// <summary>
		/// Gets an item at the specified index.
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public CheckList.CheckListItem this[int index]
		{
			get
			{
				return Data[index];
			}
		}

		public CheckList.CheckListItem this[CheckList.CheckListItem item]
		{
			get
			{
				int index = Array.IndexOf(Data, item);
				return Data[index];
			}
		}

		/// <summary>
		/// Gets an item by its Value.
		/// </summary>
		/// <param name="value">The value of the item to retrieve.</param>
		/// <returns>CheckListItem</returns>
		public CheckList.CheckListItem this[string value]
		{
			get
			{
				CheckList.CheckListItem item = new CheckList.CheckListItem();

				foreach (dynamic existingItem in Data)
				{
					if (existingItem.Value == value)
					{
						item = existingItem;
						break;
					}
				}

				return item;
			}
		}

		protected internal CheckList.CheckListItem[] ResizeArray(CheckList.CheckListItem[] array)
		{
			if(array != null)
			{
				CheckList.CheckListItem[] newArray = new CheckList.CheckListItem[array.Length];

				for(int index = 0; index < array.Length; index++)
				{
					newArray[index] = array[index];
				}

				return newArray;
			}
			else
			{
				return array;
			}
		}

		/// <summary>
		/// Gets all items matching true or false.
		/// </summary>
		/// <param name="isChecked"></param>
		/// <returns>Items matching either true or false.</returns>
		public CheckList.CheckListItem[] this[bool isChecked]
		{
			get
			{
				CheckList.CheckListItem[] items = null;

				if (isChecked)
				{
					items = Data.Where<CheckList.CheckListItem>(item => item.Checked).ToArray<CheckList.CheckListItem>().ToArray();
				}
				else
				{
					items = Data.Where<CheckList.CheckListItem>(item => !item.Checked).ToArray<CheckList.CheckListItem>().ToArray();
				}

				return items;
			}
		}
	}
}