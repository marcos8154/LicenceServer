namespace Doware_LicenceServer
{
    partial class Configure
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btConfigurar = new System.Windows.Forms.Button();
            this.txId_instalacao = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txId_contrato = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txId_cliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Configurar servidor de licenças";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(-1, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(558, 1);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btConfigurar);
            this.panel2.Controls.Add(this.txId_instalacao);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txId_contrato);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txId_cliente);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(1, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(426, 246);
            this.panel2.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Teal;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(234, 205);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 28);
            this.button1.TabIndex = 7;
            this.button1.Text = "Sair";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btConfigurar
            // 
            this.btConfigurar.BackColor = System.Drawing.Color.Teal;
            this.btConfigurar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btConfigurar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btConfigurar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btConfigurar.ForeColor = System.Drawing.Color.White;
            this.btConfigurar.Location = new System.Drawing.Point(313, 205);
            this.btConfigurar.Name = "btConfigurar";
            this.btConfigurar.Size = new System.Drawing.Size(102, 28);
            this.btConfigurar.TabIndex = 6;
            this.btConfigurar.Text = "Configurar";
            this.btConfigurar.UseVisualStyleBackColor = false;
            this.btConfigurar.Click += new System.EventHandler(this.btConfigurar_Click);
            // 
            // txId_instalacao
            // 
            this.txId_instalacao.BackColor = System.Drawing.Color.White;
            this.txId_instalacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.txId_instalacao.Location = new System.Drawing.Point(124, 99);
            this.txId_instalacao.Name = "txId_instalacao";
            this.txId_instalacao.ReadOnly = true;
            this.txId_instalacao.Size = new System.Drawing.Size(291, 23);
            this.txId_instalacao.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(11, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "ID da instalação";
            // 
            // txId_contrato
            // 
            this.txId_contrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.txId_contrato.Location = new System.Drawing.Point(124, 70);
            this.txId_contrato.Name = "txId_contrato";
            this.txId_contrato.Size = new System.Drawing.Size(291, 23);
            this.txId_contrato.TabIndex = 3;
            this.txId_contrato.Leave += new System.EventHandler(this.txId_contrato_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(11, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "ID do contrato";
            // 
            // txId_cliente
            // 
            this.txId_cliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.txId_cliente.Location = new System.Drawing.Point(124, 41);
            this.txId_cliente.Name = "txId_cliente";
            this.txId_cliente.Size = new System.Drawing.Size(291, 23);
            this.txId_cliente.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(11, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "ID do cliente";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Doware_LicenceServer.Properties.Resources.doware;
            this.pictureBox1.Location = new System.Drawing.Point(321, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 39);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Configure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(428, 291);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(444, 330);
            this.MinimumSize = new System.Drawing.Size(444, 250);
            this.Name = "Configure";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Doware Licence Server - Versão ";
            this.Load += new System.EventHandler(this.Configure_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txId_contrato;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txId_cliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txId_instalacao;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btConfigurar;
        private System.Windows.Forms.Button button1;
    }
}