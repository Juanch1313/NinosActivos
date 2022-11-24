namespace NinosActivos
{
    partial class Mensaje
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mensaje));
            this.LMensaje = new System.Windows.Forms.Label();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LMensaje
            // 
            this.LMensaje.AutoSize = true;
            this.LMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LMensaje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(183)))), ((int)(((byte)(5)))));
            this.LMensaje.Location = new System.Drawing.Point(21, 26);
            this.LMensaje.Name = "LMensaje";
            this.LMensaje.Size = new System.Drawing.Size(275, 24);
            this.LMensaje.TabIndex = 0;
            this.LMensaje.Text = "Aqui se mostrara el mensaje";
            this.LMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(180)))));
            this.BtnAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(42)))), ((int)(((byte)(108)))));
            this.BtnAceptar.Location = new System.Drawing.Point(186, 186);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(107, 52);
            this.BtnAceptar.TabIndex = 1;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = false;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // Mensaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(26)))), ((int)(((byte)(115)))));
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.LMensaje);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Mensaje";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ERROR";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LMensaje;
        private System.Windows.Forms.Button BtnAceptar;
    }
}