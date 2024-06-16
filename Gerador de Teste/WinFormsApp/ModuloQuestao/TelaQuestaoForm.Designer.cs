namespace WinFormsApp.ModuloQuestao
{
    partial class TelaQuestaoForm
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
            cmbMateria = new ComboBox();
            label2 = new Label();
            txtEnunciado = new TextBox();
            txtResposta = new TextBox();
            label3 = new Label();
            btnAdicionarAlternativa = new Button();
            groupBox1 = new GroupBox();
            listAlternativa = new CheckedListBox();
            btnRemoverAlternativa = new Button();
            btnGravar = new Button();
            btnCancelar = new Button();
            txtId = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 71);
            label1.Name = "label1";
            label1.Size = new Size(63, 20);
            label1.TabIndex = 0;
            label1.Text = "Matéria:";
            // 
            // cmbMateria
            // 
            cmbMateria.FormattingEnabled = true;
            cmbMateria.Location = new Point(101, 68);
            cmbMateria.Name = "cmbMateria";
            cmbMateria.Size = new Size(151, 28);
            cmbMateria.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 132);
            label2.Name = "label2";
            label2.Size = new Size(81, 20);
            label2.TabIndex = 2;
            label2.Text = "Enunciado:";
            // 
            // txtEnunciado
            // 
            txtEnunciado.Location = new Point(101, 114);
            txtEnunciado.Multiline = true;
            txtEnunciado.Name = "txtEnunciado";
            txtEnunciado.PlaceholderText = "Quanto é 2 + 2?";
            txtEnunciado.Size = new Size(316, 60);
            txtEnunciado.TabIndex = 3;
            // 
            // txtResposta
            // 
            txtResposta.Location = new Point(101, 185);
            txtResposta.Multiline = true;
            txtResposta.Name = "txtResposta";
            txtResposta.Size = new Size(182, 48);
            txtResposta.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 195);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 4;
            label3.Text = "Resposta:";
            // 
            // btnAdicionarAlternativa
            // 
            btnAdicionarAlternativa.Location = new Point(289, 185);
            btnAdicionarAlternativa.Name = "btnAdicionarAlternativa";
            btnAdicionarAlternativa.Size = new Size(128, 48);
            btnAdicionarAlternativa.TabIndex = 6;
            btnAdicionarAlternativa.Text = "Adicionar";
            btnAdicionarAlternativa.UseVisualStyleBackColor = true;
            btnAdicionarAlternativa.Click += btnAdicionarAlternativa_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listAlternativa);
            groupBox1.Controls.Add(btnRemoverAlternativa);
            groupBox1.Location = new Point(14, 264);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(403, 237);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Alternativas";
            // 
            // listAlternativa
            // 
            listAlternativa.BackColor = SystemColors.Control;
            listAlternativa.BorderStyle = BorderStyle.None;
            listAlternativa.FormattingEnabled = true;
            listAlternativa.Location = new Point(6, 63);
            listAlternativa.Name = "listAlternativa";
            listAlternativa.Size = new Size(391, 154);
            listAlternativa.TabIndex = 1;
            // 
            // btnRemoverAlternativa
            // 
            btnRemoverAlternativa.Location = new Point(18, 26);
            btnRemoverAlternativa.Name = "btnRemoverAlternativa";
            btnRemoverAlternativa.Size = new Size(129, 34);
            btnRemoverAlternativa.TabIndex = 0;
            btnRemoverAlternativa.Text = "Remover";
            btnRemoverAlternativa.UseVisualStyleBackColor = true;
            btnRemoverAlternativa.Click += btnRemoverAlternativa_Click;
            // 
            // btnGravar
            // 
            btnGravar.BackColor = Color.Lime;
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.Location = new Point(182, 539);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(111, 49);
            btnGravar.TabIndex = 8;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = false;
            btnGravar.Click += btnGravar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(192, 0, 0);
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(306, 539);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(111, 49);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(101, 22);
            txtId.Name = "txtId";
            txtId.PlaceholderText = "0";
            txtId.Size = new Size(100, 27);
            txtId.TabIndex = 10;
            txtId.Visible = false;
            // 
            // TelaQuestaoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(435, 600);
            Controls.Add(txtId);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(groupBox1);
            Controls.Add(btnAdicionarAlternativa);
            Controls.Add(txtResposta);
            Controls.Add(label3);
            Controls.Add(txtEnunciado);
            Controls.Add(label2);
            Controls.Add(cmbMateria);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TelaQuestaoForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastro de Questões";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbMateria;
        private Label label2;
        private TextBox txtEnunciado;
        private TextBox txtResposta;
        private Label label3;
        private Button btnAdicionarAlternativa;
        private GroupBox groupBox1;
        private Button btnRemoverAlternativa;
        private Button btnGravar;
        private Button btnCancelar;
        private TextBox txtId;
        private CheckedListBox listAlternativa;
    }
}