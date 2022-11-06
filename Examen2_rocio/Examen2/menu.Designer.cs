namespace Examen2
{
    partial class menu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tiposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresarLosTiposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tikectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ingresarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tiposToolStripMenuItem,
            this.tikectsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(343, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tiposToolStripMenuItem
            // 
            this.tiposToolStripMenuItem.BackColor = System.Drawing.Color.BurlyWood;
            this.tiposToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ingresarLosTiposToolStripMenuItem});
            this.tiposToolStripMenuItem.Name = "tiposToolStripMenuItem";
            this.tiposToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.tiposToolStripMenuItem.Text = "Tipos";
            // 
            // ingresarLosTiposToolStripMenuItem
            // 
            this.ingresarLosTiposToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ingresarLosTiposToolStripMenuItem.Name = "ingresarLosTiposToolStripMenuItem";
            this.ingresarLosTiposToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.ingresarLosTiposToolStripMenuItem.Text = "Ingresar los tipos";
            this.ingresarLosTiposToolStripMenuItem.Click += new System.EventHandler(this.ingresarLosTiposToolStripMenuItem_Click);
            // 
            // tikectsToolStripMenuItem
            // 
            this.tikectsToolStripMenuItem.BackColor = System.Drawing.Color.BurlyWood;
            this.tikectsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ingresarToolStripMenuItem});
            this.tikectsToolStripMenuItem.Name = "tikectsToolStripMenuItem";
            this.tikectsToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.tikectsToolStripMenuItem.Text = "Tikects";
            // 
            // ingresarToolStripMenuItem
            // 
            this.ingresarToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ingresarToolStripMenuItem.Name = "ingresarToolStripMenuItem";
            this.ingresarToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.ingresarToolStripMenuItem.Text = "Ingresar";
            this.ingresarToolStripMenuItem.Click += new System.EventHandler(this.ingresarToolStripMenuItem_Click);
            // 
            // menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(343, 129);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tiposToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingresarLosTiposToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tikectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ingresarToolStripMenuItem;
    }
}