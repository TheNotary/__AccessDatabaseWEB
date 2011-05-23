using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using ADOX;
using System.IO;
using System.Runtime.InteropServices;
using System.Data.OleDb;
using System.Collections.Specialized;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Web;



namespace __AccessDatabase
{
    public partial class Form1 : Form
    {
        private BindingSource bindingSource1 = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        DataSet myDataset;
        DataSet MasterDataset = new DataSet();
        string MyConString = "";
        bool INFOMODE = false;
        Dictionary<string, string> helperTextDic = new Dictionary<string, string>();

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void btnReadDatabase_Click(object sender, EventArgs e)
        {
            if (INFOMODE) return;

            if (radMysql.Checked)
            {
                consoleWrite("reading database from across the web!...");

                MySqlConnection connection = new MySqlConnection(MyConString);
                MySqlCommand command = connection.CreateCommand();
                MySqlDataReader Reader;
                command.CommandText = "select * from " + txtTable.Text;

                MySqlDataAdapter myAdapter = new MySqlDataAdapter(command.CommandText, connection);



                // check if txtTable.Text exists
                bool tableExist = myAdapter.TableExists(txtTable.Text);
                if (tableExist)
                {
                    connection.Open();




                    myDataset = new DataSet();

                    myAdapter.Fill(myDataset, txtTable.Text);


                    bindingSource1.DataSource = myDataset.Tables[0];
                    dataGridView1.DataSource = bindingSource1;

                    consoleWrite("Download Successful");

                    //try
                    //{
                    //    Reader = command.ExecuteReader();
                    //    while (Reader.Read())
                    //    {
                    //        string thisrow = "";
                    //        for (int i = 0; i < Reader.FieldCount; i++)
                    //            thisrow += Reader.GetValue(i).ToString() + ",";
                    //        listBox1.Items.Add(thisrow);
                    //    }
                    //}
                    //catch (Exception exp)
                    //{
                    //    consoleWrite("Error:  " + exp.Message);
                    //}



                    connection.Close();
                }
                else if (!tableExist)
                {
                    consoleWrite("Table does not exist.");
                }

            }
            else
            {
                //  Set textbox to say "reading..." for 2 seconds
                consoleWrite("reading database table...");

                //  download the database's table into myDataset
                myDataset = GetDataAccessDb(false);

                if (myDataset == null)        // if GetData should fail... it returns a null...  if we have a null, we gotta stop this execution
                    return;


                bindingSource1.DataSource = myDataset.Tables[0];
                dataGridView1.DataSource = bindingSource1;

                consoleWrite("DataBase table '" + txtTable.Text + "' is now visible in text dataGridView.");
                textBox2.Text = "Now Showing the .mdb data!!!!!!!!!!!!!!!!";
            }
        }

        private void consoleWrite(string p)
        {
            if (p == "")
                listBox1.Items.Add("");
            else
                listBox1.Items.Add(DateTime.Now.Minute + ":" + DateTime.Now.Second + " >>         " + p);

            listBox1.SelectedIndex = listBox1.Items.Count - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (INFOMODE) return;
            string pstrDB = txtDbPath.Text;

            try
            {
                Catalog cat = new Catalog();                    // WARNING!  To get this to work you need to include Microsoft ADO 2.x in references
                string strCreateDB = "";
                strCreateDB += "Provider=Microsoft.Jet.OLEDB.4.0;";
                strCreateDB += "Data Source=" + pstrDB + ";";
                strCreateDB += "Jet OLEDB:Engine Type=5";
                strCreateDB = MyConString;
                cat.Create(strCreateDB);

                // The junk below closes the connection.  You only need this if you rly want to delete the file after I guess...
                //  Microsoft ActiveX Data Objects 2.8 Library
                //ADODB.Connection connection = (ADODB.Connection)cat.ActiveConnection;   // we're not goona use this method of closing as a means to omit the ActiveX object library
                //connection.Close();

                //Marshal.ReleaseComObject(cat);         // we don't need this to close the connection anymore... just interesting
                cat = null;
                GC.Collect(); // This is the last resort - don't use if ReleaseComObject works.
            }
            catch (Exception)
            {
                MessageBox.Show("Already exists (probably)");
                SetDbsExistance();
                return;
            }

            SetDbsExistance();
        }

        Dictionary<string, Control> FindControl = new Dictionary<string, Control>();


        private void Form1_Load(object sender, EventArgs e)
        {
            SetDbsExistance();


            SetupDataSetCol();

            InstallDataSetRow();

            SetupHelperText();



            addOmniClickEvent(this.Controls);
        }



        private void addOmniClickEvent(Control.ControlCollection controls)
        {
            foreach (Control aControl in controls)
            {
                // add control to a dictionary
                FindControl.Add(aControl.Name, aControl);

                if (aControl.GetType() == typeof(System.Windows.Forms.Button))
                {
                    aControl.Click += new EventHandler(DoThisForAllButtons);
                }
                else if (aControl.GetType() == typeof(System.Windows.Forms.Panel))
                {
                    // recursion i
                    addOmniClickEvent(aControl.Controls);
                }
            }
        }



        private void SetupHelperText()
        {
            
            helperTextDic.Add(button6.Name, "Click this button to make the datagridview become 'bound' to the DataSet declared in memory (\"MasterDataset\").  Anychanges you make to MasterDataset will show up in the DataGridView and vice-versa!!!");
            helperTextDic.Add(button16.Name, "Click this button to update any changes you made to the above DataGridView.  The updates are made to the actual database from where you got the data.  (Hint:  Click on a row header and hit delete to delete a record.)");

            helperTextDic.Add(radMysql.Name, "Clicking this RadioButton will attempt to initiate a connection to a remote SQL server (or a local connection if the MySQL server you specify is 'localhost')  It will also make all of the applicable buttons operate against the MySQL database specified.");
            helperTextDic.Add(radAccess.Name, "Clicking this RadioButton will associate all of the applicable buttons with the access database specified under 'Database Path'.");
            

            //helperTextDic.Add(chkMySql.Name, "bla");


        }

        private void DoThisForAllButtons(object sender, EventArgs e)
        {
            if (INFOMODE && ((Control)sender).Name != btnInfo.Name)    // unless it's the info button...
            {
                listBox1.Items.Clear();
                string helpText = getControlHelpText(((Control)sender).Name);
                consoleWrite(((Control)sender).Text, helpText);

                this.Cursor = Cursors.Default;
                foreach (KeyValuePair<string, string> ctrl in helperTextDic)
                {
                    Control theControl = FindControl[ctrl.Key];
                    theControl.BackColor = SystemColors.Control;
                }
                INFOMODE = false;
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                return;
            }


        }




        private void InstallDataSetRow()
        {
            string rowC1 = textBox5.Text;
            string rowC2 = textBox6.Text;
            DataRow newrow = MasterDataset.Tables[0].NewRow();       // make row in the likeness of the table
            newrow[0] = rowC1;                                   // put data in the row
            newrow[1] = rowC2;
            MasterDataset.Tables[0].Rows.Add(newrow);                // install the row into the table
        }

        private void SetupDataSetCol()
        {
            string col1 = textBox3.Text;
            string col2 = textBox4.Text;
            string tableName = txtTable.Text;
            


            MasterDataset.Tables.Add(tableName);                       // install a new table
            MasterDataset.Tables[tableName].Columns.Add(col1);      // install a new column (and name it)
            MasterDataset.Tables[tableName].Columns.Add(col2);      // install a new column (and name it)
        }

        private void SetDbsExistance()
        {
            // clear db checkbox
            chkDbsExists.Checked = false;

            if (!radMysql.Checked)
            {
                MyConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source = " + txtDbPath.Text + ";";
                if (File.Exists(txtDbPath.Text))
                {
                    chkDbsExists.Text = "Database Exists";
                    consoleWrite("recalculating database existance... " + chkDbsExists.Text);
                    chkDbsExists.Checked = true;
                    button1.Enabled = false;
                    button9.Enabled = false;
                    button2.Enabled = true;
                }
                else
                {
                    chkDbsExists.Text = "Database not found";
                    consoleWrite("recalculating database existance... " + chkDbsExists.Text);
                    chkDbsExists.Checked = false;
                    button1.Enabled = true;
                    button9.Enabled = true;
                    button2.Enabled = false;
                }
                CheckDbsTable();

            }
            else if (radMysql.Checked)
            {
                // code that checks if connection can be established...
                MyConString = "SERVER=" + txtServer.Text + ";" +
                "DATABASE=" + txtDb.Text + ";" +
                "UID=" + txtUser.Text + ";" +
                "PASSWORD=" + txtPass.Text + ";";
                MySqlConnection connection = new MySqlConnection(MyConString);
                MySqlCommand command = connection.CreateCommand();
                //command.CommandText = "select * from " + txtTable.Text;
                consoleWrite("");
                consoleWrite("Checking connection to Database... (working)");
                Application.DoEvents();
                try
                {
                    connection.Open();
                    consoleWrite("Success!  Remote connection to MySQL server is possible!");
                    chkDbsExists.Checked = true;
                }
                catch (Exception exp)
                {
                    consoleWrite("Failed:  " + exp.Message);

                }

                connection.Close();

                CheckDbsTable();
            }
        }

        private void CheckDbsTable()
        {
            string tableName = txtTable.Text;

            // open .mdb
            // check table
            if (radAccess.Checked)
            {
                DataSet myDataset = GetDataAccessDb(true);
                if (myDataset == null)
                {
                    SetTableNotCorrect();
                    return;
                }

                if (myDataset.Tables.Count >= 1)
                {
                    foreach (DataTable tbl in myDataset.Tables)
                    {
                        if (tbl.TableName == tableName)
                        {
                            chkTableName.Text = "Table: " + tbl.TableName + " Exists";
                            chkTableName.Checked = true;
                        }
                        else
                        {
                            SetTableNotCorrect();
                        }
                    }
                }
            }
            else if (radMysql.Checked)
            {
                // check if table exists
                consoleWrite("Checking if table exists...");

                MySqlConnection connection = new MySqlConnection(MyConString);
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select * from " + txtTable.Text;

                MySqlDataAdapter myAdapter = new MySqlDataAdapter(command.CommandText, connection);



                // check if txtTable.Text exists
                bool tableExist = myAdapter.TableExists(txtTable.Text);

                if (tableExist)
                {
                    chkTableName.Text = "Table: " + txtTable.Text + " Exists";
                    chkTableName.Checked = true;
                }
                else
                    SetTableNotCorrect();

                consoleWrite("Done.");


            }


        }

        private void SetTableNotCorrect()
        {
            chkTableName.Checked = false;
            chkTableName.Text = "Table Not Found";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (INFOMODE) return;
            try
            {
                if (File.Exists(txtDbPath.Text))
                    File.Delete(txtDbPath.Text);
                if (!radMysql.Checked)
                    consoleWrite("Database Deleted from hard drive " + txtDbPath.Text);
            }
            catch (Exception exp)
            {
                MessageBox.Show("You need to restart the app before you can delete the database...", "sorry about this");
            }
            SetDbsExistance();

        }

        private DataSet GetDataAccessDb(bool silent)
        {
            string pstrDB = txtDbPath.Text;
            string tableName = txtTable.Text;

            DataSet accessData = new DataSet();

            String svlQuery = "SELECT * FROM " + tableName;
            OleDbConnection oledbConnection1 = new OleDbConnection();
            oledbConnection1.ConnectionString = MyConString;

            OleDbDataAdapter oledbDataAdapter1 = new OleDbDataAdapter(svlQuery, oledbConnection1);


            try
            {
                oledbConnection1.Open();
            }
            catch { if (!silent) MessageBox.Show("Database (.mdb) missing! (probably)"); accessData = null; }

            try
            {
                oledbDataAdapter1.Fill(accessData, tableName);
            }
            catch (Exception)
            {
                if (!silent) MessageBox.Show("This thing is empty! (probably)"); accessData = null;
            }

            oledbConnection1.Close();

            return accessData;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (INFOMODE) return;
            //  This inserts a row of data into a .mdb file!!!
            string pstrDB = txtDbPath.Text;
            string tableName = txtTable.Text;


            OleDbConnection oledbConnection1 = new OleDbConnection();
            oledbConnection1.ConnectionString = MyConString;

            OleDbDataAdapter oledbDataAdapter1 = new OleDbDataAdapter();
            oledbDataAdapter1 = new OleDbDataAdapter();

            // 
            // oleDbUpdateCommand
            // 
            OleDbCommand updateCommand = new OleDbCommand();
            updateCommand.Connection = oledbConnection1;
            updateCommand.Parameters.Add(new OleDbParameter("MyCol", OleDbType.VarWChar, 50, "MyDsCol"));
            updateCommand.Parameters.Add(new OleDbParameter("MySecondCol", OleDbType.VarWChar, 50, "MySecondDsCol"));

            // 
            // oleDbInsertCommand
            // 
            OleDbCommand insertCommand = new OleDbCommand();
            insertCommand.Connection = oledbConnection1;
            insertCommand.CommandText = "INSERT INTO " + tableName + "(MyCol, MySecondCol) VALUES (?, ?)";

            //  These refer to the DataSet's specs
            insertCommand.Parameters.Add(new OleDbParameter("MyCol", OleDbType.VarWChar, 50, "myDsCol"));      // UID, datatype, maxLength, DataSet.ColumnName
            insertCommand.Parameters.Add(new OleDbParameter("MySecondCol", OleDbType.VarWChar, 50, "mySecondDsCol"));

            // 
            // oleDbDeleteCommand
            // 
            OleDbCommand deleteCommand = new OleDbCommand();
            deleteCommand.CommandText = "DELETE FROM " + tableName + " " +
                "WHERE (MyCol = ?) " +
                "AND (MySecondCol = ? OR ? IS NULL AND MySecondCol IS NULL) ";

            deleteCommand.Connection = oledbConnection1;
            deleteCommand.Parameters.Add(new OleDbParameter("Original_MyCol", OleDbType.VarWChar      , 50, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "MyDsCol", DataRowVersion.Original, null));
            deleteCommand.Parameters.Add(new OleDbParameter("Original_MySecondCol", OleDbType.VarWChar, 50, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "MySecondDsCol", DataRowVersion.Original, null));
            deleteCommand.Parameters.Add(new OleDbParameter("Original_MySecondCol1", OleDbType.VarWChar, 50, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "MySecondDsCol", DataRowVersion.Original, null));

            //oledbDataAdapter1.UpdateCommand = updateCommand;
            oledbDataAdapter1.InsertCommand = insertCommand;
            //oledbDataAdapter1.DeleteCommand = deleteCommand;
            

            oledbConnection1.Open();



            oledbDataAdapter1.Update(MasterDataset, tableName);  //  DataSet, DataSet.TableName

            //  When a DataSet is made in memory, each row has a secret unique ID.
            //  When you UPDATE the DataSet to the .mdb, the row gets transfered
            //  But if you UPDATE the same row again (eg when you don't add another row to the DataSet), the .mdb can tell that you haven't really added another row!
            //  And so the DataSet can't send the same row twice (according to a secret UID)!

            oledbConnection1.Close();
        }

      


        private void btnBindDatasetToGrid_Click(object sender, EventArgs e)
        {
            if (INFOMODE)
                return;

            bindingSource1.DataSource = MasterDataset.Tables[0];
            dataGridView1.DataSource = bindingSource1;
            
            textBox2.Text = "Now Showing the C# DataSet";

            if (chkShowAdvice.Checked) MessageBox.Show("Great!  Now the below datagridview is 'bound' to the DataSet called 'MasterDataset'.  Anychanges you make to MasterDataset will show up below and visa-versa!!!");
        }

        private string getControlHelpText(string p)
        {

            if (helperTextDic.ContainsKey(p))
                return helperTextDic[p];
            else
                return "No Help Found =(";
        }

        private void consoleWrite(string p, string p_2)
        {
            listBox1.Items.Add("");
            listBox1.Items.Add("---------------------------------------- " + p + "-----------------------------------");

            int width = 50;
            int tillNextWordBoundry = 0;
            if (p_2.Length > width)
            {
                for (int i = 0; i < p_2.Length; i += width)
                {
                    if (i + width < p_2.Length)
                    {
                        // find index of next word boundry starting from i + width
                        //p_2.Substring(i + width);
                        int indexOfHit = p_2.Substring(i + width).IndexOf(" ") + i;
                        tillNextWordBoundry = indexOfHit - i;
                        if (tillNextWordBoundry == -1)
                        {
                            tillNextWordBoundry = 0;
                            if (p_2.Substring(i).Length < width*2)
                            {
                                listBox1.Items.Add("|" + "  " + p_2.Substring(i));
                                break;
                            }
                        }
 
                        // then make width + tillNextBoundry

                        listBox1.Items.Add("|" + "  " + p_2.Substring(i, width + tillNextWordBoundry));

                        // and finally, ensure that i skips ahead appropriately so we don't double print words...
                        i += tillNextWordBoundry;
                    }
                    else
                        listBox1.Items.Add("|" + "  " + p_2.Substring(i));
                }
            }
            else
                listBox1.Items.Add("|" + "  " + p_2);

            listBox1.Items.Add("----------------------------------------" + new String('-', p.Length*2) + "-----------------------------------");
            listBox1.Items.Add("");

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (INFOMODE)
                return; 
            string tableName = txtTable.Text;

            try
            {
                string mystr = MasterDataset.Tables[tableName].Rows[0].ItemArray.GetValue(0).ToString();
                MessageBox.Show(mystr);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed.  No Rows in MasterDataset?");
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (INFOMODE) return;

            //  This creates a brand new table called SampleTable in test.mdb

            string pstrDB = txtDbPath.Text;
            string tableName = txtTable.Text;
            String svlQuery = "CREATE TABLE " + tableName + " ( P_Id AUTOINCREMENT, MyCol char(50), MySecondCol char(20), PRIMARY KEY (P_Id))";

            if (radAccess.Checked)
            {
                // Setup Connection
                OleDbConnection myConnection = new OleDbConnection();
                myConnection.ConnectionString = MyConString;
                myConnection.Open();

                // Setup Command
                OleDbCommand myCommand = new OleDbCommand(svlQuery);
                myCommand.Connection = myConnection;

                //Run Command
                try
                {
                    myCommand.ExecuteNonQuery();
                    consoleWrite("Table Created");
                }
                catch (Exception exp)
                {
                    consoleWrite("Error creating table");
                    MessageBox.Show("Table not created because... \n\r" + exp.ToString());
                }



                // Close connection
                myConnection.Close();
                CheckDbsTable();
            }
            else if (radMysql.Checked)
            {
                svlQuery = "CREATE TABLE " + tableName + " ( P_Id int, MyCol text(50), MySecondCol text(20))";

                //consoleWrite("not implimented");

                MySqlConnection myConnection = new MySqlConnection();
                myConnection.ConnectionString = MyConString;
                myConnection.Open();

                MySqlCommand myCommand = new MySqlCommand(svlQuery);

                myCommand.Connection = myConnection;

                //Run Command
                try
                {
                    myCommand.ExecuteNonQuery();
                    consoleWrite("Table Created");
                }
                catch (Exception exp)
                {
                    consoleWrite("Error creating table");
                    MessageBox.Show("Table not created because... \n\r" + exp.ToString());
                }



                // Close connection
                myConnection.Close();
                CheckDbsTable();


                return;
            }



        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (INFOMODE) return;
            try
            {
                ADOX.CatalogClass cat = new ADOX.CatalogClass();

                cat.Create(MyConString);

                // The junk below closes the connection.  You only need this if you rly want to delete the file after I guess...
                //  Microsoft ActiveX Data Objects 2.8 Library
                ADODB.Connection connection = (ADODB.Connection)cat.ActiveConnection;
                connection.Close();
                
                // //Marshal.ReleaseComObject(cat);         // we don't need this to close the connection anymore... just interesting
                // cat = null;
                // GC.Collect(); // This is the last resort - don't use if ReleaseComObject works.
            }
                catch (Exception exp)
            {
                MessageBox.Show("Already exists (probably) \n\r" + exp);
            }
            SetDbsExistance();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (INFOMODE) return;
            //  this button inserts a new row into MasterDataset
            //  The row's contents are determined by the contents of the associated textboxes
            //  Finally the MasterDataset gets bound to the gridview so you can see the changes you made.  
            InstallDataSetRow();

            bindingSource1.DataSource = MasterDataset.Tables[0];
            dataGridView1.DataSource = bindingSource1;

            if (chkShowAdvice.Checked) MessageBox.Show("Great!  Now click the Gridview to the MasterDataSet that you just updated!");

            textBox2.Text = "Now Showing the C# DataSet";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (INFOMODE) return;

            if (radAccess.Checked)
            {
                string tableName = txtTable.Text;
                string pstrDB = txtDbPath.Text;

                DataSet accessData = new DataSet();

                String svlQuery = "INSERT INTO " + tableName + " (MyCol) ";
                svlQuery += "VALUES (2)";

                OleDbConnection oledbConnection1 = new OleDbConnection();
                oledbConnection1.ConnectionString = MyConString;

                OleDbDataAdapter oledbDataAdapter1 = new OleDbDataAdapter(svlQuery, oledbConnection1);


                oledbDataAdapter1 = new OleDbDataAdapter();



                // 
                // oleDbInsertCommand1
                // 
                OleDbCommand insertCommand = new OleDbCommand();

                insertCommand.Connection = oledbConnection1;
                insertCommand.Parameters.Add(new OleDbParameter("MyCol", OleDbType.VarWChar, 50, "MyCol"));
                insertCommand.Parameters.Add(new OleDbParameter("MySecondCol", OleDbType.VarWChar, 50, "MySecondCol"));


                oledbDataAdapter1.InsertCommand = insertCommand;

                oledbDataAdapter1.InsertCommand.CommandText =
                    "INSERT INTO " + tableName + " (MyCol, MySecondCol) " +
                        "VALUES     ('" + "PAKFJ" + "','" + "ROREKJR" +
                        "');";



                oledbConnection1.Open();

                try
                {
                    oledbDataAdapter1.InsertCommand.ExecuteNonQuery();
                    consoleWrite("");
                    consoleWrite("Row inserted into " + txtTable.Text + " using SQL insert method");
                    consoleWrite("oledbDataAdapter1.InsertCommand.CommandText = ");
                    consoleWrite(oledbDataAdapter1.InsertCommand.CommandText);
                }
                catch (Exception exp)
                {
                    consoleWrite("error inserting row:  ");
                    consoleWrite(exp.Message);
                }

                oledbConnection1.Close();

            }
            else
            {
                consoleWrite("SQL not implimented yet, because that would be a lot of work");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (INFOMODE) return;
            string tableName = txtTable.Text;

            string rowC1 = textBox5.Text;
            string rowC2 = textBox6.Text;



            //  This inserts a row of data into a .mdb file!!!

            OleDbConnection oledbConnection1 = new OleDbConnection();
            oledbConnection1.ConnectionString = MyConString;

            OleDbDataAdapter oledbDataAdapter1 = new OleDbDataAdapter();   //  svlQuery, oledbConnection1


            oledbDataAdapter1 = new OleDbDataAdapter();


            // 
            // oleDbInsertCommand1
            // 
            OleDbCommand insertCommand = new OleDbCommand();

            insertCommand.Connection = oledbConnection1;
            insertCommand.Parameters.Add(new OleDbParameter("MyColz", OleDbType.VarWChar, 50, "MyCol"));
            insertCommand.Parameters.Add(new OleDbParameter("MySecondCol", OleDbType.VarWChar, 50, "MySecondCol"));


            oledbDataAdapter1.InsertCommand = insertCommand;

            oledbDataAdapter1.InsertCommand.CommandText =
                "INSERT INTO " + tableName + " (MyCol, MySecondCol)" +
                    "VALUES     ('" + rowC1 + "','" + rowC2 +
                    "')";


            oledbConnection1.Open();
            oledbDataAdapter1.InsertCommand.ExecuteNonQuery();
            oledbConnection1.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (INFOMODE)
                return;
            MasterDataset = new DataSet();
            SetupDataSetCol();
        }

        OleDbConnection myConnection1 = new OleDbConnection();
        DataSet accessData = new DataSet();
        OleDbDataAdapter myDataAdapter1 = new OleDbDataAdapter();





        private void button13_Click(object sender, EventArgs e)
        {
            string tableName = txtTable.Text;
            string pstrDB = txtDbPath.Text;
            myConnection1.ConnectionString = MyConString;
            //String svlQuery = "select * from SampleTable";

            //OleDbDataAdapter myDataAdapter1 = new OleDbDataAdapter(svlQuery, myConnection1);

            myDataAdapter1.SelectCommand.Connection = myConnection1;
            myDataAdapter1.SelectCommand.CommandText = "select * from " + tableName;

            #region commands

            // 
            // oleDbUpdateCommand
            // 
            OleDbCommand updateCommand = new OleDbCommand();

            updateCommand.Connection = myConnection1;
            updateCommand.CommandText = "UPDATE " + tableName + "(MyCol, MySecondCol) VALUES (?, ?)";

            updateCommand.Parameters.Add(new OleDbParameter("MyCol", OleDbType.VarWChar, 50, "MyDsCol"));
            updateCommand.Parameters.Add(new OleDbParameter("MySecondCol", OleDbType.VarWChar, 50, "MySecondDsCol"));

            // 
            // oleDbInsertCommand
            // 
            OleDbCommand insertCommand = new OleDbCommand();

            insertCommand.Connection = myConnection1;
            insertCommand.CommandText = "INSERT INTO " + tableName + "(MyCol, MySecondCol) VALUES (?, ?)";

            //  These refer to the DataSet's specs
            insertCommand.Parameters.Add(new OleDbParameter("MyCol", OleDbType.VarWChar, 50, "MyDsCol"));      // UID, datatype, maxLength, DataSet.ColumnName
            insertCommand.Parameters.Add(new OleDbParameter("MySecondCol", OleDbType.VarWChar, 50, "MySecondDsCol"));


            myDataAdapter1.UpdateCommand = updateCommand;
            myDataAdapter1.InsertCommand = insertCommand;
            #endregion



            try
            {
                myConnection1.Open();
            }
            catch { MessageBox.Show("Database (.mdb) missing! (probably)"); }

            try
            {
                myDataAdapter1.Fill(accessData, "SampleTable");
            }
            catch (Exception)
            {
                MessageBox.Show("This thing is empty! (probably)");
            }



            // BIND

            accessData.Tables[0].Locale = System.Globalization.CultureInfo.InvariantCulture;
            bindingSource1.DataSource = accessData.Tables[0];
            dataGridView1.DataSource = bindingSource1;


            //myConnection1.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string tableName = txtTable.Text;
            //  This UPDATES .mdb file!!!
            //myConnection1.Open();

            myDataAdapter1.Update(accessData, tableName);  //  DataSet, DataSet.TableName

            myConnection1.Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (INFOMODE) return;

            if (myDataset == null)
            {
                consoleWrite("Error:  myDataset == null.  You must have something in the datagrid to proceed");
                return;
            }
            //  This inserts a row of data into a .mdb file!!!
            string pstrDB = txtDbPath.Text;
            string tableName = txtTable.Text;


            OleDbConnection oledbConnection1 = new OleDbConnection();
            oledbConnection1.ConnectionString = MyConString;

            OleDbDataAdapter oledbDataAdapter1 = new OleDbDataAdapter();

            oledbDataAdapter1 = new OleDbDataAdapter();


            //updateCommand.CommandText = "UPDATE SampleTable SET author = ?, EditionNumber = ?, ISBN = ?, Title = ? " +
            //    "WHERE (MyCol = ?) " +
            //    "AND (EditionNumber = ? OR ? IS NULL AND EditionNumber IS NULL) " +
            //    "AND (Title = ? OR ? IS NULL AND Title IS NULL) " +
            //    "AND (author = ? OR ? IS NULL AND author IS NULL)";


            // 
            // oleDbUpdateCommand
            // 
            OleDbCommand updateCommand = new OleDbCommand();
            updateCommand.Connection = oledbConnection1;
            updateCommand.CommandText = "UPDATE " + tableName + " SET MyCol = @MyCol, MySecondCol = @MySecondCol WHERE P_Id = @P_IdOriginal";

            updateCommand.Parameters.Add(new OleDbParameter("@MyCol", OleDbType.VarWChar, 50, "MyCol"));
            updateCommand.Parameters.Add(new OleDbParameter("@MySecondCol", OleDbType.VarWChar, 50, "MySecondCol"));
            updateCommand.Parameters.Add(new OleDbParameter("@P_IdOriginal", OleDbType.Integer, 0, "P_Id"));
            updateCommand.Parameters["@P_IdOriginal"].SourceVersion = DataRowVersion.Original;
            

            // 
            // oleDbInsertCommand
            // 
            OleDbCommand insertCommand = new OleDbCommand();
            insertCommand.Connection = oledbConnection1;
            insertCommand.CommandText = "INSERT INTO " + tableName + "(MyCol, MySecondCol) VALUES (?, ?)";

            //  These refer to the DataSet's specs
            insertCommand.Parameters.Add(new OleDbParameter("MyCol", OleDbType.VarWChar, 50, "MyCol"));      // UID, datatype, maxLength, DataSet.ColumnName
            insertCommand.Parameters.Add(new OleDbParameter("MySecondCol", OleDbType.VarWChar, 50, "MySecondCol"));
            
            //insertCommand.Parameters["MyCol"].Value = "this text is ready to be uploaded with the nonExecute method.";
            //insertCommand.Parameters["MySecondCol"].Value = "here's more text";

            // 
            // oleDbDeleteCommand
            // 
            OleDbCommand deleteCommand = new OleDbCommand();
            deleteCommand.CommandText = "DELETE FROM " + tableName + " " +
                "WHERE (P_Id = ?) "; // +
                //"AND (MyCol = ? OR ? IS NULL AND MyCol IS NULL) " +
                //"AND (MySecondCol = ? OR ? IS NULL AND MySecondCol IS NULL) ";

            deleteCommand.Connection = oledbConnection1;
            deleteCommand.Parameters.Add(new OleDbParameter("Original_P_Id", OleDbType.Numeric, 50, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "P_Id", DataRowVersion.Original, null));
            //deleteCommand.Parameters.Add(new OleDbParameter("Original_MyCol", OleDbType.VarWChar, 50, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "MyCol", DataRowVersion.Original, null));
            // below lines are redundant now
            deleteCommand.Parameters.Add(new OleDbParameter("Original_MyCol", OleDbType.VarWChar, 50, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "MyCol", DataRowVersion.Original, null));
            deleteCommand.Parameters.Add(new OleDbParameter("Original_MySecondCol", OleDbType.VarWChar, 50, ParameterDirection.Input, false, ((Byte)(0)), ((Byte)(0)), "MySecondCol", DataRowVersion.Original, null));


            oledbDataAdapter1.UpdateCommand = updateCommand;
            oledbDataAdapter1.InsertCommand = insertCommand;
            oledbDataAdapter1.DeleteCommand = deleteCommand;


            oledbConnection1.Open();

            oledbDataAdapter1.Update(myDataset, tableName);  //  DataSet, DataSet.TableName

            // theory/ conceptualization:
            //  When a DataSet is made in memory, each row has a secret unique ID.
            //  When you UPDATE the DataSet to the .mdb, the row gets transfered
            //  But if you UPDATE the same row again (eg when you don't add another row to the DataSet), the .mdb can tell that you haven't really added another row!
            //  And so the DataSet can't send the same row twice (according to a secret UID)!


            oledbConnection1.Close();
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            if (INFOMODE) return;
            //  This inserts a row of data into a .mdb file!!!
            string pstrDB = txtDbPath.Text;
            string tableName = txtTable.Text;


            OleDbConnection oledbConnection1 = new OleDbConnection();
            oledbConnection1.ConnectionString = MyConString;

            OleDbDataAdapter oledbDataAdapter1 = new OleDbDataAdapter();

            oledbDataAdapter1 = new OleDbDataAdapter();


            // 
            // oleDbInsertCommand
            // 
            OleDbCommand insertCommand = new OleDbCommand();
            insertCommand.Connection = oledbConnection1;
            insertCommand.CommandText = "INSERT INTO " + tableName + "(" + 
                "MyCol, MySecondCol) " + 
                "VALUES (?, ?)";


            //  These refer to the DataSet's specs
            insertCommand.Parameters.Add(new OleDbParameter("MyCol", OleDbType.VarWChar, 200, "MyCol"));      // UID, datatype, maxLength, DataSet.ColumnName
            insertCommand.Parameters.Add(new OleDbParameter("MySecondCol", OleDbType.VarWChar, 50, "MySecondCol"));

            oledbDataAdapter1.InsertCommand = insertCommand;

            //insertCommand.Parameters["MyCol"].Value = "this text is ready to be uploaded with the nonExecute method.";
            //insertCommand.Parameters["MySecondCol"].Value = "here's more text";


            oledbDataAdapter1.InsertCommand.Parameters["MyCol"].Value = "this text is ready to be uploaded.";// with the nonExecute method.";
            oledbDataAdapter1.InsertCommand.Parameters["MySecondCol"].Value = "here's more text";

            oledbDataAdapter1.InsertCommand.Connection.Open();
            oledbDataAdapter1.InsertCommand.ExecuteNonQuery();
            oledbDataAdapter1.InsertCommand.Connection.Close();
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            if (INFOMODE) return;

            string tableName = txtTable.Text;

            OleDbConnection myCon = new OleDbConnection();
            myCon.ConnectionString = MyConString;
            
            string selCmd = "SELECT * FROM " + tableName;
            OleDbDataAdapter myAdapt = new OleDbDataAdapter(selCmd, myCon);

            MasterDataset.Tables.Clear();

            myCon.Open();
            myAdapt.Fill(MasterDataset, tableName);
            myCon.Close();
            
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            SetDbsExistance();
        }

        private void chkMySql_CheckedChanged(object sender, EventArgs e)
        {
            if (INFOMODE)  // notice I have to do a little more coding for checkboxes, cause I only automated it for buttons
            {
                if (((CheckBox)sender).Checked == true)
                {
                    DoThisForAllButtons(sender, e);  // and for this checkbox

                    INFOMODE = true;
                    ((CheckBox)sender).Checked = false;    // when we change this to false, we'll fire the event and wind up here a second time
                                                          // and neither time would we like to run over SetDbsExistance() there at the bottom...
                }
                else
                    INFOMODE = false;
                return;
            }

            SetDbsExistance();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (INFOMODE)
            {
                INFOMODE = false;

                foreach (KeyValuePair<string, string> ctrl in helperTextDic)
                {
                    Control theControl = FindControl[ctrl.Key];

                    theControl.BackColor = SystemColors.Control;
                }
                this.Cursor = Cursors.Default;

            }
            else
            {
                INFOMODE = true;
                // change mouse icon
                this.Cursor = Cursors.Help;

                // turn all controls blue if they have text associated with them

                // FindControl("TextBox2")
                foreach (KeyValuePair<string, string> ctrl in helperTextDic)
                {
                    Control theControl = FindControl[ctrl.Key];

                    theControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (INFOMODE) return;
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.F1)
            {
                e.Handled = true;
                button17_Click(null, e);
                
            }
            base.OnKeyUp(e);
        }

        private void btnShowTables_Click(object sender, EventArgs e)
        {
            if (INFOMODE) return;


            if (radMysql.Checked)
            {
                MySqlConnection connection = new MySqlConnection(MyConString);
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "select TABLE_SCHEMA AS DbName, TABLE_NAME AS TableName from INFORMATION_SCHEMA.TABLES";

                MySqlDataAdapter myAdapter = new MySqlDataAdapter(command.CommandText, connection);


                connection.Open();

                myDataset = new DataSet();

                myAdapter.Fill(myDataset, txtTable.Text);


                bindingSource1.DataSource = myDataset.Tables[0];
                dataGridView1.DataSource = bindingSource1;

                consoleWrite("Tables reported in main window.");

                connection.Close();


            }


        }

        private void radMysql_CheckedChanged(object sender, EventArgs e)
        {
            if (INFOMODE)  // notice I have to do a little more coding for checkboxes, cause I only automated it for buttons
            {
                if (((RadioButton)sender).Checked == true)
                {
                    DoThisForAllButtons(sender, e);  // and for this checkbox

                    INFOMODE = true;
                    ((RadioButton)sender).Checked = false;    // when we change this to false, we'll fire the event and wind up here a second time
                    // and neither time would we like to run over SetDbsExistance() there at the bottom...
                }
                else
                    INFOMODE = false;
                return;
            }

            // let's reset the table exists flag
            chkTableName.Checked = false;

            if (((RadioButton)sender).Checked == true)
                SetDbsExistance();
        }

        private void radAccess_CheckedChanged(object sender, EventArgs e)
        {
            if (INFOMODE)  // notice I have to do a little more coding for checkboxes, cause I only automated it for buttons
            {
                if (((RadioButton)sender).Checked == true)
                {
                    DoThisForAllButtons(sender, e);  // and for this checkbox

                    INFOMODE = true;
                    ((RadioButton)sender).Checked = false;    // when we change this to false, we'll fire the event and wind up here a second time
                    // and neither time would we like to run over SetDbsExistance() there at the bottom...
                }
                else
                    INFOMODE = false;
                return;
            }

            if (((RadioButton)sender).Checked == true)
            {
                // disable the MySQL stuff

                SetDbsExistance();
            }

        }

       

        private void txtTable_Leave(object sender, EventArgs e)
        {
            // check table exists
            CheckDbsTable();
        }
    }
}
