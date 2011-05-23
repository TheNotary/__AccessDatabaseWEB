using System;
using System.Windows.Forms;
namespace __AccessDatabase
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.chkDbsExists = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnReadDatabase = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.chkShowAdvice = new System.Windows.Forms.CheckBox();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.chkTableName = new System.Windows.Forms.CheckBox();
            this.button12 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.txtDbPath = new System.Windows.Forms.TextBox();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTable = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDb = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.btnInfo = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.radAccess = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.Button();
            this.radMysql = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(223, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "Create Blank Database";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkDbsExists
            // 
            this.chkDbsExists.AutoSize = true;
            this.chkDbsExists.Enabled = false;
            this.chkDbsExists.Location = new System.Drawing.Point(817, 102);
            this.chkDbsExists.Name = "chkDbsExists";
            this.chkDbsExists.Size = new System.Drawing.Size(125, 17);
            this.chkDbsExists.TabIndex = 1;
            this.chkDbsExists.Text = "Database Not Found";
            this.chkDbsExists.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(326, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 37);
            this.button2.TabIndex = 2;
            this.button2.Text = "Delete The Database";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnReadDatabase
            // 
            this.btnReadDatabase.Location = new System.Drawing.Point(817, 269);
            this.btnReadDatabase.Name = "btnReadDatabase";
            this.btnReadDatabase.Size = new System.Drawing.Size(102, 46);
            this.btnReadDatabase.TabIndex = 3;
            this.btnReadDatabase.Text = "Read The Database";
            this.btnReadDatabase.UseVisualStyleBackColor = true;
            this.btnReadDatabase.Click += new System.EventHandler(this.btnReadDatabase_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(271, 170);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(400, 201);
            this.dataGridView1.TabIndex = 5;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(229, 67);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(102, 48);
            this.button4.TabIndex = 6;
            this.button4.Text = "Fill DataSet With this data";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(358, 502);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(102, 50);
            this.button5.TabIndex = 7;
            this.button5.Text = "Send DataSet to .mdb";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(3, 4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(144, 51);
            this.button6.TabIndex = 8;
            this.button6.Text = "Bind this GridView to MasterDataset";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.btnBindDatasetToGrid_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(271, 154);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(226, 20);
            this.textBox2.TabIndex = 9;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(3, 63);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(108, 46);
            this.button7.TabIndex = 10;
            this.button7.Text = "Show Variable";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(817, 159);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(102, 47);
            this.button8.TabIndex = 11;
            this.button8.Text = "Create A Table in the .mdb";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(223, 41);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(97, 22);
            this.button9.TabIndex = 12;
            this.button9.Text = "make version 2";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "DataSet Columns";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(98, -3);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 14;
            this.textBox3.Text = "myDsCol";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(231, -3);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 15;
            this.textBox4.Text = "mySecondDsCol";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "DataSet Rows";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(98, 26);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 17;
            this.textBox5.Text = "put";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(231, 29);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 18;
            this.textBox6.Text = "more";
            // 
            // chkShowAdvice
            // 
            this.chkShowAdvice.AutoSize = true;
            this.chkShowAdvice.Location = new System.Drawing.Point(41, 22);
            this.chkShowAdvice.Name = "chkShowAdvice";
            this.chkShowAdvice.Size = new System.Drawing.Size(135, 17);
            this.chkShowAdvice.TabIndex = 19;
            this.chkShowAdvice.Text = "Show Advice MsgBoxs";
            this.chkShowAdvice.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(817, 212);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(102, 40);
            this.button10.TabIndex = 20;
            this.button10.Text = "Write Jibberish Row to .mdb";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(358, 456);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(109, 35);
            this.button11.TabIndex = 21;
            this.button11.Text = "Add row to .mdb";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // chkTableName
            // 
            this.chkTableName.AutoSize = true;
            this.chkTableName.Enabled = false;
            this.chkTableName.Location = new System.Drawing.Point(817, 122);
            this.chkTableName.Name = "chkTableName";
            this.chkTableName.Size = new System.Drawing.Size(102, 17);
            this.chkTableName.TabIndex = 22;
            this.chkTableName.Text = "Table: %s Exists";
            this.chkTableName.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(153, 4);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(89, 31);
            this.button12.TabIndex = 23;
            this.button12.Text = "Clear Dataset";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(548, 377);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(123, 52);
            this.button16.TabIndex = 25;
            this.button16.Text = "Delete/change a modified entry from the .mdb";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(584, 139);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(87, 35);
            this.button13.TabIndex = 26;
            this.button13.Text = "Parameterized Insert";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click_1);
            // 
            // txtDbPath
            // 
            this.txtDbPath.Location = new System.Drawing.Point(90, 28);
            this.txtDbPath.Name = "txtDbPath";
            this.txtDbPath.Size = new System.Drawing.Size(87, 20);
            this.txtDbPath.TabIndex = 27;
            this.txtDbPath.Text = "c:\\test2.mdb";
            this.txtDbPath.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(3, 145);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(108, 46);
            this.button14.TabIndex = 28;
            this.button14.Text = "Load MDB into MasterDataset";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click_1);
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(3, 197);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(108, 46);
            this.button15.TabIndex = 29;
            this.button15.Text = "Param Update";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(112, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Start Here =)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label4.Location = new System.Drawing.Point(6, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Database Path:";
            // 
            // txtTable
            // 
            this.txtTable.Location = new System.Drawing.Point(740, 201);
            this.txtTable.Name = "txtTable";
            this.txtTable.Size = new System.Drawing.Size(71, 20);
            this.txtTable.TabIndex = 32;
            this.txtTable.Text = "SampleTable";
            this.txtTable.Leave += new System.EventHandler(this.txtTable_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label5.Location = new System.Drawing.Point(683, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Tbl Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "DatabaseWEB:  Version 0.2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label7.Location = new System.Drawing.Point(316, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "MySQL server:";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(400, 26);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(170, 20);
            this.txtServer.TabIndex = 35;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.Black;
            this.listBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(677, 320);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(408, 212);
            this.listBox1.TabIndex = 38;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label8.Location = new System.Drawing.Point(316, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 40;
            this.label8.Text = "MySQL user:";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(400, 46);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(95, 20);
            this.txtUser.TabIndex = 39;
            this.txtUser.Text = "movestra_notary";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label9.Location = new System.Drawing.Point(316, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "MySQL pass:";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(400, 64);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(95, 20);
            this.txtPass.TabIndex = 41;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label10.Location = new System.Drawing.Point(302, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 13);
            this.label10.TabIndex = 44;
            this.label10.Text = "MySQL database:";
            // 
            // txtDb
            // 
            this.txtDb.Location = new System.Drawing.Point(400, 83);
            this.txtDb.Name = "txtDb";
            this.txtDb.Size = new System.Drawing.Size(95, 20);
            this.txtDb.TabIndex = 43;
            this.txtDb.Text = "movestra_dev";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.button12);
            this.panel1.Controls.Add(this.button14);
            this.panel1.Controls.Add(this.button15);
            this.panel1.Location = new System.Drawing.Point(12, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(253, 280);
            this.panel1.TabIndex = 45;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(104, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 46;
            this.label11.Text = "DataSet stuff";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(this.textBox4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBox5);
            this.panel2.Controls.Add(this.textBox6);
            this.panel2.Location = new System.Drawing.Point(2, 429);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(350, 127);
            this.panel2.TabIndex = 47;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(217, 411);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 13);
            this.label12.TabIndex = 48;
            this.label12.Text = "DataSet stuff";
            // 
            // btnInfo
            // 
            this.btnInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnInfo.Location = new System.Drawing.Point(12, 37);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(86, 40);
            this.btnInfo.TabIndex = 30;
            this.btnInfo.Text = "MORE INFO? (F1 to toggle)";
            this.btnInfo.UseVisualStyleBackColor = false;
            this.btnInfo.Click += new System.EventHandler(this.button17_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.button9);
            this.panel3.Controls.Add(this.txtDbPath);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(585, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(438, 74);
            this.panel3.TabIndex = 49;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(781, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(114, 13);
            this.label13.TabIndex = 50;
            this.label13.Text = "Access Database stuff";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(180, 65);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(53, 17);
            this.checkBox2.TabIndex = 51;
            this.checkBox2.Text = "Show";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // radAccess
            // 
            this.radAccess.AutoSize = true;
            this.radAccess.Checked = true;
            this.radAccess.Location = new System.Drawing.Point(612, 5);
            this.radAccess.Name = "radAccess";
            this.radAccess.Size = new System.Drawing.Size(139, 17);
            this.radAccess.TabIndex = 52;
            this.radAccess.TabStop = true;
            this.radAccess.Text = "Access Database Mode";
            this.radAccess.UseVisualStyleBackColor = true;
            this.radAccess.CheckedChanged += new System.EventHandler(this.radAccess_CheckedChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(724, 159);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 23);
            this.button3.TabIndex = 53;
            this.button3.Text = "show tables;";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnShowTables_Click);
            // 
            // radMysql
            // 
            this.radMysql.AutoSize = true;
            this.radMysql.Location = new System.Drawing.Point(381, 6);
            this.radMysql.Name = "radMysql";
            this.radMysql.Size = new System.Drawing.Size(133, 17);
            this.radMysql.TabIndex = 54;
            this.radMysql.TabStop = true;
            this.radMysql.Text = "MySql Database Mode";
            this.radMysql.UseVisualStyleBackColor = true;
            this.radMysql.CheckedChanged += new System.EventHandler(this.radMysql_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 559);
            this.Controls.Add(this.radMysql);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.chkDbsExists);
            this.Controls.Add(this.radAccess);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDb);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTable);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.chkTableName);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.chkShowAdvice);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnReadDatabase);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkDbsExists;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnReadDatabase;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.CheckBox chkShowAdvice;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.CheckBox chkTableName;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.TextBox txtDbPath;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTable;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDb;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnInfo;
        private Panel panel3;
        private Label label13;
        private CheckBox checkBox2;
        private RadioButton radAccess;
        private Button button3;
        private RadioButton radMysql;
    }
}

