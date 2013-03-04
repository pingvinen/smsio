using System;
using System.Windows.Forms;

namespace SmsIO
{
	partial class MainForm : Form
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

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			int margin = 20;
			int columnWidth = 100;

			int columnTwoX = 2*margin + columnWidth;
			System.Drawing.Size buttonSize = new System.Drawing.Size(columnWidth, 23);
			System.Drawing.Font labelFont = new System.Drawing.Font(System.Drawing.SystemFonts.DefaultFont.SystemFontName, 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);

			this.labelData = new System.Windows.Forms.Label();
			this.labelOutput = new System.Windows.Forms.Label();
			this.buttonLoadFile = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			this.buttonClearDb = new System.Windows.Forms.Button();
			this.buttonOpenDbFolder = new System.Windows.Forms.Button();
			this.buttonOutputAsRtf = new System.Windows.Forms.Button();

			this.SuspendLayout();

			#region Column 1
			// 
			// labelData
			// 
			this.labelData.Name = "labelData";
			this.labelData.Location = new System.Drawing.Point(margin, margin);
			this.labelData.Size = new System.Drawing.Size(46, 19);
			this.labelData.Font = labelFont;
			this.labelData.BackColor = System.Drawing.Color.Transparent;
			this.labelData.Text = "Data";
			this.labelData.AutoSize = true;

			// 
			// buttonLoadFile
			// 
			this.buttonLoadFile.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonLoadFile.Location = new System.Drawing.Point(margin, this.labelData.Location.Y + this.labelData.Height + margin);
			this.buttonLoadFile.Name = "buttonLoadFile";
			this.buttonLoadFile.Size = buttonSize;
			this.buttonLoadFile.TabIndex = 1;
			this.buttonLoadFile.Text = "Read backup";
			this.buttonLoadFile.UseVisualStyleBackColor = true;
			this.buttonLoadFile.Click += new System.EventHandler(this.buttonLoadFile_Click);

			// 
			// buttonOpenDbFolder
			// 
			this.buttonOpenDbFolder.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonOpenDbFolder.Location = new System.Drawing.Point(margin, this.buttonLoadFile.Location.Y + this.buttonLoadFile.Height + margin);
			this.buttonOpenDbFolder.Name = "buttonOpenDbFolder";
			this.buttonOpenDbFolder.Size = buttonSize;
			this.buttonOpenDbFolder.TabIndex = 1;
			this.buttonOpenDbFolder.Text = "Open DB folder";
			this.buttonOpenDbFolder.UseVisualStyleBackColor = true;
			this.buttonOpenDbFolder.Click += new System.EventHandler(this.buttonOpenDbFolder_Click);

			// 
			// buttonClearDb
			// 
			this.buttonClearDb.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonClearDb.Location = new System.Drawing.Point(margin, this.buttonOpenDbFolder.Location.Y + this.buttonOpenDbFolder.Height + margin);
			this.buttonClearDb.Name = "buttonClearDb";
			this.buttonClearDb.Size = buttonSize;
			this.buttonClearDb.TabIndex = 1;
			this.buttonClearDb.Text = "Clear DB";
			this.buttonClearDb.UseVisualStyleBackColor = true;
			this.buttonClearDb.Click += new EventHandler(buttonClearDb_Click);
			#endregion Column 1

			#region Column 2
			// 
			// labelOutput
			// 
			this.labelOutput.Name = "labelOutput";
			this.labelOutput.Location = new System.Drawing.Point(columnTwoX, margin	);
			this.labelOutput.Size = new System.Drawing.Size(46, 19);
			this.labelOutput.Font = labelFont;
			this.labelOutput.BackColor = System.Drawing.Color.Transparent;
			this.labelOutput.Text = "Output";
			this.labelOutput.AutoSize = true;

			// 
			// buttonOutputAsRtf
			// 
			this.buttonOutputAsRtf.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonOutputAsRtf.Location = new System.Drawing.Point(columnTwoX, this.labelOutput.Location.Y + this.labelOutput.Height + margin);
			this.buttonOutputAsRtf.Name = "buttonOutputAsRtf";
			this.buttonOutputAsRtf.Size = buttonSize;
			this.buttonOutputAsRtf.TabIndex = 1;
			this.buttonOutputAsRtf.Text = "..as RTF";
			this.buttonOutputAsRtf.UseVisualStyleBackColor = true;
			this.buttonOutputAsRtf.Click += new EventHandler(buttonOutputAsRtf_Click);

			// 
			// buttonClose
			// 
			this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonClose.Location = new System.Drawing.Point(columnTwoX, this.buttonOutputAsRtf.Location.Y + this.buttonOutputAsRtf.Height + margin);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = buttonSize;
			this.buttonClose.TabIndex = 2;
			this.buttonClose.Text = "Close";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			#endregion Column 2

			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonClose;
			this.ClientSize = new System.Drawing.Size(
					3*margin + 2*columnWidth,
					5*margin + this.labelData.Height + 3*buttonSize.Height
				);
			this.Controls.Add(this.labelData);
			this.Controls.Add(this.labelOutput);
			this.Controls.Add(this.buttonLoadFile);
			this.Controls.Add(this.buttonClearDb);
			this.Controls.Add(this.buttonOpenDbFolder);
			this.Controls.Add(this.buttonOutputAsRtf);
			this.Controls.Add(this.buttonClose);
			this.Name = "MainForm";
			this.Text = "SmsIO";
			this.StartPosition = FormStartPosition.CenterScreen;

			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private System.Windows.Forms.Label labelData;
		private System.Windows.Forms.Label labelOutput;
		private System.Windows.Forms.Button buttonLoadFile;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Button buttonClearDb;
		private System.Windows.Forms.Button buttonOpenDbFolder;
		private System.Windows.Forms.Button buttonOutputAsRtf;
	}
}