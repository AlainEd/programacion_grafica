
namespace Objetos_3D
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
            this.comboBox_objetos = new System.Windows.Forms.ComboBox();
            this.comboBox_faces = new System.Windows.Forms.ComboBox();
            this.comboBox_add_objeto = new System.Windows.Forms.ComboBox();
            this.button_add = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton_rotar = new System.Windows.Forms.RadioButton();
            this.radioButton_escalar = new System.Windows.Forms.RadioButton();
            this.radioButton_trasladar = new System.Windows.Forms.RadioButton();
            this.button_Xs = new System.Windows.Forms.Button();
            this.button_Xr = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBox_escenario = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label_rot = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_objetos
            // 
            this.comboBox_objetos.FormattingEnabled = true;
            this.comboBox_objetos.Location = new System.Drawing.Point(76, 113);
            this.comboBox_objetos.Name = "comboBox_objetos";
            this.comboBox_objetos.Size = new System.Drawing.Size(121, 21);
            this.comboBox_objetos.TabIndex = 0;
            this.comboBox_objetos.SelectedIndexChanged += new System.EventHandler(this.comboBox_objetos_SelectedIndexChanged);
            // 
            // comboBox_faces
            // 
            this.comboBox_faces.FormattingEnabled = true;
            this.comboBox_faces.Location = new System.Drawing.Point(76, 169);
            this.comboBox_faces.Name = "comboBox_faces";
            this.comboBox_faces.Size = new System.Drawing.Size(121, 21);
            this.comboBox_faces.TabIndex = 1;
            // 
            // comboBox_add_objeto
            // 
            this.comboBox_add_objeto.FormattingEnabled = true;
            this.comboBox_add_objeto.Location = new System.Drawing.Point(76, 31);
            this.comboBox_add_objeto.Name = "comboBox_add_objeto";
            this.comboBox_add_objeto.Size = new System.Drawing.Size(121, 21);
            this.comboBox_add_objeto.TabIndex = 2;
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(101, 69);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(75, 23);
            this.button_add.TabIndex = 3;
            this.button_add.Text = "Agregar";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(30, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(224, 185);
            this.panel1.TabIndex = 4;
            // 
            // radioButton_rotar
            // 
            this.radioButton_rotar.AutoSize = true;
            this.radioButton_rotar.Location = new System.Drawing.Point(15, 8);
            this.radioButton_rotar.Name = "radioButton_rotar";
            this.radioButton_rotar.Size = new System.Drawing.Size(68, 17);
            this.radioButton_rotar.TabIndex = 5;
            this.radioButton_rotar.TabStop = true;
            this.radioButton_rotar.Text = "Rotacion";
            this.radioButton_rotar.UseVisualStyleBackColor = true;
            // 
            // radioButton_escalar
            // 
            this.radioButton_escalar.AutoSize = true;
            this.radioButton_escalar.Location = new System.Drawing.Point(69, 42);
            this.radioButton_escalar.Name = "radioButton_escalar";
            this.radioButton_escalar.Size = new System.Drawing.Size(77, 17);
            this.radioButton_escalar.TabIndex = 6;
            this.radioButton_escalar.TabStop = true;
            this.radioButton_escalar.Text = "Escalacion";
            this.radioButton_escalar.UseVisualStyleBackColor = true;
            // 
            // radioButton_trasladar
            // 
            this.radioButton_trasladar.AutoSize = true;
            this.radioButton_trasladar.Location = new System.Drawing.Point(133, 8);
            this.radioButton_trasladar.Name = "radioButton_trasladar";
            this.radioButton_trasladar.Size = new System.Drawing.Size(74, 17);
            this.radioButton_trasladar.TabIndex = 7;
            this.radioButton_trasladar.TabStop = true;
            this.radioButton_trasladar.Text = "Traslacion";
            this.radioButton_trasladar.UseVisualStyleBackColor = true;
            // 
            // button_Xs
            // 
            this.button_Xs.Location = new System.Drawing.Point(62, 378);
            this.button_Xs.Name = "button_Xs";
            this.button_Xs.Size = new System.Drawing.Size(36, 29);
            this.button_Xs.TabIndex = 8;
            this.button_Xs.Text = "+";
            this.button_Xs.UseVisualStyleBackColor = true;
            this.button_Xs.Click += new System.EventHandler(this.button_Xs_Click);
            // 
            // button_Xr
            // 
            this.button_Xr.Location = new System.Drawing.Point(62, 407);
            this.button_Xr.Name = "button_Xr";
            this.button_Xr.Size = new System.Drawing.Size(36, 29);
            this.button_Xr.TabIndex = 9;
            this.button_Xr.Text = "-";
            this.button_Xr.UseVisualStyleBackColor = true;
            this.button_Xr.Click += new System.EventHandler(this.button_Xr_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(122, 407);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 29);
            this.button1.TabIndex = 11;
            this.button1.Text = "-";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(122, 378);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(36, 29);
            this.button2.TabIndex = 10;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(183, 407);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(36, 29);
            this.button3.TabIndex = 13;
            this.button3.Text = "-";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(183, 378);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(36, 29);
            this.button4.TabIndex = 12;
            this.button4.Text = "+";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label_rot);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.radioButton_rotar);
            this.panel2.Controls.Add(this.radioButton_escalar);
            this.panel2.Controls.Add(this.radioButton_trasladar);
            this.panel2.Location = new System.Drawing.Point(30, 270);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(224, 181);
            this.panel2.TabIndex = 14;
            // 
            // checkBox_escenario
            // 
            this.checkBox_escenario.AutoSize = true;
            this.checkBox_escenario.Location = new System.Drawing.Point(174, 247);
            this.checkBox_escenario.Name = "checkBox_escenario";
            this.checkBox_escenario.Size = new System.Drawing.Size(73, 17);
            this.checkBox_escenario.TabIndex = 15;
            this.checkBox_escenario.Text = "Escenario";
            this.checkBox_escenario.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(122, 70);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(35, 20);
            this.textBox1.TabIndex = 8;
            // 
            // label_rot
            // 
            this.label_rot.AutoSize = true;
            this.label_rot.Location = new System.Drawing.Point(12, 73);
            this.label_rot.Name = "label_rot";
            this.label_rot.Size = new System.Drawing.Size(104, 13);
            this.label_rot.TabIndex = 9;
            this.label_rot.Text = "Angulo de Rotacion:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(284, 661);
            this.Controls.Add(this.checkBox_escenario);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button_Xr);
            this.Controls.Add(this.button_Xs);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.comboBox_add_objeto);
            this.Controls.Add(this.comboBox_faces);
            this.Controls.Add(this.comboBox_objetos);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "Form1";
            this.Text = "Panel";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_objetos;
        private System.Windows.Forms.ComboBox comboBox_faces;
        private System.Windows.Forms.ComboBox comboBox_add_objeto;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton_rotar;
        private System.Windows.Forms.RadioButton radioButton_escalar;
        private System.Windows.Forms.RadioButton radioButton_trasladar;
        private System.Windows.Forms.Button button_Xs;
        private System.Windows.Forms.Button button_Xr;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkBox_escenario;
        private System.Windows.Forms.Label label_rot;
        private System.Windows.Forms.TextBox textBox1;
    }
}