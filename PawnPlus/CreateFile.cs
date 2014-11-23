﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace PawnPlus
{
    public partial class CreateFile : Form
    {
        private Stream resourceStream = null;

        public CreateFile()
        {
            InitializeComponent();
        }

        private void CreateFile_Load(object sender, EventArgs e)
        {
            this.TypeComboBox.SelectedIndex = 0;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (this.NameText.Text.Length == 0)
            {
                MessageBox.Show("You haven't entered the file name!");

                return;
            }

            if(this.TypeComboBox.SelectedIndex == 0)
            {
                // With this 'try' it will avoid warning generated by Code Analysis.
                try
                {
                    this.resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("PawnPlus.Resources.DefaultGameMode.pwn");

                    using (StreamReader reader = new StreamReader(resourceStream))
                    {
                        this.resourceStream = null;
                        File.WriteAllText(Path.Combine(Path.Combine(Program.main.ProjectInformation["Path"], "gamemodes"), this.NameText.Text + ".pwn"), reader.ReadToEnd());
                    }

                    Program.projectexplorer.LoadDirectory(Program.projectexplorer.FileTree, Program.main.ProjectInformation["Path"]);
                    Program.main.OpenFile(Path.Combine(Path.Combine(Program.main.ProjectInformation["Path"], "gamemodes"), this.NameText.Text + ".pwn"));
                }
                finally
                {
                    if (this.resourceStream != null)
                        this.resourceStream.Dispose();
                }
            }
            else if (this.TypeComboBox.SelectedIndex == 1)
            {
                // With this 'try' it will avoid warning generated by Code Analysis.
                try
                {
                    this.resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("PawnPlus.Resources.DefaultFilterscript.pwn");

                    using (StreamReader reader = new StreamReader(resourceStream))
                    {
                        this.resourceStream = null;
                        File.WriteAllText(Path.Combine(Path.Combine(Program.main.ProjectInformation["Path"], "filterscripts"), this.NameText.Text + ".pwn"), reader.ReadToEnd());
                    }

                    Program.projectexplorer.LoadDirectory(Program.projectexplorer.FileTree, Program.main.ProjectInformation["Path"]);
                    Program.main.OpenFile(Path.Combine(Path.Combine(Program.main.ProjectInformation["Path"], "filterscripts"), this.NameText.Text + ".pwn"));
                }
                finally
                {
                    if (this.resourceStream != null)
                        this.resourceStream.Dispose();
                }
            }
            else if (this.TypeComboBox.SelectedIndex == 2)
            {
                File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Pawn", "include", this.NameText.Text + ".inc"), String.Empty);

                Program.main.OpenFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Pawn", "include", this.NameText.Text + ".inc"));
            }

            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
