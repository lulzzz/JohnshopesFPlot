using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Windows.Forms;
using SourceGrid2;
using JohnsHope.FPlot.Library;


namespace JohnsHope.FPlot {

	//BUG deleting formula throws exception in DataForm

	/// <summary>
	/// Summary description for DataForm.
	/// </summary>
	public class DataForm: System.Windows.Forms.Form, IResetable, IEditForm {
		private System.Windows.Forms.ColorDialog colorDialog;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		DataItem item, temp;
		MainModel Model;
		static int index;
		bool newitem = false;
		LoadDataForm loadForm;
		private System.Windows.Forms.Button help;
		private DataGrid grid;
		private NumericUpDown Dimensions;
		private Label dimLabel;
		private CheckBox Errors;
		private ToolStrip toolStrip1;
		private ToolStripButton toolStripButton1;
		private ToolStripButton toolStripButton2;
		private ToolStripButton toolStripButton3;
		private ToolStripButton toolStripButton4;
		private ToolStripButton toolStripButton5;
		private ToolStripLabel toolStripLabel1;
		private ToolStripTextBox name;
		private Pen pen = new Pen(Color.Black, 2);

		public DataForm(MainModel Model, DataItem item)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.Model = Model;
			if (item == null) {
				newitem = true;
				item = new DataItem();
				item.Name = "Data " + index++;
				item.Dimensions = 2;
				Model.Items.Add(item);
			} else if (!Model.Items.Contains(item)) Model.Items.Add(item);
			this.item = item;
			temp = new DataItem();
			loadForm = NewLoadForm();

			Reset();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataForm));
			this.colorDialog = new System.Windows.Forms.ColorDialog();
			this.help = new System.Windows.Forms.Button();
			this.grid = new JohnsHope.FPlot.DataGrid();
			this.Dimensions = new System.Windows.Forms.NumericUpDown();
			this.dimLabel = new System.Windows.Forms.Label();
			this.Errors = new System.Windows.Forms.CheckBox();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.name = new System.Windows.Forms.ToolStripTextBox();
			((System.ComponentModel.ISupportInitialize)(this.Dimensions)).BeginInit();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// help
			// 
			this.help.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.help.Location = new System.Drawing.Point(580, 384);
			this.help.Margin = new System.Windows.Forms.Padding(2);
			this.help.Name = "help";
			this.help.Size = new System.Drawing.Size(68, 22);
			this.help.TabIndex = 42;
			this.help.Text = "Help...";
			this.help.Click += new System.EventHandler(this.helpClick);
			// 
			// grid
			// 
			this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grid.AutoSizeMinHeight = 10;
			this.grid.AutoSizeMinWidth = 10;
			this.grid.AutoStretchColumnsToFitWidth = false;
			this.grid.AutoStretchRowsToFitHeight = false;
			this.grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.grid.ContextMenuStyle = SourceGrid2.ContextMenuStyle.None;
			this.grid.GridToolTipActive = true;
			this.grid.Location = new System.Drawing.Point(0, 51);
			this.grid.Margin = new System.Windows.Forms.Padding(2);
			this.grid.Name = "grid";
			this.grid.Size = new System.Drawing.Size(347, 356);
			this.grid.SpecialKeys = ((SourceGrid2.GridSpecialKeys)(((((((((((SourceGrid2.GridSpecialKeys.Ctrl_C | SourceGrid2.GridSpecialKeys.Ctrl_V) 
            | SourceGrid2.GridSpecialKeys.Ctrl_X) 
            | SourceGrid2.GridSpecialKeys.Delete) 
            | SourceGrid2.GridSpecialKeys.Arrows) 
            | SourceGrid2.GridSpecialKeys.Tab) 
            | SourceGrid2.GridSpecialKeys.PageDownUp) 
            | SourceGrid2.GridSpecialKeys.Enter) 
            | SourceGrid2.GridSpecialKeys.Escape) 
            | SourceGrid2.GridSpecialKeys.Control) 
            | SourceGrid2.GridSpecialKeys.Shift)));
			this.grid.TabIndex = 43;
			// 
			// Dimensions
			// 
			this.Dimensions.Location = new System.Drawing.Point(76, 27);
			this.Dimensions.Margin = new System.Windows.Forms.Padding(2);
			this.Dimensions.Name = "Dimensions";
			this.Dimensions.Size = new System.Drawing.Size(34, 20);
			this.Dimensions.TabIndex = 45;
			this.Dimensions.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.Dimensions.ValueChanged += new System.EventHandler(this.ValueChanged);
			// 
			// dimLabel
			// 
			this.dimLabel.AutoSize = true;
			this.dimLabel.Location = new System.Drawing.Point(8, 31);
			this.dimLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.dimLabel.Name = "dimLabel";
			this.dimLabel.Size = new System.Drawing.Size(64, 13);
			this.dimLabel.TabIndex = 46;
			this.dimLabel.Text = "Dimensions:";
			// 
			// Errors
			// 
			this.Errors.AutoSize = true;
			this.Errors.Location = new System.Drawing.Point(128, 30);
			this.Errors.Margin = new System.Windows.Forms.Padding(2);
			this.Errors.Name = "Errors";
			this.Errors.Size = new System.Drawing.Size(53, 17);
			this.Errors.TabIndex = 47;
			this.Errors.Text = "Errors";
			this.Errors.UseVisualStyleBackColor = true;
			this.Errors.CheckedChanged += new System.EventHandler(this.ErrChanged);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripLabel1,
            this.name});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(347, 25);
			this.toolStrip1.TabIndex = 49;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = global::JohnsHope.FPlot.Properties.Resources.ok;
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton1.Text = "toolStripButton1";
			this.toolStripButton1.ToolTipText = "Apply Changes & Exit";
			this.toolStripButton1.Click += new System.EventHandler(this.okClick);
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton2.Image = global::JohnsHope.FPlot.Properties.Resources.delete;
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton2.Text = "Exit Window";
			this.toolStripButton2.Click += new System.EventHandler(this.cancelClick);
			// 
			// toolStripButton3
			// 
			this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton3.Image = global::JohnsHope.FPlot.Properties.Resources.Icons_MenuFileSaveIcon;
			this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton3.Name = "toolStripButton3";
			this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton3.Text = "Apply Changes";
			this.toolStripButton3.Click += new System.EventHandler(this.applyClick);
			// 
			// toolStripButton4
			// 
			this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
			this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton4.Name = "toolStripButton4";
			this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton4.Text = "Edit Style";
			this.toolStripButton4.ToolTipText = "Line Style for Painting";
			this.toolStripButton4.Click += new System.EventHandler(this.StyleClick);
			// 
			// toolStripButton5
			// 
			this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton5.Image = global::JohnsHope.FPlot.Properties.Resources.Icons_MenuFileOpenIcon;
			this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton5.Name = "toolStripButton5";
			this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton5.Text = "Load Data From File...";
			this.toolStripButton5.Click += new System.EventHandler(this.loadClick);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(42, 22);
			this.toolStripLabel1.Text = "Name:";
			// 
			// name
			// 
			this.name.Name = "name";
			this.name.Size = new System.Drawing.Size(169, 23);
			// 
			// DataForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(347, 406);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.Errors);
			this.Controls.Add(this.dimLabel);
			this.Controls.Add(this.Dimensions);
			this.Controls.Add(this.grid);
			this.Controls.Add(this.help);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MaximumSize = new System.Drawing.Size(1804, 1882);
			this.MinimumSize = new System.Drawing.Size(349, 337);
			this.Name = "DataForm";
			this.Text = "Edit data ";
			((System.ComponentModel.ISupportInitialize)(this.Dimensions)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
		
		public void Reset() {
			name.Text = item.Name;
			this.Text = item.Name;
			grid.data = item;
			Dimensions.Value = item.Dimensions;
			Errors.Checked = item.ErrorColumns;
			item.x.deepCopy = item.y.deepCopy = item.z.deepCopy = item.dx.deepCopy = item.dy.deepCopy = item.dz.deepCopy = true;
			grid.LoadDataSource(item);
		}

		public void Apply() {
			item.Name = name.Text;
			item.Dimensions = (int)Dimensions.Value;
			item.ErrorColumns = Errors.Checked;
			item.Compile();
			Reset();
			Model.Items.Update(item);
		}

		private void okClick(object sender, System.EventArgs e) {
			Apply();
			this.Hide();
		}

		private void applyClick(object sender, System.EventArgs e) {
			Apply();
		}

		private void cancelClick(object sender, System.EventArgs e) {
			if (newitem) {
				Model.Items.Remove(item);
			}
			this.Hide();
		}

		private LoadDataForm NewLoadForm() {
			LoadDataForm f = new LoadDataForm(Model, this, item);
			if (item.Source == null) f.SetSource();
			return f;
		}

		private void loadClick(object sender, System.EventArgs e) {
			Apply();
			if (loadForm.IsDisposed) loadForm = NewLoadForm();
			loadForm.Reset();
			if (loadForm.WindowState == FormWindowState.Minimized) loadForm.WindowState = FormWindowState.Normal;
			loadForm.Show();
			loadForm.BringToFront();
		}

		private void helpClick(object sender, System.EventArgs e) {
			Help.ShowHelp(this, Properties.Resources.HelpFile, "DataForm.html");
		}

		private void ValueChanged(object sender, EventArgs e) {
			if (Dimensions.Value < 1) Dimensions.Value = 1;
			else if (Dimensions.Value > 3) Dimensions.Value = 3;
			int d1 = (int)Dimensions.Value, d0 = item.Dimensions;
			item.Dimensions = d1;
			if (d1 > d0) {
				if (d1 >= 3 && d0 <= 2) {
					item.z.Source = item.dz.Source = null;
				} 
				if (d1 >= 2 && d0 <= 1) {
					item.y.Source = item.dy.Source = null;
				}
			}
			grid.SetDim();
		}

		private void ErrChanged(object sender, EventArgs e) {
			item.ErrorColumns = Errors.Checked;
			grid.SetDim();
		}

		private void NameChanged(object sender, EventArgs e) {
			this.Text = name.Text;
		}

		public void Edit(SourceLocation loc) {
			if (loadForm.IsDisposed) loadForm = NewLoadForm();
			loadForm.Edit(loc);
			if (loadForm.WindowState == FormWindowState.Minimized) loadForm.WindowState = FormWindowState.Normal;
			loadForm.Show();
			loadForm.BringToFront();
		}

		private void StyleClick(object sender, EventArgs e) {
			DataLineStyleForm.New(Model, item);
		}

	}

}

