namespace WinFormsApp.Modulo_disciplina
{
    partial class TelaDisciplinaForm
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
            TxtID = new TextBox();
            TxtNome = new TextBox();
            labelId = new Label();
            label2 = new Label();
            BtnGravar = new Button();
            BtnCancelar = new Button();
            SuspendLayout();
            // 
            // TxtID
            // 
            TxtID.Enabled = false;
            TxtID.Location = new Point(87, 57);
            TxtID.Multiline = true;
            TxtID.Name = "TxtID";
            TxtID.PlaceholderText = "0";
            TxtID.Size = new Size(322, 23);
            TxtID.TabIndex = 0;
            // 
            // TxtNome
            // 
            TxtNome.Location = new Point(87, 105);
            TxtNome.Multiline = true;
            TxtNome.Name = "TxtNome";
            TxtNome.Size = new Size(322, 28);
            TxtNome.TabIndex = 1;
            // 
            // labelId
            // 
            labelId.AutoSize = true;
            labelId.Font = new Font("Segoe UI", 11.25F);
            labelId.Location = new Point(50, 60);
            labelId.Name = "labelId";
            labelId.Size = new Size(31, 20);
            labelId.TabIndex = 2;
            labelId.Text = "ID :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F);
            label2.Location = new Point(24, 108);
            label2.Name = "label2";
            label2.Size = new Size(57, 20);
            label2.TabIndex = 3;
            label2.Text = "Nome :";
            label2.Click += label2_Click;
            // 
            // BtnGravar
            // 
            BtnGravar.BackColor = Color.Lime;
            BtnGravar.DialogResult = DialogResult.OK;
            BtnGravar.Font = new Font("Segoe UI", 11.25F);
            BtnGravar.Location = new Point(12, 176);
            BtnGravar.Name = "BtnGravar";
            BtnGravar.Size = new Size(94, 54);
            BtnGravar.TabIndex = 4;
            BtnGravar.Text = "Gravar";
            BtnGravar.UseVisualStyleBackColor = false;
            BtnGravar.Click += btnGravar_Click;
            // 
            // BtnCancelar
            // 
            BtnCancelar.BackColor = Color.FromArgb(192, 0, 0);
            BtnCancelar.DialogResult = DialogResult.Cancel;
            BtnCancelar.Font = new Font("Segoe UI", 11.25F);
            BtnCancelar.Location = new Point(387, 176);
            BtnCancelar.Name = "BtnCancelar";
            BtnCancelar.Size = new Size(94, 54);
            BtnCancelar.TabIndex = 5;
            BtnCancelar.Text = "Cancelar";
            BtnCancelar.UseVisualStyleBackColor = false;
            // 
            // TelaDisciplinaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(493, 242);
            Controls.Add(BtnCancelar);
            Controls.Add(BtnGravar);
            Controls.Add(label2);
            Controls.Add(labelId);
            Controls.Add(TxtNome);
            Controls.Add(TxtID);
            Name = "TelaDisciplinaForm";
            Text = "Cadastro De Disciplinas";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TxtID;
        private TextBox TxtNome;
        private Label labelId;
        private Label label2;
        private Button BtnGravar;
        private Button BtnCancelar;
    }
}