# CheckList

## Usage
-

```csharp
CheckList<CheckList.CheckListItem> list = new CheckList<CheckList.CheckListItem>();

// Add some items to the Grocery list.
list.Add("Eggs", false);
list.Add("Cheese", false);
list.Add("Bread", false);

// Check an item once it's been picked in-store.
list[0].Check();

// Check it another way.
list["Eggs"].Check();

// Un-check it.
list[0].Uncheck();

// Enumerate the list outputting each item.
foreach(CheckList.CheckListItem item in list)
{
    Console.WriteLine(item.Value + " " + item.Checked);
}

// Check to see if an item is Checked.
if(list["Bread"].Checked)
{
    // TODO: Something.
}

// Change a CheckListItem.
list["Eggs"].Change(new CheckListItem()
{
	Value = "Pizza Slice",
	Checked = false
});
```
