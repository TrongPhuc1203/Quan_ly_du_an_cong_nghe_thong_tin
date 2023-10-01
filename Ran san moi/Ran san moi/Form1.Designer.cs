namespace Ran_san_moi
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
            this.components = new System.ComponentModel.Container();
            this.btnBatDau = new System.Windows.Forms.Button();
            this.btnChupAnh = new System.Windows.Forms.Button();
            this.picKhungHinh = new System.Windows.Forms.PictureBox();
            this.txtDiem = new System.Windows.Forms.Label();
            this.txtDiemCaoNhat = new System.Windows.Forms.Label();
            this.HenGio = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picKhungHinh)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBatDau
            // 
            this.btnBatDau.BackColor = System.Drawing.Color.LawnGreen;
            this.btnBatDau.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatDau.Location = new System.Drawing.Point(1130, 39);
            this.btnBatDau.Name = "btnBatDau";
            this.btnBatDau.Size = new System.Drawing.Size(120, 64);
            this.btnBatDau.TabIndex = 0;
            this.btnBatDau.Text = "Bắt đầu";
            this.btnBatDau.UseVisualStyleBackColor = false;
            this.btnBatDau.Click += new System.EventHandler(this.StartGame);
            // 
            // btnChupAnh
            // 
            this.btnChupAnh.BackColor = System.Drawing.Color.Cyan;
            this.btnChupAnh.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChupAnh.Location = new System.Drawing.Point(1130, 136);
            this.btnChupAnh.Name = "btnChupAnh";
            this.btnChupAnh.Size = new System.Drawing.Size(120, 64);
            this.btnChupAnh.TabIndex = 1;
            this.btnChupAnh.Text = "Chụp ảnh";
            this.btnChupAnh.UseVisualStyleBackColor = false;
            this.btnChupAnh.Click += new System.EventHandler(this.TakeSnapShot);
            // 
            // picKhungHinh
            // 
            this.picKhungHinh.BackColor = System.Drawing.Color.Silver;
            this.picKhungHinh.Location = new System.Drawing.Point(27, 39);
            this.picKhungHinh.Name = "picKhungHinh";
            this.picKhungHinh.Size = new System.Drawing.Size(1029, 565);
            this.picKhungHinh.TabIndex = 2;
            this.picKhungHinh.TabStop = false;
            this.picKhungHinh.Paint += new System.Windows.Forms.PaintEventHandler(this.UpdatePictureBoxGraphics);
            // 
            // txtDiem
            // 
            this.txtDiem.AutoSize = true;
            this.txtDiem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiem.Location = new System.Drawing.Point(1126, 231);
            this.txtDiem.Name = "txtDiem";
            this.txtDiem.Size = new System.Drawing.Size(76, 23);
            this.txtDiem.TabIndex = 3;
            this.txtDiem.Text = "Điểm: 0";
            // 
            // txtDiemCaoNhat
            // 
            this.txtDiemCaoNhat.AutoSize = true;
            this.txtDiemCaoNhat.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiemCaoNhat.Location = new System.Drawing.Point(1126, 289);
            this.txtDiemCaoNhat.Name = "txtDiemCaoNhat";
            this.txtDiemCaoNhat.Size = new System.Drawing.Size(130, 23);
            this.txtDiemCaoNhat.TabIndex = 4;
            this.txtDiemCaoNhat.Text = "Điểm cao nhất";
            // 
            // HenGio
            // 
            this.HenGio.Interval = 40;
            this.HenGio.Tick += new System.EventHandler(this.GameTimerEvent);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 636);
            this.Controls.Add(this.txtDiemCaoNhat);
            this.Controls.Add(this.txtDiem);
            this.Controls.Add(this.picKhungHinh);
            this.Controls.Add(this.btnChupAnh);
            this.Controls.Add(this.btnBatDau);
            this.Name = "Form1";
            this.Text = "Rắn săn mồi";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.picKhungHinh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBatDau;
        private System.Windows.Forms.Button btnChupAnh;
        private System.Windows.Forms.PictureBox picKhungHinh;
        private System.Windows.Forms.Label txtDiem;
        private System.Windows.Forms.Label txtDiemCaoNhat;
        private System.Windows.Forms.Timer HenGio;
    }
}

