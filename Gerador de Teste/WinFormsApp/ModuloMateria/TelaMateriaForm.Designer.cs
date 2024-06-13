namespace WinFormsApp.ModuloMateria
{
    partial class TelaMateriaForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            TxtID = new TextBox();
            TxtNome = new TextBox();
            CmbDisciplina = new ComboBox();
            RB1Serie = new RadioButton();
            RB2Serie = new RadioButton();
            BtnGravar = new Button();
            BtnCancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(79, 28);
            label1.Name = "label1";
            label1.Size = new Size(31, 20);
            label1.TabIndex = 0;
            label1.Text = "ID :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 96);
            label2.Name = "label2";
            label2.Size = new Size(57, 20);
            label2.TabIndex = 1;
            label2.Text = "Nome :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 160);
            label3.Name = "label3";
            label3.Size = new Size(81, 20);
            label3.TabIndex = 2;
            label3.Text = "Disciplina :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(61, 221);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 3;
            label4.Text = "Serie :";
            // 
            // TxtID
            // 
            TxtID.Enabled = false;
            TxtID.ForeColor = SystemColors.ActiveCaptionText;
            TxtID.Location = new Point(116, 25);
            TxtID.Margin = new Padding(3, 4, 3, 4);
            TxtID.Multiline = true;
            TxtID.Name = "TxtID";
            TxtID.PlaceholderText = "0";
            TxtID.Size = new Size(114, 29);
            TxtID.TabIndex = 4;
            // 
            // TxtNome
            // 
            TxtNome.Location = new Point(116, 93);
            TxtNome.Margin = new Padding(3, 4, 3, 4);
            TxtNome.Name = "TxtNome";
            TxtNome.Size = new Size(404, 27);
            TxtNome.TabIndex = 5;
            // 
            // CmbDisciplina
            // 
            CmbDisciplina.FormattingEnabled = true;
            CmbDisciplina.Location = new Point(116, 157);
            CmbDisciplina.Margin = new Padding(3, 4, 3, 4);
            CmbDisciplina.Name = "CmbDisciplina";
            CmbDisciplina.Size = new Size(196, 28);
            CmbDisciplina.TabIndex = 6;
            // 
            // RB1Serie
            // 
            RB1Serie.AutoSize = true;
            RB1Serie.Location = new Point(116, 219);
            RB1Serie.Margin = new Padding(3, 4, 3, 4);
            RB1Serie.Name = "RB1Serie";
            RB1Serie.Size = new Size(72, 24);
            RB1Serie.TabIndex = 7;
            RB1Serie.TabStop = true;
            RB1Serie.Text = "1 Serie";
            RB1Serie.UseVisualStyleBackColor = true;
            // 
            // RB2Serie
            // 
            RB2Serie.AutoSize = true;
            RB2Serie.Location = new Point(240, 219);
            RB2Serie.Margin = new Padding(3, 4, 3, 4);
            RB2Serie.Name = "RB2Serie";
            RB2Serie.Size = new Size(72, 24);
            RB2Serie.TabIndex = 8;
            RB2Serie.TabStop = true;
            RB2Serie.Text = "2 Serie";
            RB2Serie.UseVisualStyleBackColor = true;
            // 
            // BtnGravar
            // 
            BtnGravar.BackColor = Color.Lime;
            BtnGravar.DialogResult = DialogResult.OK;
            BtnGravar.Font = new Font("Segoe UI", 11.25F);
            BtnGravar.Location = new Point(334, 274);
            BtnGravar.Margin = new Padding(3, 4, 3, 4);
            BtnGravar.Name = "BtnGravar";
            BtnGravar.Size = new Size(107, 72);
            BtnGravar.TabIndex = 9;
            BtnGravar.Text = "Gravar";
            BtnGravar.UseVisualStyleBackColor = false;
            BtnGravar.Click += btnGravar_Click;
            // 
            // BtnCancelar
            // 
            BtnCancelar.BackColor = Color.FromArgb(192, 0, 0);
            BtnCancelar.DialogResult = DialogResult.Cancel;
            BtnCancelar.Font = new Font("Segoe UI", 11.25F);
            BtnCancelar.Location = new Point(448, 274);
            BtnCancelar.Margin = new Padding(3, 4, 3, 4);
            BtnCancelar.Name = "BtnCancelar";
            BtnCancelar.Size = new Size(107, 72);
            BtnCancelar.TabIndex = 10;
            BtnCancelar.Text = "Cancelar";
            BtnCancelar.UseVisualStyleBackColor = false;
            // 
            // TelaMateriaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(570, 357);
            Controls.Add(BtnCancelar);
            Controls.Add(BtnGravar);
            Controls.Add(RB2Serie);
            Controls.Add(RB1Serie);
            Controls.Add(CmbDisciplina);
            Controls.Add(TxtNome);
            Controls.Add(TxtID);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TelaMateriaForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastro de Materias";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox TxtID;
        private TextBox TxtNome;
        private ComboBox CmbDisciplina;
        private RadioButton RB1Serie;
        private RadioButton RB2Serie;
        private Button BtnGravar;
        private Button BtnCancelar;
    }
}