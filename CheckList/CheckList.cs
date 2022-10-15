// Parts adapted from https://dotnetcodr.com/2020/10/13/roll-your-own-custom-list-with-c-net/.

using System.Collections;

namespace CheckList
{
	public class CheckList<CheckListItem> : IEnumerable<CheckListItem>
	{
		protected internal static CheckListItem[] Data;

		/// <summary>
		/// The number of elements in the list.
		/// </summary>
		public int Count { get { return Data.Length; } }

		public CheckList(int capacity = 0)
		{
			Data = new CheckListItem[capacity];
		}

		private void Resize()
		{
			CheckListItem[] array = new CheckListItem[Count + 1];

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
		public void Add(CheckListItem item)
		{
			Resize();

			Data[Count - 1] = item;
		}

		/// <summary>
		/// Removed the item from the list.
		/// </summary>
		/// <param name="item"></param>
		public void Remove(CheckListItem item)
		{
			int index = Array.IndexOf(Data, item);
			Data = Data.Where<CheckListItem>((value, i) => i != index).ToArray();
		}

		public IEnumerator<CheckListItem> GetEnumerator()
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
		public CheckListItem this[int index]
		{
			get
			{
				return Data[index];
			}
		}
	}
}