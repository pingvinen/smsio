using System;
using System.Windows.Forms;

namespace transformer
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

			this.buttonSelectFile = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();

			this.SuspendLayout();


			// 
			// buttonSelectFile
			// 
			this.buttonSelectFile.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonSelectFile.Location = new System.Drawing.Point(margin, margin);
			this.buttonSelectFile.Name = "buttonSelectFile";
			this.buttonSelectFile.Size = new System.Drawing.Size(75, 23);
			this.buttonSelectFile.TabIndex = 1;
			this.buttonSelectFile.Text = "Select file";
			this.buttonSelectFile.UseVisualStyleBackColor = true;
			this.buttonSelectFile.Click += new System.EventHandler(this.buttonSelectFile_Click);


			// 
			// buttonClose
			// 
			this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonClose.Location = new System.Drawing.Point(
				this.buttonSelectFile.Width + this.buttonSelectFile.Location.X + margin,
				this.buttonSelectFile.Location.Y);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 23);
			this.buttonClose.TabIndex = 2;
			this.buttonClose.Text = "Close";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);


			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonClose;
			this.ClientSize = new System.Drawing.Size(
					this.buttonSelectFile.Width + this.buttonClose.Width + 3*margin,
					this.buttonSelectFile.Height + 2*margin
				);
			this.Controls.Add(this.buttonSelectFile);
			this.Controls.Add(this.buttonClose);
			this.Name = "Form1";
			this.Text = "SMS backup xml to rtf";
			this.StartPosition = FormStartPosition.CenterScreen;

			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Button buttonSelectFile;
	}
}