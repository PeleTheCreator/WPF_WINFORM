# Winform Textbox Cheatsheet
**Property	Description**
Text |Get/set text
ReadOnly|Prevent editing
Enabled	|Enable/disable
Visible	|Show/hide
MaxLength |Limit characters
CharacterCasing	|Upper/Lower
PasswordChar |Mask characters
UseSystemPasswordChar |System password mask

**Multiline TextBox**
textBox1.Multiline = true;
textBox1.ScrollBars = ScrollBars.Vertical;
- Property	Use
Multiline |Multiple lines
ScrollBars |Vertical / Horizontal
AcceptsReturn |Enter key
AcceptsTab |Tab key
WordWrap |Wrap text

**Selection & Cursor**
textBox1.SelectAll();
textBox1.SelectionStart = 0;
textBox1.SelectionLength = 5;
textBox1.SelectionStart = textBox1.Text.Length;

**Common Events**
Event	Fires when
TextChanged	Any text change
KeyPress	Character typed
KeyDown	Key pressed
KeyUp	Key released
Enter	Focus gained
Leave	Focus lost

**Numeric-Only Input**
private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
{
    if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
        e.Handled = true;
}

-------------------------------------------------------------------------------------------------------------------------------------------

# WinForms ComboBox Cheatsheet
1. **ComboBox Styles** : comboBox1.DropDownStyle = ComboBoxStyle.DropDown || DropDownList || simple;
2. **Adding Items** :  comboBox1.Items.Add("Apple"); || comboBox1.Items.AddRange(new object[] { "Apple", "Banana", "Mango" });
3. **Selecting Items** object selectedItem = comboBox1.SelectedItem || string text = comboBox1.Text || int index = comboBox1.SelectedIndex;  
if (comboBox1.SelectedItem != null){}
4. **HandlingSelectionChange** : comboBox1.SelectedIndexChanged += (s, e) =>
{
    MessageBox.Show(comboBox1.SelectedItem.ToString());
};
5. **DataBinding**: 
comboBox1.DataSource = students;
comboBox1.DisplayMember = "Name";
comboBox1.ValueMember = "Id";
6. **AutoComplete**
comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
-------------------------------------------------------------------------------------------------------------------------------------------

# WinForms ListBox Cheatsheet
1. **Listbox Styles** listBox1.SelectionMode = SelectionMode.MultiExtended || one || multiSimple;
2. **Adding Items** listBox1.Items.Add("Item1"); || listBox1.Items.AddRange(new object[] { "Item1", "Item2", "Item3" });
3. **Selecting Items** object selectedItem = listBox1.SelectedItem || int index = listBox1.SelectedIndex 
foreach (var item in listBox1.SelectedItems)
{ }
4. **DataBinding**: 
listBox1.DataSource = users;
listBox1.DisplayMember = "Username";
listBox1.ValueMember = "UserId";
5. **Performance Tip**:
listBox1.BeginUpdate();
// add many items
listBox1.EndUpdate();

-------------------------------------------------------------------------------------------------------------------------------------------
## RadionButton Cheatsheet
BASIC PROPERTIES
----------------
radioButton1.Text = "Option A";
radioButton1.Checked = true;
Property        Description
--------        -----------
Text            Label text
Checked         Selected state (true / false)
Enabled         Enable / disable
Visible         Show / hide
AutoCheck       Automatic toggle behavior
TabStop         Keyboard focus handling
RightToLeft     RTL layout (text + icon)
Appearance      Normal or Button style


GROUPING RADIOBUTTONS (VERY IMPORTANT)
-------------------------------------
RadioButtons are grouped by their PARENT CONTAINER.

CORRECT:
Form
 └─ GroupBox
     ├─ RadioButton A
     └─ RadioButton B

CHECKEDCHANGED EVENT
--------------------
radioButton1.CheckedChanged += RadioButton_CheckedChanged;

Event handler:

private void RadioButton_CheckedChanged(object sender, EventArgs e)
{
    RadioButton rb = sender as RadioButton;

    if (rb.Checked)
    {
        MessageBox.Show(rb.Text);
    }
}

IMPORTANT:
- CheckedChanged fires when checked AND unchecked
- Always test: rb.Checked == true


GET SELECTED RADIOBUTTON (BEST PRACTICE)
---------------------------------------
RadioButton selected =
    groupBox1.Controls
             .OfType<RadioButton>()
             .FirstOrDefault(r => r.Checked);

if (selected != null)
{
    Console.WriteLine(selected.Text);
}


SET DEFAULT SELECTION
---------------------
radioButton1.Checked = true;
Only ONE RadioButton per group should be checked.

DISABLE AUTOMATIC SWITCHING (ADVANCED)
--------------------------------------
radioButton1.AutoCheck = false;
Used when selection logic must be manually controlled.

KEYBOARD NAVIGATION
-------------------
Key         Action
---         ------
Tab         Enter the radio group
Arrow keys Move between options
Space       Select focused radio button

APPEARANCE (BUTTON STYLE)
-------------------------
radioButton1.Appearance = Appearance.Button;
Appearance.Normal  -> Classic radio circle
Appearance.Button  -> Toggle-button look

RIGHT-TO-LEFT SUPPORT (RTL)
---------------------------
radioButton1.RightToLeft = RightToLeft.Yes;

-------------------------------------------------------------------------------------------------------------------------------------------

## WinForms RadioBox Cheatsheet

## Golden Rules for WinForms “Responsive” UI
✔ Use TableLayoutPanel for structure
✔ Use Dock = Fill for large areas
✔ Use Anchor for positioning
✔ Avoid absolute pixel positioning
✔ Set MinimumSize
✔ Test resize early
______________________________________________________________________________________________________________________
## SqlDataReader vs SqlCommand vs SqlDataAdapter
Tool__	Purpose__	Can Update DataTable?
SqlDataReader	Fast, read-only	❌ No
SqlCommand	Single SQL action	❌ No
SqlDataAdapter	Full CRUD + sync	✅ Yes

## CONNECTED
UI → Service → Repository
               │
               ├─ SqlCommand
               ├─ SqlDataReader
               └─ Open connection → Execute → Close


✔ Real-time DB access
✔ Fast, scalable
❌ No offline editing

## DISCONNECTED
UI → DataTable / DataSet
        │
        ├─ User edits locally
        ├─ SqlDataAdapter tracks changes
        └─ Save → Sync changes → DB
✔ Offline + batch editing
✔ Perfect for WinForms grids
❌ More memory

## DISCONNECTED ARCHITECTURE – CRUD (WinForms)
public DataTable LoadStudents()
{
    using var conn = new SqlConnection(_connStr);
    using var adapter = new SqlDataAdapter(
        "SELECT Id, Name, Age FROM dbo.Students", conn);

    var table = new DataTable();
    adapter.FillSchema(table, SchemaType.Source);
    adapter.Fill(table);

    return table;
}
## CREATE (Local)
DataRow row = table.NewRow();
row["Name"] = "John";
row["Age"] = 17;
table.Rows.Add(row);

## UPDATE (Local)
DataRow row = table.Rows[0];
row["Name"] = "Updated Name";

## DELETE (Local)
table.Rows[0].Delete();

## SAVE (Push all changes)
public void Save(DataTable table)
{
    using var conn = new SqlConnection(_connStr);
    conn.Open();

    var adapter = new SqlDataAdapter();

    adapter.InsertCommand = new SqlCommand("""
        INSERT INTO dbo.Students (Name, Age)
        VALUES (@name, @age);
    """, conn);
    adapter.InsertCommand.Parameters.Add("@name", SqlDbType.NVarChar, 100, "Name");
    adapter.InsertCommand.Parameters.Add("@age", SqlDbType.Int, 0, "Age");

    adapter.UpdateCommand = new SqlCommand("""
        UPDATE dbo.Students
        SET Name=@name, Age=@age
        WHERE Id=@id;
    """, conn);
    adapter.UpdateCommand.Parameters.Add("@name", SqlDbType.NVarChar, 100, "Name");
    adapter.UpdateCommand.Parameters.Add("@age", SqlDbType.Int, 0, "Age");
    adapter.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 0, "Id");

    adapter.DeleteCommand = new SqlCommand("""
        DELETE FROM dbo.Students
        WHERE Id=@id;
    """, conn);
    adapter.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 0, "Id");

    adapter.Update(table);
}
_____________________________________________________________________________________________________________________
## Connected
## READ (Connected)
public async Task<List<StudentDto>> GetAllAsync(CancellationToken ct)
{
    const string sql = "SELECT Id, Name, Age FROM dbo.Students;";
    var list = new List<StudentDto>();

    await using var conn = new SqlConnection(_connStr);
    await using var cmd = new SqlCommand(sql, conn);

    await conn.OpenAsync(ct);
    await using var reader = await cmd.ExecuteReaderAsync(ct);

    while (await reader.ReadAsync(ct))
    {
        list.Add(new StudentDto
        {
            Id = reader.GetInt32(0),
            Name = reader.GetString(1),
            Age = reader.GetInt32(2)
        });
    }

    return list;
}

## CREATE
public async Task<int> CreateAsync(string name, int age, CancellationToken ct)
{
    const string sql = """
        INSERT INTO dbo.Students (Name, Age)
        OUTPUT INSERTED.Id
        VALUES (@name, @age);
    """;

    await using var conn = new SqlConnection(_connStr);
    await using var cmd = new SqlCommand(sql, conn);

    cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = name;
    cmd.Parameters.Add("@age", SqlDbType.Int).Value = age;

    await conn.OpenAsync(ct);
    return (int)await cmd.ExecuteScalarAsync(ct);
}

## UPDATE
public async Task<int> UpdateAsync(int id, string name, int age, CancellationToken ct)
{
    const string sql = """
        UPDATE dbo.Students
        SET Name=@name, Age=@age
        WHERE Id=@id;
    """;

    await using var conn = new SqlConnection(_connStr);
    await using var cmd = new SqlCommand(sql, conn);

    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
    cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = name;
    cmd.Parameters.Add("@age", SqlDbType.Int).Value = age;

    await conn.OpenAsync(ct);
    return await cmd.ExecuteNonQueryAsync(ct);
}

## DELETE
public async Task<int> DeleteAsync(int id, CancellationToken ct)
{
    const string sql = "DELETE FROM dbo.Students WHERE Id=@id;";

    await using var conn = new SqlConnection(_connStr);
    await using var cmd = new SqlCommand(sql, conn);

    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

    await conn.OpenAsync(ct);
    return await cmd.ExecuteNonQueryAsync(ct);
}