namespace Test
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.CmdFacturar = new System.Windows.Forms.Button();
            this.Txtdate = new System.Windows.Forms.TextBox();
            this.TxtClases = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(130, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CmdFacturar
            // 
            this.CmdFacturar.Location = new System.Drawing.Point(330, 43);
            this.CmdFacturar.Name = "CmdFacturar";
            this.CmdFacturar.Size = new System.Drawing.Size(124, 23);
            this.CmdFacturar.TabIndex = 1;
            this.CmdFacturar.Text = "Facturar";
            this.CmdFacturar.UseVisualStyleBackColor = true;
            this.CmdFacturar.Click += new System.EventHandler(this.button2_Click);
            // 
            // Txtdate
            // 
            this.Txtdate.Location = new System.Drawing.Point(505, 45);
            this.Txtdate.Name = "Txtdate";
            this.Txtdate.Size = new System.Drawing.Size(149, 20);
            this.Txtdate.TabIndex = 2;
            this.Txtdate.Text = "2014/01/27";
            // 
            // TxtClases
            // 
            this.TxtClases.Location = new System.Drawing.Point(505, 71);
            this.TxtClases.Name = "TxtClases";
            this.TxtClases.Size = new System.Drawing.Size(146, 20);
            this.TxtClases.TabIndex = 4;
            this.TxtClases.Text = "A";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(79, 99);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 137);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.TxtClases);
            this.Controls.Add(this.Txtdate);
            this.Controls.Add(this.CmdFacturar);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Test Facturar";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button CmdFacturar;
        private System.Windows.Forms.TextBox Txtdate;
        private System.Windows.Forms.TextBox TxtClases;
        private System.Windows.Forms.Button button2;
    }
}

